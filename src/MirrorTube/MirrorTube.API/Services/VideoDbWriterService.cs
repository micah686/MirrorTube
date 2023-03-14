using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;
using Newtonsoft.Json;
using YoutubeDLSharp.Metadata;
using MirrorTube.API.Database.UserData.ModelsDto.YtDlp;
using AutoMapper;
using System.Net;

namespace MirrorTube.API.Services
{
    public class VideoDbWriterService : IVideoDbWriterService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly UserDatadbContext _dbContext;
        private readonly IMapper _mapper;
        public VideoDbWriterService(UserDatadbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        async Task IVideoDbWriterService.SaveInfoToDb(string filepath)
        {
            var json = JsonConvert.DeserializeObject<VideoData>(File.ReadAllText(filepath));
            if (json == null) return;

            VideoDataDto foo1 = _mapper.Map<VideoDataDto>(json);
            FormatDataDto[] foo2 = _mapper.Map<FormatDataDto[]>(json.Formats);

            var subs = await GetSubtitleData(json.Subtitles);

            var dbRecord = _dbContext.VideoDataDto.FirstOrDefault(x => x.ID == json.ID);
            if(dbRecord == null) { dbRecord = new VideoDataDto(); }
        }

        private async Task<List<SubtitleDataDto>> GetSubtitleData(Dictionary<string, SubtitleData[]> input)
        {
            List<SubtitleDataDto> output = new List<SubtitleDataDto>();
            foreach (var langList in input)
            {
                foreach (var sub in langList.Value)
                {
                    var subData = new SubtitleDataDto
                    {
                        LangCode = langList.Key
                    };
                    Enum.TryParse(sub.Ext, true, out SubtitleType subType);
                    subData.SubtitleType = subType;

                    try
                    {
                        var data = await _httpClient.GetStringAsync(sub.Url);                        
                        subData.SubtitleData = data;
                    }
                    catch (Exception) { }
                    output.Add(subData);
                }
            }
            return output;
        }
    }
}
