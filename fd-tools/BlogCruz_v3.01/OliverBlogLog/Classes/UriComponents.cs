using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OliverBlogLog
{
    public class UriParsing
    {
        Uri uri = null;

        public string HostName;
        public string PrimaryDomain;
        public string SubDomain;
        public string InternetDomain;
        public string[] QueryComponents;
        public string QueryString;
        public string Protocol;


        public UriParsing(string url)
        {
            uri = new Uri(url);
        }

        public UriParsing(Uri uri)
        {
            this.uri = uri;
        }

        public void Parse()
        {
            String[] Parts = uri.Segments;
            HostName = uri.Host;
            QueryString = uri.Query;
            Protocol = uri.Scheme;
            UriHostNameType type = uri.HostNameType;

            SubDomain = string.Empty;
            PrimaryDomain = HostName;

            if (uri.HostNameType == UriHostNameType.Dns && (!(uri.HostNameType == UriHostNameType.Unknown)))
            {
                //string host = thisUrl.Host;
                string[] hostComponents = HostName.Split('.');

                int marker = -1;
                // host name of type .in, .us, .uk... then skip two words else one word
                if (hostComponents[hostComponents.Length - 1].Length == 2)
                    marker = hostComponents.Length - 3;
                else
                    marker = hostComponents.Length - 2;

                int last = HostName.LastIndexOf(hostComponents[marker]);
                if (last > 0)
                {
                    int idx = HostName.LastIndexOf(".", last - 1);
                    SubDomain = HostName.Substring(0, idx);
                    PrimaryDomain = HostName.Replace(SubDomain + ".", string.Empty);
                }
                else
                {
                    SubDomain = string.Empty;
                    PrimaryDomain = HostName;
                }
            }



            Regex queryStringSplitter = new Regex("!|@|://|/|&");
            QueryComponents = queryStringSplitter.Split(QueryString.Replace("?", string.Empty));

        }

        public static UriParsing Parse(string url)
        {
            try
            {
                UriParsing components = new UriParsing(url);

                components.Parse();

                return components;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
