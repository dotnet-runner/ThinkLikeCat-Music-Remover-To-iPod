namespace OfficialSpotifyApiWorker;

internal class SpotifyApiWorker: ISpotifyApiWorker
{
    private SpotifyApiWorker() {}

    public static SpotifyApiWorker CreateSpotifyApiWorker() => new ();
    
    
}