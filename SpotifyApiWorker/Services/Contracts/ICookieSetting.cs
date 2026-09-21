namespace SpotifyApiWorker.Services.Contracts;

public interface ICookieSetting
{
    CookieOptions SessionOptions(TimeSpan age);
}