using Microsoft.AspNetCore.Mvc;
using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;

namespace MirrorTube.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController: ControllerBase
    {
        private readonly UserDataContext _userDataContext;
        private readonly IVideoDbWriterService _videoDbWriterService;
        public TestController(IVideoDbWriterService videoDbWriterService, UserDataContext context)
        {
            _videoDbWriterService = videoDbWriterService;
            _userDataContext = context;
        }
        
        
        [HttpGet]
        public async Task<string> DoThing()
        {
            _userDataContext.Users.Add(new TestUser() { FullName = "joe" });
            _userDataContext.SaveChanges();
            
            //var json = @"C:\Users\Micah\source\repos\MirrorTube\src\MirrorTube\MirrorTube.API\bin\Debug\net6.0\Data\UserData\youtube\[uFJHdT_ie9U]_20220101_Ochame_Kinou_-_hololive_English_Cover.info.json";
            //await _videoDbWriterService.SaveInfoToDb(json);
            return "";
        }
    }
}
