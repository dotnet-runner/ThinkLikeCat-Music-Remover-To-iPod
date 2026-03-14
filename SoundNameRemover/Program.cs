using System.Text.RegularExpressions;
using SoundNameRemover;

/*const string soundsPath = @"C:\Users\user\Downloads";

var songWorker = ISongWorker.CreateISongWorker();

var allSongsPath = new List<string>();
allSongsPath.AddRange(Directory.GetFiles(soundsPath, "*.*", SearchOption.TopDirectoryOnly)
    .Where(song => song.Contains("_spotdown") && (song.EndsWith(".mp3") || song.EndsWith(".vaw"))));

if (allSongsPath.Count == 0) return;

var correctedSongsNames = songWorker.ToCorrectNameForm(allSongsPath, "_spotdown.org", "_spotdown.app");*/

/*Regex songStandardOldPath = new(@"C:\\Users\\user\\Downloads", RegexOptions.Compiled);

var allSongsWithNewPath = correctedSongsNames.Select(song =>
    songStandardOldPath.Replace(song, @"E:\Music"))
    .ToList();

var allSongsInfo = allSongsPath.Select(x => new FileInfo(x)).ToList();

try
{
    allSongsInfo[0].MoveTo(allSongsWithNewPath[0], false);
}
catch
{
    Console.WriteLine("The tom E doesn't exist");
    Console.ReadLine();
    return;
}

for (int i = 1; i < allSongsInfo.Count; i++)
{
    allSongsInfo[i].MoveTo(allSongsWithNewPath[i], true);
}

Console.WriteLine("All songs have been removed");*/

Console.ReadLine();
