using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class FormatDataDto
    {
        //Have VideoID or some other PK
        [Key]
        public string? VideoID { get; set; }

        //audio
        public double? AudioBitrate { get; set; }
        public string? AudioCodec { get; set; }
        public double? AudioSamplingRate { get; set; }
        public int? AudioChannels { get; set; }
        public AudioQuality AudioQuality { get; set; }

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
    public enum AudioQuality
    {
        None = 0,
        Worst = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Ultra = 5,
        Source = 6,
    }
}
