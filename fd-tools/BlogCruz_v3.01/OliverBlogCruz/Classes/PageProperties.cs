using System.Collections.Generic;
using Core.Web;

namespace OliverBlogCruz
{
    public class PageProperties
    {
        internal int index;
        internal string Url;
        internal string ReferrerUrl = string.Empty;
        internal List<LinkProperties> imageCollection;
        internal long Size;
        internal long BytesDownloaded;
        internal string filename;
        internal string Status;
        internal string BlogId;

        internal event OnCurrentProcessCompleteHandler OnCurrentProcessCompleted;
        internal delegate void OnCurrentProcessCompleteHandler(object sender, OnCurrentProcessArgs args);
        internal class OnCurrentProcessArgs
        {
            public int ProcessCounter;
            public PageProperties Page;
        }

        internal PageProperties()
        {
            imageCollection = new List<LinkProperties>();
        }

        internal void client_OnReceiveData(object sender, WebClient.OnReceiveDataEventArgs e)
        {
            if (e.Done == true)
            {

                // Page processing complete, parse links
                if (!System.IO.File.Exists(filename))
                {
                    CorretiveActionForMissingFile(filename);
                    return;
                }

                HtmlParser parser = new HtmlParser(filename, this.Url);
                List<string> imageUrls = parser.GetAllUrl(ImageUrlType.ImageSrc | ImageUrlType.href, null);

                foreach (string url in imageUrls)
                {
                    LinkProperties linkProp = new LinkProperties();
                    linkProp.Url = url;
                    linkProp.Status = "New";
                    linkProp.Referrer = this.ReferrerUrl;

                    this.imageCollection.Add(linkProp);
                }

                // Raise alert to initiate next file
                OnCurrentProcessArgs args = new OnCurrentProcessArgs();
                args.ProcessCounter = index;
                args.Page = this;
                this.OnCurrentProcessCompleted(this, args);
            }

            this.Status = e.StatusCode.ToString();
            this.Size = e.TotalBytes;
            this.BytesDownloaded = e.CurrentByteCount;

            ViewController.Instance.UpdatePagesListViewItem(this);
        }

        private void CorretiveActionForMissingFile(string filename)
        {
            string message = string.Format("Downloaded file not available\r\n{0}", filename);
            System.Windows.Forms.MessageBox.Show(message);

        }
    }
}
