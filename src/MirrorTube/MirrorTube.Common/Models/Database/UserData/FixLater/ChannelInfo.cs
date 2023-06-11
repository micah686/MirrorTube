using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData.FixLater
{
    [Obsolete]
    public class ChannelInfo
    {
        [PrimaryKey]
        public string? ChannelID { get; set; }
        public string? ChannelUrl { get; set; }
        public string? ChannelName { get; set; }
        public long? ChannelFollowerCount { get; set; }
        public string? ChannelDescription { get; set; }
        [Reference]
        public ChannelPicture ChannelPicture { get; set; }
    }
}
