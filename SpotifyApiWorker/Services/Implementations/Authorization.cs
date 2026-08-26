using SpotifyAPI.Web;
using SpotifyApiWorker.Exceptions;
using SpotifyApiWorker.Services.Contracts;

namespace SpotifyApiWorker.Services.Implementations;

public class Authorization: IAuthorization
{
    private readonly Uri _redirectUri = new ("http://127.0.0.1:5000/api/authorization/callback");
    public string State { get; } = Guid.NewGuid().ToString();

    public Uri CreateAuthorizationUri()
    {
        var login = new LoginRequest( _redirectUri, IMyInfo.ServerSpotifyClientId, LoginRequest.ResponseType.Code)
        {
            State = State,
            Scope = [Scopes.UserReadPrivate, Scopes.UserReadEmail, Scopes.PlaylistReadPrivate]
        };
        
        return login.ToUri();
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