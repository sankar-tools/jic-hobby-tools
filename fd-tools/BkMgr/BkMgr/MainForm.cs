using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fd.tools.bookmarks.objects;
using System.Data.OleDb;
using fd.lib.ui.common.db;
using fd.lib.ui.common;
using fd.lib.ui.common.error;

namespace BkMgr
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            InitControls();

        }

        private void InitControls()
        {
            lvwLinks.View = View.Details;
            lvwLinks.FullRowSelect = true;
            lvwLinks.Columns.Clear();

            lvwLinks.Columns.Add(LinkColumns.Url.ToString(), LinkColumns.Url.ToString(), 200);
            lvwLinks.Columns.Add(LinkColumns.Categories.ToString(), LinkColumns.Categories.ToString(), 200);
            lvwLinks.Columns.Add(LinkColumns.Type.ToString(), LinkColumns.Type.ToString(), 60);
            lvwLinks.Columns.Add(LinkColumns.Rating.ToString(), LinkColumns.Rating.ToString(), 30);
            lvwLinks.Columns.Add(LinkColumns.Queued.ToString(), LinkColumns.Queued.ToString(), 30);
            lvwLinks.Columns.Add(LinkColumns.Modified.ToString(), LinkColumns.Modified.ToString(), 60);
            lvwLinks.Columns.Add(LinkColumns.Visited.ToString(), LinkColumns.Visited.ToString(), 60);
            lvwLinks.Columns.Add(LinkColumns.Desc.ToString(), LinkColumns.Desc.ToString(), 200);
            lvwLinks.Columns.Add(LinkColumns.Remarks.ToString(), LinkColumns.Remarks.ToString(), 200);

            LoadControlsFromDB();
        }

        private void Add2List(LinkProperties link)
        {
            RemoveFromList(link.Url);

            ListViewItem lvw = lvwLinks.Items.Add(LinkColumns.Url.ToString(), link.Url,0);
            lvw.SubItems.Add(link.Category);
            lvw.SubItems.Add(link.UrlType); 
            lvw.SubItems.Add(link.Rating);
            lvw.SubItems.Add(link.Queued.ToString());
            lvw.SubItems.Add(link.LastModified.ToString());
            lvw.SubItems.Add(link.LastVisited.ToString());
            lvw.SubItems.Add(link.Desc);
            lvw.SubItems.Add(link.Remarks);
        }

        private void RemoveFromList(string url)
        {
            foreach (ListViewItem item in lvwLinks.Items)
            {
                if (item.SubItems[0].Text == url)
                    item.Remove();
            }
        }

        private void LoadControlsFromDB()
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbCommand cmd1 = new OleDbCommand();
            OleDbCommand cmd2 = new OleDbCommand();
            OleDbDataReader rdr = null;

            string constr = ConfigData.ConnectionString;

            List<string> tags = new List<string>();

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = "select distinct category from CoolLinks";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string[] t = rdr.GetString(0).Split(new char[] {','});
                    foreach (string s in t)
                    {
                        tags.Add(s.Trim());
                    }
                }

                cn.Close();
                rdr.Close();

                tags.Sort();
                HashSet<string> utags = new HashSet<string>(tags, StringComparer.OrdinalIgnoreCase);
                chkTags.Items.Clear();
                foreach(string tag in utags)
                    chkTags.Items.Add(tag);

                cn.Open();

                cmd2.Connection = cn;
                cmd2.CommandText = "select distinct urlType from CoolLinks";
                rdr = cmd2.ExecuteReader();

                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                        drpUrlType.Items.Add(rdr.GetString(0));
                }

                cn.Close();
                rdr.Close();

                cn.Open();

                cmd1.Connection = cn;
                cmd1.CommandText = "select siteUrl, category, urlType, rating, descript, remarks, lastUpdate, lastVisited, nextSession from CoolLinks";
                rdr = cmd1.ExecuteReader();

                while (rdr.Read())
                {
                    LinkProperties link = new LinkProperties();
                    link.Url = rdr.GetString(0);
                    link.Category = rdr.GetString(1);
                    link.UrlType = rdr.GetString(2);
                    link.Rating = rdr.GetString(3);
                    link.Desc = rdr.GetString(4);
                    link.Remarks = rdr.GetString(5);
                    link.LastModified = rdr.GetDateTime(6);
                    link.LastVisited = rdr.GetDateTime(7);
                    link.Queued = rdr.GetString(8);

                    Add2List(link);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                //System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            finally
            {
                cmd.Dispose();
                cmd1.Dispose();
                cmd2.Dispose();

                rdr.Close();
                cn.Close();
                cn.Dispose();
            }
        }

        private void LoadLinksFromDB(List<string> selectedTags)
        {
            lvwLinks.Items.Clear();

            OleDbConnection cn = new OleDbConnection(ConfigData.ConnectionString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader rdr = null;

            try
            {
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = "select siteUrl, category, urlType, rating, descript, remarks, lastUpdate, lastVisited, nextSession from CoolLinks";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    LinkProperties link = new LinkProperties();
                    link.Url = rdr.GetString(0);
                    link.Category = rdr.GetString(1);
                    link.UrlType = rdr.GetString(2);
                    link.Rating = rdr.GetString(3);
                    link.Desc = rdr.GetString(4);
                    link.Remarks = rdr.GetString(5);
                    link.LastModified = rdr.GetDateTime(6);
                    link.LastVisited = rdr.GetDateTime(7);
                    link.Queued = rdr.GetString(8);

                    if (IsTagSelected(link.Category, selectedTags) == true)
                        Add2List(link);
                }
            }
            catch (Exception ex)
            {
                ErrorDialog.Show("DB Error", "Error reading links from DB", ex);
            }
            finally
            {
                cmd.Dispose();
                rdr.Close();
                cn.Close();
                cn.Dispose();
            }
        }

        private bool IsTagSelected(string p, List<string> selectedTags)
        {
            foreach (string tag in selectedTags)
                if (p.Contains(tag))
                    return true;

            return false;
        }

        private bool ParseBoolString(string p)
        {
            if (p.ToUpper() == "YES" || p.ToUpper() == "TRUE" || p.ToUpper() == "1")
                return true;
            return false;
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadControlsFromDB();

        }

        private void tsbtnProperties_Click(object sender, EventArgs e)
        {
            ConfigForm frm = new ConfigForm();
            frm.Show();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (IsControlsValid())
                Save2DB();

        }

        private void Save2DB()
        {
            LinkProperties lnk = new LinkProperties();
            lnk.Url = txtUrl.Text;
            lnk.Category = txtCategories.Text;
            lnk.Desc = txtDesc.Text;
            lnk.Remarks = txtRemarks.Text;
            lnk.Queued = chkQueue.Checked?"Yes":"No";
            lnk.Rating = drpRating.Text;
            lnk.UrlType = drpUrlType.Text;
            lnk.LastModified = DateTime.Now;
            lnk.LastVisited = DateTime.Now;

            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                cn.ConnectionString = ConfigData.ConnectionString;;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = "delete from CoolLinks where SiteUrl ='" + lnk.Url + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into CoolLinks (SiteUrl, Category, Descript, remarks, lastUpdate, rating, urlType, lastVisited, nextSession) values(?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("SiteUrl", OleDbType.VarChar);
                cmd.Parameters.Add("Category", OleDbType.VarChar);
                cmd.Parameters.Add("Descript", OleDbType.VarChar);
                cmd.Parameters.Add("remarks", OleDbType.LongVarChar);
                cmd.Parameters.Add("lastUpdate", OleDbType.Date);
                cmd.Parameters.Add("Rating", OleDbType.VarChar);
                cmd.Parameters.Add("UrlType", OleDbType.VarChar);
                cmd.Parameters.Add("lastVisited", OleDbType.Date);
                cmd.Parameters.Add("nextSession", OleDbType.VarChar);


                cmd.Parameters[0].Value = lnk.Url;
                cmd.Parameters[1].Value = lnk.Category;
                cmd.Parameters[2].Value = lnk.Desc;
                cmd.Parameters[3].Value = lnk.Remarks;
                cmd.Parameters[4].Value = lnk.LastModified;
                cmd.Parameters[5].Value = lnk.Rating;
                cmd.Parameters[6].Value = lnk.UrlType;
                cmd.Parameters[7].Value = lnk.LastVisited;
                cmd.Parameters[8].Value = lnk.Queued;

                cmd.ExecuteNonQuery();

                Add2List(lnk);

                MessageBox.Show("Coollink successfully added to DB [" + lnk.Url + "]");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        private bool IsControlsValid()
        {
            if (!DataValidator.IsString(txtUrl, "Url"))
                return false;

            if (!DataValidator.IsString(txtCategories, "Tags"))
                return false;

            if (!DataValidator.IsString(drpUrlType, "Link Type"))
                return false;

            return true;
        }

        private void tsbtnBrowse_Click(object sender, EventArgs e)
        {
            Sys.OpenInBrowser(lvwLinks.SelectedItems[0].Text);
        }

        private void lvwCoolLinks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer cmp = new ListViewItemComparer(e.Column);
            if (lvwLinks.Sorting == SortOrder.Ascending)
            {
                lvwLinks.Sorting = SortOrder.Descending;
                cmp.Sort = SortOrder.Descending;
            }
            else
            {
                lvwLinks.Sorting = SortOrder.Ascending;
                cmp.Sort = SortOrder.Ascending;
            }

            // Sort last updated column as date
            if (e.Column == 4) cmp.SortAs = SortAs.Date;

            // Sort last updated column as date
            if (e.Column == 5) cmp.SortAs = SortAs.Date;

            //Assign sorting process
            this.lvwLinks.ListViewItemSorter = cmp;
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvwLinks.SelectedItems[0];
            if (item != null)
            {
                txtUrl.Text = item.SubItems[0].Text;
                txtCategories.Text = item.SubItems[1].Text;
                drpUrlType.Text = item.SubItems[2].Text;
                drpRating.Text = item.SubItems[3].Text; 
                chkQueue.Checked = (item.SubItems[4].Text.ToUpper() == "YES") ? true : false;

                txtDesc.Text = item.SubItems[7].Text;
                txtRemarks.Text = item.SubItems[8].Text;
            }
        }

        private void tbnTagsApplyFilter_Click(object sender, EventArgs e)
        {
            List<string> tagsSelcted = new List<string>();

            foreach (object itemChecked in chkTags.CheckedItems)
            {
                tagsSelcted.Add(itemChecked.ToString());
            }

            LoadLinksFromDB(tagsSelcted);
        }

        private void tsbtnTagsClearFilter_Click(object sender, EventArgs e)
        {
            LoadControlsFromDB();
        }
    }

    enum LinkColumns
    { 
        Url = 0,
        Categories = 1,
        Type = 2,
        Rating = 3,
        Queued = 4,
        Modified = 5,
        Visited = 6,
        Desc = 7,
        Remarks = 8
    }
}
