using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoChapter
    {
        [PrimaryKey]
        [ForeignKey(typeof(VideoInfoLatest))]
        public string? VideoId { get; set; }
        public float? StartTime { get; set; }
        public float? EndTime { get; set; }
        public string? Title { get; set; }
    }
}
