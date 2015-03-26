namespace BkMgr
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnProperties = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnTagsClearFilter = new System.Windows.Forms.ToolStripButton();
            this.tbnTagsApplyFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.pnlTags = new System.Windows.Forms.Panel();
            this.chkTags = new System.Windows.Forms.CheckedListBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lvwLinks = new System.Windows.Forms.ListView();
            this.colhdrLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrCategories = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrVisited = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrQueued = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrRating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.drpRating = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkQueue = new System.Windows.Forms.CheckBox();
            this.drpUrlType = new System.Windows.Forms.ComboBox();
            this.txtCategories = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlTags.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnProperties,
            this.tsbtnRefresh,
            this.toolStripSeparator1,
            this.tsbtnTagsClearFilter,
            this.tbnTagsApplyFilter,
            this.toolStripSeparator2,
            this.tsbtnBrowse,
            this.toolStripSeparator3,
            this.tsbtnEdit,
            this.tsbtnSave,
            this.tsbtnDelete});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(923, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnProperties
            // 
            this.tsbtnProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnProperties.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnProperties.Image")));
            this.tsbtnProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnProperties.Name = "tsbtnProperties";
            this.tsbtnProperties.Size = new System.Drawing.Size(64, 22);
            this.tsbtnProperties.Text = "Properties";
            this.tsbtnProperties.Click += new System.EventHandler(this.tsbtnProperties_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(50, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnTagsClearFilter
            // 
            this.tsbtnTagsClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnTagsClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTagsClearFilter.Image")));
            this.tsbtnTagsClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTagsClearFilter.Name = "tsbtnTagsClearFilter";
            this.tsbtnTagsClearFilter.Size = new System.Drawing.Size(67, 22);
            this.tsbtnTagsClearFilter.Text = "Clear Filter";
            this.tsbtnTagsClearFilter.Click += new System.EventHandler(this.tsbtnTagsClearFilter_Click);
            // 
            // tbnTagsApplyFilter
            // 
            this.tbnTagsApplyFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbnTagsApplyFilter.Image = ((System.Drawing.Image)(resources.GetObject("tbnTagsApplyFilter.Image")));
            this.tbnTagsApplyFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnTagsApplyFilter.Name = "tbnTagsApplyFilter";
            this.tbnTagsApplyFilter.Size = new System.Drawing.Size(71, 22);
            this.tbnTagsApplyFilter.Text = "Apply Filter";
            this.tbnTagsApplyFilter.Click += new System.EventHandler(this.tbnTagsApplyFilter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnBrowse
            // 
            this.tsbtnBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBrowse.Image")));
            this.tsbtnBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBrowse.Name = "tsbtnBrowse";
            this.tsbtnBrowse.Size = new System.Drawing.Size(49, 22);
            this.tsbtnBrowse.Text = "Browse";
            this.tsbtnBrowse.Click += new System.EventHandler(this.tsbtnBrowse_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEdit.Image")));
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(31, 22);
            this.tsbtnEdit.Text = "Edit";
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(35, 22);
            this.tsbtnSave.Text = "Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(44, 22);
            this.tsbtnDelete.Text = "Delete";
            // 
            // pnlTags
            // 
            this.pnlTags.Controls.Add(this.chkTags);
            this.pnlTags.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTags.Location = new System.Drawing.Point(0, 25);
            this.pnlTags.Name = "pnlTags";
            this.pnlTags.Size = new System.Drawing.Size(200, 405);
            this.pnlTags.TabIndex = 3;
            // 
            // chkTags
            // 
            this.chkTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTags.FormattingEnabled = true;
            this.chkTags.Location = new System.Drawing.Point(0, 0);
            this.chkTags.Name = "chkTags";
            this.chkTags.Size = new System.Drawing.Size(200, 405);
            this.chkTags.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lvwLinks);
            this.pnlRight.Controls.Add(this.pnlControls);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(200, 25);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(723, 405);
            this.pnlRight.TabIndex = 4;
            // 
            // lvwLinks
            // 
            this.lvwLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhdrLink,
            this.colhdrCategories,
            this.colhdrType,
            this.colhdrLastModified,
            this.colhdrVisited,
            this.colhdrQueued,
            this.colhdrRating,
            this.colhdrDesc,
            this.colhdrRemarks});
            this.lvwLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLinks.Location = new System.Drawing.Point(0, 152);
            this.lvwLinks.Name = "lvwLinks";
            this.lvwLinks.Size = new System.Drawing.Size(723, 253);
            this.lvwLinks.TabIndex = 1;
            this.lvwLinks.UseCompatibleStateImageBehavior = false;
            this.lvwLinks.View = System.Windows.Forms.View.Details;
            // 
            // colhdrLink
            // 
            this.colhdrLink.Text = "Link";
            this.colhdrLink.Width = 200;
            // 
            // colhdrCategories
            // 
            this.colhdrCategories.Text = "Categories";
            this.colhdrCategories.Width = 200;
            // 
            // colhdrType
            // 
            this.colhdrType.Text = "Type";
            // 
            // colhdrLastModified
            // 
            this.colhdrLastModified.Text = "Modified";
            // 
            // colhdrVisited
            // 
            this.colhdrVisited.Text = "Visited";
            // 
            // colhdrQueued
            // 
            this.colhdrQueued.Text = "Q";
            this.colhdrQueued.Width = 20;
            // 
            // colhdrRating
            // 
            this.colhdrRating.Text = "Rating";
            this.colhdrRating.Width = 30;
            // 
            // colhdrDesc
            // 
            this.colhdrDesc.Text = "Desc";
            this.colhdrDesc.Width = 150;
            // 
            // colhdrRemarks
            // 
            this.colhdrRemarks.Text = "Remarks";
            this.colhdrRemarks.Width = 150;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.drpRating);
            this.pnlControls.Controls.Add(this.txtDesc);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.txtRemarks);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.chkQueue);
            this.pnlControls.Controls.Add(this.drpUrlType);
            this.pnlControls.Controls.Add(this.txtCategories);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.txtUrl);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(723, 152);
            this.pnlControls.TabIndex = 0;
            // 
            // drpRating
            // 
            this.drpRating.FormattingEnabled = true;
            this.drpRating.Location = new System.Drawing.Point(599, 35);
            this.drpRating.Name = "drpRating";
            this.drpRating.Size = new System.Drawing.Size(121, 21);
            this.drpRating.TabIndex = 12;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(34, 99);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(558, 20);
            this.txtDesc.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Desc";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(34, 125);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(558, 20);
            this.txtRemarks.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Remarks";
            // 
            // chkQueue
            // 
            this.chkQueue.AutoSize = true;
            this.chkQueue.Location = new System.Drawing.Point(599, 63);
            this.chkQueue.Name = "chkQueue";
            this.chkQueue.Size = new System.Drawing.Size(92, 17);
            this.chkQueue.TabIndex = 6;
            this.chkQueue.Text = "Add to Queue";
            this.chkQueue.UseVisualStyleBackColor = true;
            // 
            // drpUrlType
            // 
            this.drpUrlType.FormattingEnabled = true;
            this.drpUrlType.Location = new System.Drawing.Point(599, 6);
            this.drpUrlType.Name = "drpUrlType";
            this.drpUrlType.Size = new System.Drawing.Size(121, 21);
            this.drpUrlType.TabIndex = 5;
            // 
            // txtCategories
            // 
            this.txtCategories.Location = new System.Drawing.Point(34, 32);
            this.txtCategories.Multiline = true;
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCategories.Size = new System.Drawing.Size(558, 61);
            this.txtCategories.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tags";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(34, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(558, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 430);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTags);
            this.Controls.Add(this.tsMain);
            this.Name = "frmMain";
            this.Text = "Bookmarks Manager";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlTags.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.Panel pnlTags;
        private System.Windows.Forms.CheckedListBox chkTags;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ListView lvwLinks;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.TextBox txtCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpUrlType;
        private System.Windows.Forms.CheckBox chkQueue;
        private System.Windows.Forms.ToolStripButton tsbtnProperties;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnTagsClearFilter;
        private System.Windows.Forms.ToolStripButton tbnTagsApplyFilter;
        private System.Windows.Forms.ColumnHeader colhdrLink;
        private System.Windows.Forms.ColumnHeader colhdrCategories;
        private System.Windows.Forms.ColumnHeader colhdrType;
        private System.Windows.Forms.ColumnHeader colhdrLastModified;
        private System.Windows.Forms.ColumnHeader colhdrVisited;
        private System.Windows.Forms.ColumnHeader colhdrQueued;
        private System.Windows.Forms.ColumnHeader colhdrRating;
        private System.Windows.Forms.ColumnHeader colhdrDesc;
        private System.Windows.Forms.ColumnHeader colhdrRemarks;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpRating;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnBrowse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnEdit;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;


    }
}

