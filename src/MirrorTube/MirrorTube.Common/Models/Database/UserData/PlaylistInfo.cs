using ServiceStack.DataAnnotations;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class PlaylistInfo
    {
        [PrimaryKey]
        public int PlaylistId { get; set; }
        public string? PlaylistTitle { get; set; }
        public string? PlaylistUrl { get; set; }
    }
}
