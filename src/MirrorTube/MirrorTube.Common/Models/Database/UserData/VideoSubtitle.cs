using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoSubtitle
    {
        [PrimaryKey]
        public string? UniqueVideoId { get; set; }
        public string? SubtitleData { get; set; }
        public SubtitleType SubtitleType { get; set; }
    }
}
