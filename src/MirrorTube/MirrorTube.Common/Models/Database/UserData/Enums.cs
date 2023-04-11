using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public enum Availability
    {
        Private,
        PremiumOnly,
        SubscriberOnly,
        NeedsAuth,
        Unlisted,
        Public
    }
}
