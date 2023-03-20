using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;
using Newtonsoft.Json;
using YoutubeDLSharp.Metadata;
using MirrorTube.API.Database.UserData.ModelsDto.YtDlp;
using AutoMapper;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using NetBox.Extensions;
using Microsoft.EntityFrameworkCore;

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

            VideoDataDto videoData = _mapper.Map<VideoDataDto>(json);
            FormatDataDto[] formatData = _mapper.Map<FormatDataDto[]>(json.Formats);
            var formatList = GetFormatData(videoData.FormatID, formatData);


            var captions = await GetSubtitleData(json.Subtitles);
            var subs = await GetSubtitleData(json.Subtitles);



            //videoData.Subtitles = subs;
            //videoData.AutomaticCaptions = captions;

            //var uniqueID = GenerateUniqueID(videoData);

            try
            {
                var dbRecord = _dbContext.VideoDataDto.FirstOrDefault(x => x.ID == json.ID);
                dbRecord ??= new VideoDataDto();

                _dbContext.Entry(dbRecord).Collection(c => c.Formats).Load();
                _dbContext.Entry(dbRecord).Collection(c => c.Subtitles).Load();
                _dbContext.Entry(dbRecord).Collection(c => c.AutomaticCaptions).Load();


                var newFormats = dbRecord.Formats;
                newFormats.AddRange(formatList);

                dbRecord.Formats = new List<FormatDataDto>();
                dbRecord.Formats.AddRange(formatList);


                videoData.PK_ID = dbRecord.PK_ID;
                _dbContext.Entry(dbRecord).CurrentValues.SetValues(videoData);
                //_dbContext.Entry(dbRecord.Formats).CurrentValues.SetValues(formatList);

                //dbRecord.Formats.AddRange(formatList);
                _dbContext.Update(dbRecord);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            

            var d2 = _dbContext.VideoDataDto.FirstOrDefault();
            var d3 = d2?.Formats;
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

        private FormatDataDto[] GetFormatData(string? formatString, IEnumerable<FormatDataDto> allFormats)
        {
            if(formatString == null) return Array.Empty<FormatDataDto>();
            var splitIds = formatString.Split("+");
            if(splitIds.Length > 0)
            {
                var formatList = new List<FormatDataDto>();
                foreach (var id in splitIds)
                {
                    var format = allFormats.Where(x => x.FormatId == id).FirstOrDefault();
                    if (format != null)
                    {
                        formatList.Add(format);
                    }                    
                }
                return formatList.ToArray();
            }
            else
            {
                return Array.Empty<FormatDataDto>();
            }
        }

        private string GenerateUniqueID(VideoDataDto videoData)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(videoData.ID);
            sb.Append(videoData.WebpageUrl);
            sb.Append(videoData.UploadDate.ToString());
            sb.Append(videoData.Timestamp.ToString());
            sb.Append(videoData.ModifiedDate.ToString());
            sb.Append(videoData.ModifiedTimestamp.ToString());

            var dataBytes = Encoding.UTF8.GetBytes(sb.ToString());

            var uniqueID = BitConverter.ToString(SHA1.HashData(dataBytes)).Replace("-", "");
            return uniqueID;
        }
    }
}
