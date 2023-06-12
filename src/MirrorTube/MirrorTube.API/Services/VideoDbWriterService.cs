using MirrorTube.API.Interfaces;
using Newtonsoft.Json;
using YoutubeDLSharp.Metadata;
using System.Text;
using MirrorTube.Common.Models;
using MirrorTube.API.Helpers;
using Hangfire.Server;


namespace MirrorTube.API.Services
{
    public class VideoDbWriterService : IVideoDbWriterService
    {      
        //private readonly IMapper _mapper;
        public VideoDbWriterService()
        {
            //_mapper = mapper;
        }


        public async Task StartWriteToDb(PerformContext? context)
        {
            if (context == null) { return; }
            var filepath = context.GetJobParameter<string>("AntecedentResult");
            await SaveInfoToDb(filepath);
        }

        public async Task SaveInfoToDb(string filepath)
        {

            try
            {
                var json = File.ReadAllText(filepath);
                var videoData = JsonConvert.DeserializeObject<VideoData>(File.ReadAllText(filepath));
                if (videoData == null) return;


                //VideoData videoData = _mapper.Map<VideoData>(json);
                var videoInfo = await VideoInfoFormatter.GetVideoInfo(videoData);

                var videoTrack = VideoInfoFormatter.GetTrackData(videoData);
                var videoSeries = VideoInfoFormatter.GetSeriesData(videoData);
                var videoFormat = VideoInfoFormatter.GetFormatData(videoData.FormatID, videoData.Formats, videoData.ID);
                var videoSubtitles = VideoInfoFormatter.GetSubtitleData(videoData.Subtitles);


                //var captions = await GetSubtitleData(json.Subtitles);

                var mixValues = new List<string>()
                    {   videoData.ID,
                        videoData.WebpageUrl,
                        videoData.UploadDate?.ToString()??"",
                        videoData.Timestamp?.ToString()??"",
                        videoData.ModifiedDate ?.ToString() ?? "",
                        videoData.ModifiedTimestamp ?.ToString() ?? ""
                    };
                GenerateUniqueID(mixValues);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }    

        

        public HexId GenerateUniqueID(IEnumerable<string> mixValues)
        {
            HexId hexId = Common.Models.HexId.GenerateUniqueHexId(mixValues);
            return hexId;
        }

    }
    
}
