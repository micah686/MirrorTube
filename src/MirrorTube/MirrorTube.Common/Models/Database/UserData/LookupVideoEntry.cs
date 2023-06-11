using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    [CompositeIndex(nameof(VideoId), nameof(UniqueVideoId), Unique = true)]
    public class LookupVideoEntry
    {
        [AutoIncrement]
        public int Id { get; set; }
        public int VideoId { get; set; }
        [Obsolete("FIX THIS LATER WITH CORRECT ATTRIBUTE")]
        public DateTimeOffset MetadataDate { get; set; }
        public HexId UniqueVideoId { get; set; }
    }
}
