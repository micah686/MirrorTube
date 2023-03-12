using MirrorTube.API.Interfaces;

namespace MirrorTube.API.Services
{
    public class DownloadService : IDownloadService
    {
        Task IDownloadService.DownloadAudio(string url)
        {
            throw new NotImplementedException();
        }

        Task IDownloadService.DownloadAudioPlaylist(string url)
        {
            throw new NotImplementedException();
        }

        Task IDownloadService.DownloadVideo(string url)
        {
            throw new NotImplementedException();
        }

        Task IDownloadService.DownloadVideoPlaylist(string url)
        {
            throw new NotImplementedException();
        }
    }
}
