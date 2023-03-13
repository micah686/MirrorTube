using Hangfire;
using Microsoft.AspNetCore.Mvc;
using MirrorTube.API.Services;

namespace MirrorTube.API.Controllers
{
    [ApiController]
    public class DownloadController: ControllerBase
    {
        [Route("/api/v1/downloadvideo")]
        [HttpPost]
        public string DownloadVideo(string url)
        {
            var id = BackgroundJob.Enqueue<DownloadService>(x => x.DownloadVideo(url));
            return id;
        }
    }
}
