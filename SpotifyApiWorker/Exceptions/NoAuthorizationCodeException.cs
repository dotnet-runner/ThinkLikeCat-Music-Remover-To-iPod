namespace SpotifyApiWorker.Exceptions;

public class NoAuthorizationCodeException : Exception
{
    public NoAuthorizationCodeException() : base("Not found authorization code") { }
    
    public NoAuthorizationCodeException(string message) : base(message) { }
}