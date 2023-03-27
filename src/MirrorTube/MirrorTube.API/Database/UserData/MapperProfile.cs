using AutoMapper;
using MirrorTube.API.Database.UserData.ModelsDto.YtDlp;
using YoutubeDLSharp.Metadata;

namespace MirrorTube.API.Database.UserData
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoData, VideoDataDto>()
                .ForMember(dest => dest.VideoID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Formats, src => src.Ignore())
                .ForMember(dest => dest.Subtitles, src => src.Ignore())
                .ForMember(dest => dest.AutomaticCaptions, src => src.Ignore());
            CreateMap<FormatData, FormatDataDto>();
            


        }
    }
}
