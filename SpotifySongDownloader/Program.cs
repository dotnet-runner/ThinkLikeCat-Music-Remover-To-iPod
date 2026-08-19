using SongWorker;

const string soundsPath = @"C:\Users\user\Downloads";

var songWorker = ISongWorker.CreateISongWorker();

songWorker.GetAllSongsPath(soundsPath)
    .ToCorrectNameForm("_spotdown.org", "_spotdown.app")
    .SaveTo(@"E:\Music");

Console.ReadLine();