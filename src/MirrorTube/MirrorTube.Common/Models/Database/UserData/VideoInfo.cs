namespace MirrorTube.Common.Models.Database.UserData
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class VideoInfoHistory: VideoInfoBase
    {
        public int Id { get; set; } //PK
        public override DateTimeOffset MetadataScrapeDate { get; init; } = DateTimeOffset.UtcNow;
    }

    public class VideoInfo: VideoInfoBase
    {
        public override DateTimeOffset MetadataScrapeDate { get; init; } = DateTimeOffset.UtcNow;
    }

    public abstract class VideoInfoBase
    {

        public int ContentId { get; set; } //uniqueID: //webpageURL+externalVideoId+title, link to normalized table
        public string? ExternalVideoID { get; set; } //videoID grabbed by external tools, like yt-dlp
        public virtual DateTimeOffset MetadataScrapeDate { get; init; }
        public long? AcroFsIdThumbnail { get; set; } //thumbnail


        public int? AgeLimit { get; set; }
        public float? AverageRating { get; set; }
        public string? Description { get; set; }
        public long? LikeCount { get; set; }
        public long? DislikeCount { get; set; }
        public float? Duration { get; set; }
        public string? Extension { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public DateTimeOffset? ModifiedTimestamp { get; set; }
        public DateTimeOffset? UploadDate { get; set; }
        public DateTimeOffset? UploadDateTimestamp { get; set; }
        public string? Title { get; set; }
        public bool? WasLive { get; set; }
        public string? WebpageUrl { get; set; }
        public long? ViewCount { get; set; }
        public long? CommentCount { get; set; }
        public string? UserChannelID { get; set; }
        public string? ChannelUrl { get; set; }
        public string? ExtractorKey { get; set; }
        public string? License { get; set; }
        public string? Uploader { get; set; }
        public string? Location { get; set; }

        //break these out into own tables?
        public int[]? VideoCast { get; set; } //use normalized tables for lookup
        public int[]? Categories { get; set; }
        public int[]? Tags { get; set; }
        public Availability? Availability { get; set; }

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
