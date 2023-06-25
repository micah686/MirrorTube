using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class UserUploaderInfo
    {        
        public string Id { get; set; } //composite of AccountId and Domain
        public string AccountId { get; set; } //unique, never changes //eg: UCXuqSBlHAE6Xw-yeJA0Tunw
        public string AccountName { get; set; } //Friendly name (eg: Linux Tech Tips)
        public string? AccountHandle { get; set; } //compact name handle (eg: @linustechtips)
        public string? AccountUrl { get; set; } // (eg: https://www.youtube.com/channel/UCXuqSBlHAE6Xw-yeJA0Tunw)
                                               //use the most unique one possible, eg channelId over handle
        public string Domain { get; set; } //use domain of site, like "youtube", "twitch"


        public long? AccountFollowerCount { get; set; }
        public string? AccountDescription { get; set; }
        public long? AcroFsIdAvatarLogo { get; set; }
        public long? AcroFsIdBanner { get; set; }

    }
}
