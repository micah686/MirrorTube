using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData.FixLater
{
    [Obsolete]
    public class VideoCommentPicture
    {
        [PrimaryKey]
        public string AuthorID { get; set; }
        public string AuthorThumbnail { get; set; }
    }
}
