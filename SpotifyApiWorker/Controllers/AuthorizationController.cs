using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using SpotifyApiWorker.Exceptions;
using SpotifyApiWorker.Services.Contracts;

namespace SpotifyApiWorker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorization _authorization;
    private readonly IServerSessionKeyGenerator _sessionKeyGenerator;
    private readonly ICookieSetting _cookieSetting;
    private readonly IRedisService _redisService;
    
    public AuthorizationController(IAuthorization authorization, ICookieSetting cookieSetting, IServerSessionKeyGenerator serverSessionKeyGenerator,
        IRedisService redisService)
    {
        _authorization = authorization;
        _cookieSetting = cookieSetting;
        _sessionKeyGenerator = serverSessionKeyGenerator;
        _redisService = redisService;
    }
    
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        /*if (Request.Cookies["_userSessionKey"] is not null)
            Redirect();*/
        
        var authUri = _authorization.CreateAuthorizationUri().ToString();
        var key = _sessionKeyGenerator.Generate();
        
        await _redisService.WriteAsync(key, _authorization.State);
        
        Response.Cookies.Append("_userSessionKey", key.ToString(),
            _cookieSetting.SpotifyStateSessionOptions());
        
        return Redirect(authUri);
    }
    
    [HttpGet("callback")]
    public async Task<IActionResult> Callback([FromQuery] string? code, [FromQuery] string? state, [FromQuery] string? error = null)
    {
        if (error is not null)
            return Unauthorized("Authorization Error");
        
        var userSessionKey = Request.Cookies["_userSessionKey"] ?? string.Empty;
        var sessionState = await _redisService.GetAsync(userSessionKey);
        
        if (sessionState != state)
            return BadRequest("Authorization Error, cookie is not correct");
        
        _ = _redisService.DeleteAsync(new(userSessionKey));
        Response.Cookies.Delete("_userSessionKey");
        
        try
        {
            var accessToken = await _authorization.TryGetAuthorizationCode(code);
            var spotify = new SpotifyClient(accessToken);
            return Ok(spotify);
        }
        catch (NoAuthorizationCodeException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (AuthorizationCodeTokenException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (AccessTokenException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}