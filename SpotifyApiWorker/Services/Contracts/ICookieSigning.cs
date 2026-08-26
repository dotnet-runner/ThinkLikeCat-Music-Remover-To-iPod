using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Contracts;

public interface ICookieSigning
{
   SignedCookie CookieSign(string data);
   bool IsSignCorrect(string? cookieContent);
   string? CookieData(string? cookieContent);
}