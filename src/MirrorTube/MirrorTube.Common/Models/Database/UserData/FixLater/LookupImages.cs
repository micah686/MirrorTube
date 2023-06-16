using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData.FixLater
{
    
    public class LookupImagesHistory: LookupImagesBase
    {
        public long PreviousImageIndex { get; set; }
        public DateTimeOffset UpdatedDate { get; } = DateTimeOffset.UtcNow;
    }
    
    public class LookupImages: LookupImagesBase
    {  //empty so it inherits from abstract class     
    }

    public abstract class LookupImagesBase
    {
        public long ImageIndex { get; set; }
    }
}
