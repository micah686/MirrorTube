namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoTrack
    {
        public int ContentId { get; set; } //link to normalized table

        public string? Track { get; set; }

        public int? TrackNumber { get; set; }

        public string? TrackId { get; set; }

        public int ArtistId { get; set; }

        public int GenreId { get; set; }

        public string? Album { get; set; }

        public string? AlbumType { get; set; }

        public int AlbumArtistId { get; set; }

        public int? DiscNumber { get; set; }

        public string? ReleaseYear { get; set; }

        public int ComposerId { get; set; }
    }
}
