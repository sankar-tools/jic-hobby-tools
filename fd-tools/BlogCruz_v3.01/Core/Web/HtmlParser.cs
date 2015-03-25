using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Core.Web
{
    public class HtmlParser
    {
        string htmlFilePath;
        string htmlText;
        string pageUrl;

        public HtmlParser(string filePath, string url)
        {
            htmlFilePath = filePath;
            pageUrl = url;

            StreamReader streamReader = new StreamReader(filePath);
            htmlText = streamReader.ReadToEnd();
            streamReader.Close();
        }
        
        public List<string> GetAllUrl(ImageUrlType type, List<string> filterSites)
        {
            List<string> linksFound = new List<string>();

            LinkParser parser = new LinkParser();

            if((type & ImageUrlType.href) > 0 )
                parser.ParseHrefLinks(htmlText, pageUrl);

            if ((type & ImageUrlType.ImageSrc) > 0)
                parser.ParseImgLinks(htmlText, pageUrl);

            return parser.GoodUrls;
        }
    }

    public enum ImageUrlType
    {
        none = 0x0,
        ImageSrc = 0x1,
        href = 0x2
    }
}
