﻿using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoLookup
    {
        [PrimaryKey]
        public string UniqueVideoId { get; set; }
        public string VideoId { get; set; }
        public DateTime MetadataScrapeDate { get; set; }
    }
}
