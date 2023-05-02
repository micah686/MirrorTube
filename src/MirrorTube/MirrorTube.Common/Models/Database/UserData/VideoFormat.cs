using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoFormat
    {
        //Have VideoID or some other PK
        [PrimaryKey]
        [ForeignKey(typeof(VideoInfoLatest))]
        public string? VideoID { get; set; }

        //audio
        public double? AudioBitrate { get; set; }
        public string? AudioCodec { get; set; }
        public double? AudioSamplingRate { get; set; }
        public short? AudioChannels { get; set; }

        //Video
        public string? DynamicRange { get; set; }
        public double? VideoBitrate { get; set; }
        public float? FrameRate { get; set; }
        public string? VideoCodec { get; set; }
        public string? Resolution { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? FriendlyVideoResolution { get; set; }
    }
}
