using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SansTech.Net.Http;
using System.Threading;


namespace FormSmartGetIm
{
    public partial class Main : Form
    {

        HttpHelper myBros = new HttpHelper();
        string currentUrl = string.Empty;

        Thread webThread = null;
        ThreadStart webThreadStartDelegate = null;

        public Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            pnlAddUrl.Visible = false;

            myBros.OnReceiveData += new HttpHelper.OnReceiveDataHandler(myBros_OnReceiveData);
            myBros.ThrowExceptions = true;

            GlobalParams.State = RunState.Start;
        }

        private void tsbtnAddUrl_Click(object sender, EventArgs e)
        {
            pnlAddUrl.Visible = true;
        }

        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            pnlAddUrl.Visible = false;
            if(!String.IsNullOrEmpty(txtAddUrl.Text))
            {
                ListViewItem item = new ListViewItem(GlobalParams.Counter++.ToString());
                item.SubItems.Add(txtAddUrl.Text);
                item.SubItems.Add("Unknowm");
                item.SubItems.Add("-1");
                item.SubItems.Add("New");
                lvwUrls.Items.Add(item);
            }
        }

        private void txtAddUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnRun_Click(object sender, EventArgs e)
        {
            if(GlobalParams.State == RunState.Start)
            {
                webThreadStartDelegate = new ThreadStart(ThreadStartAction);
                webThread = new Thread(webThreadStartDelegate);
                webThread.Start();

                GlobalParams.State = RunState.Running;
                tsbtnRun.Text = "Stop";
            }
            else
            //if(Params.State != RunState.Start)
            {
                //ToDo:: Destroy threads

                GlobalParams.State = RunState.Start;
                tsbtnRun.Text = "Start";
            }

            //Params.State = Params.State==RunState.Stopped ? RunState.Running : RunState.Stopped;
            //tsbtnRun.Text = Params.State == RunState.Stopped ? "Start" : "Stop";
            //MessageBox.Show(Params.State.ToString());

            //if (Params.State == RunState.Running)
            //{ 
                
            //}
        }

        // Use to start the thread as a delegate
        private void ThreadStartAction()
        {
            LogMessage("processing thread started");
            ProcessLinks();
        }

        private void ProcessLinks()
        {
            while (true)
            {
                if(GlobalParams.State == RunState.Stopped)
                    break;

                ListViewItem nextUrlItem = GetNextUrlItem();

                if (nextUrlItem == null)
                    break;

                currentUrl = nextUrlItem.SubItems[1].Text;
                nextUrlItem.SubItems[4].Text = "Initiated";

                string doc = GetHtmlDocument(currentUrl);

            }
        }

        private string GetHtmlDocument(string link)
        {
            string doc = String.Empty;
            try
            {
                doc = myBros.GetUrlEvents(link, 10240);
            }
            catch (Exception ex)
            { 
                LogMessage(ex.ToString());
            }

            return doc;
        }


        // Controlled crawling method written on Data received event of HttpHelper
        private void myBros_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if (args.Done) // Current page fetch is complete
            {
                ImageLinkParser lparse = new ImageLinkParser();
                lparse.ParseHrefLinks(args.Document, currentUrl, GlobalParams.GetIgnoreList());

                //ImageList images = new ImageList();
                //images.ImageSize = new Size(150, 150);
                lvwProcess.Items.Clear();

                for (int i = 0; i < lparse.GoodUrls.Count; i++)
                {
                    if (lparse.GoodUrls[i].Link != null)
                    {
                        //Image bmp = LoadImage(lparse.GoodUrls[i].Image);
                        //if (bmp != null)
                        //{
                        //    images.Images.Add(bmp);
                        //    lvwLinkHierarchy.Items.Add(lparse.GoodUrls[i].Filename, i);
                        //}

                        ListViewItem item = new ListViewItem((i+1).ToString());
                        item.SubItems.Add(new ListViewItem.ListViewSubItem().Text = lparse.GoodUrls[i].Link);
                        lvwProcess.Items.Add(item);
                    }
                }

                LogMessage(currentUrl + " processsed, " + lparse.GoodUrls.Count.ToString() + " link(s) found");

                ProcessSubLinks(args.Params.Title);

                //lvwLinkHierarchy.LargeImageList = images;
            }
            else // Current page fetch is in progress update status
            {
                //ListViewItem item = null;
                //lock (lck)
                //{
                //    if (lck.fetchLevel == 1)
                //    {
                //        item = currentHighLevelListItem;
                //    }

                //    if (lck.fetchLevel == 2)
                //    {
                //        item = currentSecondLevelListItem;
                //    }
                //}

                //item.SubItems[1].Text = args.CurrentByteCount.ToString() + "/" + args.TotalBytes.ToString();
            }
        }

        string imagePath = string.Empty;
        private void ProcessSubLinks(string title)
        {
            string savePath = Properties.Settings.Default.savePath + "\\" + title;
 
            for (int i = 0; i < lvwProcess.Items.Count; i++)
            {
                string url = lvwProcess.Items[i].SubItems[1].Text;
                url = UrlHelper.MassageUrl(url);
                LogMessage("Downloading " + url);

                string saveFile = savePath + "\\" + UrlHelper.GetFilename(url);
                imagePath = savePath;

                HttpHelper http = new HttpHelper();
                http.OnReceiveData += new HttpHelper.OnReceiveDataHandler(http_OnReceiveData);
                http.UseReferrer = true;
                http.Referrer = currentUrl;
                http.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
                http.HandleCookies = true;
                //http.Cookies
                attempt = 2;
                http.GetUrlEvents(url, 10240);
                //http.DownloadFileEv(url, currentUrl, saveFile);
                LogMessage(url + " saved to " + saveFile);
            }
        }

        static int attempt = 0;

        private void http_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if (args.Done) // Current page fetch is complete
            {
                string referrer = currentUrl;
                LogMessage(args.Params.ContentType);
                switch (args.DocumentType)
                { 
                    case HttpHelper.DocType.image:
                        string content = args.Document;
                        break;

                    case HttpHelper.DocType.html:
                        string postParam = "pre";

                        if(attempt < 3)
                        //for (int i = 1; i < 4; i++)
                        {
                            HttpHelper http = new HttpHelper();
 
                            http.AddPostKey("op", "view");
                            string imageId = args.Params.Url.Substring(args.Params.Url.IndexOf("/", 9)+1);
                            http.AddPostKey("id", imageId);
                            http.AddPostKey(postParam, (attempt).ToString());
                            //if(attempt ==2)
                                http.AddPostKey("next", "Continue+to+image.");
                            http.UseReferrer = true;
                            http.Referrer = referrer;
                            http.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
                            http.HandleCookies = true;
                            http.OnReceiveData += new HttpHelper.OnReceiveDataHandler(http_OnReceiveData);
                            string doc = http.GetUrl(args.Params.Url);
                            //new FileViewer().Show(doc);
                            referrer = args.Params.Url;
                            attempt++;
                            //http.get
                            SaveImages(doc, args.Params.Url);
                        }
                        else
                            MessageBox.Show("Max attempts exhausted");

                        break;

                }
                

                //lvwLinkHierarchy.LargeImageList = images;
            }
            else // Current page fetch is in progress update status
            {
                //ListViewItem item = null;
                //lock (lck)
                //{
                //    if (lck.fetchLevel == 1)
                //    {
                //        item = currentHighLevelListItem;
                //    }

                //    if (lck.fetchLevel == 2)
                //    {
                //        item = currentSecondLevelListItem;
                //    }
                //}

                //item.SubItems[1].Text = args.CurrentByteCount.ToString() + "/" + args.TotalBytes.ToString();
            }
        }

        private void SaveImages(string doc, string url)
        {
            ImageLinkParser lparse = new ImageLinkParser();
            lparse.ParseImageLinks(doc, url, GlobalParams.GetIgnoreList());

            for (int i = 0; i < lparse.GoodUrls.Count; i++)
            {
                if (lparse.GoodUrls[i].Link != null)
                {
                    try
                    {
                        string saveFile = imagePath + "\\" + UrlHelper.GetFilename(lparse.GoodUrls[i].Link);
                        HttpHelper http = new HttpHelper();
                        http.AllowRedirect = true;
                        http.DownloadFileEv(lparse.GoodUrls[i].Link, url, saveFile);
                        //SaveImage(lparse.GoodUrls[i].Link, saveFile);
                        LogMessage("image " + lparse.GoodUrls[i].Link + " saved to " + saveFile);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("failed " + lparse.GoodUrls[i].Link);
                    }
                }
                LogMessage(i.ToString() + " image(s) saved.");
            }
        }

        private ListViewItem GetNextUrlItem()
        {
            for (int i = 0; i < lvwUrls.Items.Count; i++)
            {
                if (lvwUrls.Items[i].SubItems[4].Text == "New")
                    return lvwUrls.Items[i];
            }

            return null;
        }

        private void LogMessage(string s)
        {
            txtLog.Text += "[" + DateTime.Now.ToString() + "] " + s + "\r\n";
        }

        private void SaveImage(string url, string path)
        {
            try
            {
                System.Net.WebRequest request =
                    System.Net.WebRequest.Create(url);

                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream =
                    response.GetResponseStream();

                //Bitmap bmp = new Bitmap(responseStream);
                Image img = Image.FromStream(responseStream);

                responseStream.Dispose();
                img.Save(path);

                //return img;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //return null;

        }
    }
}
