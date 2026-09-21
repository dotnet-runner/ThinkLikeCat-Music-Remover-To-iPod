namespace SpotifyApiWorker.ValueObjects;

public readonly record struct ServerSessionKey(string Value)
{
    public override string ToString() => Value;
}