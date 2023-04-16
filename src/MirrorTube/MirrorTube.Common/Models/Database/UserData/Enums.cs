namespace MirrorTube.Common.Models.Database.UserData
{
    public enum Availability
    {
        Public,
        Private,
        PremiumOnly,
        SubscriberOnly,
        NeedsAuth,
        Unlisted
    }
    public enum SubtitleType
    {
        Unknown,
        Vtt,
        Ttml,
        Srv3,
        Srv2,
        Srv1,
        Json3
    }
}
