using AutoMapper;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.MapperProfiles
{
    public class UserDataProfile : Profile
    {
        public UserDataProfile()
        {
            CreateMap<VideoInfo, VideoInfoHistory>();
        }
    }
}
