using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoChaptersDto
    {
        public class ChapterDataDto
        {
            public string? UniqueVideoId { get; set; }
            public float? StartTime { get; set; }
            public float? EndTime { get; set; }
            public string? Title { get; set; }
        }
    }
}
