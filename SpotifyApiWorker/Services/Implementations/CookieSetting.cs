using SpotifyApiWorker.Services.Contracts;

namespace SpotifyApiWorker.Services.Implementations;

public class CookieSetting: ICookieSetting
{
    private readonly CookieOptions _baseOptions = new()
    {
        HttpOnly = true,
        Secure = true,
        Path = "/",
        SameSite = SameSiteMode.Strict
    };

    public CookieOptions SessionOptions()
    {
        return _baseOptions;
    }

    public CookieOptions SpotifyStateSessionOptions()
    {
        _baseOptions.SameSite = SameSiteMode.Lax;
        return SessionOptions();
    }
}