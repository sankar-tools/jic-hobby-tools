using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OliverBlogCruz
{
    public class LinkFilter
    {
        #region Singleton
        private static LinkFilter instance;

        private LinkFilter() { }

        public static LinkFilter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LinkFilter();
                }
                return instance;
            }
        }
        #endregion singleton

        public string SiteFilter = string.Empty;
        public bool ApplyFilter = false;

        public bool IsValid(LinkProperties link )
        {
            if (!ApplyFilter) return true;  

            //SiteFilter += ",";
            string[] allowedDomains = SiteFilter.Split(new char[]{';',','});

            foreach(string domain in allowedDomains)
            {
                if (!string.IsNullOrEmpty(domain))
                {
                    if (link.Url.Contains(domain))
                        return true;
                }
            }

            return false;
        }
    }
}
