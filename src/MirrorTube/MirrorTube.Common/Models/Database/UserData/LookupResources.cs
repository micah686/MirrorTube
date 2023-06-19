using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class LookupResourcesHistory: LookupResourcesBase
    {        
        public long? PreviousAcroFsId { get; set; }
        public DateTimeOffset Timestamp { get; init; }
        public long GroupId { get; set; }
    }
    
    public class LookupResources: LookupResourcesBase
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
    }
    
    public abstract class LookupResourcesBase
    {                
        public long AcroFsId { get; set; }
    }
}
