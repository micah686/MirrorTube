using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class ChannelPicture
    {
        [PrimaryKey]
        public string ChannelId { get; set; }
        public string? AvatarLogo { get; set; }
        public string? Banner { get; set; }
    }
}
