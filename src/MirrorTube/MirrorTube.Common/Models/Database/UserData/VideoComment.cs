using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoComment
    {
        [PrimaryKey]
        public string CommentId { get; set; }
        public string VideoId { get; set; }
        public string Author { get; set; }
        public string AuthorID { get; set; }
        public VideoCommentPicture? AuthorPicturePath { get; set; }

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
