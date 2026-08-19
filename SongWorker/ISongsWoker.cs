namespace SongWorker;

public interface ISongWorker
{
    public static ISongWorker CreateISongWorker() => SongWorker.Instance;
    
    public ISongWorker ToCorrectNameForm(params string[] garbageNames);

    public ISongWorker GetAllSongsPath(string directoryPath);
    
    public void SaveTo(string newFolderPath);
}