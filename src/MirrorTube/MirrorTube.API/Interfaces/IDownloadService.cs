namespace MirrorTube.API.Interfaces
{
    public interface IDownloadService
    {
        public Task DownloadVideo(string url);
        public Task DownloadVideoPlaylist(string url);

        public Task DownloadAudio(string url);
        public Task DownloadAudioPlaylist(string url);
    }
}
