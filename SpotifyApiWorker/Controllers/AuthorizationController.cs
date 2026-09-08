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

    public AuthorizationController(IAuthorization authorization)
    {
        _authorization = authorization;
    }
    
    [HttpGet("login")]
    public IActionResult Login()
    {
        var authUri = _authorization.CreateAuthorizationUri().ToString();
        Console.WriteLine(authUri);
        /*var cookieValue = _cookieSigning.CookieSign(_authorization.State).ToString()*/;
        //Response.Cookies.Append("State", cookieValue);
        return Redirect(authUri);
    }

    [HttpGet("callback")]
    public async Task<IActionResult> Callback([FromQuery] string? code, [FromQuery] string? state, [FromQuery] string? error = null)
    {
        if (error is not null)
            return Unauthorized("Authorization Error");

        /*var cookieContent = Request.Cookies["State"] ?? string.Empty;
        if (!_cookieSigning.IsSignCorrect(cookieContent))
            return BadRequest("Authorization Error, cookie is not correct");
        
        if(state != _cookieSigning.CookieData(cookieContent))
            return Unauthorized("Authorization Error, URI and cookie is not same");
        
        Response.Cookies.Delete("State");*/
        
        string accessToken;

        try
        {
            accessToken = await _authorization.TryGetAuthorizationCode(code);
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

        var spotify = new SpotifyClient(accessToken);
        return Ok(spotify);
    }
}