using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoCaption
    {
        [PrimaryKey]
        public string? UniqueVideoId { get; set; }
        public string? CaptionData { get; set; }
        public SubtitleType CaptionType { get; set; }
    }
}
