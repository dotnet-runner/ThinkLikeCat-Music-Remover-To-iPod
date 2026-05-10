namespace SongWorker;

public interface ISongWorker
{
    public ISongWorker ToCorrectNameForm(params string[] garbageNames);

    public ISongWorker GetAllSongsPath(string directoryPath);
    
    public void SaveTo(string newFolderPath);
    
    public static ISongWorker CreateISongWorker() => SongWorker.CreateSongWorker();
}