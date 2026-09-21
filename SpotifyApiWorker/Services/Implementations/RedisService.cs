using SpotifyApiWorker.Services.Contracts;
using SpotifyApiWorker.ValueObjects;
using StackExchange.Redis;

namespace SpotifyApiWorker.Services.Implementations;

public class RedisService: IRedisService
{
    private readonly IDatabase _redisDbContext;
    
    public RedisService(IConnectionMultiplexer redisConnect)
    {
        _redisDbContext = redisConnect.GetDatabase();
    }
    
    public Task Write(ServerSessionKey key, object value)
    {
        return _redisDbContext.StringAppendAsync(key.Value, value.ToString());
    }
}