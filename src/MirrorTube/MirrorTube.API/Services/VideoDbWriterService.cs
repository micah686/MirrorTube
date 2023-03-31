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
            var jData = File.ReadAllText(filepath);
            var json = JsonConvert.DeserializeObject<VideoData>(File.ReadAllText(filepath));
            if (json == null) return;

            //Format_ID can be appended with a dash and a number, like so: 248+248-1
            VideoDataDto videoData = _mapper.Map<VideoDataDto>(json);
            FormatDataDto[] formatData = _mapper.Map<FormatDataDto[]>(json.Formats);
            var formatList = GetFormatData("videoData.FormatID", formatData, json.ID);
            videoData.SeriesData = GetSeriesData(json);
            videoData.TrackData = GetTrackData(json);


            var captions = await GetSubtitleData(json.Subtitles);
            var subs = await GetSubtitleData(json.Subtitles);



            //videoData.Subtitles = subs;
            //videoData.AutomaticCaptions = captions;

            //var uniqueID = GenerateUniqueID(videoData);

            try
            {
                var dbRecord = _dbContext.VideoDataDto.FirstOrDefault(x => x.VideoID == json.ID);
                if (dbRecord != null)
                {
                    //_dbContext.Entry(dbRecord).Collection(c => c.Formats).Load();
                    _dbContext.Entry(dbRecord).Collection(c => c.Subtitles).Load();
                    _dbContext.Entry(dbRecord).Collection(c => c.AutomaticCaptions).Load();
                }
                dbRecord ??= new VideoDataDto();
                //dbRecord.Formats.AddRange(formatList);


                _dbContext.Update(dbRecord);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
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

        private FormatDataDto[] GetFormatData(string? formatString, IEnumerable<FormatDataDto> allFormats, string videoID)
        {
            if(formatString == null) return Array.Empty<FormatDataDto>();
            var splitIds = formatString.Split("+");
            if(splitIds.Length > 0)
            {
                var formatList = new List<FormatDataDto>();
                //foreach (var id in splitIds)
                //{
                //    var format = allFormats.Where(x => x.FormatId == id).FirstOrDefault();
                //    if (format != null)
                //    {
                //        format.VideoId = videoID;
                //        format.PK_VideoFormatId = $"{videoID}{format.FormatId}";
                //        formatList.Add(format);
                //    }                    
                //}
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
            sb.Append(videoData.VideoID);
            sb.Append(videoData.WebpageUrl);
            sb.Append(videoData.UploadDate.ToString());
            sb.Append(videoData.Timestamp.ToString());
            sb.Append(videoData.ModifiedDate.ToString());
            sb.Append(videoData.ModifiedTimestamp.ToString());

            var dataBytes = Encoding.UTF8.GetBytes(sb.ToString());

            var uniqueID = BitConverter.ToString(SHA1.HashData(dataBytes)).Replace("-", "");
            return uniqueID;
        }

        private SeriesDataDto? GetSeriesData(VideoData data)
        {
            var series = new SeriesDataDto();
            series.PK_VideoID = data.ID;
            series.Series = data.Series;
            series.SeriesId = data.SeriesId;
            series.Season = data.Season;
            series.SeasonNumber = data.SeasonNumber;
            series.SeasonId = data.SeasonId;
            series.Episode = data.Episode;
            series.EpisodeNumber = data.EpisodeNumber;
            series.EpisodeId = data.EpisodeId;

            var seriesData = $"{data.Series}{data.SeriesId}{data.Season}{data.SeasonNumber}{data.SeasonId}{data.Episode}{data.EpisodeNumber}{data.EpisodeId}";
            if(!string.IsNullOrEmpty(seriesData))
            {
                return series;
            }
            else { return null; }
        }

        private TrackDataDto? GetTrackData(VideoData data)
        {
            var track = new TrackDataDto();
            track.PK_VideoID = data.ID;
            track.Track = data.Track;
            track.TrackNumber = data.TrackNumber;
            track.TrackId = data.TrackId;
            track.Artist = data.Artist;
            track.Genre = data.Genre;
            track.Album = data.Album;
            track.AlbumType = data.AlbumType;
            track.AlbumArtist = data.AlbumArtist;
            track.DiscNumber = data.DiscNumber;
            track.ReleaseYear = data.ReleaseYear;
            track.Composer = data.Composer;

            var trackData = $"{data.Track}{data.TrackNumber}{data.TrackId}{data.Artist}{data.Genre}{data.Album}{data.AlbumType}{data.AlbumArtist}{data.DiscNumber}{data.ReleaseYear}{data.Composer}";
            if (!string.IsNullOrEmpty(trackData))
            {
                return track;
            }
            else { return null; }
        }
    }

    public class Foo : YoutubeDLSharp.Metadata.VideoData
    {

    }
}
