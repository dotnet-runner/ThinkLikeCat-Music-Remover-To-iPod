namespace SpotifyApiWorker.Services.Contracts;

public interface ICookieSetting
{
    public static readonly TimeSpan SessionTime = TimeSpan.FromMinutes(10);
    CookieOptions AuthSessionOptions(TimeSpan age);
    CookieOptions SpotifyStateSessionOptions();
}