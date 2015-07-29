using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansTech.Generic
{
    public class UrlHelper
    {
        public static string GetFilename(string url)
        {
            string filename = null;
            Uri uri = new Uri(url);
            if (uri.IsFile)
            {
                filename = System.IO.Path.GetFileName(uri.LocalPath);
            }
            return filename;
        }
    }
}
