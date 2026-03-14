namespace SoungWorker;

public interface ISongWorker
{
    public IEnumerable<string> ToCorrectNameForm(IEnumerable<string> songsNames, params IEnumerable<string> garbageNames);

    public void SaveTo(string newPath, IEnumerable<string> songsNames);
    
    public static ISongWorker CreateISongWorker() => SongWorker.CreateSongWorker();
}