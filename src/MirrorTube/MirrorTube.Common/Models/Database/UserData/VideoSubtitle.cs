namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoSubtitle
    {
        public int ContentId { get; set; } //link to normalized table
        public string? SubtitleData { get; set; }
        public SubtitleType SubtitleType { get; set; }
        public string SubtitleLanguage { get; set; }
    }
}
