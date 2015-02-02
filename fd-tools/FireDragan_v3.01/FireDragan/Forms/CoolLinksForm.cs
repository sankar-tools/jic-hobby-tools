using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace FireDragan
{
    /// <summary>
    /// Summary description for CoolLinksForm.
    /// </summary>
    public class CoolLinksForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox drpCategory;
        private System.Windows.Forms.ColumnHeader colHdrLink;
        private System.Windows.Forms.ColumnHeader colHdrCategory;
        private System.Windows.Forms.ListView lvwCoolLinks;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private ToolStrip tsCoollinks;
        private ToolStripButton tsbtnSave;
        private ToolStripButton tsbtnRemove;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox tscboCategories;
        private ToolStripButton tsbtnFilter;
        private StatusStrip ssCoollinks;
        private ToolStripStatusLabel tsstatMain;
        private TextBox txtRemarks;
        private ComboBox drpRating;
        private Label label4;
        private ColumnHeader colHdrRating;
        private ComboBox drpUrlType;
        private Label label6;
        private ToolStripButton tsbtnRefresh;
        private ColumnHeader colHdrUrlType;
        private ColumnHeader colHdrLastUpdated;
        private ColumnHeader colHdrDesc;
        private ColumnHeader colHdrRemarks;
        private ToolStripButton tsbtnEdit;
        private CheckBox chkLastVisited;
        private CheckBox chkNextSession;
        private ColumnHeader colHdrLastVisited;
        private ColumnHeader colHdrNext;
        private Label label5;

        public string CoolLink
        {
            get
            {
                return (txtLink.Text);
            }
            set
            {
                txtLink.Text = value;
            }
        }

        public CoolLinksForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //InitializeForm();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoolLinksForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.drpCategory = new System.Windows.Forms.ComboBox();
            this.lvwCoolLinks = new System.Windows.Forms.ListView();
            this.colHdrLink = new System.Windows.Forms.ColumnHeader();
            this.colHdrCategory = new System.Windows.Forms.ColumnHeader();
            this.colHdrRating = new System.Windows.Forms.ColumnHeader();
            this.colHdrUrlType = new System.Windows.Forms.ColumnHeader();
            this.colHdrLastUpdated = new System.Windows.Forms.ColumnHeader();
            this.colHdrDesc = new System.Windows.Forms.ColumnHeader();
            this.colHdrRemarks = new System.Windows.Forms.ColumnHeader();
            this.tsCoollinks = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscboCategories = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnFilter = new System.Windows.Forms.ToolStripButton();
            this.ssCoollinks = new System.Windows.Forms.StatusStrip();
            this.tsstatMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.drpRating = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.drpUrlType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLastVisited = new System.Windows.Forms.CheckBox();
            this.chkNextSession = new System.Windows.Forms.CheckBox();
            this.colHdrLastVisited = new System.Windows.Forms.ColumnHeader();
            this.colHdrNext = new System.Windows.Forms.ColumnHeader();
            this.tsCoollinks.SuspendLayout();
            this.ssCoollinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(55, 31);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(533, 20);
            this.txtLink.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desc";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(55, 54);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(627, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // drpCategory
            // 
            this.drpCategory.Location = new System.Drawing.Point(649, 30);
            this.drpCategory.Name = "drpCategory";
            this.drpCategory.Size = new System.Drawing.Size(231, 21);
            this.drpCategory.Sorted = true;
            this.drpCategory.TabIndex = 5;
            // 
            // lvwCoolLinks
            // 
            this.lvwCoolLinks.AllowColumnReorder = true;
            this.lvwCoolLinks.CheckBoxes = true;
            this.lvwCoolLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHdrLink,
            this.colHdrCategory,
            this.colHdrRating,
            this.colHdrUrlType,
            this.colHdrLastUpdated,
            this.colHdrLastVisited,
            this.colHdrNext,
            this.colHdrDesc,
            this.colHdrRemarks});
            this.lvwCoolLinks.FullRowSelect = true;
            this.lvwCoolLinks.GridLines = true;
            this.lvwCoolLinks.Location = new System.Drawing.Point(12, 148);
            this.lvwCoolLinks.Name = "lvwCoolLinks";
            this.lvwCoolLinks.ShowItemToolTips = true;
            this.lvwCoolLinks.Size = new System.Drawing.Size(962, 258);
            this.lvwCoolLinks.TabIndex = 7;
            this.lvwCoolLinks.UseCompatibleStateImageBehavior = false;
            this.lvwCoolLinks.View = System.Windows.Forms.View.Details;
            this.lvwCoolLinks.DoubleClick += new System.EventHandler(this.lvwCoolLinks_DoubleClick);
            this.lvwCoolLinks.SelectedIndexChanged += new System.EventHandler(this.lvwCoolLinks_SelectedIndexChanged);
            this.lvwCoolLinks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwCoolLinks_ColumnClick);
            // 
            // colHdrLink
            // 
            this.colHdrLink.Text = "Link";
            this.colHdrLink.Width = 250;
            // 
            // colHdrCategory
            // 
            this.colHdrCategory.Text = "Category";
            // 
            // colHdrRating
            // 
            this.colHdrRating.Text = "Rating";
            this.colHdrRating.Width = 25;
            // 
            // colHdrUrlType
            // 
            this.colHdrUrlType.Text = "UrlType";
            this.colHdrUrlType.Width = 150;
            // 
            // colHdrLastUpdated
            // 
            this.colHdrLastUpdated.Text = "Last Updated";
            // 
            // colHdrDesc
            // 
            this.colHdrDesc.DisplayIndex = 6;
            this.colHdrDesc.Text = "Desc";
            this.colHdrDesc.Width = 250;
            // 
            // colHdrRemarks
            // 
            this.colHdrRemarks.DisplayIndex = 7;
            this.colHdrRemarks.Text = "Remarks";
            this.colHdrRemarks.Width = 400;
            // 
            // tsCoollinks
            // 
            this.tsCoollinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnEdit,
            this.tsbtnSave,
            this.tsbtnRemove,
            this.toolStripSeparator1,
            this.tscboCategories,
            this.tsbtnFilter});
            this.tsCoollinks.Location = new System.Drawing.Point(0, 0);
            this.tsCoollinks.Name = "tsCoollinks";
            this.tsCoollinks.Size = new System.Drawing.Size(984, 25);
            this.tsCoollinks.TabIndex = 8;
            this.tsCoollinks.Text = "toolStrip1";
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(65, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEdit.Image = global::FireDragan.Properties.Resources.sig;
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbtnEdit.Text = "Edit";
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::FireDragan.Properties.Resources.save;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "Save";
            this.tsbtnSave.ToolTipText = "Save coollink to DB";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnRemove
            // 
            this.tsbtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRemove.Image = global::FireDragan.Properties.Resources.delete;
            this.tsbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemove.Name = "tsbtnRemove";
            this.tsbtnRemove.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRemove.Text = "Remove";
            this.tsbtnRemove.ToolTipText = "Remove coollink from DB";
            this.tsbtnRemove.Click += new System.EventHandler(this.tsbtnRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tscboCategories
            // 
            this.tscboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscboCategories.Name = "tscboCategories";
            this.tscboCategories.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbtnFilter
            // 
            this.tsbtnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFilter.Image = global::FireDragan.Properties.Resources.Go;
            this.tsbtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFilter.Name = "tsbtnFilter";
            this.tsbtnFilter.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFilter.Text = "Filter";
            this.tsbtnFilter.ToolTipText = "Filter coollinks";
            // 
            // ssCoollinks
            // 
            this.ssCoollinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsstatMain});
            this.ssCoollinks.Location = new System.Drawing.Point(0, 409);
            this.ssCoollinks.Name = "ssCoollinks";
            this.ssCoollinks.Size = new System.Drawing.Size(984, 22);
            this.ssCoollinks.TabIndex = 9;
            this.ssCoollinks.Text = "statusStrip1";
            // 
            // tsstatMain
            // 
            this.tsstatMain.Name = "tsstatMain";
            this.tsstatMain.Size = new System.Drawing.Size(969, 17);
            this.tsstatMain.Spring = true;
            this.tsstatMain.Text = "Ready...";
            this.tsstatMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(55, 78);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(752, 64);
            this.txtRemarks.TabIndex = 10;
            // 
            // drpRating
            // 
            this.drpRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpRating.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.drpRating.Location = new System.Drawing.Point(930, 29);
            this.drpRating.Name = "drpRating";
            this.drpRating.Size = new System.Drawing.Size(44, 21);
            this.drpRating.Sorted = true;
            this.drpRating.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(886, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rating";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Remarks";
            // 
            // drpUrlType
            // 
            this.drpUrlType.Location = new System.Drawing.Point(743, 54);
            this.drpUrlType.Name = "drpUrlType";
            this.drpUrlType.Size = new System.Drawing.Size(231, 21);
            this.drpUrlType.Sorted = true;
            this.drpUrlType.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(688, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Url Type";
            // 
            // chkLastVisited
            // 
            this.chkLastVisited.AutoSize = true;
            this.chkLastVisited.Location = new System.Drawing.Point(814, 81);
            this.chkLastVisited.Name = "chkLastVisited";
            this.chkLastVisited.Size = new System.Drawing.Size(80, 17);
            this.chkLastVisited.TabIndex = 16;
            this.chkLastVisited.Text = "Last Visited";
            this.chkLastVisited.UseVisualStyleBackColor = true;
            // 
            // chkNextSession
            // 
            this.chkNextSession.AutoSize = true;
            this.chkNextSession.Location = new System.Drawing.Point(814, 96);
            this.chkNextSession.Name = "chkNextSession";
            this.chkNextSession.Size = new System.Drawing.Size(88, 17);
            this.chkNextSession.TabIndex = 17;
            this.chkNextSession.Text = "Next Session";
            this.chkNextSession.UseVisualStyleBackColor = true;
            // 
            // colHdrLastVisited
            // 
            this.colHdrLastVisited.Text = "Last Visit";
            // 
            // colHdrNext
            // 
            this.colHdrNext.Text = "Next Visit";
            // 
            // CoolLinksForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 431);
            this.Controls.Add(this.chkNextSession);
            this.Controls.Add(this.chkLastVisited);
            this.Controls.Add(this.drpUrlType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.drpRating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.ssCoollinks);
            this.Controls.Add(this.tsCoollinks);
            this.Controls.Add(this.lvwCoolLinks);
            this.Controls.Add(this.drpCategory);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label1);
            this.Name = "CoolLinksForm";
            this.Text = "CoolLinksForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CoolLinksForm_Closing);
            this.Load += new System.EventHandler(this.CoolLinksForm_Load);
            this.tsCoollinks.ResumeLayout(false);
            this.tsCoollinks.PerformLayout();
            this.ssCoollinks.ResumeLayout(false);
            this.ssCoollinks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private void InitializeForm()
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbCommand cmd1 = new OleDbCommand();
            OleDbCommand cmd2 = new OleDbCommand();
            OleDbDataReader rdr = null;

            string constr = SettingsHelper.Current.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = "select distinct category from CoolLinks";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    drpCategory.Items.Add(rdr.GetString(0));
                    tscboCategories.Items.Add(rdr.GetString(0));
                }

                cn.Close();
                rdr.Close();

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
                cmd1.CommandText = "select siteUrl, category, rating, lastUpdate, descript, remarks, urlType, lastVisited, nextSession from CoolLinks";
                rdr = cmd1.ExecuteReader();

                while (rdr.Read())
                {
                    Add2List(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3).ToString(), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetDateTime(7).ToString(), rdr.GetString(8));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                System.Diagnostics.Debug.WriteLine(ex.Message);

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

        private void SaveSiteData()
        {
            DateTime dt = DateTime.MinValue;
            string bl = "No";

            if (chkLastVisited.Checked == true)
                dt = DateTime.Now;

            bl = (chkNextSession.Checked?"Yes":"No");

            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string constr = SettingsHelper.Current.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = "delete from CoolLinks where SiteUrl ='" + txtLink.Text + "'";
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


                cmd.Parameters[0].Value = txtLink.Text;
                cmd.Parameters[1].Value = drpCategory.Text;
                cmd.Parameters[2].Value = txtDesc.Text;
                cmd.Parameters[3].Value = txtRemarks.Text;
                cmd.Parameters[4].Value = DateTime.Now;
                cmd.Parameters[5].Value = drpRating.Items[drpRating.SelectedIndex].ToString();
                cmd.Parameters[6].Value = drpUrlType.Text;
                cmd.Parameters[7].Value = dt;
                cmd.Parameters[8].Value = bl;

                cmd.ExecuteNonQuery();

                Add2List(txtLink.Text,
                    drpCategory.Text,
                    drpRating.Items[drpRating.SelectedIndex].ToString(),
                    DateTime.Now.ToString(),
                    txtDesc.Text,
                    txtRemarks.Text,
                    drpUrlType.Text,
                    dt.ToString(),
                    bl.ToString());

                tsstatMain.Text = "Coollink successfully added to DB [" + txtLink.Text + "]";

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

        private void Add2List(string url, string cate, string rating, string lastUpdate, string desc, string remarks, string urlType, string lastVisit, string nextSession)
        {
            RemoveFromList(url);

            ListViewItem lvw = lvwCoolLinks.Items.Add(url);
            lvw.SubItems.Add(cate);
            lvw.SubItems.Add(rating);
            lvw.SubItems.Add(urlType);
            lvw.SubItems.Add(lastUpdate);
            lvw.SubItems.Add(lastVisit);
            lvw.SubItems.Add(nextSession);
            lvw.SubItems.Add(desc);
            lvw.SubItems.Add(remarks);
        }

        private void RemoveFromList(string url)
        {
            foreach (ListViewItem item in lvwCoolLinks.Items)
            {
                if (item.SubItems[0].Text == url)
                    item.Remove();
            }
        }

        private void AssignData2Controls(string url, string cate, string rating, string urlType, string desc, string remarks)
        {
            txtLink.Text = url;
            drpCategory.Text = cate;
            drpRating.SelectedIndex = Convert.ToInt32(rating) - 1;
            txtDesc.Text = desc;
            txtRemarks.Text = remarks;
            drpUrlType.Text = urlType;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveSiteData();
        }

        private void tsbtnRemove_Click(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string constr = SettingsHelper.Current.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = "delete from CoolLinks where SiteUrl ='" + txtLink.Text + "'";
                cmd.ExecuteNonQuery();

                RemoveFromList(txtLink.Text);

                tsstatMain.Text = "Coollink removed from DB [" + txtLink.Text + "]";
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

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            lvwCoolLinks.Items.Clear();
            drpUrlType.Items.Clear();
            drpCategory.Items.Clear();
            tscboCategories.Items.Clear();

            InitializeForm();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvwCoolLinks.SelectedItems[0];

            //AssignData2Controls(string url, string cate, string rating, string urlType, string lastUpdated, string lastVisited, string nextSession, string desc, string remarks)
            AssignData2Controls(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[7].Text, item.SubItems[8].Text);
        }

        public event UriSelected UriSelected;

        private void lvwCoolLinks_DoubleClick(object sender, System.EventArgs e)
        {
            UriSelectedEventArgs args = new UriSelectedEventArgs(lvwCoolLinks.SelectedItems[0].SubItems[0].Text);

            UriSelected(this, args);
        }

        private void lvwCoolLinks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwCoolLinks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer cmp = new ListViewItemComparer(e.Column);
            if (lvwCoolLinks.Sorting == SortOrder.Ascending)
            {
                lvwCoolLinks.Sorting = SortOrder.Descending;
                cmp.Sort = SortOrder.Descending;
            }
            else
            {
                lvwCoolLinks.Sorting = SortOrder.Ascending;
                cmp.Sort = SortOrder.Ascending;
            }

            // Sort last updated column as date
            if (e.Column == 4) cmp.SortAs = SortAs.Date;

            // Sort last updated column as date
            if (e.Column == 5) cmp.SortAs = SortAs.Date;

            //Assign sorting process
            this.lvwCoolLinks.ListViewItemSorter = cmp;

        }

        private void CoolLinksForm_Load(object sender, EventArgs e)
        {

        }

        private void CoolLinksForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
