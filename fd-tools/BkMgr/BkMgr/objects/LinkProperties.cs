using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fd.tools.bookmarks.objects
{
    public class LinkProperties
    {
        public string Url {get; set;}
        public string Category {get; set;}
        public string Rating { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastVisited { get; set; }
        public string Desc { get; set; }
        public string Remarks { get; set; }
        public string UrlType { get; set; }
        public string Queued { get; set; }
    }
}
