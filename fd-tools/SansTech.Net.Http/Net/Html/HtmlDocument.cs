using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SansTech.Net.Html
{
    public class HtmlDocument
    {
        string docContent = string.Empty;

        public HtmlDocument()
        { }

        public HtmlDocument(string content)
        {
            docContent = content;

        }

        public string GetTitle()
        {
            Regex titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string title = "unknown";
            Match m = titleCheck.Match(docContent);

            if (m.Success)
            {
                // we found a <title></title> match =]
                title = m.Groups[1].Value.ToString();
            }

            return title;
        }

        public int GetSize()
        {
            return docContent.Length;
        }
    }
}
