namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoSeries
    {
        public int VideoId { get; set; } //link to normalized table

        public string? Series { get; set; }

        public string? SeriesId { get; set; }

        public string? Season { get; set; }

        public int? SeasonNumber { get; set; }

        public string? SeasonId { get; set; }

        public string? Episode { get; set; }

        public int? EpisodeNumber { get; set; }

        public string? EpisodeId { get; set; }
    }
}
