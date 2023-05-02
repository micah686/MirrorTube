using Config.Net;
using MirrorTube.Common.Configuration;
using MirrorTube.Common.Secure;
using ServiceStack.OrmLite;
using MirrorTube.Common.Models.Database.UserData;

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

            CreateTables();
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

        private static void CreateTables()
        {
            var conn_str = "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=postgres;Include Error Detail=true";
            var dbFactory = new OrmLiteConnectionFactory(conn_str, PostgreSqlDialect.Provider);

            using (var db = dbFactory.Open())
            {
                db.DropAndCreateTable<VideoInfoHistory>();
                db.DropAndCreateTable<VideoInfoLatest>();
                db.DropAndCreateTable<VideoFormat>();
                db.DropAndCreateTable<VideoInfo>();
            }
        }
    }
}
