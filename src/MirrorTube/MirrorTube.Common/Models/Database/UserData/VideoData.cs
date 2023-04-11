﻿namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoData
    {
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

        public string[]? VideoCast { get; set; }
        public string[]? Categories { get; set; }
        public string[]? Tags { get; set; }
        public Availability? Availability { get; set; }

    }
}