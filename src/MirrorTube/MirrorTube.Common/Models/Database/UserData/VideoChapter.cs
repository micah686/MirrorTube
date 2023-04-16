using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoChapter
    {
        [PrimaryKey]
        public string? UniqueVideoId { get; set; }
        public float? StartTime { get; set; }
        public float? EndTime { get; set; }
        public string? Title { get; set; }
    }
}
