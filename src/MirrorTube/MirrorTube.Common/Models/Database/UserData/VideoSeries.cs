namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoSeries
    {
        public int ContentId { get; set; } //link to normalized table

        public int SeriesId { get; set; }

        public int SeasonId { get; set; }

        public int? SeasonNumber { get; set; }

        public string? Episode { get; set; }

        public int? EpisodeNumber { get; set; }
    }
}
