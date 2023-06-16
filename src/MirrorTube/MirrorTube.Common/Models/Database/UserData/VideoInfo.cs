namespace MirrorTube.Common.Models.Database.UserData
{
    
    public class VideoInfoHistory: VideoInfoBase
    {
        public int HistoryId { get; set; }
    }

    public class VideoInfo: VideoInfoBase
    {

    }

    public abstract class VideoInfoBase
    {
        public string VideoId { get; set; } //uniqueID: //webpageURL+externalVideoId+title
        public string? ExternalVideoID { get; set; } //videoID grabbed by external tools, like yt-dlp
        public DateTimeOffset MetadataScrapeDate { get; } = DateTimeOffset.UtcNow;
        public long ThumbnailPathId { get; set; }


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
        public string Uploader { get; set; }
        public string Location { get; set; }

        //break these out into own tables?
        public int[]? VideoCast { get; set; } //use normalized tables for lookup
        public int[]? Categories { get; set; }
        public int[]? Tags { get; set; }
        public Availability? Availability { get; set; }

    }
}
