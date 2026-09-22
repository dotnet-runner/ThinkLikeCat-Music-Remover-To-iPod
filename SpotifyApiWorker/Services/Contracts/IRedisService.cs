using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Contracts;

public interface IRedisService
{
    Task<string> GetAsync(string key);
    Task WriteAsync(ServerSessionKey key, object value);
    Task DeleteAsync(ServerSessionKey key);
}