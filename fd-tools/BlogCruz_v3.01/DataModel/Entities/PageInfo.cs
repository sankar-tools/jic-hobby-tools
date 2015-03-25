using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel.Entities
{
    public class PageInfo
    {
        internal int index;
        internal string Url;
        protected internal List<LinkInfo> imageUrl;
        internal long Size;
        internal long BytesDownloaded;
        internal string filename;
        internal string Status;
    }
}
