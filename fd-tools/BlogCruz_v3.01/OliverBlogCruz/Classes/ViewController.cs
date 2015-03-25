using System;
using System.Windows.Forms;

namespace OliverBlogCruz
{
    class ViewController
    {
        #region Singleton
        private static ViewController instance;

        private ViewController() { }

        public static ViewController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViewController();
                }
                return instance;
            }
        }
        #endregion singleton

        private ListView PagesListView
        {
            get { return MainForm.lvwPages; }
        }

        private ListView AllLinksListView
        {
            get { return MainForm.lvwAllLinks; }
        }

        private ListView GroupedLinksListView
        {
            get { return MainForm.lvwGroupedLinks; }
        }

        private ListView LinkDetailsListView
        {
            get { return MainForm.lvwLinkDetails; }
        }


        public OBCMain MainForm;

        internal void UpdatePagesListViewItem(PageProperties pageProp)
        {
            PagesListView.BeginInvoke((MethodInvoker)delegate
            {
                PagesListView.Items[pageProp.index].SubItems[Convert.ToInt32(PageListColumns.Images)].Text = pageProp.imageCollection.Count.ToString();
                PagesListView.Items[pageProp.index].SubItems[Convert.ToInt32(PageListColumns.Status)].Text = pageProp.Status;
            });
        }

        internal void InitListViews()
        {
            PagesListView.Scrollable = true;
            PagesListView.View = View.Details;
            PagesListView.Sorting = SortOrder.Ascending;
            PagesListView.FullRowSelect = true;
            PagesListView.GridLines = true;
            PagesListView.Scrollable = true;
            PagesListView.HeaderStyle = ColumnHeaderStyle.Clickable;

            PagesListView.Columns.Add(PageListColumns.ID.ToString(), PageListColumns.ID.ToString(), 50);
            PagesListView.Columns.Add(PageListColumns.Url.ToString(), PageListColumns.Url.ToString(), 350);
            PagesListView.Columns.Add(PageListColumns.Size.ToString(), PageListColumns.Size.ToString(), 60);
            PagesListView.Columns.Add(PageListColumns.Status.ToString(), PageListColumns.Status.ToString(), 60);
            PagesListView.Columns.Add(PageListColumns.Images.ToString(), PageListColumns.Images.ToString(), 60);

            AllLinksListView.Scrollable = true;
            AllLinksListView.View = View.Details;
            AllLinksListView.Sorting = SortOrder.Ascending;
            AllLinksListView.FullRowSelect = true;
            AllLinksListView.GridLines = true;
            AllLinksListView.Scrollable = true;
            AllLinksListView.HeaderStyle = ColumnHeaderStyle.Clickable;

            AllLinksListView.Columns.Add(PageListColumns.ID.ToString(), PageListColumns.ID.ToString(), 50);
            AllLinksListView.Columns.Add(PageListColumns.Url.ToString(), PageListColumns.Url.ToString(), 350);
            AllLinksListView.Columns.Add(PageListColumns.Size.ToString(), PageListColumns.Size.ToString(), 60);
            AllLinksListView.Columns.Add(PageListColumns.Status.ToString(), PageListColumns.Status.ToString(), 60);
            AllLinksListView.Columns.Add(PageListColumns.Images.ToString(), PageListColumns.Images.ToString(), 60);


            GroupedLinksListView.Scrollable = true;
            GroupedLinksListView.View = View.Details;
            GroupedLinksListView.Sorting = SortOrder.Ascending;
            GroupedLinksListView.FullRowSelect = true;
            GroupedLinksListView.GridLines = true;
            GroupedLinksListView.Scrollable = true;
            GroupedLinksListView.HeaderStyle = ColumnHeaderStyle.Clickable;

            GroupedLinksListView.Columns.Add(PageListColumns.ID.ToString(), PageListColumns.ID.ToString(), 30);
            GroupedLinksListView.Columns.Add(PageListColumns.Url.ToString(), PageListColumns.Url.ToString(), 300);
            GroupedLinksListView.Columns.Add(PageListColumns.Size.ToString(), PageListColumns.Size.ToString(), 60);
            GroupedLinksListView.Columns.Add(PageListColumns.Status.ToString(), PageListColumns.Size.ToString(), 60);

            LinkDetailsListView.Scrollable = true;
            LinkDetailsListView.View = View.Details;
            LinkDetailsListView.Sorting = SortOrder.Ascending;
            LinkDetailsListView.FullRowSelect = true;
            LinkDetailsListView.GridLines = true;
            LinkDetailsListView.Scrollable = true;
            LinkDetailsListView.HeaderStyle = ColumnHeaderStyle.Clickable;

            LinkDetailsListView.Columns.Add(PageListColumns.ID.ToString(), PageListColumns.ID.ToString(), 50);
            LinkDetailsListView.Columns.Add(PageListColumns.Url.ToString(), PageListColumns.Url.ToString(), 350);
        }

        internal void AddItem2PagesListViewItem(PageProperties pageProp)
        {
            ListViewItem vwItem = new ListViewItem(pageProp.index.ToString());
            vwItem.SubItems.Add(pageProp.Url);
            vwItem.SubItems.Add("-1");
            vwItem.SubItems.Add("New");
            vwItem.SubItems.Add("-1");

            PagesListView.Items.Add(vwItem);
        }

        internal void AddItem2AllLinksListViewItem(PageProperties pageProp, int linkIndex)
        {
            LinkProperties linkProp = pageProp.imageCollection[linkIndex];

            ListViewItem vwItem = new ListViewItem(linkIndex.ToString());
            vwItem.SubItems.Add(linkProp.Url);
            vwItem.SubItems.Add("-1");
            vwItem.SubItems.Add("New");
            vwItem.SubItems.Add("-1");

            GroupedLinksListView.BeginInvoke((MethodInvoker)delegate
            {
                AllLinksListView.Items.Add(vwItem);
            });
        }

        private delegate ListViewItem GetListViewItemDelegate(ListView lvw, int index);

        //TODO:: Deadcode
        private ListViewItem GetListViewItem(ListView controlListView, int index)
        {
            ListViewItem lvwItem;

            if (controlListView.InvokeRequired)
            {
                // This is a worker thread so delegate the task.        
                lvwItem = (ListViewItem)controlListView.Invoke(new GetListViewItemDelegate(this.GetListViewItem), controlListView, index);
            }
            else
            {
                // This is the UI thread so perform the task.        
                lvwItem = controlListView.Items[index];
            }

            return lvwItem;
        }
    }
}
