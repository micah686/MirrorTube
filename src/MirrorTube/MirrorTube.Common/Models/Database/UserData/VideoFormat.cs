namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoFormat
    {
        public int ContentId { get; set; } //link to normalized table

        //audio
        public double? AudioBitrate { get; set; }
        public int AudioCodecId { get; set; }
        public double? AudioSamplingRate { get; set; }
        public short? AudioChannels { get; set; }

        //Video
        public int DynamicRangeId { get; set; }
        public double? VideoBitrate { get; set; }
        public float? FrameRate { get; set; }
        public int VideoCodecId { get; set; }
        public int ResolutionId { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int FriendlyVideoResolutionId { get; set; }
    }
}
