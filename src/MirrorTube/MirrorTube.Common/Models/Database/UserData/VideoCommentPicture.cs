using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class VideoCommentPicture
    {
        [PrimaryKey]
        public string AuthorID { get; set; }
        public string AuthorThumbnail { get; set; }
    }
}
