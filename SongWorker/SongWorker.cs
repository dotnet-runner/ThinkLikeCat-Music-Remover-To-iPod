using System.Text.RegularExpressions;

namespace SongWorker;

internal class SongWorker: ISongWorker
{
    public List<string> AllSongsPaths { get; private set; } = new();

    private SongWorker() { }
    
    public static SongWorker CreateSongWorker() => new ();

    public ISongWorker GetAllSongsPath(string directoryPath)
    {
        var extensions = new[] { ".mp3", ".wav" };
        
        var songs = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(file => extensions.Contains(Path.GetExtension(file).ToLower()));

        AllSongsPaths.AddRange(songs);

        return this;
    }

    private static Regex CreateRemoverRegex(IEnumerable<string> garbageNames)
    {
        garbageNames = garbageNames.Select(name => '(' + Regex.Escape(name) + ')');
        var removerString = string.Join('|', garbageNames);
        
        return new Regex(removerString, RegexOptions.Compiled | RegexOptions.RightToLeft);
    }
    
    public ISongWorker ToCorrectNameForm(params string[] garbageNames)
    {
        if (garbageNames.Length == 0) return this;
        
        var remover = CreateRemoverRegex(garbageNames);

        AllSongsPaths = AllSongsPaths.Select(oldSongPath =>
            {
                var songDirectory = Path.GetDirectoryName(oldSongPath);
                var songName = Path.GetFileName(oldSongPath);
                var correctSongName = remover.Replace(songName, string.Empty);
                var correctSongPath = Path.Combine(songDirectory!, correctSongName);
                
                File.Move(oldSongPath, correctSongName, true);
                
                return correctSongPath;
            }
        ).ToList();

        return this;
    }
    
    public ISongWorker SaveTo(string newDirectory)
    {
        if(!Directory.Exists(newDirectory))
            Directory.CreateDirectory(newDirectory);
        
        if(AllSongsPaths.Count == 0) return this;
        
        Parallel.ForEach(AllSongsPaths, oldSongPath =>
            {
                var fileName = Path.GetFileName(oldSongPath);
                
                var newFileWay = Path.Combine(newDirectory, fileName);
                
                File.Move(oldSongPath, newFileWay, true);
                
                SaveLog(oldSongPath, newFileWay);
            }
        );
        
        Console.WriteLine("All songs have been removed");
        return this;
    }

    private static void SaveLog(string oldFilePath, string newFilePath) =>
        Console.WriteLine($"{oldFilePath} --> {newFilePath}");
}