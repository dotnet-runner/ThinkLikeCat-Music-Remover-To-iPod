using SpotifyApiWorker.Services.Implementations;
using StackExchange.Redis;

namespace SpotifyApiWorker.ValueObjects;

public readonly record struct ServerSessionKey
{
    public string Value { get; }

    public ServerSessionKey(string Value)
    {
        if(string.IsNullOrWhiteSpace(Value))
            throw new ArgumentNullException(nameof(Value));
        
        if(Value.Length != ServerSessionKeyGenerator.ServerSessionKeyLength)
            throw new ArgumentOutOfRangeException(nameof(Value));
        
        this.Value = Value;
    }
    
    public ServerSessionKey(RedisValue value) : this(value.ToString()) { }
    
    public override string ToString() => Value;
    
    public static implicit operator string(ServerSessionKey value) => value.Value;
}