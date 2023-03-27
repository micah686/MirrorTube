using System.ComponentModel.DataAnnotations;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class SeriesDataDto
    {
        [Key]
        public string? PK_VideoID { get; set; }
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
