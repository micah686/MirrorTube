using System.ComponentModel.DataAnnotations;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class FormatDataDto
    {
        [Key]
        public string PK_ID { get; set; }


        public string VideoId { get; set; }
        
        public string Url { get; set; }
        public string ManifestUrl { get; set; }
        public string Extension { get; set; }
        public string Format { get; set; }
        public string FormatId { get; set; }
        public string FormatNote { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Resolution { get; set; }
        public string DynamicRange { get; set; }
        public double? Bitrate { get; set; }
        public double? AudioBitrate { get; set; }
        public string AudioCodec { get; set; }
        public double? AudioSamplingRate { get; set; }
        public int? AudioChannels { get; set; }
        public double? VideoBitrate { get; set; }
        public float? FrameRate { get; set; }
        public string VideoCodec { get; set; }
        public string ContainerFormat { get; set; }
        public long? FileSize { get; set; }
        public long? ApproximateFileSize { get; set; }
        public string PlayerUrl { get; set; }
        public string Protocol { get; set; }
        public string FragmentBaseUrl { get; set; }
        public bool? IsFromStart { get; set; }
        public int? Preference { get; set; }
        public string Language { get; set; }
        public int? LanguagePreference { get; set; }
        public double? Quality { get; set; }
        public int? SourcePreference { get; set; }
        public float? StretchedRatio { get; set; }
        public bool? NoResume { get; set; }
        public bool? HasDRM { get; set; }

    }
}
