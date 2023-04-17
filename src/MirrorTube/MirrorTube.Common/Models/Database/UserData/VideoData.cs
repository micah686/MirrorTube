using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoData
    {
        [PrimaryKey]
        public string VideoID { get; set; }
        [Reference]
        public VideoTrack? VideoTrack { get; set; }
        [Reference]
        public VideoSeries? VideoSeries { get; set; }
        [Reference]
        public VideoFormat? VideoFormat { get; set; }
        [Reference]
        public List<VideoComment> VideoComments { get; set; } = new List<VideoComment>();
    }
}
