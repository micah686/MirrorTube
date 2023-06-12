namespace MirrorTube.Common.Models.Database.UserData
{
    public class LookupVideoEntry
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        [Obsolete("FIX THIS LATER WITH CORRECT ATTRIBUTE")]
        public DateTimeOffset MetadataDate { get; set; }
        public HexId UniqueVideoId { get; set; }
    }
}
