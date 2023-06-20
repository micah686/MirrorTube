using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class UserUploaderInfo
    {
        public string UserUploaderId { get; set; } //combine
        public string Uploader { get; set; }
        public string UploaderId { get; set; }
        public string UploaderUrl { get; set; }
        public string? ChannelID { get; set; } //unique, never changes
        public string? ChannelUrl { get; set; }


        public string? ChannelName { get; set; }
        public long? ChannelFollowerCount { get; set; }
        public string? ChannelDescription { get; set; }

    }
}
