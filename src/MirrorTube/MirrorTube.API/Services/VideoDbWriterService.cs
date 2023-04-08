using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;
using Newtonsoft.Json;
using YoutubeDLSharp.Metadata;
using MirrorTube.API.Database.UserData.ModelsDto.YtDlp;
using AutoMapper;
using System.Text;

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

            
            VideoDataDto videoData = _mapper.Map<VideoDataDto>(json);
            var formatData = GetFormatData(json.FormatID, json.Formats, json.ID);
            //videoData.SeriesData = GetSeriesData(json);
            //videoData.TrackData = GetTrackData(json);


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
                    //_dbContext.Entry(dbRecord).Collection(c => c.Subtitles).Load();
                    //_dbContext.Entry(dbRecord).Collection(c => c.AutomaticCaptions).Load();
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

        private static FormatDataDto GetFormatData(string? formatString, IEnumerable<FormatData> allFormats, string VideoID)
        {
            //Format_ID can be appended with a dash and a number, like so: 248+248-1
            var output = new FormatDataDto();
            output.VideoID = VideoID;
            if (formatString == null) return new FormatDataDto();
            var splitIds = formatString.Split('+');
            if (splitIds.Length > 0)
            {
                var formats = allFormats.Where(r => splitIds.Contains(r.FormatId));
                foreach (var format in formats)
                {
                    if(format.AudioBitrate != null)//audio format
                    {
                        output.AudioBitrate = format.AudioBitrate;
                        output.AudioCodec = format.AudioCodec;
                        output.AudioSamplingRate = format.AudioSamplingRate;
                        output.AudioChannels = format.AudioChannels;
                    }
                    else if(format.VideoBitrate != null)//video format
                    {
                        output.DynamicRange = format.DynamicRange;
                        output.VideoBitrate = format.VideoBitrate;
                        output.FrameRate = format.FrameRate;
                        output.VideoCodec = format.VideoCodec;
                        output.Resolution = format.Resolution;
                        output.Width = format.Width;
                        output.Height = format.Height;
                        output.FriendlyVideoResolution = format.FormatNote;
                    }
                    else { }
                }
            }
            return output;
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

            var dataBytes = (ReadOnlySpan<byte>)Encoding.UTF8.GetBytes(sb.ToString());

            var uniqueID = Blake3.Hasher.Hash(dataBytes).ToString();
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
    
}
