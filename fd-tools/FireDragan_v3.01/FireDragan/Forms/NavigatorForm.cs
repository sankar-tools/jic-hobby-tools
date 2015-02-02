using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FireDragan
{
    public partial class NavigatorForm : Form
    {
        public NavigatorForm()
        {
            InitializeComponent();

            this.AutoScroll = true;
        }

        private PageLinkManager pageLinks = null;

        public PageLinkManager PageLinks
        {
            get { return pageLinks; }
            set { pageLinks = value; }
        }

        public void Show()
        {
            base.Show();
            Refresh();
        }

        public void Refresh()
        {
            LinksListVw.Items.Clear();

            if (PageLinks != null)
            {
                PageLink[] pgLinks = pageLinks.GetLinks();
                for (int i = 0; i < pgLinks.Length; i++)
                {
                    ListViewItem item = this.LinksListVw.Items.Add((i+1).ToString());
                    item.SubItems.Add(pgLinks[i].Link);
                    item.SubItems.Add(pgLinks[i].Status);
                    item.SubItems.Add(pgLinks[i].BrowseLink);
                }
            }
        }

        private void tscmbUsageMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tscmbUsageMode.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < LinksListVw.Items.Count; i++)
                    {
                        LinksListVw.Items[i].SubItems[3].Text = "";
                    }
                    break;

                case 1:
                    for (int i = 0; i < LinksListVw.Items.Count; i++)
                    {
                        LinksListVw.Items[i].SubItems[3].Text = LinksListVw.Items[i].SubItems[1].Text;
                    }
                    break;

                case 2:
                    for (int i = 0; i < LinksListVw.Items.Count; i++)
                    {
                        LinksListVw.Items[i].SubItems[3].Text = LinksListVw.Items[i].SubItems[2].Text;
                    }
                    break;

            }
        }

        private void tsbtnEncode_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LinksListVw.Items.Count; i++)
            {
                LinksListVw.Items[i].SubItems[3].Text = Uri.EscapeDataString(LinksListVw.Items[i].SubItems[3].Text);
            }
        }

        private void tsbtnDecode_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LinksListVw.Items.Count; i++)
            {
                LinksListVw.Items[i].SubItems[3].Text = Uri.UnescapeDataString(LinksListVw.Items[i].SubItems[3].Text);
            }

        }

        private void tsbtnGo_Click(object sender, EventArgs e)
        {
            // Chop all the string till the first occurance of pre string
            if (tstxtPre.Text.Length != 0)
            {
                for (int i = 0; i < LinksListVw.Items.Count; i++)
                {
                    string text = LinksListVw.Items[i].SubItems[3].Text;
                    int firstOccurance = text.IndexOf(tstxtPre.Text);
                    int startPoint = 0;

                    if (firstOccurance > 0)
                    {
                        startPoint = firstOccurance + tstxtPre.Text.Length;
                    }

                    LinksListVw.Items[i].SubItems[3].Text =
                        LinksListVw.Items[i].SubItems[3].Text.Substring(startPoint);
                }
            }

            // Chop all the string from the last occurance of the post string
            if (tstxtPost.Text.Length != 0)
            {
                for (int i = 0; i < LinksListVw.Items.Count; i++)
                {
                    string text = LinksListVw.Items[i].SubItems[3].Text;
                    int lastOccurance = LinksListVw.Items[i].SubItems[3].Text.LastIndexOf(tstxtPost.Text);
                    int newlength = text.Length;

                    if (lastOccurance > 0)
                    {
                        newlength = lastOccurance;
                    }

                    LinksListVw.Items[i].SubItems[3].Text = text.Substring(0, newlength);
                }
            }

        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (PageLinks != null)
            {
                PageLink[] pgLinks = pageLinks.GetLinks();
                for (int i = 0; i < pgLinks.Length; i++)
                {
                    pgLinks[i].BrowseLink = LinksListVw.Items[i].SubItems[3].Text;
                }

                pageLinks.SetLinks(pgLinks);
            }

        }

        private void LinksListVw_DoubleClick(object sender, EventArgs e)
        {
            UriSelectedEventArgs args = new UriSelectedEventArgs(LinksListVw.SelectedItems[0].SubItems[3].Text);

            UriSelected(this, args);
        }

        public event UriSelected UriSelected;
        public event NavigatorReset NavigatorReset;

        private void NavigatorForm_Load(object sender, EventArgs e)
        {

        }

        private void NavigatorForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void tsbtnReset_Click(object sender, EventArgs e)
        {
            LinksListVw.Items.Clear();
   
            //EventArgs args = new EventArgs();
            //NavigatorReset(this, args);

            //if (PageLinks != null)
            //{
            //    PageLink[] pgLinks = pageLinks.GetLinks();
            //    for (int i = 0; i < pgLinks.Length; i++)
            //    {
            //        pgLinks[i].BrowseLink = string.Empty;
            //    }

            //    pageLinks.SetLinks(pgLinks);
            //}

            pageLinks.Clear();
            pageLinks.IsGarbage = true;
        }

        private void LinksListVw_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnSearchGo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LinksListVw.Items.Count; i++)
            {
                LinksListVw.Items[i].Checked = false;

                for (int j = 0; j < LinksListVw.Columns.Count; j++)
                    if (LinksListVw.Items[i].SubItems[j].Text.ToUpper().Contains(tstxtSearch.Text.ToUpper()))
                        LinksListVw.Items[i].Checked = true;
            }
        }

        private void tsbtnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LinksListVw.Items.Count; )
            {
                if (LinksListVw.Items[i].Checked)
                {
                    LinksListVw.Items[i].Remove();
                }
                else
                    i++;
            }

        }

        private void LinksListVw_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer cmp = new ListViewItemComparer(e.Column);
            if (LinksListVw.Sorting == SortOrder.Ascending)
            {
                LinksListVw.Sorting = SortOrder.Descending;
                cmp.Sort = SortOrder.Descending;
            }
            else
            {
                LinksListVw.Sorting = SortOrder.Ascending;
                cmp.Sort = SortOrder.Ascending;
            }
            //Column 1 should be sorted in interger format
            if (e.Column == 0) cmp.SortAs = SortAs.Integer;

            this.LinksListVw.ListViewItemSorter = cmp;

        }

    }


    public class UriSelectedEventArgs : System.EventArgs
    {
        // Stores the new value.
        private string newUri;

        // Create a new instance of the 
        // ValueUpdatedEventArgs class.
        // newValue represents the change to the value.
        public UriSelectedEventArgs(string newValue)
        {
            this.newUri = newValue;
        }

        // Gets the updated value.
        public string NewUri
        {
            get
            {
                return this.newUri;
            }
        }

    }
    



}