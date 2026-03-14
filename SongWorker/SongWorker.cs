using System.Text.RegularExpressions; 

namespace SoungWorker;

internal class SongWorker: ISongWorker
{
    //key is song name, value is path for this song
    private Dictionary<string, string> _songParts;

    private SongWorker() { _songParts = new(); }

    public static SongWorker CreateSongWorker() => new SongWorker();
    
    private static Regex CreateRemoverRegex(IEnumerable<string> garbageNames)
    {
        garbageNames = garbageNames.Select(name => '(' + name + ')');
        var removerString = string.Join('|', garbageNames);

        return new Regex(removerString, RegexOptions.Compiled | RegexOptions.RightToLeft);
    }
    
    public IEnumerable<string> ToCorrectNameForm(IEnumerable<string> songsNames, params IEnumerable<string> garbageNames)
    {
        var remover = CreateRemoverRegex(garbageNames);

        var songsWithCorrectNames = songsNames.Select(song =>
            remover.Replace(song, string.Empty)
        );

        var pathSeparator = new Regex(@"(?<=\\)", RegexOptions.RightToLeft);
        foreach (var songPath in songsWithCorrectNames)
        {
            var res = pathSeparator.Split(songPath, 2);
            _songParts.Add(res[1], res[0]);
        }
        
        return songsWithCorrectNames;
    }

    public void SaveTo(string newPath, IEnumerable<string> songsNames)
    {
        Parallel.ForEach(_songParts, song =>
            {
                var oldFileWay = song.Value + song.Key;
                var newFileWay = newPath + song.Key;

                var songInfo = new FileInfo(oldFileWay);
                songInfo.MoveTo(newFileWay, true);

                SaveLog(oldFileWay, newFileWay);
            }
        );
    }

    private static void SaveLog(string oldFileName, string newFileName) =>
        Console.WriteLine($"{oldFileName} --> {newFileName}");
}