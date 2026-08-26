namespace SpotifyApiWorker.ValueObjects;

public sealed record SignedCookie(string Data, byte[] Signature)
{
    public override string ToString() => $"{Data}:{Convert.ToBase64String(Signature)}";
}