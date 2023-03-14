using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YoutubeDLSharp.Converters;
using YoutubeDLSharp.Metadata;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class VideoDataDto
    {
        [Key]
        public string PK_ID { get; set; }
        
        public MetadataType ResultType { get; set; }

        public string Extractor { get; set; }

        public string ExtractorKey { get; set; }

        //public VideoData[] Entries { get; set; }

        public string ID { get; set; }

        public string Title { get; set; }

        public ICollection<FormatDataDto> Formats { get; set; }

        public string Url { get; set; }

        public string Extension { get; set; }

        public string Format { get; set; }

        public string FormatID { get; set; }

        public string PlayerUrl { get; set; }

        public bool Direct { get; set; }

        public string AltTitle { get; set; }

        public string DisplayID { get; set; }

        public ICollection<ThumbnailData> Thumbnails { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }

        public string Uploader { get; set; }

        public string License { get; set; }

        public string Creator { get; set; }

        public DateTime? ReleaseTimestamp { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? Timestamp { get; set; }

        public DateTime? UploadDate { get; set; }

        public DateTime? ModifiedTimestamp { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string UploaderID { get; set; }

        public string UploaderUrl { get; set; }

        public string Channel { get; set; }

        public string ChannelID { get; set; }

        public string ChannelUrl { get; set; }

        public long? ChannelFollowerCount { get; set; }

        public string Location { get; set; }

        [ForeignKey("subtitles")]
        public ICollection<SubtitleDataDto> Subtitles { get; set; } //modified from dictionary

        [ForeignKey("automatic_captions")]
        public ICollection<SubtitleDataDto> AutomaticCaptions { get; set; } //modified from dictionary

        public float? Duration { get; set; }

        public long? ViewCount { get; set; }

        public long? ConcurrentViewCount { get; set; }

        public long? LikeCount { get; set; }

        public long? DislikeCount { get; set; }

        public long? RepostCount { get; set; }

        public double? AverageRating { get; set; }

        public long? CommentCount { get; set; }

        public ICollection<CommentData> Comments { get; set; }

        public int? AgeLimit { get; set; }

        public string WebpageUrl { get; set; }

        public string[] Categories { get; set; }

        public string[] Tags { get; set; }

        public string[] Cast { get; set; }

        public bool? IsLive { get; set; }

        public bool? WasLive { get; set; }

        public LiveStatus LiveStatus { get; set; }

        public float? StartTime { get; set; }

        public float? EndTime { get; set; }

        public string PlayableInEmbed { get; set; }

        public Availability? Availability { get; set; }

        public ChapterData[] Chapters { get; set; }

        public string Chapter { get; set; }

        public int? ChapterNumber { get; set; }

        public string ChapterId { get; set; }

        public string Series { get; set; }

        public string SeriesId { get; set; }

        public string Season { get; set; }

        public int? SeasonNumber { get; set; }

        public string SeasonId { get; set; }

        public string Episode { get; set; }

        public int? EpisodeNumber { get; set; }

        public string EpisodeId { get; set; }

        public string Track { get; set; }

        public int? TrackNumber { get; set; }

        public string TrackId { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }

        public string Album { get; set; }

        public string AlbumType { get; set; }

        public string AlbumArtist { get; set; }

        public int? DiscNumber { get; set; }

        public string ReleaseYear { get; set; }

        public string Composer { get; set; }

        public long? SectionStart { get; set; }

        public long? SectionEnd { get; set; }

        public long? StoryboardFragmentRows { get; set; }

        public long? StoryboardFragmentColumns { get; set; }
    }
}
