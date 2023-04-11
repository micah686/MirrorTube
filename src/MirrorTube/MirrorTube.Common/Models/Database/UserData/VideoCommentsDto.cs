using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoCommentsDto
    {
        public string VideoId { get; set; }
        public string Author { get; set; }
        public string AuthorID { get; set; }

        public string HtmlComment { get; set; }

        public string TextComment { get; set; }

        public DateTime CommentTimestamp { get; set; }
        public string ParentComment { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public bool? IsFavorited { get; set; }
        public bool? AuthorIsUploader { get; set; }
    }
}
