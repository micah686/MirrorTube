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
            var json = @"C:\Users\Micah\source\repos\micah686\MirrorTube\src\MirrorTube\MirrorTube.API\bin\Debug\net6.0\Data\UserData\youtube\[9CunwUs08og]_20230326_I_Beat_Netflix_s_Password_Sharing_Crackdown.info.json";
            await _videoDbWriterService.SaveInfoToDb(json);
            return "";
        }
    }
}
