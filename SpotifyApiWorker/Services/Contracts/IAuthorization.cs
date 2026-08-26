namespace SpotifyApiWorker.Services.Contracts;

public interface IAuthorization
{
    string State { get; }
    Uri CreateAuthorizationUri();
    public Task<string> TryGetAuthorizationCode(string? code);
}