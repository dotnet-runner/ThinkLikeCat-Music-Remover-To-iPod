using System.Security.Cryptography;
using SpotifyApiWorker.Services.Contracts;
using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Implementations;

public class ServerSessionKeyGenerator: IServerSessionKeyGenerator
{
    public ServerSessionKey Generate()
    {
        var randomBytes = new byte[32];
        
        using (var randomizer = RandomNumberGenerator.Create()) {
            randomizer.GetBytes(randomBytes);
        }
        
        var key = Convert.ToBase64String(randomBytes);
        return new ServerSessionKey(key);
    }
}