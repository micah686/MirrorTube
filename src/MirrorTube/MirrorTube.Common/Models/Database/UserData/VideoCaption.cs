﻿namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoCaption
    {
        public int ContentId { get; set; } //link to normalized table
        public string? CaptionData { get; set; }
        public SubtitleType CaptionType { get; set; }
        public int LanguageId { get; set; }
    }
}
