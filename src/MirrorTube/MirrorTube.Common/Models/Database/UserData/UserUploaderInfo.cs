using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class UserUploaderInfo
    {
        public string? UserChannelID { get; set; } //unique, never changes //eg: UCXuqSBlHAE6Xw-yeJA0Tunw

        public string Uploader { get; set; } //Friendly name (eg: Linux Tech Tips)
        public string UploaderId { get; set; } //compact name handle (eg: @linustechtips)
        public string UploaderUrl { get; set; } // (eg: http://www.youtube.com/@linustechtips)
        public string? ChannelUrl { get; set; } // (eg: https://www.youtube.com/channel/UCXuqSBlHAE6Xw-yeJA0Tunw)


        public string? ChannelName { get; set; }
        public long? ChannelFollowerCount { get; set; }
        public string? ChannelDescription { get; set; }
        public long? AcroFsIdAvatarLogo { get; set; }
        public long? AcroFsIdBanner { get; set; }

    }
}
