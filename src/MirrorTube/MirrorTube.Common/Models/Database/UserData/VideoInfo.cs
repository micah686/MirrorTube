using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoInfo
    {
        [PrimaryKey]
        public string UniuqeVideoId { get; set; }
        public DateTime MetadataScrapeDate { get; } = DateTime.UtcNow;
        public string? VideoID { get; set; }
        public int? AgeLimit { get; set; }
        public float? AverageRating { get; set; }
        public string? Description { get; set; }
        public long? LikeCount { get; set; }
        public long? DislikeCount { get; set; }
        public float? Duration { get; set; }
        public string? Extension { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ModifiedTimestamp { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? UploadDateTimestamp { get; set; }
        public string? Title { get; set; }
        public bool? WasLive { get; set; }
        public string? WebpageUrl { get; set; }
        public long? ViewCount { get; set; }
        public long? CommentCount { get; set; }
        public string? ChannelID { get; set; }
        public string? ChannelUrl { get; set; }
        public string? ExtractorKey { get; set; }
        public string? License { get; set; }

        public string[]? VideoCast { get; set; }
        public string[]? Categories { get; set; }
        public string[]? Tags { get; set; }
        public Availability? Availability { get; set; }

        [Reference]
        public VideoData VideoData { get; set; }
        public List<VideoChapter> Chapters { get; set; } = new List<VideoChapter>();
        public List<VideoSubtitle> Subtitles { get; set; } = new List<VideoSubtitle>();
        public List<VideoCaption> Captions { get; set; } = new List<VideoCaption>();

    }
}
