﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class VideoInfoHistory
    {
        [PrimaryKey]
        public HexId UniqueVideoId { get; set; }
        public string VideoId { get; set; }
        public DateTime MetadataDate { get; set; }
    }
}