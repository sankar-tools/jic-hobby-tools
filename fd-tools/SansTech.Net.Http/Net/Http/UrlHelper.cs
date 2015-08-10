using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansTech.Net.Http
{
    public class UrlHelper
    {
        public static string GetFilename(string url)
        {
            string filename = null;
            Uri uri = new Uri(url);
            //if (uri.IsFile)
            {
                filename = System.IO.Path.GetFileName(uri.LocalPath);
            }
            return filename;
        }

        public static string MassageUrl(string url)
        {
            //string filename = null;
            url = url.Replace("://", ":///");
            url = url.Replace("//", "/");
            Uri uri = new Uri(url);
            //if (uri.IsFile)

            return uri.AbsoluteUri;
        }

        public static string GetDomain(string url)
        {
            Uri myUri = new Uri(url);
            string host = myUri.Host;
            return host;
        }
    }
}
