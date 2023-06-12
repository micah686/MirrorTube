namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoSubtitle
    {
        public string? VideoId { get; set; }
        public string? SubtitleData { get; set; }
        public SubtitleType SubtitleType { get; set; }
        public string SubtitleLanguage { get; set; }
    }
}
