using System.ComponentModel.DataAnnotations;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class TrackDataDto
    {
        [Key]
        public string? PK_VideoID { get; set; }
        
        public string? Track { get; set; }

        public int? TrackNumber { get; set; }

        public string? TrackId { get; set; }

        public string? Artist { get; set; }

        public string? Genre { get; set; }

        public string? Album { get; set; }

        public string? AlbumType { get; set; }

        public string? AlbumArtist { get; set; }

        public int? DiscNumber { get; set; }

        public string? ReleaseYear { get; set; }

        public string? Composer { get; set; }
    }
}
