namespace OfficialSpotifyApiWorker;

public interface ISpotifyApiWorker
{
    public static ISpotifyApiWorker CreateSpotifyApiWorker() => SpotifyApiWorker.CreateSpotifyApiWorker();
}