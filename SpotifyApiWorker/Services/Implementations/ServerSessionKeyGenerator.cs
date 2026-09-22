using System.Security.Cryptography;
using SpotifyApiWorker.Services.Contracts;
using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Implementations;

public class ServerSessionKeyGenerator: IServerSessionKeyGenerator
{
    public const int ServerSessionKeyLength = 32;
    
    public ServerSessionKey Generate()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        var chars = new char[ServerSessionKeyLength];
        for (int i = 0; i < ServerSessionKeyLength; i++)
        {
            int randomIndex = RandomNumberGenerator.GetInt32(alphabet.Length);
            chars[i] = alphabet[randomIndex];
        }
        
        var key = new string(chars);
        return new ServerSessionKey(key);
    }
}