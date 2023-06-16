namespace MirrorTube.Common.Models.Database.UserData
{
    public class LookupPlaylistTracks
    {
        public int PlaylistId { get; set; }
        public HexId UniqueVideoId { get; set; }
    }
}
