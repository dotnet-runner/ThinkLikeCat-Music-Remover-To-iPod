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
    private readonly IRedisService _redis;
    
    public AuthorizationController(IAuthorization authorization, ICookieSetting cookieSetting, IServerSessionKeyGenerator serverSessionKeyGenerator,
        IRedisService redis)
    {
        _authorization = authorization;
        _cookieSetting = cookieSetting;
        _sessionKeyGenerator = serverSessionKeyGenerator;
        _redis = redis;
    }
    
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        /*if (Request.Cookies["_userSessionKey"] is not null)
            Redirect();*/
        
        var authUri = _authorization.CreateAuthorizationUri().ToString();
        var key = _sessionKeyGenerator.Generate();
        
        await _redis.WriteAsync(key, _authorization.State);
        
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
        var sessionState = await _redis.GetAsync(userSessionKey);
        
        if (sessionState != state)
            return BadRequest("Authorization Error, cookie is not correct");
        
        _ = _redis.DeleteAsync(new(userSessionKey));
        Response.Cookies.Delete("_userSessionKey");

        try
        {
            var authCode = await _authorization.TryGetAuthorizationCode(code);
            var accessToken = authCode.AccessToken;
            
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new AccessTokenException();
            
            var spotify = new SpotifyClient(accessToken);
            var user = await spotify.UserProfile.Current();
            
            return Ok(user);
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
        catch (APIException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}