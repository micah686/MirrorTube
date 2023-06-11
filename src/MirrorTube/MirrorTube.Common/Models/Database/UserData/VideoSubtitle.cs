﻿using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoSubtitle
    {
        [PrimaryKey]
        public string? VideoId { get; set; }
        public string? SubtitleData { get; set; }
        public SubtitleType SubtitleType { get; set; }
        public string SubtitleLanguage { get; set; }
    }
}
