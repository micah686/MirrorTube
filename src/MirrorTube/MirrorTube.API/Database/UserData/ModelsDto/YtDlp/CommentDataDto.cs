namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class CommentDataDto
    {
        public string ID { get; set; }
        public string Author { get; set; }
        public string AuthorID { get; set; }

        public string AuthorThumbnailBase64 { get; set; }

        public string HtmlComment { get; set; }

        public string TextComment { get; set; }

        public DateTime Timestamp { get; set; }
        public string ParentComment { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public bool? IsFavorited { get; set; }
        public bool? AuthorIsUploader { get; set; }
    }
}
