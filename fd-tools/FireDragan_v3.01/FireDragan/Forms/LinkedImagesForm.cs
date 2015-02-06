using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FireDragan
{
    public partial class LinkedImageForm : Form
    {
        public event StatusChanged StatusChanged;

        HttpHelper myBros = new HttpHelper();

        ListViewItem currentHighLevelListItem = null;
        ListViewItem currentSecondLevelListItem = null;

        ImageFetchLocked lck = new ImageFetchLocked();

        string baseUrl = string.Empty;
        string currentUrl = string.Empty;

        Thread webThread = null;
        ThreadStart webThreadStartDelegate = null;

        public LinkedImageForm()
        {
            InitializeComponent();

            LinkedImageForm.CheckForIllegalCrossThreadCalls = false; 
            myBros.OnReceiveData += new HttpHelper.OnReceiveDataHandler(myBros_OnReceiveData);
            myBros.ThrowExceptions = true;
        }

        // Add a new link to highlevel list
        public void AddLink(string link)
        {
            ListViewItem item = lvwLinks.Items.Add(link);
            item.SubItems.Add("New");
            //item.SubItems[1].Text = "New";
        }

        // Inititate the crawling by clicking on the highlevel list item
        private void lvwLinks_DoubleClick(object sender, EventArgs e)
        {
            webThreadStartDelegate = new ThreadStart(ThreadStartAction);
            webThread = new Thread(webThreadStartDelegate);
            webThread.Start();
        }

        // Use to start the thread as a delegate
        private void ThreadStartAction()
        {
            currentHighLevelListItem = lvwLinks.SelectedItems[0];
            currentHighLevelListItem.SubItems[1].Text = "Initated";
            GrabPageLinks(lvwLinks.SelectedItems[0].Text);
            MessageBox.Show("Processing the page complete");
        }

        // Initiate the crawel at level 1
        private void GrabPageLinks(string link)
        {
            lvwLinkHierarchy.Items.Clear();

            ListViewItem item = lvwLinkHierarchy.Items.Add(link);
            item.SubItems.Add("Main");

            lck.fetchLevel = 1;

            baseUrl = link;
            GetHtmlDocForLink(link);
        }

        // Initiate the navigation at a specific level
        private void GetHtmlDocForLink(string link)
        {
            //WebBrowser browser = new WebBrowser();
            currentUrl = link;
            try
            {
                string doc = myBros.GetUrlEvents(link, 10240);
            }
            catch (Exception)
            { 
                //MessageBox.Show(ex.ToString());

                if(currentSecondLevelListItem != null)
                    currentSecondLevelListItem.SubItems[1].Text = "Failed";

                GoWithNextFetch();
            }
            //browser.DocumentCompleted +=new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);

            //HttpHelper myHttp = new HttpHelper();
            //string str = myHttp.GetUrl(link);
            //browser.DocumentText = str;

            //return browser.Document;
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

        // Controlled crawling method written on Data received event of HttpHelper
        private void myBros_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if(args.Done) // Current page fetch is complete
            {
                ImageLinkParser lparse = new ImageLinkParser();
                lparse.ParseHrefLinks(args.Document, currentUrl);

                ImageList images = new ImageList();
                images.ImageSize = new Size(150, 150);
                        
                for (int i=0; i < lparse.GoodUrls.Count; i++)
                {
                    if (lparse.GoodUrls[i].Image != null)
                    {
                        Image bmp = LoadImage(lparse.GoodUrls[i].Image);
                        if (bmp != null)
                        {
                            images.Images.Add(bmp);
                            lvwLinkHierarchy.Items.Add(lparse.GoodUrls[i].Filename, i);
                        }
                    }
                }

                lvwLinkHierarchy.LargeImageList = images;
            }
            else // Current page fetch is in progress update status
            {
                ListViewItem item = null;
                lock (lck)
                {
                    if (lck.fetchLevel == 1)
                    {
                        item = currentHighLevelListItem;
                    }

                    if (lck.fetchLevel == 2)
                    {
                        item = currentSecondLevelListItem;
                    }
                }

                item.SubItems[1].Text = args.CurrentByteCount.ToString() + "/" + args.TotalBytes.ToString();
            }
        }

        private void GoWithNextFetch()
        {
            currentSecondLevelListItem = GetNextSecondLevelItem();
            if (currentSecondLevelListItem != null)
            {
                currentSecondLevelListItem.SubItems[1].Text = "Inprogress";
                string url = currentSecondLevelListItem.SubItems[0].Text.Trim();
                GetHtmlDocForLink(url);
            }
            else
            {
                //MessageBox.Show("Processing the page completed");
                webThread.Abort();
            }
        }

        private void AddNewFoundLink(string lnk)
        {
            bool found = false;

            for (int i = 0; i < lvwLinkHierarchy.Items.Count; i++)
            {
                if (lvwLinkHierarchy.Items[i].SubItems[0].Text.Trim().ToLower() == lnk.Trim().ToLower())
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                ListViewItem item = lvwLinkHierarchy.Items.Add(lnk);
                item.SubItems.Add("New");

                // Incase domain check activated, mark external links as skipped
                if (chkInDomain.Checked == true)
                {
                    if (!LinkParser.IsSameDomain(new Uri(baseUrl), new Uri(lnk)))
                    {
                        item.SubItems[1].Text ="Skipped" ;
                    }
                }

                if (LinkParser.GetLinkType(lnk) != LinkType.WebPage)
                    item.SubItems[1].Text = "Skipped";
            }

            tslblCount.Text = "[" + lvwLinkHierarchy.Items.Count.ToString() + "]";
        }

        private ListViewItem GetNextSecondLevelItem()
        {
            return GetNextItemFromList(lvwLinkHierarchy, 1, "New");
        }

        private ListViewItem GetNextItemFromList(ListView lview, int subIndex, string value)
        {
            ListViewItem lvw = null;

            for (int i = 0; i < lview.Items.Count; i++)
            {
                if (lview.Items[i].SubItems[subIndex].Text == value)
                {
                    lvw = lview.Items[i];
                    break;
                }
            }

            return lvw;
        }

        private void tsbtnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwImageLinks.Items)
            {
                if (item.Checked)
                {
                    item.Remove();
                }
            }

            statusStrip1.Text = "Selected items removed";
        }

        private void tsbtnRemoveAll_Click(object sender, EventArgs e)
        {
            lvwImageLinks.Items.Clear();
            statusStrip1.Text = "All items removed";
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveLinks(false);

        }

        private void SaveLinks(bool autoSave)
        {
            int counter = lvwImageLinks.Items.Count;

            SettingsHelper helper = SettingsHelper.Current;

            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string constr = helper.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority, category) values(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("referrer", OleDbType.VarChar);
                cmd.Parameters.Add("Priority", OleDbType.VarChar);
                cmd.Parameters.Add("Category", OleDbType.VarChar);

                foreach (ListViewItem lvw in lvwImageLinks.Items)
                {
                    cmd.Parameters[0].Value = lvw.SubItems[1].Text;
                    cmd.Parameters[1].Value = lvw.SubItems[2].Text;
                    cmd.Parameters[2].Value = lvw.SubItems[3].Text;
                    cmd.Parameters[3].Value = lvw.SubItems[4].Text;

                    cmd.ExecuteNonQuery();

                    lvw.Remove();
                }

                StatusEventArgs args = new StatusEventArgs();

                if (autoSave)
                    args.Message = "[AutoSave Active] " + counter.ToString() + " row(s) added to DB successfully";
                else
                    args.Message = counter.ToString() + " row(s) added to DB successfully";

                args.Panel = StatusPanels.MainPanel;
                StatusChanged(this, args);


                args.Message = "Count :: 0";
                args.Panel = StatusPanels.ImageCounter;
                StatusChanged(this, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //LogHelper.WriteLog(LogLevel.Verbose, "Exception : " + e.Message);

            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public void AddLinks(string[] links, string url, string priority, string category)
        {
            int counter = lvwImageLinks.Items.Count;

            for (int i = 0; i < links.Length; i++)
            {
                ListViewItem item = lvwImageLinks.Items.Add((++counter).ToString());

                item.SubItems.Add(links[i]);
                item.SubItems.Add(url);
                item.SubItems.Add(priority);
                item.SubItems.Add(category);
            }

            this.Show();

            StatusEventArgs args = new StatusEventArgs();

            args.Message = links.Length.ToString() + " row(s) added successfully";
            args.Panel = StatusPanels.MainPanel;
            StatusChanged(this, args);

            statusStrip1.Text = "["+links.Length.ToString() + "] row(s) added successfully";
            args.Message = "Count :: " + lvwImageLinks.Items.Count.ToString();
            args.Panel = StatusPanels.ImageCounter;
            StatusChanged(this, args);

            int autoSaveLimit = SettingsHelper.Current.AlterImageLevel;

            if (lvwImageLinks.Items.Count > autoSaveLimit)
            {
                SaveLinks(true);
            }
        }



        //enum HtmlElementType
        //{
        //    HRef,
        //    Image
        //}






        //private bool IsSameDomain(Uri url1, Uri url2)
        //{
        //    return (url1.Host == url2.Host);
        //}


        //private string[] GetHtmlElementPaths(HtmlDocument myDoc, HtmlElementType type)
        //{
        //    System.Collections.ArrayList arr = new System.Collections.ArrayList();

        //    try
        //    {
        //        switch (type)
        //        {
        //            case HtmlElementType.HRef:
        //                foreach (HtmlElement lnkElement in myDoc.Links)
        //                {
        //                    arr.Add(lnkElement.GetAttribute("Href"));
        //                }

        //                break;

        //            case HtmlElementType.Image:
        //                foreach (HtmlElement lnkElement in myDoc.Images)
        //                {
        //                    arr.Add(lnkElement.GetAttribute("Src"));
        //                }

        //                foreach (HtmlElement lnkElement in myDoc.Links)
        //                {
        //                    if (IsImageUrl(lnkElement.GetAttribute("Href")))
        //                        arr.Add(lnkElement.GetAttribute("Href"));
        //                }


        //                break;
        //        }

        //    }
        //    catch (InvalidCastException ex)
        //    {
        //        MessageBox.Show("Invalidcast : " + ex.ToString());
        //    }

        //    string[] urls = new string[arr.Count];

        //    arr.CopyTo(urls, 0);
        //    return (urls);
        //}

        private void tsbtnFilter_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (ListViewItem item in lvwLinkHierarchy.Items)
            {
                if (LinkParser.GetLinkType(item.Text) == LinkType.Image && item.Text.ToUpper().IndexOf(tstxtFilter.Text.ToUpper()) > 0)
                {
                    item.Checked = true;
                    count++;
                }
            }

            statusStrip1.Text = "[" + count.ToString() + "] items selected";
        }

        //public Boolean IsImageUrl(string uri)
        //{
        //    string fileExt = uri.Substring(uri.LastIndexOf(".") + 1).ToLower();

        //    if (fileExt.Length > 0)
        //    {
        //        string imageExtensions = SettingsHelper.Current.ImageExpression;
        //        return (!(imageExtensions.IndexOf(fileExt) < 0));
        //    }
        //    else
        //        return false;
        //}


        // Add filtered links from Link Hierarchy List to List #3
        private void tsbtnAddLinks_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            foreach (ListViewItem item in lvwLinkHierarchy.Items)
            {
                if (item.Checked)
                {
                    arr.Add(item.Text.Substring(item.Text.IndexOf("http://")));
                    
                }
            }

            string[] urls = new string[arr.Count];

            arr.CopyTo(urls, 0);

            AddLinks(urls, lvwLinkHierarchy.Items[0].Text, (tscboPriority.Text==""?"None":tscboPriority.Text), tscboCategory.Text);
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            lvwLinkHierarchy.Items.Clear();

            statusStrip1.Text = "All fetched linked cleared from hierachial grid";
        }

        private void lvwLinks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tscboCategory_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnUnselect_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (ListViewItem item in lvwLinkHierarchy.Items)
            {
                if(item.Checked == true)
                {
                    item.Checked = false;
                    count++;
                }
            }

            statusStrip1.Text = "[" + count.ToString() + "] items unselected";

        }

        //private void lvwLinks_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}


    }
}

public class ImageFetchLocked
{
    public int fetchLevel = 0;
}
