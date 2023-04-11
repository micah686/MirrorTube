using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class ChannelData
    {
        public string? ChannelID { get; set; }
        public string? ChannelUrl { get; set; }
        public string? ChannelName { get; set; }
        public long? ChannelFollowerCount { get; set; }
        public string? ChannelDescription { get; set; }
    }
}
