namespace MirrorTube.API.Interfaces
{
    public interface IDownloadService
    {
        Task DownloadVideo(string url);
        Task DownloadVideoPlaylist(string url);

        Task DownloadAudio(string url);
        Task DownloadAudioPlaylist(string url);
    }
}
