using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorTube.Common.Models.Database.UserData
{
    internal class CommentAuthorProfilePics
    {
        public string AuthorID { get; set; }
        public byte[] AuthorThumbnail { get; set; }
    }
}
