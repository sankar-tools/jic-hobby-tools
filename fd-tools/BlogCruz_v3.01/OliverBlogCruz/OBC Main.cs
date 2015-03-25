using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using Core.Web;
using System.IO;

namespace OliverBlogCruz
{
    public partial class OBCMain : Form
    {
        Int32 startIndex;
        Int32 endIndex;
        Int32 step;
        string pageUrl;
        string referrerUrl;
        int padLength;
        char padChar;
        string blogId;

        RunningState currentState = RunningState.Idel;
        List<PageProperties> pageCollection;

        //int processPageCounter = 0;
        //string downloadPath = string.Empty;

        public OBCMain()
        {
            InitializeComponent();

            ViewController.Instance.MainForm = this;
            ViewController.Instance.InitListViews();

            txtFilter.Text = Properties.Settings.Default.FiltersInclude;
            txtFilterExclude.Text = Properties.Settings.Default.FiltersExclude;
            txtUrl.Text = Properties.Settings.Default.UrlPattern;
            txtReferrer.Text = Properties.Settings.Default.UrlPattern;

            txtStartIndex.Text = "1";
            txtStep.Text = "1";

            InitializeListViewSorter();


            LinkFilter.Instance.ApplyFilter = chkFilter.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            switch (currentState)
            { 
                case RunningState.Idel:
                    StartAction();
                    break;
                case RunningState.Paused:
                    ResumeAction();
                    break;
                case RunningState.Running:
                    PauseAction();
                    break;
            }

        }

        private void PauseAction()
        {
            throw new NotImplementedException();
        }

        private void ResumeAction()
        {
            throw new NotImplementedException();
        }

        private void StartAction()
        {
            if (ValidateControls() != true)
                return;

            lvwPages.Items.Clear();
            lvwGroupedLinks.Items.Clear();
            lvwAllLinks.Items.Clear();

            pageUrl = txtUrl.Text.Replace("[site]", txtID.Text);
            referrerUrl = pageUrl.Replace("[i]", txtStartIndex.Text);
            
            startIndex = Convert.ToInt32(txtStartIndex.Text);
            endIndex = Convert.ToInt32(txtEndIndex.Text);
            step = Convert.ToInt32(txtStep.Text);

            if (!string.IsNullOrEmpty(txtPadChar.Text) && !string.IsNullOrWhiteSpace(txtPadLen.Text))
            {
                padChar = txtPadChar.Text.Trim().ToCharArray()[0];
                padLength = Convert.ToInt32(txtPadLen.Text);
            }
            blogId = txtID.Text;

            pageCollection = new List<PageProperties>();
            GeneratePages();

            ThreadController thController = new ThreadController();
            thController.pageCollection = pageCollection;
            thController.BlogId = blogId;
            thController.InitiateProcess();
        }

        private bool ValidateControls()
        {
            if (!txtUrl.Text.Contains("[i]"))
            {
                MessageBox.Show("Serial Url marker is missing", "Data Error");
                return false;
            }

            if (!txtUrl.Text.Contains("[site]"))
            {
                MessageBox.Show("Site Url marker is missing", "Data Error");
                return false;
            }


            if (String.IsNullOrEmpty(txtReferrer.Text))
            {
                MessageBox.Show("Referrer Url marker is missing", "Data Error");
                return false;
            }

            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Blog Id is missing", "Data Error");
                return false;
            }

            if (String.IsNullOrEmpty(txtStartIndex.Text) ||
                String.IsNullOrEmpty(txtEndIndex.Text) ||
                String.IsNullOrEmpty(txtStep.Text))
            {
                MessageBox.Show("Series index data is missing", "Data Error");
                return false;
            }

            if (Convert.ToInt32(txtStartIndex.Text) > Convert.ToInt32(txtEndIndex.Text))
            {
                MessageBox.Show("Start index cannot be greater than end index", "Data Error");
                return false;
            }

            return true;
        }

        private void GeneratePages()
        {
            int i =0;
            if (pageCollection.Count > 0)
                pageCollection.Clear();

            for (i = startIndex; i <= endIndex; i+=step)
            {
                PageProperties pageProp = new PageProperties();
                pageProp.Url = pageUrl.Replace("[i]", i.ToString().PadLeft(padLength, padChar));
                pageProp.index = i-startIndex;
                pageProp.BlogId = txtID.Text;
                pageProp.ReferrerUrl = txtReferrer.Text;

                pageCollection.Add(pageProp);

                pageProp.OnCurrentProcessCompleted += new PageProperties.OnCurrentProcessCompleteHandler(pageProp_OnCurrentProcessCompleted);

                ViewController.Instance.AddItem2PagesListViewItem(pageProp);
            }

            sbtMain.Text = String.Format("{0} page(s) generated", (i-startIndex-1).ToString());
        }
        
        void pageProp_OnCurrentProcessCompleted(object sender, PageProperties.OnCurrentProcessArgs args)
        {
            //ShowAllLinks(args);

            statusMain.BeginInvoke((MethodInvoker)delegate
            {
                sbtMain.Text = String.Format("Page {0} of {1} urls downloaded and processes", args.ProcessCounter+1, pageCollection.Count);
            });
            
        }

        private void ShowAllLinks()
        {
            Stats.FindAllLinksStartTime = DateTime.Now;
            int linkIndex = 0;
            int totalLinks = 0;
            lvwGroupedLinks.Items.Clear();

            foreach (PageProperties pageProp in pageCollection)
            {
                totalLinks += pageProp.imageCollection.Count;

                foreach (LinkProperties linkProp in pageProp.imageCollection)
                {
                    ListViewItem vwItem = new ListViewItem(linkIndex.ToString());
                    vwItem.SubItems.Add(linkProp.Url);
                    vwItem.SubItems.Add("-1");
                    vwItem.SubItems.Add("New");
                    vwItem.SubItems.Add("-1");

                    if (LinkFilter.Instance.IsValid(linkProp))
                    {
                        lvwAllLinks.BeginInvoke((MethodInvoker)delegate
                        {
                            lvwAllLinks.Items.Add(vwItem);
                        });
                        linkIndex++;
                    }
                }
            }
            Stats.FindAllLinksEndTime = DateTime.Now;

            sbtMain.Text = string.Format("Showing {0} of {1} links", linkIndex.ToString(), totalLinks.ToString());
        }

        private void txtPadLen_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvwLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGroupedLinks.SelectedIndices.Count > 0)
            {
                lvwLinkDetails.Items.Clear();
                int selectedPageIndex = lvwGroupedLinks.SelectedIndices[0];

                string key = lvwGroupedLinks.Items[selectedPageIndex].SubItems[1].Text;
                List<LinkProperties> links = linkGroups[key];

                for (int i = 0; i < links.Count; i++)
                {
                    ListViewItem vwItem = new ListViewItem(i.ToString());
                    vwItem.SubItems.Add(links[i].Url);

                    lvwLinkDetails.Items.Add(vwItem);
                }
            }
        }

        private void lvwPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPages.SelectedIndices.Count > 0)
            {
                lvwGroupedLinks.Items.Clear();
                int selectedPageIndex = lvwPages.SelectedIndices[0];

                PageProperties selectedPage = pageCollection[selectedPageIndex];

                for (int i = 0; i < selectedPage.imageCollection.Count; i++)
                {
                    ViewController.Instance.AddItem2AllLinksListViewItem(selectedPage, i);
                }
            }
        }

        #region Column Click Sorting Code
        
        private ListViewColumnSorter pagelistColumnSorter = null;
        private ListViewColumnSorter allLinkslistColumnSorter = null;
        private ListViewColumnSorter groupedLinkslistColumnSorter = null;
        private ListViewColumnSorter detailedLinksListColumnSorter = null;

        private void InitializeListViewSorter()
        {
            pagelistColumnSorter = new ListViewColumnSorter();
            lvwPages.ListViewItemSorter = pagelistColumnSorter;

            allLinkslistColumnSorter = new ListViewColumnSorter();
            lvwAllLinks.ListViewItemSorter = allLinkslistColumnSorter;

            groupedLinkslistColumnSorter = new ListViewColumnSorter();
            lvwGroupedLinks.ListViewItemSorter = groupedLinkslistColumnSorter;

            detailedLinksListColumnSorter = new ListViewColumnSorter();
            lvwLinkDetails.ListViewItemSorter = detailedLinksListColumnSorter;
        }


        void lvwLinkDetails_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == detailedLinksListColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (detailedLinksListColumnSorter.Order == SortOrder.Ascending)
                {
                    detailedLinksListColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    detailedLinksListColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                detailedLinksListColumnSorter.ColumnType = GetColumnType(lvwLinkDetails, e.Column);
                detailedLinksListColumnSorter.SortColumn = e.Column;
                detailedLinksListColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwLinkDetails.Sort();

        }

        void lvwGroupedLinks_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == groupedLinkslistColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (groupedLinkslistColumnSorter.Order == SortOrder.Ascending)
                {
                    groupedLinkslistColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    groupedLinkslistColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                groupedLinkslistColumnSorter.ColumnType = GetColumnType(lvwGroupedLinks, e.Column);
                groupedLinkslistColumnSorter.SortColumn = e.Column;
                groupedLinkslistColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwGroupedLinks.Sort();
        }


        private void lvwPages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == pagelistColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (pagelistColumnSorter.Order == SortOrder.Ascending)
                {
                    pagelistColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    pagelistColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                pagelistColumnSorter.ColumnType = GetColumnType(lvwPages, e.Column);
                pagelistColumnSorter.SortColumn = e.Column;
                pagelistColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwPages.Sort();
        }


        private void lvwAllLinks_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == allLinkslistColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (allLinkslistColumnSorter.Order == SortOrder.Ascending)
                {
                    allLinkslistColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    allLinkslistColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                allLinkslistColumnSorter.ColumnType = GetColumnType(lvwAllLinks, e.Column);
                allLinkslistColumnSorter.SortColumn = e.Column;
                allLinkslistColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwAllLinks.Sort();
        }

        #endregion

        private Type GetColumnType(ListView lvw, int column)
        {
            if (lvw == lvwPages || lvw == lvwGroupedLinks)
            {
                if (column == Convert.ToInt16(PageListColumns.ID) || column == Convert.ToInt16(PageListColumns.Images) || column == Convert.ToInt16(PageListColumns.Size))
                {
                    return typeof(int);
                }
                else
                    return typeof(string);
            }
            return null; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult userAction = MessageBox.Show("You are about to save to DB from all links grid\r\nHave you filtered the data?", "Confirm!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (userAction == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                DBController.DatabaseConnectionString = Properties.Settings.Default.DBConnection;
                int totalLinks = DBController.SaveLinks(pageCollection);
                //int totalLinks = DBController.SaveLinks(linkGroups, GetSelectedItems(), txtID.Text);

                string message = totalLinks.ToString() + " links added to database";
                MessageBox.Show(message);
                sbtMain.Text = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        private List<String> GetSelectedItems()
        {
            List<string> selectedKeys = new List<string>();
            foreach (ListViewItem item in lvwGroupedLinks.CheckedItems)
            {
                selectedKeys.Add(item.SubItems[Convert.ToInt32(PageListColumns.Url)].Text);
            }

            return selectedKeys;
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            ReplaceSelectedText(txtUrl, "[i]");

        }

        private void ReplaceSelectedText(TextBox txtBoxCntrl, string replacement)
        {
            if (txtBoxCntrl.SelectedText.Length > 0)
            {
                txtBoxCntrl.Text = txtBoxCntrl.Text.Substring(0, txtBoxCntrl.SelectionStart) + replacement +
                    txtBoxCntrl.Text.Substring(txtBoxCntrl.SelectionStart + txtBoxCntrl.SelectedText.Length);
            }
        }

        private void btnBlogID_Click(object sender, EventArgs e)
        {
            txtID.Text = txtUrl.SelectedText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult userAction = MessageBox.Show("This may time sometime to complete\r\nDo you want to continue?", "Confirm!",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (userAction == System.Windows.Forms.DialogResult.Yes)
            {
                ShowAllLinks();
                DisplayStats();
            }
        }

        Dictionary<string, List<LinkProperties>> linkGroups = null;
        private void ShowLinkGroupings()
        {
            Stats.GroupingStartTime = DateTime.Now;

            linkGroups = new Dictionary<string, List<LinkProperties>>();
            foreach (PageProperties pageProp in pageCollection)
            {
                foreach (LinkProperties linkProp in pageProp.imageCollection)
                {
                    string urlKey = GetHostName(linkProp.Url);
                    Core.Prime.UriComponents components = Core.Prime.UriComponents.Parse(urlKey);

                    if (components != null)
                        urlKey = components.PrimaryDomain;

                    List<LinkProperties> urlCollection = null;

                    // if key does not exist, add new entry
                    if(!linkGroups.TryGetValue(urlKey, out urlCollection))
                    {
                        urlCollection = new List<LinkProperties>();
                        linkGroups.Add(urlKey, urlCollection);
                    }

                    //linkProp.Referrer = txtReferrer.Text;
                    urlCollection.Add(linkProp);
                    linkGroups[urlKey] = urlCollection;
                }
            }

            Stats.GroupingEndTime = DateTime.Now;

            lvwGroupedLinks.Items.Clear();

            int linkIndex = 0;
            int linkCount = 0;
            foreach (string key in linkGroups.Keys)
            {
                List<LinkProperties> links = linkGroups[key];

                ListViewItem vwItem = new ListViewItem(linkIndex.ToString());

                string filterFlag = "";

                if (IsExcludedSite(key))
                {
                    filterFlag = "N";
                }

                if (IsIncludedSite(key))
                {
                    filterFlag = "Y";
                    vwItem.Checked = true;
                }

                vwItem.SubItems.Add(key);
                vwItem.SubItems.Add(links.Count.ToString());
                vwItem.SubItems.Add(filterFlag);

                lvwGroupedLinks.Items.Add(vwItem);

                linkIndex++;
                linkCount += links.Count;
            }

            sbtMain.Text = string.Format("Found {0} links under {1} domain names", linkCount.ToString(), linkIndex.ToString());
        }

        private bool IsIncludedSite(string key)
        {
            string[] includes = txtFilter.Text.Split(new char[] { ',', ';' });

            foreach (string include in includes)
            { 
                if(key.ToUpper().Contains(include.ToUpper()) && !string.IsNullOrEmpty(include))
                    return true;
            }

            return false;
        }

        private bool IsExcludedSite(string key)
        {
            string[] excludes = txtFilterExclude.Text.Split(new char[] { ',', ';' });

            foreach (string exclude in excludes)
            {
                if (key.ToUpper().Contains(exclude.ToUpper()) && !string.IsNullOrEmpty(exclude))
                    return true;
            }

            return false;
        }

        private void DisplayStats()
        {
            StringBuilder statsBuffer = new StringBuilder();

            statsBuffer.AppendLine("Operational Statistics...");

            statsBuffer.AppendLine(string.Format("Sort All Link ran from {0} to {1} for {2}",
                Stats.FindAllLinksStartTime, Stats.FindAllLinksEndTime, Stats.FindAllLinksEndTime- Stats.FindAllLinksStartTime));

            statsBuffer.AppendLine(string.Format("Link Grouping ran from {0} to {1} for {2}",
                Stats.GroupingStartTime, Stats.GroupingEndTime, Stats.GroupingEndTime - Stats.GroupingStartTime));

            txtStats.Text = statsBuffer.ToString();

        }

        private string GetHostName(string p)
        {
            int slashIndex  = p.IndexOf('/',9);

            // if url does not end with / but a proper web link then return whole link
            if (slashIndex < 0)
            {
                if (p.Contains("http"))
                    return p;
                else
                    return string.Empty;
            }

            return (p.Substring(0, slashIndex));
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            LinkFilter.Instance.ApplyFilter = chkFilter.Checked;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            LinkFilter.Instance.SiteFilter = txtFilter.Text;
        }

        private void txtStartIndex_TextChanged(object sender, EventArgs e)
        {
            int startIndex = 0;
            if (Int32.TryParse(txtStartIndex.Text, out startIndex ))
            {
                txtEndIndex.Text = (startIndex + 20).ToString();
            }
        }

        private void btnGroupedLinks_Click(object sender, EventArgs e)
        {
            ShowLinkGroupings();
            DisplayStats();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult userAction = MessageBox.Show("You are about to save to DB from grouped linked\r\nHave you validated the data?", "Confirm!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (userAction == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                DBController.DatabaseConnectionString = Properties.Settings.Default.DBConnection;
                //int totalLinks = DBController.SaveLinks(pageCollection);
                int totalLinks = DBController.SaveLinks(linkGroups, GetSelectedItems(), txtID.Text);

                string message = totalLinks.ToString() + " links added to database";

                LogListSession session = new LogListSession();
                session.StartIndex = Convert.ToInt32(txtStartIndex.Text);
                session.EndIndex = Convert.ToInt32(txtEndIndex.Text);
                session.StepIndex = Convert.ToInt32(txtStep.Text);
                session.Images = totalLinks;

                DBController.SaveSession(session, txtID.Text);

                MessageBox.Show(message);
                sbtMain.Text = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message);
            }

        }

        private void lvwAllLinks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
