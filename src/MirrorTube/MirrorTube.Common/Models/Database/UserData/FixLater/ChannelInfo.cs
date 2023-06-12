namespace MirrorTube.Common.Models.Database.UserData.FixLater
{
    public class ChannelInfo
    {
        public string? ChannelID { get; set; }
        public string? ChannelUrl { get; set; }
        public string? ChannelName { get; set; }
        public long? ChannelFollowerCount { get; set; }
        public string? ChannelDescription { get; set; }
        public ChannelPicture ChannelPicture { get; set; }
    }
}
