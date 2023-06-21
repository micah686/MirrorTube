using AutoMapper;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.MapperProfiles
{
    public class VideoInfoProfile :Profile
    {
        public VideoInfoProfile()
        {
            CreateMap<VideoInfo, VideoInfoHistory>();
        }
    }
}
