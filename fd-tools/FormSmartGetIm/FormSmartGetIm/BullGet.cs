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

using SansTech;
using System.IO;

namespace FormSmartGetIm
{
    public partial class BullGet : Form
    {
        #region Inner Definitions

        #region enums
        enum eColumns
        {
            // this must match the order at which the columns are added
            Id = 0,
            Url = 1,
            Title = 2,
            Type = 3,
            Size = 4,
            Downloaded = 5,
            Status = 6
        }

        enum Status
        {
            New,
            Done
        }
        #endregion

        #endregion

        #region Class attributes


        Thread webThread = null;
        ThreadStart webThreadStartDelegate = null;
        //CommonTools.Node processingNode = null;
        private CommonTools.TreeListView treeListView1;
        #endregion

        public BullGet()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            GlobalParams.State = RunState.Start;
        }

        private void BullGet_Load(object sender, EventArgs e)
        {
            InitControls();
            InitHouseKeeping();
        }

        private void InitHouseKeeping()
        {
            SansTech.IO.Directory.EnsureDirectory(Properties.Settings.Default.savePath);

            GlobalParams.ActivityLog = new SansTech.Diagonstics.Log(Properties.Settings.Default.logPath);
            GlobalParams.LinksList = new SansTech.Diagonstics.Log(Properties.Settings.Default.linkList);

            LoadProcMap();
            
        }

        public string[][] procMap;

        private void LoadProcMap()
        {
            string procFilePath = Properties.Settings.Default.procMap;

            var filePath = procFilePath;
            var data = File.ReadLines(filePath).Select(x => x.Split(',')).ToArray();
            procMap = data;

            foreach (var dataitem in procMap)
            {
                var x = dataitem;
            }
        }


        private void InitControls()
        {
            pnlAddUrl.Visible = false;

            // 
            // treeListView1
            // 
            this.treeListView1 = new CommonTools.TreeListView();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.treeListView1.Images = null;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.Size = new System.Drawing.Size(0, 0);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeListView1.Images = null;
            this.treeListView1.Location = new System.Drawing.Point(69, 18);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.Size = new System.Drawing.Size(770, 271);
            this.treeListView1.TabIndex = 0;

            treeListView1.BeginUpdate();
            treeListView1.Dock = DockStyle.Fill;
            this.pnlTree.Controls.Add(treeListView1);

            treeListView1.Columns.Add(new CommonTools.TreeListColumn("id", "#", 60));
            treeListView1.Columns.Add(new CommonTools.TreeListColumn("Url", "Url", 200));
            treeListView1.Columns.Add(new CommonTools.TreeListColumn("Title", "Title", 300));
            treeListView1.Columns.Add(new CommonTools.TreeListColumn("Type", "Type", 100));
            treeListView1.Columns.Add(new CommonTools.TreeListColumn("Size", "Size", 60));
            treeListView1.Columns.Add(new CommonTools.TreeListColumn("Downloaded", "Downloaded", 60));
            treeListView1.Columns.Add(new CommonTools.TreeListColumn("Status", "Status", 80));
            treeListView1.EndUpdate();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
        }

        #region Toobar Button Events
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            pnlAddUrl.Visible = true;
            pnlAddUrl.BringToFront();
            txtAddUrl.SelectAll();
            txtAddUrl.Focus();
        }

        private void tsbtnStart_Click(object sender, EventArgs e)
        {
            if (GlobalParams.State == RunState.Start)
            {
                webThreadStartDelegate = new ThreadStart(ThreadStartAction);
                webThread = new Thread(webThreadStartDelegate);
                webThread.Start();

                GlobalParams.State = RunState.Running;
                tsbtnStart.Text = "Stop";
            }
            else
            //if(Params.State != RunState.Start)
            {
                //ToDo:: Destroy threads

                GlobalParams.State = RunState.Start;
                tsbtnStart.Text = "Start";
            }
        }
        #endregion

        #region Panel Events
        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            pnlAddUrl.Visible = false;
            AddUrl2Log(txtAddUrl.Text);
            AddUrl2Tree(txtAddUrl.Text, null);
        }

        private void AddUrl2Log(string url)
        {
            GlobalParams.LinksList.Write(url);
        }

        #endregion

        #region Tree Methods

        private void AddUrl2Tree(string url, CommonTools.Node parentNode)
        {
            UrlTrackParams oparams = new UrlTrackParams(HttpHelper.Ping(url));
            AddTreeNode(oparams, parentNode);
        }

        private void AddUrlSet2Tree(ImageLinkParser lparse, HttpHelper.OnReceiveDataEventArgs args)
        {
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

                    //ListViewItem item = new ListViewItem((i + 1).ToString());
                    //item.SubItems.Add(new ListViewItem.ListViewSubItem().Text = lparse.GoodUrls[i].Link);
                    //lvwProcess.Items.Add(item);

                    UrlTrackParams oparams = new UrlTrackParams(args.Params);
                    oparams.Url = lparse.GoodUrls[i].Link;
                    AddTreeNode(oparams, GlobalParams.ParentNode);
                }

            }
        }

        private void AddUrlSet2Tree(List<UrlTrackParams> oparams)//, HttpHelper.OnReceiveDataEventArgs args)
        {
            for (int i = 0; i < oparams.Count; i++)
            {
                //if (lparse.GoodUrls[i].Link != null)
                {
                    //Image bmp = LoadImage(lparse.GoodUrls[i].Image);
                    //if (bmp != null)
                    //{
                    //    images.Images.Add(bmp);
                    //    lvwLinkHierarchy.Items.Add(lparse.GoodUrls[i].Filename, i);
                    //}

                    //ListViewItem item = new ListViewItem((i + 1).ToString());
                    //item.SubItems.Add(new ListViewItem.ListViewSubItem().Text = lparse.GoodUrls[i].Link);
                    //lvwProcess.Items.Add(item);

                    //UrlTrackParams oparams = new UrlTrackParams(args.Params);
                    //oparams.Url = lparse.GoodUrls[i].Link;
                    AddTreeNode(oparams[i], GlobalParams.ParentNode);
                }

            }
        }



        private void AddTreeNode(UrlTrackParams oParams, CommonTools.Node parent)
        {
            treeListView1.BeginUpdate();
            CommonTools.Node node = new CommonTools.Node();
            node[(int)eColumns.Id] = 0;
            node[(int)eColumns.Url] = oParams.Url;
            node[(int)eColumns.Title] = oParams.Title;
            node[(int)eColumns.Size] = oParams.Size;
            node[(int)eColumns.Downloaded] = oParams.DownloadedSize;
            node[(int)eColumns.Type] = oParams.ContentType;
            node[(int)eColumns.Status] = oParams.Status;
            node.Expanded = true;

            if (parent != null)
                parent.Nodes.Add(node);
            else
                treeListView1.Nodes.Add(node);
            treeListView1.EndUpdate();
        }

        private void UpdateTreeNode(UrlTrackParams oParams, CommonTools.Node node)
        {
            treeListView1.BeginUpdate();

            node[(int)eColumns.Id] = 0;
            node[(int)eColumns.Url] = oParams.Url;
            node[(int)eColumns.Title] = oParams.Title;
            node[(int)eColumns.Size] = oParams.Size;
            node[(int)eColumns.Downloaded] = oParams.DownloadedSize;
            node[(int)eColumns.Type] = oParams.ContentType;
            node[(int)eColumns.Status] = oParams.Status;
            node.Expanded = true;

            treeListView1.EndUpdate();
        }

        private UrlTrackParams GetParamsForNode(CommonTools.Node node)
        {
            UrlTrackParams oparams = new UrlTrackParams();

            oparams.Id = "0";
            oparams.Url = node[(int)eColumns.Url].ToEmptyString();
            oparams.Title = node[(int)eColumns.Title].ToEmptyString();
            oparams.Size = long.Parse(node[(int)eColumns.Size].ToEmptyString());
            oparams.Status = node[(int)eColumns.Status].ToEmptyString();
            oparams.ContentType = node[(int)eColumns.Type].ToEmptyString();

            return oparams;

        }
        #endregion

        #region Main Logic
        private void ThreadStartAction()
        {
            LogMessage("processing thread started");

            ProcessLinks();
        }

        private void ProcessLinks()
        {
            //while (true)
            {
                //if (GlobalParams.State == RunState.Stopped)
                //    break;

                GlobalParams.CurrentLevel = 1;

                ProcessThisNode(GetNextNewTreeNode());
                //Thread.Sleep(10000);
            }

            MessageBox.Show("Process completed successfully");
            this.BringToFront();
            this.Visible = true;
        }

        private void ProcessThisNode(CommonTools.Node node)
        {
            if (node != null)
            {
                HttpHelper httpHandle = GetHttpHandle(new HttpHelper.OnReceiveDataHandler(httpHandle_OnReceiveData));

                GlobalParams.ParentNode = node;

                string currentUrl = GetCurrentUrl(node);
                httpHandle.Referrer = currentUrl;

                //if(!CanIgnore(currentUrl))
                {

                    //if(UrlIsIndomain(currentUrl))
                    //{
                    //    string domain = UrlHelper.GetDomain(currentUrl);
                
                    //    // Handle post params
                    //    int attempt = 2;
                    //    string imageId = currentUrl.Substring(currentUrl.IndexOf("/", 9) + 1);

                    //    httpHandle.AddPostKey("op", "view");
                    //    httpHandle.AddPostKey("id", imageId);
                    //    httpHandle.AddPostKey("pre", (attempt).ToString());
                    //    httpHandle.AddPostKey("next", "Continue+to+image.");
                    //}


                    GlobalParams.ParentNode[(int)eColumns.Status] = "Initiated";

                    string doc = httpHandle.GetUrlEvents(currentUrl, 10240);
                }

                // Current link processed, find the next one.

                //if (GlobalParams.CurrentNode.HasChildren)
                //    ProcessThisNode(GlobalParams.CurrentNode.Nodes[0]);
                //else // this node is leaf, go with next sibling
                //{
                //    CommonTools.Node sibling = GlobalParams.CurrentNode.NextSibling;
                //    if (sibling != null)
                //        ProcessThisNode(sibling);
                //    else // no more siblings, move to parent node
                //    {
                //        if (GlobalParams.CurrentNode.Parent != null)
                //        {
                //            CommonTools.Node parentSibling = GlobalParams.CurrentNode.Parent.NextSibling;
                //            ProcessThisNode(parentSibling);
                //            // if parentsibling is also null, then ProcessThisNode exits to while(true) loop finding if any more links added
                //        }
                //        //else if parent is null... top level item stop
                //    }
                //}
            }
        }

        private bool CanIgnore(string currentUrl)
        {
            string thisDomain = UrlHelper.GetDomain(currentUrl);

            foreach (string domain in Properties.Settings.Default.ignoreList.Split(new char[] { ',', ';' }))
            {
                if (thisDomain.IndexOf(domain) >= 0)
                    return true;
            }

            return false;
        }

        private bool UrlIsIndomain(string currentUrl)
        {
            string thisDomain = UrlHelper.GetDomain(currentUrl);

            foreach (string domain in Properties.Settings.Default.domains.Split(new char[]{',',';'}))
            {
                if (thisDomain.IndexOf(domain) >= 0)
                    return true;
            }

            return false;
        }

        private HttpHelper GetHttpHandle(HttpHelper.OnReceiveDataHandler handle)
        {
            HttpHelper httpHandle = new HttpHelper();
            httpHandle.OnReceiveData += handle;

            httpHandle.AllowRedirect = false;
            httpHandle.TimeOut = 60;
            httpHandle.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
            httpHandle.HandleCookies = true;
            httpHandle.ThrowExceptions = false;
            httpHandle.BufferSize = 102400;
            return httpHandle;
        }

        private string GetCurrentUrl(CommonTools.Node node)
        {
            return node[(int)eColumns.Url].ToEmptyString();
        }

        private string GetCurrentTitle(CommonTools.Node node)
        {
            return node[(int)eColumns.Title].ToEmptyString();
        }

        private void httpHandle_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if (args.Done) // Current page fetch is complete
            {
                string currentUrl = GetCurrentUrl(GlobalParams.ParentNode);

                UrlTrackParams oparams = new UrlTrackParams(args.Params);

                switch (args.DocumentType)
                {
                    case HttpHelper.DocType.html:

                        ImageLinkParser lparse = new ImageLinkParser();

                        lparse.ParseImageLinks(args.Document, currentUrl, GlobalParams.GetIgnoreList());

                        //ImageList images = new ImageList();
                        //images.ImageSize = new Size(150, 150);
                        //lvwProcess.Items.Clear();

                        //AddUrlSet2Tree(lparse, args);
                        int imageCount = lparse.GoodUrls.Count;

                        lparse.ParseHrefLinks(args.Document, currentUrl, GlobalParams.GetIgnoreList());
                        //AddUrlSet2Tree(lparse, args);
                        int pageCount = lparse.GoodUrls.Count;
                        ImViewer vw = new ImViewer();
                        //vw.OnSelectionCompleted += new ImViewer.OnSelectionComplete(vw_OnSelectionCompleted);
                        vw.AssignLinks(lparse.GoodUrls);
                        vw.ShowList();
                        AddUrlSet2Tree(vw.Links);
                        ProcessSubLinks(args.Params.Title);
                        LogMessage(String.Format("{0} processed, {1} image(s) & {2} page(s) found", currentUrl, imageCount, pageCount));
                        break;

                    case HttpHelper.DocType.image:

                        break;

                    default:
                        LogMessage(currentUrl + " is skipped");
                        break;
                }

                oparams.DownloadedSize = args.Params.Size;
                oparams.Status = "Done";
                UpdateTreeNode(oparams, GlobalParams.ParentNode);
                
            }
            else // Current page fetch is in progress update status
            {
                UrlTrackParams oparams = new UrlTrackParams(args.Params);

                //bool cancel = false;
                switch (args.DocumentType)
                {
                    default:
                    //case HttpHelper.DocType.html:
                        oparams.DownloadedSize = args.CurrentByteCount;
                        oparams.Status = "WIP";
                        break;

                    //case HttpHelper.DocType.image:
                    //    //cancel = true;
                    //    args.Cancel = true;
                    //    string savePath = Properties.Settings.Default.savePath + "\\" + GetCurrentTitle(GlobalParams.CurrentNode) + "\\" + UrlHelper.GetFilename(args.Params.Url);
                    //    //SansTech.IO.File.WriteBinary(savePath, args.Document);
                        
                    //    HttpHelper http = new HttpHelper();
                    //    http.AllowRedirect = true;
                    //    http.DownloadFileEv(args.Params.Url, args.Params.Url, savePath);
                    //    //SaveImage(lparse.GoodUrls[i].Link, saveFile);
                    //    LogMessage("image " + args.Params.Url + " saved to " + savePath);

                    //    //LogMessage(currentUrl + " image saved to " + savePath);
                    //    oparams.DownloadedSize = args.CurrentByteCount;
                    //    oparams.Status = "Done";
                    //    break;

                    //default:
                    //    //cancel = true;
                    //    args.Cancel = true;
                    //    oparams.DownloadedSize = 0;
                    //    oparams.Status = "Cancelled";
                    //    break;
                }

                UpdateTreeNode(oparams, GlobalParams.ParentNode);

                //item.SubItems[1].Text = args.CurrentByteCount.ToString() + "/" + args.TotalBytes.ToString();
            }

            if (args.Error)
            {
                UrlTrackParams oparams = new UrlTrackParams(args.Params);
                oparams.DownloadedSize = args.CurrentByteCount;
                oparams.Status = args.ErrorMsg;

                UpdateTreeNode(oparams, GlobalParams.ParentNode);

            }
        }

        //void vw_OnSelectionCompleted(ImViewer sender)
        //{
        //    AddUrlSet2Tree(sender.Links);

        //    ProcessChildren();
        //}

        //private void ProcessChildren()
        //{
        //    throw new NotImplementedException();
        //}
        string imagePath = string.Empty;
        private void ProcessSubLinks(string title)
        {
            int maxLength = title.Length > 50 ? 50 : title.Length;

            imagePath = Properties.Settings.Default.savePath + "\\" + title.Substring(0, maxLength);
            CommonTools.Node parent = GlobalParams.ParentNode;

            for (int i = 0; i < parent.Nodes.Count; i++)
            {
                GlobalParams.ImageNode = parent.Nodes[i];
                UrlTrackParams oparams = GetParamsForNode(GlobalParams.ImageNode);

                if (oparams.Status == "Selected")
                {
                    string url = oparams.Url;
                    url = UrlHelper.MassageUrl(url);
                    LogMessage("Downloading " + url);

                    HttpHelper http = new HttpHelper();

                    
                    int procItem=-1;

                    for (int ndx = 0; ndx < procMap.Length; ndx++)
                    {
                        if (url.Contains(procMap[ndx][0]))
                        {
                            procItem = ndx;
                            break;
                        }
                    }

                    if (procItem == -1)
                    {
                        if(GlobalParams.ShowMessages)
                            MessageBox.Show("Map not found using procPost");
                        procItem = 0;
                    }



                    string[] procData = procMap[procItem];
                    switch (procData[1])
                    {
                        case "procPost":

                            
                            http.AddPostKey("op", "view");
                            string[] pathsegments = new Uri(url).PathAndQuery.Split(new char[]{'/','.','?'});
                            //string imageId = url.Substring(url.IndexOf("/", 9) + 1);
                            string imageId = pathsegments[Int32.Parse( procData[5])];
                            http.AddPostKey("id", imageId);
                            http.AddPostKey("pre", procData[2]);
                            http.AddPostKey(procData[3], procData[4]);
                            break;

                        case "procSimplePost":
                            http.AddPostKey("imgContinue", "Continue to image ... ");
                            break;

                    }

                    http.UseReferrer = true;
                    http.Referrer = url;
                    http.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
                    //System.Net.CookieCollection cookies = new System.Net.CookieCollection();
                    //cookies.Add(new System.Net.Cookie("rand", "495394820483759408"));
                    //http.Cookies = cookies;
                    http.HandleCookies = true;
                    //http.OnReceiveData += new HttpHelper.OnReceiveDataHandler(http_OnReceiveData);
                    string doc = http.GetUrl(url);
                    if (http.Error)
                    {
                        LogMessage("Error downloading " + url);
                        LogMessage(">>> " + http.ErrorMsg);
                    }
                    else
                    {
                        //new FileViewer().Show(doc);
                        //referrer = args.Params.Url;
                        //attempt++;
                        //http.HttpParams;
                        SaveImages(http.HttpParams, GlobalParams.ImageNode);

                        LogMessage("Completed downloading " + url);
                    }
                }

                //string saveFile = savePath + "\\" + UrlHelper.GetFilename(url);
                //imagePath = savePath;

                //HttpHelper http = new HttpHelper();
                //http.OnReceiveData += new HttpHelper.OnReceiveDataHandler(http_OnLinkReceiveData);
                //http.UseReferrer = true;
                //http.Referrer = currentUrl;
                //http.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
                //http.HandleCookies = true;
                ////http.Cookies
                //attempt = 2;
                //http.GetUrlEvents(url, 10240);
                ////http.DownloadFileEv(url, currentUrl, saveFile);
                //LogMessage(url + " saved to " + saveFile);
            }
        }

        private void SaveImages(HttpHelper.OnReceiveDataEventArgs oparams, CommonTools.Node thisNode)
        {
            ImageLinkParser lparse = new ImageLinkParser();
            lparse.ParseImageLinks(oparams.Document, oparams.Params.Url, GlobalParams.GetIgnoreList());

            for (int i = 0; i < lparse.GoodUrls.Count; i++)
            {
                if (lparse.GoodUrls[i].Link != null)
                {
                    try
                    {
                        string uniqueFileName = SansTech.IO.Directory.GetUniqueFilename(imagePath, UrlHelper.GetFilename(lparse.GoodUrls[i].Link), "jpg");
                        //string saveImageFile = imagePath + "\\" + UrlHelper.GetFilename(lparse.GoodUrls[i].Link);
                        //string saveImageFile2 = imagePath + @"\try\" + UrlHelper.GetFilename(lparse.GoodUrls[i].Link);
                        HttpHelper http = GetHttpHandle(new HttpHelper.OnReceiveDataHandler(httpHandle_OnImageDownload));
                        http.AllowRedirect = true;
                        //http.DownloadFileEv(lparse.GoodUrls[i].Link, oparams.Params.Url, saveImageFile);
                        http.DownloadFileEv(lparse.GoodUrls[i].Link, lparse.GoodUrls[i].Link, uniqueFileName);
                        //SaveImage(lparse.GoodUrls[i].Link, saveImageFile2);
                        //SaveImage(lparse.GoodUrls[i].Link, saveFile);
                        LogMessage("image " + lparse.GoodUrls[i].Link + " saved to " + uniqueFileName);
                        UrlTrackParams uparams = new UrlTrackParams(oparams.Params);
                        uparams.Status = "Done";
                        UpdateTreeNode(uparams, thisNode);
                    }
                    catch (Exception ex)
                    {
                        //if (GlobalParams.ShowMessages)
                        MessageBox.Show("Ex @ " + lparse.GoodUrls[i].Link + "\r\n" + ex.StackTrace);
                    }
                }
                LogMessage(i.ToString() + " image(s) saved.");
            }
        }


        private void httpHandle_OnImageDownload(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if (args.Done) // Current page fetch is complete
            {
                //string currentUrl = GetCurrentUrl(GlobalParams.ParentNode);

                UrlTrackParams oparams = new UrlTrackParams(args.Params);

                //switch (args.DocumentType)
                //{
                //    case HttpHelper.DocType.html:

                //        ImageLinkParser lparse = new ImageLinkParser();

                //        lparse.ParseImageLinks(args.Document, currentUrl, GlobalParams.GetIgnoreList());

                //        //ImageList images = new ImageList();
                //        //images.ImageSize = new Size(150, 150);
                //        //lvwProcess.Items.Clear();

                //        //AddUrlSet2Tree(lparse, args);
                //        int imageCount = lparse.GoodUrls.Count;

                //        lparse.ParseHrefLinks(args.Document, currentUrl, GlobalParams.GetIgnoreList());
                //        //AddUrlSet2Tree(lparse, args);
                //        int pageCount = lparse.GoodUrls.Count;
                //        ImViewer vw = new ImViewer();
                //        //vw.OnSelectionCompleted += new ImViewer.OnSelectionComplete(vw_OnSelectionCompleted);
                //        vw.AssignLinks(lparse.GoodUrls);
                //        vw.ShowList();
                //        AddUrlSet2Tree(vw.Links);
                //        ProcessSubLinks(args.Params.Title);
                //        LogMessage(String.Format("{0} processed, {1} image(s) & {2} page(s) found", currentUrl, imageCount, pageCount));
                //        break;

                //    case HttpHelper.DocType.image:

                //        break;

                //    default:
                //        LogMessage(currentUrl + " is skipped");
                //        break;
                //}

                oparams.DownloadedSize = args.Params.Size;
                oparams.Status = "Done";
                UpdateTreeNode(oparams, GlobalParams.ImageNode);

            }
            else // Current page fetch is in progress update status
            {
                UrlTrackParams oparams = new UrlTrackParams(args.Params);

                ////bool cancel = false;
                //switch (args.DocumentType)
                //{
                //    default:
                        //case HttpHelper.DocType.html:
                        oparams.DownloadedSize = args.CurrentByteCount;
                        oparams.Status = "WIP";
                        //break;

                    //case HttpHelper.DocType.image:
                    //    //cancel = true;
                    //    args.Cancel = true;
                    //    string savePath = Properties.Settings.Default.savePath + "\\" + GetCurrentTitle(GlobalParams.CurrentNode) + "\\" + UrlHelper.GetFilename(args.Params.Url);
                    //    //SansTech.IO.File.WriteBinary(savePath, args.Document);

                    //    HttpHelper http = new HttpHelper();
                    //    http.AllowRedirect = true;
                    //    http.DownloadFileEv(args.Params.Url, args.Params.Url, savePath);
                    //    //SaveImage(lparse.GoodUrls[i].Link, saveFile);
                    //    LogMessage("image " + args.Params.Url + " saved to " + savePath);

                    //    //LogMessage(currentUrl + " image saved to " + savePath);
                    //    oparams.DownloadedSize = args.CurrentByteCount;
                    //    oparams.Status = "Done";
                    //    break;

                    //default:
                    //    //cancel = true;
                    //    args.Cancel = true;
                    //    oparams.DownloadedSize = 0;
                    //    oparams.Status = "Cancelled";
                    //    break;
                //}

                UpdateTreeNode(oparams, GlobalParams.ParentNode);

                //item.SubItems[1].Text = args.CurrentByteCount.ToString() + "/" + args.TotalBytes.ToString();
            }

            if (args.Error)
            {
                UrlTrackParams oparams = new UrlTrackParams(args.Params);
                oparams.DownloadedSize = args.CurrentByteCount;
                oparams.Status = args.ErrorMsg;

                UpdateTreeNode(oparams, GlobalParams.ParentNode);

            }
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
                if(GlobalParams.ShowMessages)
                    MessageBox.Show(e.ToString());
            }
            //return null;

        }

        private CommonTools.Node GetNextNewTreeNode()
        {
            for (int i = 0; i < treeListView1.Nodes.Count; i++)
            {
                CommonTools.Node thisNode = treeListView1.Nodes[i];
                string status = thisNode[(int)eColumns.Status].ToString();
                if (status == "New")
                    return thisNode;
            }

            return null;
        }
        #endregion

        private void LogMessage(string s)
        {
            string logMsg = "[" + DateTime.Now.ToString() + "] " + s ;
            txtLog.Text += logMsg + "\r\n";
            GlobalParams.ActivityLog.Write(logMsg);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string clipBoardData = Clipboard.GetText();
            if (UrlHelper.IsUrl(clipBoardData))
            {
                txtAddUrl.Text = clipBoardData;
            }
            else
                MessageBox.Show("Not a valid Url");
        }

        private void tsbtnShowMsg_Click(object sender, EventArgs e)
        {
            GlobalParams.ShowMessages = tsbtnShowMsg.Checked;
            tsbtnShowMsg.Text = !tsbtnShowMsg.Checked ? "Show Message" : "Hide Messages";
        }
    }
}
