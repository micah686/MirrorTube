using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YoutubeDLSharp.Converters;
using YoutubeDLSharp.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AutoMapper.Configuration.Annotations;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class VideoDataDto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public string PK_ID { get; set; }


        public string? Extractor { get; set; }

        public string? ExtractorKey { get; set; }

        public string? VideoID { get; set; }

        public string? Title { get; set; }

        public virtual List<FormatDataDto> Formats { get; set; } = new List<FormatDataDto>();

        public string? Url { get; set; }

        public string? Extension { get; set; }        

        public string? FormatID { get; set; }



        public string? AltTitle { get; set; }

        public string? DisplayID { get; set; }

        public string? Description { get; set; }

        public string? Uploader { get; set; }

        public string? License { get; set; }

        public string? Creator { get; set; }

        public DateTime? Timestamp { get; set; }

        public DateTime? UploadDate { get; set; }

        public DateTime? ModifiedTimestamp { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? UploaderID { get; set; }

        public string? UploaderUrl { get; set; }

        public string? Channel { get; set; }

        public string? ChannelID { get; set; }

        public string? ChannelUrl { get; set; }

        public long? ChannelFollowerCount { get; set; }

        public string? Location { get; set; }

        [ForeignKey("subtitles")]
        public List<SubtitleDataDto> Subtitles { get; set; } = new List<SubtitleDataDto>(); 

        [ForeignKey("automatic_captions")]
        public List<SubtitleDataDto> AutomaticCaptions { get; set; } = new List<SubtitleDataDto>(); 
        public float? Duration { get; set; }

        public long? ViewCount { get; set; }

        public long? ConcurrentViewCount { get; set; }

        public long? LikeCount { get; set; }

        public long? DislikeCount { get; set; }

        public long? RepostCount { get; set; }

        public double? AverageRating { get; set; }

        public long? CommentCount { get; set; }

        public ICollection<CommentData>? Comments { get; set; }

        public int? AgeLimit { get; set; }

        public string? WebpageUrl { get; set; }

        public string[]? Categories { get; set; }

        public string[]? Tags { get; set; }

        public string[]? Cast { get; set; }

        public bool? WasLive { get; set; }

        public float? StartTime { get; set; }

        public float? EndTime { get; set; }


        public Availability? Availability { get; set; }

        public ChapterData[]? Chapters { get; set; }

        public string? Chapter { get; set; }

        public int? ChapterNumber { get; set; }

        public string? ChapterId { get; set; }

        public SeriesDataDto? SeriesData { get; set; }

        public TrackDataDto? TrackData { get; set; }




        

        public long? SectionStart { get; set; }

        public long? SectionEnd { get; set; }

        public long? StoryboardFragmentRows { get; set; }

        public long? StoryboardFragmentColumns { get; set; }
    }
}
