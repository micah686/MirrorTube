using FluentStorage.Blobs;
using Microsoft.AspNetCore.Mvc;
using MirrorTube.API.Interfaces;

namespace MirrorTube.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController: ControllerBase
    {
        private readonly IVideoDbWriterService _videoDbWriterService;
        public TestController(IVideoDbWriterService videoDbWriterService)
        {
            _videoDbWriterService = videoDbWriterService;
        }
        
        
        [HttpGet]
        public async Task<string> DoThing()
        {
            var json = @"C:\Users\Micah\source\repos\MirrorTube\src\MirrorTube\MirrorTube.API\bin\Debug\net6.0\Data\UserData\youtube\[qlrvzLRgzdc]_20220903_Hoist_the_Colours_The_Bass_Singers_of_TikTok.info.json";
            await _videoDbWriterService.SaveInfoToDb(json);
            return "";
        }
    }
}
