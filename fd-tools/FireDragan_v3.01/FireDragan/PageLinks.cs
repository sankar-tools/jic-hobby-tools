using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FireDragan
{
    public class PageLink
    {
        private string link = "";
        private string status;
        private string browseLink;

        public PageLink(string link, string status)
        {
            this.link = link;
            this.status = status;
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string BrowseLink
        {
            get { return browseLink; }
            set { browseLink = value; }
        }
    }

    public class PageLinkManager
    {
        public enum UsageModes
        {
            Title = 0,
            Link = 1
        };

        public enum LinkTypes
        {
            Normal = 0,
            EncodedUrl = 1,
            AppendedUrl = 2,
            EncryptedUrl = 3
        }

        private UsageModes usageMode = UsageModes.Link;
        private LinkTypes linkType = LinkTypes.Normal;
        private bool isGarbage = true;

        public UsageModes UsageMode
        {
            get { return usageMode; }
            set { usageMode = value; }
        }

        public LinkTypes LinkType
        {
            get { return linkType; }
            set { linkType = value; }
        }

        public bool IsGarbage
        {
            get { return isGarbage; }
            set { isGarbage = value; }
        }


        ArrayList pageLinksArray = new ArrayList();

        public void AddLink(string link, string status)
        {
            pageLinksArray.Add(new PageLink(link, status));
        }

        public void Clear()
        {
            pageLinksArray.Clear();
        }

        public void AddLink(PageLink pgLink)
        {
            pageLinksArray.Add(pgLink);
        }

        public PageLink GetLink(int i)
        {
            return ((PageLink) pageLinksArray[i]);
        }

        public PageLink[] GetLinks()
        {
            PageLink[] pgLinks = new PageLink[pageLinksArray.Count];

            pageLinksArray.CopyTo(pgLinks, 0);

            return pgLinks;
        }

        public void SetLinks(PageLink[] param)
        {
            for (int i = 0; i < pageLinksArray.Count; i++)
            {
                ((PageLink)pageLinksArray[i]).BrowseLink = param[i].BrowseLink;
            }
        }

        public void ProcessLinks()
        {
            switch (linkType)
            { 
                case  LinkTypes.Normal:
                    for (int i = 0; i < pageLinksArray.Count; i++)
                    {
                        PageLink pgLink = ((PageLink)pageLinksArray[i]);

                        pgLink.BrowseLink = pgLink.Link;
                    }
                    break;

                case LinkTypes.AppendedUrl:
                    throw new NotImplementedException("Encrypted Url transformation funtion not yet implemented");

                case LinkTypes.EncryptedUrl:
                    throw new NotImplementedException("Encrypted Url transformation funtion not yet implemented");

                case LinkTypes.EncodedUrl:
                    throw new NotImplementedException("Encrypted Url transformation funtion not yet implemented");
            }
        }


    }
}
