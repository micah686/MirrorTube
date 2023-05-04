using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoCaption
    {
        [PrimaryKey]
        [ForeignKey(typeof(VideoInfoLatest))]
        public string? VideoId { get; set; }
        public string? CaptionData { get; set; }
        public SubtitleType CaptionType { get; set; }
        public string CaptionLanguage { get; set; }
    }
}
