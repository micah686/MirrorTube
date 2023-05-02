using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoInfoLatest
    {
        [PrimaryKey]
        public string VideoId { get; set; }
        public string UniqueVideoId { get; set; }
    }
}
