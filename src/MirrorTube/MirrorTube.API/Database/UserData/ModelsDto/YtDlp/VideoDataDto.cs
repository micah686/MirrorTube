using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YoutubeDLSharp.Converters;
using YoutubeDLSharp.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{

    public class VideoDataDto
    {
        public DateTime MetadataScrapeDate { get; } = DateTime.UtcNow;
        
        public List<SubtitleDataDto> AutomaticCaptions { get; set; } = new List<SubtitleDataDto>();
        public List<SubtitleDataDto> Subtitles { get; set; } = new List<SubtitleDataDto>();
        public ChapterDataDto[]? Chapters { get; set; }
        public ICollection<CommentDataDto>? Comments { get; set; }



        public string? ExtractorKey { get; set; }
        public int? AgeLimit { get; set; }
        
        public Availability? Availability { get; set; }
        public double? AverageRating { get; set; }
        public string[]? Cast { get; set; }
        public string[]? Categories { get; set; }
        public string[]? Tags { get; set; }
        public string? Channel { get; set; }
        public long? ChannelFollowerCount { get; set; }
        public string? ChannelID { get; set; }
        public string? ChannelUrl { get; set; }
        public string? Chapter { get; set; }
        public int? ChapterNumber { get; set; }
        public string? ChapterId { get; set; }
        
        public long? CommentCount { get; set; }
        
        public string? Description { get; set; }
        public long? DislikeCount { get; set; }
        public float? Duration { get; set; }
        public string? Extension { get; set; }
        public long? LikeCount { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ModifiedTimestamp { get; set; }
        
        
        
        public DateTime? Timestamp { get; set; }
        public string? Title { get; set; }
        
        public DateTime? UploadDate { get; set; }
        public string? Uploader { get; set; }
        public string? UploaderID { get; set; }
        public string? UploaderUrl { get; set; }
        public string? VideoID { get; set; }
        public long? ViewCount { get; set; }
        public bool? WasLive { get; set; }
        public string? WebpageUrl { get; set; }


        public FormatDataDto? FormatInfo { get; set; }
        public SeriesDataDto? SeriesData { get; set; }
        public TrackDataDto? TrackData { get; set; }
    }

    

    public enum Availability
    {        
        Private,
        PremiumOnly,
        SubscriberOnly,
        NeedsAuth,
        Unlisted,
        Public
    }


}
