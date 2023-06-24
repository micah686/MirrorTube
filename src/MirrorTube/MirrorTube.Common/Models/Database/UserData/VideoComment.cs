namespace MirrorTube.Common.Models.Database.UserData
{
    [Obsolete]
    public class VideoComment
    {
        public string CommentId { get; set; }
        public int ContentId { get; set; } //link to normalized table
        public string UserDisplayName { get; set; } //Author, (eg: @linustechtips)
        public string? UserChannelID { get; set; } //AuthorId (eg: UCXuqSBlHAE6Xw-yeJA0Tunw)
        public long AcroFsIdAvatar { get; set; } //foreign key to resources

        public string HtmlComment { get; set; }

        public string TextComment { get; set; }

        public DateTimeOffset CommentTimestamp { get; set; }
        public string ParentComment { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public bool? IsFavorited { get; set; }
        public bool? AuthorIsUploader { get; set; }
    }
}
