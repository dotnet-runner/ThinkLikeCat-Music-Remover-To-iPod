using System.Text.RegularExpressions;

const string soundsPath = @"C:\Users\user\Downloads";
var allSongsPath = new List<string>();
allSongsPath.AddRange(Directory.GetFiles(soundsPath, "*.*", SearchOption.TopDirectoryOnly)
        .Where(song => (song.EndsWith(".mp3") || song.EndsWith(".vaw")) && song.Contains("_spotdown")));

if (allSongsPath.Count == 0) return;

var allSongsNewPath = allSongsPath.Select(song =>
    Regex.Replace(Regex.Replace(song, @"_spotdown\.((org)|(app))", string.Empty), 
        "Downloads", @"Music\iMusic")).ToList();
var allSongsInfo = allSongsPath.Select(x => new FileInfo(x)).ToList();
for (int i = 0; i < allSongsInfo.Count; i++)
{ 
    allSongsInfo[i].MoveTo(allSongsNewPath[i], true);
}

Console.WriteLine("All songs have been removed");