using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OliverBlogLog
{
    public class Core
    {
        public static string GetHostName(string p)
        {
            int slashIndex = p.IndexOf('/', 9);

            // if url does not end with / but a proper web link then return whole link
            if (slashIndex < 0)
            {
                if (p.Contains("http"))
                    return p;
                else
                    return string.Empty;
            }

            return (p.Substring(0, slashIndex));
        }

    }


}
