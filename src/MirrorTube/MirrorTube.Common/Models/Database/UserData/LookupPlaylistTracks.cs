using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class LookupPlaylistTracks
    {
        public int PlaylistId { get; set; }
        public HexId UniqueVideoId { get; set; }
        public int Position { get; set; }
    }
}
