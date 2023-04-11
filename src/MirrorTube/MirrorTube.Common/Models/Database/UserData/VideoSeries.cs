using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoSeries
    {
        public string? VideoId { get; set; }

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
