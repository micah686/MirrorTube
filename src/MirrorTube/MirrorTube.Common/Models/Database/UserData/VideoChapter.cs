﻿namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoChapter
    {
        public int ContentId { get; set; } //link to normalized table
        public float? StartTime { get; set; }
        public float? EndTime { get; set; }
        public string? Title { get; set; }
    }
}
