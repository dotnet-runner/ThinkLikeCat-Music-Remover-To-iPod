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
    
    public async Task<string> GetAsync(string key) =>
        await _redisDbContext.StringGetAsync(key);
    
    public Task WriteAsync(ServerSessionKey key, object value)
    {
        return _redisDbContext.StringAppendAsync(key.Value, value.ToString());
    }
    
    public Task DeleteAsync(ServerSessionKey key)
    {
        return _redisDbContext.KeyDeleteAsync(key.Value, CommandFlags.FireAndForget);
    }
}