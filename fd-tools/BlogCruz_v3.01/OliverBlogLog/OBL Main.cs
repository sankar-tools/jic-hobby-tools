using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.IO;

namespace OliverBlogLog
{
    public partial class OBLMain : Form
    {
        public OBLMain()
        {
            InitializeComponent();
            InitializeControls();
            InitializeListViewSorter();

            this.Activated += new EventHandler(OBLMain_Activated);
            
        }

        void OBLMain_Activated(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    Uri identified = null;
                    string url = Clipboard.GetText();
                    if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out identified))
                        txtUrl.Text = identified.AbsoluteUri;
                }
            }
            // Ignore exception due to uri formating issues
            catch (Exception)
            { }
        }

        private void InitializeControls()
        {
            txtStartIndex.Text = "1";

            if (!String.IsNullOrEmpty(txtUrl.Text))
                txtID.Text = ExtractBlogId(txtUrl.Text);

            //RefreshLogData();

        }

        private void InitLogListView(Dictionary<string, LogItem> dictionary)
        {
            lvwLogEntries.Scrollable = true;
            lvwLogEntries.View = View.Details;
            lvwLogEntries.Sorting = SortOrder.Ascending;
            lvwLogEntries.FullRowSelect = true;
            lvwLogEntries.GridLines = true;
            lvwLogEntries.Scrollable = true;
            lvwLogEntries.MultiSelect = false;
            lvwLogEntries.HeaderStyle = ColumnHeaderStyle.Clickable;

            lvwLogEntries.Columns.Add(LogEntriesColumns.ID.ToString(), LogEntriesColumns.ID.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.BlogID.ToString(), LogEntriesColumns.BlogID.ToString(), 100);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Url.ToString(), LogEntriesColumns.Url.ToString(), 350);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Rating.ToString(), LogEntriesColumns.Rating.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.keywords.ToString(), LogEntriesColumns.keywords.ToString(), 150);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Created.ToString(), LogEntriesColumns.Created.ToString(), 150);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Modified.ToString(), LogEntriesColumns.Modified.ToString(), 150);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Grabbed.ToString(), LogEntriesColumns.Grabbed.ToString(), 150);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Threads.ToString(), LogEntriesColumns.Threads.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.MinIndex.ToString(), LogEntriesColumns.MinIndex.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.MaxIndex.ToString(), LogEntriesColumns.MaxIndex.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.Sessions.ToString(), LogEntriesColumns.Sessions.ToString(), 50);

            lvwLogEntries.Columns.Add(LogEntriesColumns.NewCounter.ToString(), LogEntriesColumns.NewCounter.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.DoneCounter.ToString(), LogEntriesColumns.DoneCounter.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.HoldCounter.ToString(), LogEntriesColumns.HoldCounter.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.BadCounter.ToString(), LogEntriesColumns.BadCounter.ToString(), 50);
            lvwLogEntries.Columns.Add(LogEntriesColumns.MiscCounter.ToString(), LogEntriesColumns.MiscCounter.ToString(), 50);

            LoadLogEntries(dictionary);
        }

        private void InitLogSessionsListView()
        {
            lvwLogSessions.Scrollable = true;
            lvwLogSessions.View = View.Details;
            lvwLogSessions.Sorting = SortOrder.Ascending;
            lvwLogSessions.FullRowSelect = true;
            lvwLogSessions.GridLines = true;
            lvwLogSessions.Scrollable = true;
            lvwLogSessions.CheckBoxes = false;
            lvwLogSessions.HeaderStyle = ColumnHeaderStyle.Clickable;

            lvwLogSessions.Columns.Add(LogSessionsColumns.ID.ToString(), LogSessionsColumns.ID.ToString(), 50);
            lvwLogSessions.Columns.Add(LogSessionsColumns.SessionID.ToString(), LogSessionsColumns.SessionID.ToString(), 50);
            lvwLogSessions.Columns.Add(LogSessionsColumns.SessionDate.ToString(), LogSessionsColumns.SessionDate.ToString(), 120);
            lvwLogSessions.Columns.Add(LogSessionsColumns.StartIndex.ToString(), LogSessionsColumns.StartIndex.ToString(), 50);
            lvwLogSessions.Columns.Add(LogSessionsColumns.EndIndex.ToString(), LogSessionsColumns.EndIndex.ToString(), 50);
            lvwLogSessions.Columns.Add(LogSessionsColumns.Step.ToString(), LogSessionsColumns.Step.ToString(), 50);
            lvwLogSessions.Columns.Add(LogSessionsColumns.Images.ToString(), LogSessionsColumns.Images.ToString(), 100);
        }

        private void InitLogStatsListView()
        {
            lvwStats.Scrollable = true;
            lvwStats.View = View.Details;
            lvwStats.Sorting = SortOrder.Ascending;
            lvwStats.FullRowSelect = true;
            lvwStats.GridLines = true;
            lvwStats.Scrollable = true;
            lvwStats.CheckBoxes = false;
            lvwStats.HeaderStyle = ColumnHeaderStyle.Clickable;

            lvwStats.Columns.Add(LogStatsColumns.ID.ToString(), LogStatsColumns.ID.ToString(), 50);
            lvwStats.Columns.Add(LogStatsColumns.Url.ToString(), LogStatsColumns.Url.ToString(), 150);
            lvwStats.Columns.Add(LogStatsColumns.NewCounter.ToString(), LogStatsColumns.NewCounter.ToString(), 50);
            lvwStats.Columns.Add(LogStatsColumns.DoneCounter.ToString(), LogStatsColumns.DoneCounter.ToString(), 50);
            lvwStats.Columns.Add(LogStatsColumns.HoldCounter.ToString(), LogStatsColumns.HoldCounter.ToString(), 50);
            lvwStats.Columns.Add(LogStatsColumns.BadCounter.ToString(), LogStatsColumns.BadCounter.ToString(), 50);
            lvwStats.Columns.Add(LogStatsColumns.MiscCounter.ToString(), LogStatsColumns.MiscCounter.ToString(), 50);
        }


        private void LoadLogEntries(Dictionary<string, LogItem> dictionary)
        {
            lvwLogEntries.Items.Clear();

            int linkIndex = 0;
            foreach (string key in dictionary.Keys)
            {
                LogItem logEntry = dictionary[key];

                ListViewItem vwItem = new ListViewItem(linkIndex.ToString());
                vwItem.SubItems.Add(logEntry.BlogId);
                vwItem.SubItems.Add(logEntry.Link);
                vwItem.SubItems.Add(logEntry.Rating.ToString());
                vwItem.SubItems.Add(logEntry.Keywords.ToString());
                vwItem.SubItems.Add(logEntry.Created.ToString());
                vwItem.SubItems.Add(logEntry.Modified.ToString());
                vwItem.SubItems.Add(logEntry.Grabbed.ToString());
                vwItem.SubItems.Add(logEntry.TotalThreads.ToString());
                vwItem.SubItems.Add(logEntry.MinIndex.ToString());
                vwItem.SubItems.Add(logEntry.MaxIndex.ToString());
                vwItem.SubItems.Add(logEntry.Sessions.Count.ToString());

                vwItem.SubItems.Add(logEntry.NewCounter.ToString());
                vwItem.SubItems.Add(logEntry.DoneCounter.ToString());
                vwItem.SubItems.Add(logEntry.HoldCounter.ToString());
                vwItem.SubItems.Add(logEntry.BadCounter.ToString());
                vwItem.SubItems.Add(logEntry.OtherCounter.ToString());

                linkIndex++;

                lvwLogEntries.Items.Add(vwItem);

            }
        }

        private string ExtractBlogId(string p)
        {
            string blogId = null;
            int markerPositionStart = p.IndexOf("?t=") + 3;
            int markerPositionEnd = p.IndexOf("&page=");

            if(markerPositionStart>0 && markerPositionEnd>0 && markerPositionEnd > markerPositionStart)
            {
                blogId = p.Substring(markerPositionStart, markerPositionEnd - markerPositionStart);
            }
            return blogId;
        }

        private bool ValidateControls()
        {
            if(String.IsNullOrEmpty(txtUrl.Text))
            {
                MessageBox.Show("Url is missing", "Data Error");
                return false;
            }

            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Blog Id is missing", "Data Error");
                return false;
            }

            if (String.IsNullOrEmpty(txtStartIndex.Text) ||
                String.IsNullOrEmpty(txtEndIndex.Text) ||
                String.IsNullOrEmpty(txtRating.Text))
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

        void lvwLogEntries_DoubleClick(object sender, System.EventArgs e)
        {
            LogItem item = GetLogEntry4SelectedItem();

            txtUrl.Text = item.Link;
            txtID.Text = item.BlogId;
            txtEndIndex.Text = item.TotalThreads.ToString() ;
            txtKeywords.Text = item.Keywords;
            txtRating.Text = item.Rating.ToString();

        }

        private LogItem GetLogEntry4SelectedItem()
        {
            LogItem item = null;
            if (lvwLogEntries.SelectedIndices.Count > 0)
            {
                int selectedIndex = lvwLogEntries.SelectedIndices[0];
                string blogId = lvwLogEntries.Items[selectedIndex].SubItems[Convert.ToInt32(LogEntriesColumns.BlogID)].Text;
                item = Log.Entries[blogId];
            }
            return item;
        }

        private void lvwLogEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Display Sessions
            lvwLogSessions.Items.Clear();

            LogItem item = GetLogEntry4SelectedItem();
            if (item == null) return;

            if (item.Sessions.Count <= 0)
            {
                lvwLogSessions.View = View.List;
                ListViewItem vwItem = new ListViewItem("No sessions found for blogId " + item.BlogId);
                lvwLogSessions.Items.Add(vwItem);
            }
            else
            {

                int index = 0;
                lvwLogSessions.View = View.Details;
                foreach (LogListSession session in item.Sessions)
                {
                    ListViewItem vwItem = new ListViewItem(index.ToString());
                    vwItem.SubItems.Add(session.SessionId.ToString());
                    vwItem.SubItems.Add(session.Session.ToString());
                    vwItem.SubItems.Add(session.StartIndex.ToString());
                    vwItem.SubItems.Add(session.EndIndex.ToString());
                    vwItem.SubItems.Add(session.StepIndex.ToString());
                    vwItem.SubItems.Add(session.Images.ToString());

                    index++;

                    lvwLogSessions.Items.Add(vwItem);
                }
            }
            #endregion

            #region Display Stats
            lvwStats.Items.Clear();
            if (item.Stats == null || item.Stats.Count <= 0)
            {
                lvwStats.View = View.List;
                ListViewItem vwItem = new ListViewItem("No stats found for blogId " + item.BlogId);
                lvwStats.Items.Add(vwItem);
            }
            else
            {

                int index = 0;
                lvwStats.View = View.Details;
                foreach (string key in item.Stats.Keys)
                {
                    LogStats stats = item.Stats[key];

                    ListViewItem vwItem = new ListViewItem(index.ToString());
                    vwItem.SubItems.Add(stats.Domain);
                    vwItem.SubItems.Add(stats.New.ToString());
                    vwItem.SubItems.Add(stats.Done.ToString());
                    vwItem.SubItems.Add(stats.Hold.ToString());
                    vwItem.SubItems.Add(stats.NotFound.ToString());
                    vwItem.SubItems.Add(stats.Others.ToString());

                    index++;

                    lvwStats.Items.Add(vwItem);
                }
            }
            #endregion

        }


        #region Column Click Sorting Code
        
        private ListViewColumnSorter logEntryListColumnSorter = null;
        private ListViewColumnSorter logSessionListColumnSorter = null;

        private void InitializeListViewSorter()
        {
            logEntryListColumnSorter = new ListViewColumnSorter();
            lvwLogEntries.ListViewItemSorter = logEntryListColumnSorter;

            logSessionListColumnSorter = new ListViewColumnSorter();
            lvwLogSessions.ListViewItemSorter = logSessionListColumnSorter;
        }


        private void lvwLogEntries_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == logEntryListColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (logEntryListColumnSorter.Order == SortOrder.Ascending)
                {
                    logEntryListColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    logEntryListColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                logEntryListColumnSorter.ColumnType = GetColumnType(lvwLogEntries, e.Column);
                logEntryListColumnSorter.SortColumn = e.Column;
                logEntryListColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwLogEntries.Sort();
        }


        private void lvwLogSessions_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == logSessionListColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (logSessionListColumnSorter.Order == SortOrder.Ascending)
                {
                    logSessionListColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    logSessionListColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                logSessionListColumnSorter.ColumnType = GetColumnType(lvwAllLinks, e.Column);
                logSessionListColumnSorter.SortColumn = e.Column;
                logSessionListColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwLogSessions.Sort();
        }

        #endregion

        private Type GetColumnType(ListView lvw, int column)
        {
            if (lvw == lvwLogEntries)
            {
                if (column == Convert.ToInt16(LogEntriesColumns.ID) || 
                    column == Convert.ToInt16(LogEntriesColumns.Sessions) ||
                    column == Convert.ToInt16(LogEntriesColumns.MinIndex) ||
                    column == Convert.ToInt16(LogEntriesColumns.MaxIndex) ||
                    column == Convert.ToInt16(LogEntriesColumns.Rating) ||
                    column == Convert.ToInt16(LogEntriesColumns.Threads))
                {
                    return typeof(int);
                }
                else if (column == Convert.ToInt16(LogEntriesColumns.Created) ||
                    column == Convert.ToInt16(LogEntriesColumns.Modified) ||
                    column == Convert.ToInt16(LogEntriesColumns.Grabbed))
                {
                    return typeof(DateTime);
                }
                else
                    return typeof(string);
            }

            if (lvw == lvwLogSessions)
            {
                if (column == Convert.ToInt16(LogSessionsColumns.ID) ||
                    column == Convert.ToInt16(LogSessionsColumns.SessionID) ||
                    column == Convert.ToInt16(LogSessionsColumns.Images) ||
                    column == Convert.ToInt16(LogSessionsColumns.StartIndex) ||
                    column == Convert.ToInt16(LogSessionsColumns.EndIndex) ||
                    column == Convert.ToInt16(LogSessionsColumns.StartIndex))
                {
                    return typeof(int);
                }
                else if (column == Convert.ToInt16(LogSessionsColumns.SessionDate))
                    return typeof(DateTime);
                else
                    return typeof(string);
            }

            return null; 
        }


        private void btnBlogID_Click(object sender, EventArgs e)
        {
            txtID.Text = ExtractBlogId(txtUrl.Text);
        }

        private void btnBros_Click(object sender, EventArgs e)
        {
            OpenInBrowser(txtUrl.Text);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                LogItem item = new LogItem();
                item.BlogId = txtID.Text;
                item.Link = txtUrl.Text;
                item.TotalThreads = Convert.ToInt32(txtEndIndex.Text);
                item.Rating = Convert.ToInt32(txtRating.Text);
                item.Keywords = txtKeywords.Text;

                DBController.DatabaseConnectionString = Properties.Settings.Default.DBConnection;
                string action = DBController.SaveLogItem(item);
                MessageBox.Show(String.Format("DB action successfull\r\n{0}", item.BlogId), action);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void RefreshLogData()
        {
            DBController.DatabaseConnectionString = Properties.Settings.Default.DBConnection;
            System.Data.DataSet ds = DBController.GetBlogList();
            Log.FillEntries(ds);
            LoadLogEntries(Log.Entries);
        }

        private void RefreshAllData()
        {
            DBController.DatabaseConnectionString = Properties.Settings.Default.DBConnection;
            System.Data.DataSet ds = DBController.GetBlogList();
            Log.FillEntries(ds);

            InitLogListView(Log.Entries);
            InitLogSessionsListView();
            InitLogStatsListView();
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            string archivePath = Properties.Settings.Default.ArchievePath + @"\" + txtID.Text;
            OpenInImageViewer(archivePath);
        }

        private void OpenInImageViewer(string archivePath)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            string imageViewerPath = Properties.Settings.Default.ImageViewer.Replace("{path}", archivePath);

            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = imageViewerPath;
                myProcess.StartInfo.Arguments = archivePath;
                myProcess.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OpenInBrowser(string p)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();

            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = p;
                myProcess.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
