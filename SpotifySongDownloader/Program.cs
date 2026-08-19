using SongWorker;

const string soundsPath = @"C:\Users\user\Downloads";

var songWorker = ISongWorker.CreateISongWorker();

songWorker.GetAllSongsPath(soundsPath)
    .ToCorrectNameForm("_spotdown.org", "_spotdown.app")
    .SaveTo(@"E:\Music");

Console.ReadLine();

/*
 * Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
        modified:   .gitignore
        deleted:    OfficialSpotifyApiWorker/ISpotifyApiWorker.cs
        deleted:    OfficialSpotifyApiWorker/OfficialSpotifyApiWorker.csproj
        deleted:    OfficialSpotifyApiWorker/SpotifyApiWorker.cs
        deleted:    OfficialSpotifyApiWorker/obj/Debug/net10.0/OfficialSpotifyApiWorker.AssemblyInfoInputs.cache
        deleted:    OfficialSpotifyApiWorker/obj/Debug/net10.0/OfficialSpotifyApiWorker.assets.cache
        deleted:    OfficialSpotifyApiWorker/obj/project.assets.json
        deleted:    OfficialSpotifyApiWorker/obj/project.nuget.cache
        deleted:    OfficialSpotifyApiWorker/obj/project.packagespec.json
        deleted:    OfficialSpotifyApiWorker/obj/rider.project.model.nuget.info
        deleted:    OfficialSpotifyApiWorker/obj/rider.project.restore.info
        modified:   SongWorker/ISongsWoker.cs
        modified:   SongWorker/SongWorker.cs
        modified:   SongWorker/SongWorker.csproj
        modified:   SongWorker/obj/Debug/net10.0/SongWorker.AssemblyInfo.cs
        modified:   SongWorker/obj/Debug/net10.0/SongWorker.AssemblyInfoInputs.cache
        modified:   SongWorker/obj/Debug/net10.0/SongWorker.assets.cache
        new file:   SongWorker/obj/Debug/net10.0/SongWorker.csproj.AssemblyReference.cache
        modified:   SongWorker/obj/SongWorker.csproj.nuget.dgspec.json
        modified:   SongWorker/obj/project.assets.json
        modified:   SongWorker/obj/project.nuget.cache
        modified:   SongWorker/obj/project.packagespec.json
        modified:   SongWorker/obj/rider.project.model.nuget.info
        modified:   SongWorker/obj/rider.project.restore.info
        modified:   SoundNameRemover.sln
        deleted:    SoundNameRemover/obj/Debug/net10.0/SoundNameRemover.AssemblyInfoInputs.cache
        deleted:    SoundNameRemover/obj/project.packagespec.json
        deleted:    SoundNameRemover/obj/rider.project.model.nuget.info
        deleted:    SoundNameRemover/obj/rider.project.restore.info
        new file:   SpotifyApiWorker/Controllers/AuthorizationController.cs
        new file:   SpotifyApiWorker/Exceptions/AccessTokenException.cs
        new file:   SpotifyApiWorker/Exceptions/AuthorizationCodeTokenException.cs
        new file:   SpotifyApiWorker/Exceptions/NoAuthorizationCodeException.cs
        new file:   SpotifyApiWorker/MyInfo.cs
        new file:   SpotifyApiWorker/Program.cs
        new file:   SpotifyApiWorker/Properties/launchSettings.json
        new file:   SpotifyApiWorker/Services/Contracts/IAuthorization.cs
        new file:   SpotifyApiWorker/Services/Implementations/Authorization.cs
        new file:   SpotifyApiWorker/SpotifyApiWorker.csproj
        new file:   SpotifyApiWorker/WebTest.http
        new file:   SpotifyApiWorker/appsettings.Development.json
        new file:   SpotifyApiWorker/appsettings.json
        new file:   SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.dll
        new file:   SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.pdb
        renamed:    OfficialSpotifyApiWorker/obj/Debug/net10.0/.NETCoreApp,Version=v10.0.AssemblyAttributes.cs -> SpotifyApiWorker/obj/Debug/net10.0/.NETCoreApp,Version=v10.0.AssemblyAttributes.cs
        renamed:    OfficialSpotifyApiWorker/obj/Debug/net10.0/OfficialSpotifyApiWorker.AssemblyInfo.cs -> SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.AssemblyInfo.cs
        new file:   SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.AssemblyInfoInputs.cache
        new file:   SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.GeneratedMSBuildEditorConfig.editorconfig
        new file:   SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.GlobalUsings.g.cs
        new file:   SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.assets.cache
        new file:   SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.csproj.AssemblyReference.cache
        new file:   SpotifyApiWorker/obj/Debug/net10.0/WebTest.AssemblyInfo.cs
        new file:   SpotifyApiWorker/obj/Debug/net10.0/WebTest.AssemblyInfoInputs.cache
        new file:   SpotifyApiWorker/obj/Debug/net10.0/WebTest.GeneratedMSBuildEditorConfig.editorconfig
        new file:   SpotifyApiWorker/obj/Debug/net10.0/WebTest.GlobalUsings.g.cs
        new file:   SpotifyApiWorker/obj/Debug/net10.0/WebTest.assets.cache
        new file:   SpotifyApiWorker/obj/Debug/net10.0/WebTest.csproj.AssemblyReference.cache
        new file:   SpotifyApiWorker/obj/UserAuthorization.csproj.nuget.dgspec.json
        renamed:    OfficialSpotifyApiWorker/obj/OfficialSpotifyApiWorker.csproj.nuget.g.props -> SpotifyApiWorker/obj/UserAuthorization.csproj.nuget.g.props
        new file:   SpotifyApiWorker/obj/UserAuthorization.csproj.nuget.g.targets
        renamed:    OfficialSpotifyApiWorker/obj/OfficialSpotifyApiWorker.csproj.nuget.dgspec.json -> SpotifyApiWorker/obj/WebTest.csproj.nuget.dgspec.json
        renamed:    SoundNameRemover/obj/SoundNameRemover.csproj.nuget.g.props -> SpotifyApiWorker/obj/WebTest.csproj.nuget.g.props
        new file:   SpotifyApiWorker/obj/WebTest.csproj.nuget.g.targets
        new file:   SpotifyApiWorker/obj/project.assets.json
        new file:   SpotifyApiWorker/obj/project.nuget.cache
        new file:   SpotifyApiWorker/obj/project.packagespec.json
        new file:   SpotifyApiWorker/obj/rider.project.model.nuget.info
        new file:   SpotifyApiWorker/obj/rider.project.restore.info
        renamed:    SoundNameRemover/Program.cs -> SpotifySongDownloader/Program.cs
        renamed:    SoundNameRemover/SoundNameRemover.csproj -> SpotifySongDownloader/SpotifySongDownloader.csproj
        renamed:    SoundNameRemover/obj/Debug/net10.0/.NETCoreApp,Version=v10.0.AssemblyAttributes.cs -> SpotifySongDownloader/obj/Debug/net10.0/.NETCoreApp,Version=v10.0.AssemblyAttributes.cs
        renamed:    SoundNameRemover/obj/Debug/net10.0/SoundNameRemover.AssemblyInfo.cs -> SpotifySongDownloader/obj/Debug/net10.0/SoundNameRemover.AssemblyInfo.cs
        new file:   SpotifySongDownloader/obj/Debug/net10.0/SoundNameRemover.AssemblyInfoInputs.cache
        renamed:    SoundNameRemover/obj/Debug/net10.0/SoundNameRemover.GeneratedMSBuildEditorConfig.editorconfig -> SpotifySongDownloader/obj/Debug/net10.0/SoundNameRemover.GeneratedMSBuildEditorConfig.editorconfig
        renamed:    SoundNameRemover/obj/Debug/net10.0/SoundNameRemover.GlobalUsings.g.cs -> SpotifySongDownloader/obj/Debug/net10.0/SoundNameRemover.GlobalUsings.g.cs
        renamed:    SoundNameRemover/obj/Debug/net10.0/SoundNameRemover.assets.cache -> SpotifySongDownloader/obj/Debug/net10.0/SoundNameRemover.assets.cache
        renamed:    SoundNameRemover/obj/Debug/net10.0/SoundNameRemover.csproj.AssemblyReference.cache -> SpotifySongDownloader/obj/Debug/net10.0/SoundNameRemover.csproj.AssemblyReference.cache
        new file:   SpotifySongDownloader/obj/Debug/net10.0/SpotifySongDownloader.AssemblyInfo.cs
        new file:   SpotifySongDownloader/obj/Debug/net10.0/SpotifySongDownloader.AssemblyInfoInputs.cache
        renamed:    OfficialSpotifyApiWorker/obj/Debug/net10.0/OfficialSpotifyApiWorker.GeneratedMSBuildEditorConfig.editorconfig -> SpotifySongDownloader/obj/Debug/net10.0/SpotifySongDownloader.GeneratedMSBuildEditorConfig.editorconfig
        renamed:    OfficialSpotifyApiWorker/obj/Debug/net10.0/OfficialSpotifyApiWorker.GlobalUsings.g.cs -> SpotifySongDownloader/obj/Debug/net10.0/SpotifySongDownloader.GlobalUsings.g.cs
        new file:   SpotifySongDownloader/obj/Debug/net10.0/SpotifySongDownloader.assets.cache
        new file:   SpotifySongDownloader/obj/Debug/net10.0/SpotifySongDownloader.csproj.AssemblyReference.cache
        renamed:    SoundNameRemover/obj/Debug/net9.0/.NETCoreApp,Version=v9.0.AssemblyAttributes.cs -> SpotifySongDownloader/obj/Debug/net9.0/.NETCoreApp,Version=v9.0.AssemblyAttributes.cs
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.AssemblyInfo.cs -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.AssemblyInfo.cs
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.AssemblyInfoInputs.cache -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.AssemblyInfoInputs.cache
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.GeneratedMSBuildEditorConfig.editorconfig -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.GeneratedMSBuildEditorConfig.editorconfig
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.GlobalUsings.g.cs -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.GlobalUsings.g.cs
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.assets.cache -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.assets.cache
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.csproj.AssemblyReference.cache -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.csproj.AssemblyReference.cache
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.csproj.CoreCompileInputs.cache -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.csproj.CoreCompileInputs.cache
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.csproj.FileListAbsolute.txt -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.csproj.FileListAbsolute.txt
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.dll -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.dll
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.genruntimeconfig.cache -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.genruntimeconfig.cache
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.pdb -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.pdb
        renamed:    SoundNameRemover/obj/Debug/net9.0/SoundNameRemover.sourcelink.json -> SpotifySongDownloader/obj/Debug/net9.0/SoundNameRemover.sourcelink.json
        renamed:    SoundNameRemover/obj/Debug/net9.0/apphost.exe -> SpotifySongDownloader/obj/Debug/net9.0/apphost.exe
        renamed:    SoundNameRemover/obj/Debug/net9.0/ref/SoundNameRemover.dll -> SpotifySongDownloader/obj/Debug/net9.0/ref/SoundNameRemover.dll
        renamed:    SoundNameRemover/obj/Debug/net9.0/refint/SoundNameRemover.dll -> SpotifySongDownloader/obj/Debug/net9.0/refint/SoundNameRemover.dll
        renamed:    SoundNameRemover/obj/SoundNameRemover.csproj.nuget.dgspec.json -> SpotifySongDownloader/obj/SoundNameRemover.csproj.nuget.dgspec.json
        new file:   SpotifySongDownloader/obj/SoundNameRemover.csproj.nuget.g.props
        renamed:    SoundNameRemover/obj/SoundNameRemover.csproj.nuget.g.targets -> SpotifySongDownloader/obj/SoundNameRemover.csproj.nuget.g.targets
        new file:   SpotifySongDownloader/obj/SpotifySongDownloader.csproj.nuget.dgspec.json
        new file:   SpotifySongDownloader/obj/SpotifySongDownloader.csproj.nuget.g.props
        renamed:    OfficialSpotifyApiWorker/obj/OfficialSpotifyApiWorker.csproj.nuget.g.targets -> SpotifySongDownloader/obj/SpotifySongDownloader.csproj.nuget.g.targets
        renamed:    SoundNameRemover/obj/project.assets.json -> SpotifySongDownloader/obj/project.assets.json
        renamed:    SoundNameRemover/obj/project.nuget.cache -> SpotifySongDownloader/obj/project.nuget.cache
        new file:   SpotifySongDownloader/obj/project.packagespec.json
        new file:   SpotifySongDownloader/obj/rider.project.model.nuget.info
        new file:   SpotifySongDownloader/obj/rider.project.restore.info
        new file:   UserAuthorization/UserAuthorization.csproj

Changes not staged for commit:
  (use "git add/rm <file>..." to update what will be committed)
  (use "git restore <file>..." to discard changes in working directory)
        modified:   SongWorker/SongWorker.cs
        modified:   SongWorker/obj/SongWorker.csproj.nuget.dgspec.json
        modified:   SongWorker/obj/project.assets.json
        modified:   SongWorker/obj/project.nuget.cache
        modified:   SongWorker/obj/project.packagespec.json
        modified:   SongWorker/obj/rider.project.model.nuget.info
        modified:   SongWorker/obj/rider.project.restore.info
        modified:   SoundNameRemover.sln
        modified:   SpotifyApiWorker/Controllers/AuthorizationController.cs
        modified:   SpotifyApiWorker/Exceptions/AccessTokenException.cs
        modified:   SpotifyApiWorker/Exceptions/AuthorizationCodeTokenException.cs
        modified:   SpotifyApiWorker/Exceptions/NoAuthorizationCodeException.cs
        modified:   SpotifyApiWorker/MyInfo.cs
        modified:   SpotifyApiWorker/Program.cs
        modified:   SpotifyApiWorker/Services/Contracts/IAuthorization.cs
        modified:   SpotifyApiWorker/Services/Implementations/Authorization.cs
        modified:   SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.dll
        modified:   SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.pdb
        modified:   SpotifyApiWorker/obj/project.assets.json
        modified:   SpotifyApiWorker/obj/project.nuget.cache
        modified:   SpotifyApiWorker/obj/project.packagespec.json
        modified:   SpotifyApiWorker/obj/rider.project.model.nuget.info
        modified:   SpotifyApiWorker/obj/rider.project.restore.info
        modified:   SpotifySongDownloader/obj/SpotifySongDownloader.csproj.nuget.dgspec.json
        modified:   SpotifySongDownloader/obj/project.assets.json
        modified:   SpotifySongDownloader/obj/project.nuget.cache
        modified:   SpotifySongDownloader/obj/project.packagespec.json
        modified:   SpotifySongDownloader/obj/rider.project.model.nuget.info
        modified:   SpotifySongDownloader/obj/rider.project.restore.info
        deleted:    UserAuthorization/UserAuthorization.csproj

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .vs/
        SpotifyApiWorker/UserAuthorization.csproj.user
        SpotifyApiWorker/bin/Debug/net10.0/EmbedIO.dll
        SpotifyApiWorker/bin/Debug/net10.0/Microsoft.AspNetCore.Authentication.Negotiate.dll
        SpotifyApiWorker/bin/Debug/net10.0/Microsoft.AspNetCore.OpenApi.dll
        SpotifyApiWorker/bin/Debug/net10.0/Microsoft.OpenApi.dll
        SpotifyApiWorker/bin/Debug/net10.0/Newtonsoft.Json.dll
        SpotifyApiWorker/bin/Debug/net10.0/SpotifyAPI.Web.Auth.dll
        SpotifyApiWorker/bin/Debug/net10.0/SpotifyAPI.Web.dll
        SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.deps.json
        SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.exe
        SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.runtimeconfig.json
        SpotifyApiWorker/bin/Debug/net10.0/SpotifyApiWorker.staticwebassets.endpoints.json
        SpotifyApiWorker/bin/Debug/net10.0/Swan.Lite.dll
        SpotifyApiWorker/bin/Debug/net10.0/Swashbuckle.AspNetCore.Swagger.dll
        SpotifyApiWorker/bin/Debug/net10.0/Swashbuckle.AspNetCore.SwaggerGen.dll
        SpotifyApiWorker/bin/Debug/net10.0/Swashbuckle.AspNetCore.SwaggerUI.dll
        SpotifyApiWorker/bin/Debug/net10.0/System.DirectoryServices.Protocols.dll
        SpotifyApiWorker/bin/Debug/net10.0/UserAuthorization.deps.json
        SpotifyApiWorker/bin/Debug/net10.0/UserAuthorization.exe
        SpotifyApiWorker/bin/Debug/net10.0/UserAuthorization.runtimeconfig.json
        SpotifyApiWorker/bin/Debug/net10.0/UserAuthorization.staticwebassets.endpoints.json
        SpotifyApiWorker/bin/Debug/net10.0/appsettings.Development.json
        SpotifyApiWorker/bin/Debug/net10.0/appsettings.json
        SpotifyApiWorker/bin/Debug/net10.0/runtimes/
        SpotifyApiWorker/obj/Debug/net10.0/ApiEndpoints.json
        SpotifyApiWorker/obj/Debug/net10.0/EndpointInfo/
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.AssemblyInfo.cs
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.AssemblyInfoInputs.cache
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.GeneratedMSBuildEditorConfig.editorconfig
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.GlobalUsings.g.cs
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.MvcApplicationPartsAssemblyInfo.cache
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.MvcApplicationPartsAssemblyInfo.cs
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.assets.cache
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.csproj.AssemblyReference.cache
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.csproj.CoreCompileInputs.cache
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.csproj.FileListAbsolute.txt
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.dll
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.genruntimeconfig.cache
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.pdb
        SpotifyApiWorker/obj/Debug/net10.0/SpotifyApiWorker.sourcelink.json
        SpotifyApiWorker/obj/Debug/net10.0/UserAuth.A498AE91.Up2Date
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.MvcApplicationPartsAssemblyInfo.cache
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.MvcApplicationPartsAssemblyInfo.cs
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.csproj.BuildWithSkipAnalyzers
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.csproj.CoreCompileInputs.cache
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.csproj.FileListAbsolute.txt
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.dll
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.genruntimeconfig.cache
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.pdb
        SpotifyApiWorker/obj/Debug/net10.0/UserAuthorization.sourcelink.json
        SpotifyApiWorker/obj/Debug/net10.0/apphost.exe
        SpotifyApiWorker/obj/Debug/net10.0/ref/
        SpotifyApiWorker/obj/Debug/net10.0/refint/
        SpotifyApiWorker/obj/Debug/net10.0/rjsmcshtml.dswa.cache.json
        SpotifyApiWorker/obj/Debug/net10.0/rjsmrazor.dswa.cache.json
        SpotifyApiWorker/obj/Debug/net10.0/rpswa.dswa.cache.json
        SpotifyApiWorker/obj/Debug/net10.0/staticwebassets.build.endpoints.json
        SpotifyApiWorker/obj/Debug/net10.0/staticwebassets.build.json
        SpotifyApiWorker/obj/Debug/net10.0/staticwebassets.build.json.cache
        SpotifyApiWorker/obj/Debug/net10.0/staticwebassets.references.upToDateCheck.txt
        SpotifyApiWorker/obj/Debug/net10.0/staticwebassets.removed.txt
        SpotifyApiWorker/obj/Debug/net10.0/swae.build.ex.cache
        SpotifyApiWorker/obj/SpotifyApiWorker.csproj.nuget.dgspec.json
        SpotifyApiWorker/obj/SpotifyApiWorker.csproj.nuget.g.props
        SpotifyApiWorker/obj/SpotifyApiWorker.csproj.nuget.g.targets
*/