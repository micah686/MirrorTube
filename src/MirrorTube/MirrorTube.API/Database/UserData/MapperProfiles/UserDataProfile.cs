using AutoMapper;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.MapperProfiles
{
    public class UserDataProfile : Profile
    {
        public UserDataProfile()
        {
            CreateMap<LookupResources, LookupResourcesHistory>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
