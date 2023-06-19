using Config.Net;
using MirrorTube.Common.Configuration;
using MirrorTube.Common.Secure;
using MirrorTube.Common.Models.Database.UserData;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MirrorTube.API.Database;

namespace MirrorTube.API
{
    public static class StartupChecks
    {
        internal static void RunStartupChecks()
        {
            CreateDirectories();
            Globals.ConfigSettings = new ConfigurationBuilder<ISettingsRoot>().UseJsonFile(Path.Combine(Globals.ServerDataPath, "config.json")).Build();
            if (!SecureStore.DoesSecureStoreExist())
            {
                SecureStore.CreateSecureStore();
            }
            DownloadBinaries();

            DbHelper.CreateInitialDb().GetAwaiter().GetResult();
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(Globals.ServerDataPath);
            Directory.CreateDirectory(Globals.UserDataPath);
        }

        private static void DownloadBinaries()
        {
            var ytdlp = Path.Combine(Globals.ServerDataPath, YoutubeDLSharp.Utils.YtDlpBinaryName);
            var ffmpeg = Path.Combine(Globals.ServerDataPath, YoutubeDLSharp.Utils.FfmpegBinaryName);
            var ffprobe = Path.Combine(Globals.ServerDataPath, YoutubeDLSharp.Utils.FfprobeBinaryName);

            if (!File.Exists(ytdlp)) { YoutubeDLSharp.Utils.DownloadYtDlp(Path.GetDirectoryName(ytdlp)); }
            if (!File.Exists(ffmpeg)) { YoutubeDLSharp.Utils.DownloadFFmpeg(Path.GetDirectoryName(ffmpeg)); }
            if (!File.Exists(ffprobe)) { YoutubeDLSharp.Utils.DownloadFFprobe(Path.GetDirectoryName(ffprobe)); }
        }

        
    }
}
