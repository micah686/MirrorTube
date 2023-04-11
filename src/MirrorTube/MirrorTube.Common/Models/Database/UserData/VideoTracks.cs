using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoTracks
    {
        [Key]
        public string? VideoID { get; set; }

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
