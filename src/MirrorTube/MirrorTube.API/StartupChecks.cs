using MirrorTube.Common.Secure;
namespace MirrorTube.API
{
    public static class StartupChecks
    {
        internal static void RunStartupChecks()
        {
            CreateDirectories();
            if (!SecureStore.DoesSecureStoreExist())
            {
                SecureStore.CreateSecureStore();
            }
            DownloadBinaries();
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(Globals.ServerDataPath);            
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
