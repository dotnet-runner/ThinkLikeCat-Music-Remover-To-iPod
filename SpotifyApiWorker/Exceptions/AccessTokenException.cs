namespace SpotifyApiWorker.Exceptions;

public class AccessTokenException: Exception
{
    public AccessTokenException() : base("Can't get an access token") { }
    
    public AccessTokenException(string message) : base(message) { }
}