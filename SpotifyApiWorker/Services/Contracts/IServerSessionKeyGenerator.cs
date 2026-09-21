using SpotifyApiWorker.ValueObjects;

namespace SpotifyApiWorker.Services.Contracts;

public interface IServerSessionKeyGenerator
{
    ServerSessionKey Generate();
}