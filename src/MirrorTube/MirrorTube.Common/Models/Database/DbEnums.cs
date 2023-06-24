using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database
{
    public enum Availability
    {
        Public,
        Private,
        PremiumOnly,
        SubscriberOnly,
        NeedsAuth,
        Unlisted
    }
    public enum SubtitleType
    {
        Unknown,
        Vtt,
        Ttml,
        Srv3,
        Srv2,
        Srv1,
        Json3
    }
}
