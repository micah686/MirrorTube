using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    public class UserUploaderCustomGroups
    {
        public string Id { get; set; }
        public int GroupId { get; set; }
        public string UserUploaderId { get; set; }
        public string GroupName { get; set; }
    }
}
