using SpotifyApiWorker.Services.Contracts;

namespace SpotifyApiWorker.Services.Implementations;

public class CookieService: ICookieService
{
    private CookieOptions _baseOptions = new()
    {
        HttpOnly = true,
        Secure = true,
    };
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}