namespace SpotifyApiWorker.Services.Contracts;

public interface IAuthorization
{
    public Uri CreateAuthorizationUri();
    string CookieStateContent();
    public string CookieCrypt(string data);
    public Task<string> TryGetAuthorizationCode(string? code);
}