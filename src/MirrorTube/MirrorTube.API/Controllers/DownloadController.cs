using Hangfire;
using Hangfire.Storage.Monitoring;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;
using MirrorTube.API.Services;
using Newtonsoft.Json;
using ServiceStack;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq.Expressions;

namespace MirrorTube.API.Controllers
{
    [ApiController]
    public class DownloadController: ControllerBase
    {
        [Route("/api/v1/downloadvideo")]
        [HttpPost]
        public void DownloadVideo(string url)
        {
            var data = BackgroundJob.Enqueue<DownloadService>(x => x.DownloadVideo(url));
            
            BackgroundJob.ContinueJobWith<VideoDbWriterService>(data, x => x.StartWriteToDb(null));
        }
    }

    
}
