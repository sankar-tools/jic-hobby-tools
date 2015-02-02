using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

namespace FireDragan
{
    public enum LinkType
    { 
        None,
        Unknown,
        WebPage,
        Image,
        Stylesheet,
        Javascript
    }

    public class LinkParser
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinkParser() { }

        #endregion
        #region Constants

        private const string _HREF_REGEX = "href=\"[a-zA-Z./:&\\d_-]+\"";
        private const string _IMG_REGEX = "src=\"[a-zA-Z./:&\\d_-]+\"";

        #endregion
        #region Private Instance Fields

        private List<string> _goodUrls = new List<string>();
        private List<string> _badUrls = new List<string>();
        private List<string> _otherUrls = new List<string>();
        private List<string> _externalUrls = new List<string>();
        private List<string> _exceptions = new List<string>();

        #endregion
        #region Public Properties

        public List<string> GoodUrls
        {
            get { return _goodUrls; }
            set { _goodUrls = value; }
        }

        public List<string> BadUrls
        {
            get { return _badUrls; }
            set { _badUrls = value; }
        }

        public List<string> OtherUrls
        {
            get { return _otherUrls; }
            set { _otherUrls = value; }
        }

        public List<string> ExternalUrls
        {
            get { return _externalUrls; }
            set { _externalUrls = value; }
        }

        public List<string> Exceptions
        {
            get { return _exceptions; }
            set { _exceptions = value; }
        }

        #endregion

        /// <summary>
        /// Parses a page looking for links.
        /// </summary>
        /// <param name="page">The page whose text is to be parsed.</param>
        /// <param name="sourceUrl">The source url of the page.</param>
        public void ParseHrefLinks(string pageText, string sourceUrl)
        {
            GoodUrls.Clear();

            MatchCollection matches = Regex.Matches(pageText, _HREF_REGEX);

            for (int i = 0; i <= matches.Count - 1; i++)
            {
                Match anchorMatch = matches[i];

                if (anchorMatch.Value == String.Empty)
                {
                    BadUrls.Add("Blank url value on page " + sourceUrl);
                    continue;
                }

                string foundHref = null;
                try
                {
                    foundHref = anchorMatch.Value.Replace("href=\"", "");
                    //foundHref = anchorMatch.Value.Replace("src=\"", "");
                    foundHref = foundHref.Substring(0, foundHref.IndexOf("\""));
                }
                catch (Exception exc)
                {
                    Exceptions.Add("Error parsing matched href: " + exc.Message);
                }

                foundHref = FixPath(sourceUrl, foundHref);
                if (!GoodUrls.Contains(foundHref))
                {
                    //if (IsExternalUrl(foundHref))
                    //{
                    //    _externalUrls.Add(foundHref);
                    //}
                    //else if (!IsAWebPage(foundHref))
                    //{
                    //    foundHref = FixPath(sourceUrl, foundHref);
                    //    _otherUrls.Add(foundHref);
                    //}
                    //else
                    {
                        GoodUrls.Add(foundHref);
                    }
                }
            }
        }

        //public void ParseHrefLinks(string pageText, string sourceUrl)
        //{
        //    ParseLinks(pageText, sourceUrl, _HREF_REGEX);
        //}

        public void ParseImgLinks(string pageText, string sourceUrl)
        {
            GoodUrls.Clear();

            MatchCollection matches = Regex.Matches(pageText, _IMG_REGEX);

            for (int i = 0; i <= matches.Count - 1; i++)
            {
                Match anchorMatch = matches[i];

                if (anchorMatch.Value == String.Empty)
                {
                    BadUrls.Add("Blank url value on page " + sourceUrl);
                    continue;
                }

                string foundHref = null;
                try
                {
                    foundHref = anchorMatch.Value.Replace("src=\"", "");
                    foundHref = foundHref.Substring(0, foundHref.IndexOf("\""));
                }
                catch (Exception exc)
                {
                    Exceptions.Add("Error parsing matched href: " + exc.Message);
                }

                foundHref = FixPath(sourceUrl, foundHref);
                if (!GoodUrls.Contains(foundHref))
                {
                    GoodUrls.Add(foundHref);
                }
            }

        }
        /// <summary>
        /// Fixes a path. Makes sure it is a fully functional absolute url.
        /// </summary>
        /// <param name="originatingUrl">The url that the link was found in.</param>
        /// <param name="link">The link to be fixed up.</param>
        /// <returns>A fixed url that is fit to be fetched.</returns>
        public string FixPath(string originatingUrl, string link)
        {
            //Identify the base path of the originating url 
            //   eg: http://www.csharp-station.com/HowTo/HttpWebFetch.aspx will return
            //       http://www.csharp-station.com/HowTo/
            string basePath = originatingUrl.Substring(0, originatingUrl.LastIndexOf("/"));

            string formattedLink = String.Empty;

            // Check if the url is already an absolute url
            if (link.Trim().StartsWith("http") || link.Trim().StartsWith("www"))
            {
                formattedLink = link;
            }

            // Check if the url is relative to base parent directory 
            //   eg: http://www.csharp-station.com/ for http://www.csharp-station.com/HowTo/HttpWebFetch.aspx
            else if (link.IndexOf("../") > -1)
            {
                formattedLink = ResolveRelativePaths(link, originatingUrl);
            }
            else if (originatingUrl.IndexOf(basePath) > -1
                && link.IndexOf(basePath) == -1)
            {
                formattedLink = originatingUrl.Substring(0, originatingUrl.LastIndexOf("/") + 1) + link;
            }
            else if (link.IndexOf(basePath) == -1)
            {
                formattedLink = basePath + link;
            }

            return formattedLink;
        }

        /// <summary>
        /// Needed a method to turn a relative path into an absolute path. And this seems to work.
        /// </summary>
        /// <param name="relativeUrl">The relative url.</param>
        /// <param name="baseUrl">The url that contained the relative url.</param>
        /// <returns>A url that was relative but is now absolute.</returns>
        private string ResolveRelativePaths(string relativeUrl, string baseUrl)
        {
            string resolvedUrl = String.Empty;

            string[] relativeUrlArray = relativeUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] originatingUrlElements = baseUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int indexOfFirstNonRelativePathElement = 0;
            for (int i = 0; i <= relativeUrlArray.Length - 1; i++)
            {
                if (relativeUrlArray[i] != "..")
                {
                    indexOfFirstNonRelativePathElement = i;
                    break;
                }
            }

            int countOfOriginatingUrlElementsToUse = originatingUrlElements.Length - indexOfFirstNonRelativePathElement - 1;
            for (int i = 0; i <= countOfOriginatingUrlElementsToUse - 1; i++)
            {
                if (originatingUrlElements[i] == "http:" || originatingUrlElements[i] == "https:")
                    resolvedUrl += originatingUrlElements[i] + "//";
                else
                    resolvedUrl += originatingUrlElements[i] + "/";
            }

            for (int i = 0; i <= relativeUrlArray.Length - 1; i++)
            {
                if (i >= indexOfFirstNonRelativePathElement)
                {
                    resolvedUrl += relativeUrlArray[i];

                    if (i < relativeUrlArray.Length - 1)
                        resolvedUrl += "/";
                }
            }

            return resolvedUrl;
        }

        /// <summary>
        /// Is the url to an external site?
        /// </summary>
        /// <param name="url">The url whose externality of destination is in question.</param>
        /// <returns>Boolean indicating whether or not the url is to an external destination.</returns>
        public static bool IsExternalUrl(string url)
        {
            //if (url.IndexOf(ConfigurationManager.AppSettings["authority"]//is about the domain) > -1)
            //{
            //    return false;
            //}
            if (url.Substring(0, 7) == "http://" || url.Substring(0, 3) == "www" || url.Substring(0, 7) == "https://")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Is the value of the href pointing to a web page?
        /// </summary>
        /// <param name="foundHref">The value of the href that needs to be interogated.</param>
        /// <returns>Boolen </returns>
        public static bool IsAWebPage(string foundHref)
        {
            if (foundHref.IndexOf("javascript:") == 0)
                return false;

            string extension = GetUrlExtension(foundHref);
            switch (extension)
            {
                case "jpg":
                case "css":
                    return false;
                default:
                    return true;
            }

        }

        // Get the extension for the url
        public static string GetUrlExtension(string foundHref)
        {
            string extension = foundHref.Substring(foundHref.LastIndexOf(".") + 1, foundHref.Length - foundHref.LastIndexOf(".") - 1);
            return extension;
        }

        // Find the type of url
        public static LinkType GetLinkType(string url)
        {
            LinkType retType = LinkType.None;

            string extension = GetUrlExtension(url);

            string imageExtensions = SettingsHelper.Current.ImageExpression;
            string pageExtensions = SettingsHelper.Current.PageExpression;
            string styleExtensions = SettingsHelper.Current.StyleExpression;
            string javascriptExtensions = SettingsHelper.Current.JavascriptExpression;

            if (!(imageExtensions.IndexOf(extension) < 0))
                retType = LinkType.Image;
            else if (!(pageExtensions.IndexOf(extension) < 0))
                retType = LinkType.WebPage;
            else if (!(styleExtensions.IndexOf(extension) < 0))
                retType = LinkType.Stylesheet;
            else if (!(javascriptExtensions.IndexOf(extension) < 0))
                retType = LinkType.Javascript;
            else
                retType = LinkType.Unknown;

            return retType;
        }

        //Check if urls belong to same domain
        public static bool IsSameDomain(Uri url1, Uri url2)
        {
            return (url1.Host == url2.Host);
        }
    }
}