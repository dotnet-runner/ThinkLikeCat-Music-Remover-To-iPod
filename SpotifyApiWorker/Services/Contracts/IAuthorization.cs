using SpotifyAPI.Web;

namespace SpotifyApiWorker.Services.Contracts;

public interface IAuthorization
{
    string State { get; }
    Uri CreateAuthorizationUri();
    public Task<AuthorizationCodeTokenResponse> TryGetAuthorizationCode(string? code);
}