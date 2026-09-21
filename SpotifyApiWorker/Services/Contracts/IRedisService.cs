using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Contracts;

public interface IRedisService
{
    Task Write(ServerSessionKey key, object value);
}