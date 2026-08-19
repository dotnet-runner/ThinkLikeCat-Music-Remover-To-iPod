using System.Security.Cryptography;
using System.Text;
using SpotifyAPI.Web;
using SpotifyApiWorker.Exceptions;
using SpotifyApiWorker.Services.Contracts;

namespace SpotifyApiWorker.Services.Implementations;

public class Authorization: IAuthorization
{
    private readonly Uri _redirectUri = new ("http://127.0.0.1:5000/api/authorization/callback");
    private readonly string _state = Guid.NewGuid().ToString();
    
    public Uri CreateAuthorizationUri()
    {
        var login = new LoginRequest( _redirectUri, IMyInfo.ServerSpotifyClientId, LoginRequest.ResponseType.Code)
        {
            State = _state,
            Scope = [Scopes.UserReadPrivate, Scopes.UserReadEmail, Scopes.PlaylistReadPrivate]
        };
        
        return login.ToUri();
    }

    public string CookieStateContent() => CookieCrypt(_state); 
    
    public string CookieCrypt(string data)
    {
        var bData = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        var cookieData = CookieAlgorithmCrypt(bData);
        return $"{bData}:{Convert.ToBase64String(cookieData)}";
    }

    private byte[] CookieAlgorithmCrypt(string data) =>
        HMACSHA256.HashData(IMyInfo.ServerSecretKey, Encoding.UTF8.GetBytes(data));
    
    public bool IsCookieCorrect(string? cookie)
    {
        if (string.IsNullOrWhiteSpace(cookie))
            return false;

        var parts = cookie.Split(':');
        if (parts.Length != 2)
            return false;

        var base64Data = parts[0];
        var base64Hmac = parts[1];

        byte[] hmacBytes;
        try
        {
            hmacBytes = Convert.FromBase64String(base64Hmac);
        }
        catch
        {
            return false;
        }

        var computed = CookieAlgorithmCrypt(base64Data);
        
        return CryptographicOperations.FixedTimeEquals(computed, hmacBytes);
    }

    public async Task<string> TryGetAuthorizationCode(string? code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new NoAuthorizationCodeException();

        AuthorizationCodeTokenResponse response;
        try
        {
            response = await new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest(
                    IMyInfo.ServerSpotifyClientId, IMyInfo.ServerSpotifyClientSecret, code, _redirectUri
                )
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to request token: {ex.Message}");
            throw new AuthorizationCodeTokenException(ex.Message);
        }
        var accessToken = response.AccessToken;
        
        if (string.IsNullOrWhiteSpace(accessToken))
            throw new AccessTokenException();
        
        return accessToken;
    }
}