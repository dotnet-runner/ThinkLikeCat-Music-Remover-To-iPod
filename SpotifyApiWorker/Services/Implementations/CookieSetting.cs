using SpotifyApiWorker.Services.Contracts;

namespace SpotifyApiWorker.Services.Implementations;

public class CookieSetting: ICookieSetting
{
    private readonly CookieOptions _baseOptions = new()
    {
        HttpOnly = true,
        Secure = true,
        Path = "/"
    };

    public CookieOptions SessionOptions(TimeSpan age)
    {
        _baseOptions.MaxAge = age;
        return _baseOptions;
    }
}