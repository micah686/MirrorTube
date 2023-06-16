using AutoMapper;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData
{
    public class UserDataProfile : Profile
    {
        public UserDataProfile()
        {
            CreateMap<VideoInfo, VideoInfoHistory>();
        }
    }
}
