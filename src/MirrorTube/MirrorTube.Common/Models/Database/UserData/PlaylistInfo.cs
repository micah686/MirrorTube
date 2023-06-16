namespace MirrorTube.Common.Models.Database.UserData
{
    public class PlaylistInfo
    {
        public int PlaylistId { get; set; }
        public string? PlaylistTitle { get; set; }
        public string? PlaylistUrl { get; set; }
        public int Position { get; set; }
        public int? HistoryId { get; set; }
    }
}
