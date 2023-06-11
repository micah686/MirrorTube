using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class NormalizedUniqueVideoId
    {
        [PrimaryKey]
        public int Id { get; set; }
        public HexId VideoId { get; set; }
    }
}
