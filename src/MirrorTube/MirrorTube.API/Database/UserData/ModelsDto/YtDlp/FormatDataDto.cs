using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class FormatDataDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string PK_ID { get; set; }


        public string? VideoId { get; set; }
        
        public string? Extension { get; set; }
        public string? Format { get; set; }
        public string? FormatId { get; set; }
        public string? FormatNote { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public double? Bitrate { get; set; }
        public long? FileSize { get; set; }
        public bool? HasDRM { get; set; }

        //Video
        public string? DynamicRange { get; set; }
        public double? VideoBitrate { get; set; }
        public float? FrameRate { get; set; }
        public string? VideoCodec { get; set; }
        public string? Resolution { get; set; }

        //Audio
        public double? AudioBitrate { get; set; }
        public string? AudioCodec { get; set; }
        public double? AudioSamplingRate { get; set; }
        public int? AudioChannels { get; set; }

        
       
        
        

    }
}
