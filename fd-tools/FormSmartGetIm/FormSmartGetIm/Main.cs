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

            Params.State = RunState.Start;
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
                ListViewItem item = new ListViewItem(Params.Counter++.ToString());
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
            if(Params.State == RunState.Start)
            {
                webThreadStartDelegate = new ThreadStart(ThreadStartAction);
                webThread = new Thread(webThreadStartDelegate);
                webThread.Start();

                Params.State = RunState.Running;
                tsbtnRun.Text = "Stop";
            }
            else
            //if(Params.State != RunState.Start)
            {
                //ToDo:: Destroy threads

                Params.State = RunState.Start;
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
                if(Params.State == RunState.Stopped)
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
                lparse.ParseHrefLinks(args.Document, currentUrl);

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

                ProcessSubLinks(args.Title);

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

        private void ProcessSubLinks(string title)
        {
            string savePath = @"D:\temp\~!0001" + "\\" + title;
 
            for (int i = 0; i < lvwProcess.Items.Count; i++)
            {
                string url = lvwProcess.Items[i].SubItems[1].Text;
                url = UrlHelper.MassageUrl(url);
                LogMessage("Downloading " + url);

                string saveFile = savePath + "\\" + UrlHelper.GetFilename(url);

                HttpHelper http = new HttpHelper();
                http.OnReceiveData += new HttpHelper.OnReceiveDataHandler(http_OnReceiveData);
                http.GetUrlEvents(url, 10240);
                //http.DownloadFileEv(url, currentUrl, saveFile);
                LogMessage(url + " saved to " + saveFile);
            }
        }

        private void http_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if (args.Done) // Current page fetch is complete
            {
                LogMessage(args.ContentType);
                switch (args.DocumentType)
                { 
                    case HttpHelper.DocType.image:
                        string content = args.Document;
                        break;

                    case HttpHelper.DocType.html:
                        string postParam = "pre";

                        for (int i = 1; i < 4; i++)
                        {
                            HttpHelper http = new HttpHelper();
                            http.AddPostKey(postParam, i.ToString());
                            http.OnReceiveData += new HttpHelper.OnReceiveDataHandler(http_OnReceiveData);
                            string doc = http.GetUrl(args.Url);
                            //http.get
                        }

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
            txtLog.Text += "[" + DateTime.Now.ToString() + s + "\r\n";
        }

        private Image LoadImage(string url)
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


                return img;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;

        }
    }
}
