using System.Security.Cryptography;
using System.Text;
using SpotifyApiWorker.Services.Contracts;
using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Implementations;

public class CookieSigning: ICookieSigning
{
    public SignedCookie CookieSign(string value)
    { 
        var signature = CookieAlgorithmSigning(value);
        return new SignedCookie(value, signature);
    }

    private byte[] CookieAlgorithmSigning(string data) =>
        HMACSHA256.HashData(IMyInfo.ServerSignKey, Encoding.UTF8.GetBytes(data));
    
    public bool IsSignCorrect(string? cookieContent)
    {
        if(!TryParse(cookieContent, out var cookie) || cookie is null)
            return false;
        
        var computed = CookieAlgorithmSigning(cookie.Data);
        
        return CryptographicOperations.FixedTimeEquals(computed, cookie.Signature);
    }

    private bool TryParse(string? value, out SignedCookie? cookie)
    {
        cookie = null;

        if (string.IsNullOrWhiteSpace(value))
            return false;

        var parts = value.Split(':');
        if (parts.Length != 2)
            return false;

        try
        {
            var signature = Convert.FromBase64String(parts[1]);
            cookie = new SignedCookie(parts[0], signature);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public string? CookieData(string? cookieContent)
    {
        if(!TryParse(cookieContent, out var cookie) || cookie is null)
            return null;
        
        return cookie.Data;
    }
}