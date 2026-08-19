namespace SpotifyApiWorker.Exceptions;

public class AuthorizationCodeTokenException : Exception
{
    public AuthorizationCodeTokenException() : base("Can't get an access token with authorization code") { }
    
    public AuthorizationCodeTokenException(string message) : base(message) { }
}