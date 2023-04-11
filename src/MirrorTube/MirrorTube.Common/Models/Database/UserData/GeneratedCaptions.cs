using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class GeneratedCaptions
    {
        public string? UniqueVideoId { get; set; }
        public string? SubtitleData { get; set; }
        public SubtitleType SubtitleType { get; set; }
    }
    public enum SubtitleType
    {
        Unknown,
        Vtt,
        Ttml,
        Srv3,
        Srv2,
        Srv1,
        Json3
    }
}
