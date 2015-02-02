namespace FireDragan
{
    partial class LinkedImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkedImageForm));
            this.lvwLinks = new System.Windows.Forms.ListView();
            this.colhdrLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwLinkHierarchy = new System.Windows.Forms.ListView();
            this.colhdrLinkHir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrLinkHirStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwImageLinks = new System.Windows.Forms.ListView();
            this.colhdrId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrReferrer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdrCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsHtmlImages = new System.Windows.Forms.ToolStrip();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.tstxtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUnselect = new System.Windows.Forms.ToolStripButton();
            this.tscboPriority = new System.Windows.Forms.ToolStripComboBox();
            this.tscboCategory = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnAddLinks = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemoveAll = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.chkInDomain = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsHtmlImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwLinks
            // 
            this.lvwLinks.CheckBoxes = true;
            this.lvwLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhdrLink,
            this.colhdrStatus});
            this.lvwLinks.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwLinks.GridLines = true;
            this.lvwLinks.Location = new System.Drawing.Point(0, 0);
            this.lvwLinks.Name = "lvwLinks";
            this.lvwLinks.Size = new System.Drawing.Size(843, 97);
            this.lvwLinks.TabIndex = 0;
            this.lvwLinks.UseCompatibleStateImageBehavior = false;
            this.lvwLinks.View = System.Windows.Forms.View.Details;
            this.lvwLinks.SelectedIndexChanged += new System.EventHandler(this.lvwLinks_SelectedIndexChanged);
            this.lvwLinks.DoubleClick += new System.EventHandler(this.lvwLinks_DoubleClick);
            // 
            // colhdrLink
            // 
            this.colhdrLink.Text = "Html Link";
            this.colhdrLink.Width = 700;
            // 
            // colhdrStatus
            // 
            this.colhdrStatus.Text = "Status";
            this.colhdrStatus.Width = 90;
            // 
            // lvwLinkHierarchy
            // 
            this.lvwLinkHierarchy.CheckBoxes = true;
            this.lvwLinkHierarchy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhdrLinkHir,
            this.colhdrLinkHirStatus});
            this.lvwLinkHierarchy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwLinkHierarchy.GridLines = true;
            this.lvwLinkHierarchy.Location = new System.Drawing.Point(0, 97);
            this.lvwLinkHierarchy.Name = "lvwLinkHierarchy";
            this.lvwLinkHierarchy.Size = new System.Drawing.Size(843, 213);
            this.lvwLinkHierarchy.TabIndex = 1;
            this.lvwLinkHierarchy.UseCompatibleStateImageBehavior = false;
            // 
            // colhdrLinkHir
            // 
            this.colhdrLinkHir.Text = "Link Hierarchy";
            this.colhdrLinkHir.Width = 700;
            // 
            // colhdrLinkHirStatus
            // 
            this.colhdrLinkHirStatus.Text = "Status";
            this.colhdrLinkHirStatus.Width = 90;
            // 
            // lvwImageLinks
            // 
            this.lvwImageLinks.CheckBoxes = true;
            this.lvwImageLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhdrId,
            this.colhdr,
            this.colhdrReferrer,
            this.colhdrPriority,
            this.colhdrCategory});
            this.lvwImageLinks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvwImageLinks.FullRowSelect = true;
            this.lvwImageLinks.GridLines = true;
            this.lvwImageLinks.Location = new System.Drawing.Point(0, 360);
            this.lvwImageLinks.Name = "lvwImageLinks";
            this.lvwImageLinks.Size = new System.Drawing.Size(843, 131);
            this.lvwImageLinks.TabIndex = 2;
            this.lvwImageLinks.UseCompatibleStateImageBehavior = false;
            this.lvwImageLinks.View = System.Windows.Forms.View.Details;
            // 
            // colhdrId
            // 
            this.colhdrId.Text = "#";
            // 
            // colhdr
            // 
            this.colhdr.Text = "Url";
            this.colhdr.Width = 250;
            // 
            // colhdrReferrer
            // 
            this.colhdrReferrer.Text = "Referrer";
            this.colhdrReferrer.Width = 250;
            // 
            // colhdrPriority
            // 
            this.colhdrPriority.Text = "Priority";
            // 
            // colhdrCategory
            // 
            this.colhdrCategory.Text = "Category";
            this.colhdrCategory.Width = 200;
            // 
            // tsHtmlImages
            // 
            this.tsHtmlImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClear,
            this.tstxtFilter,
            this.tsbtnFilter,
            this.tsbtnUnselect,
            this.tscboPriority,
            this.tscboCategory,
            this.tsbtnAddLinks,
            this.toolStripSeparator2,
            this.tslblCount,
            this.toolStripSeparator1,
            this.tsbtnRemove,
            this.tsbtnRemoveAll,
            this.tsbtnSave});
            this.tsHtmlImages.Location = new System.Drawing.Point(0, 310);
            this.tsHtmlImages.Name = "tsHtmlImages";
            this.tsHtmlImages.Size = new System.Drawing.Size(843, 25);
            this.tsHtmlImages.TabIndex = 3;
            this.tsHtmlImages.Text = "toolStrip1";
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(66, 22);
            this.tsbtnClear.Text = "Refresh";
            this.tsbtnClear.ToolTipText = "Refresh fetched links";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // tstxtFilter
            // 
            this.tstxtFilter.Name = "tstxtFilter";
            this.tstxtFilter.Size = new System.Drawing.Size(150, 25);
            // 
            // tsbtnFilter
            // 
            this.tsbtnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFilter.Image")));
            this.tsbtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFilter.Name = "tsbtnFilter";
            this.tsbtnFilter.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFilter.Text = "Go!";
            this.tsbtnFilter.ToolTipText = "Select links to filter";
            this.tsbtnFilter.Click += new System.EventHandler(this.tsbtnFilter_Click);
            // 
            // tsbtnUnselect
            // 
            this.tsbtnUnselect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUnselect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUnselect.Image")));
            this.tsbtnUnselect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUnselect.Name = "tsbtnUnselect";
            this.tsbtnUnselect.Size = new System.Drawing.Size(23, 22);
            this.tsbtnUnselect.Text = "Unselect";
            this.tsbtnUnselect.ToolTipText = "Unselect filtered links";
            this.tsbtnUnselect.Click += new System.EventHandler(this.tsbtnUnselect_Click);
            // 
            // tscboPriority
            // 
            this.tscboPriority.Items.AddRange(new object[] {
            "None",
            "High",
            "Medium",
            "Low"});
            this.tscboPriority.Name = "tscboPriority";
            this.tscboPriority.Size = new System.Drawing.Size(80, 25);
            this.tscboPriority.Text = "High";
            // 
            // tscboCategory
            // 
            this.tscboCategory.Name = "tscboCategory";
            this.tscboCategory.Size = new System.Drawing.Size(121, 25);
            this.tscboCategory.Click += new System.EventHandler(this.tscboCategory_Click);
            // 
            // tsbtnAddLinks
            // 
            this.tsbtnAddLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddLinks.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddLinks.Image")));
            this.tsbtnAddLinks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddLinks.Name = "tsbtnAddLinks";
            this.tsbtnAddLinks.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAddLinks.Text = "Add Links";
            this.tsbtnAddLinks.ToolTipText = "Add selected links";
            this.tsbtnAddLinks.Click += new System.EventHandler(this.tsbtnAddLinks_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tslblCount
            // 
            this.tslblCount.Name = "tslblCount";
            this.tslblCount.Size = new System.Drawing.Size(62, 22);
            this.tslblCount.Text = "tslblCount";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnRemove
            // 
            this.tsbtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRemove.Image = global::FireDragan.Properties.Resources.delete;
            this.tsbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemove.Name = "tsbtnRemove";
            this.tsbtnRemove.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRemove.Text = "Remove";
            this.tsbtnRemove.ToolTipText = "Remove selected items from filtered list (List #3)";
            this.tsbtnRemove.Click += new System.EventHandler(this.tsbtnRemove_Click);
            // 
            // tsbtnRemoveAll
            // 
            this.tsbtnRemoveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRemoveAll.Image")));
            this.tsbtnRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveAll.Name = "tsbtnRemoveAll";
            this.tsbtnRemoveAll.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRemoveAll.Text = "Remove All";
            this.tsbtnRemoveAll.ToolTipText = "Remove all items from filtered list (List #3)";
            this.tsbtnRemoveAll.Click += new System.EventHandler(this.tsbtnRemoveAll_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::FireDragan.Properties.Resources.save;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "Save Links to DB";
            this.tsbtnSave.ToolTipText = "Save all the links in filtered list (List#3) to database";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // chkInDomain
            // 
            this.chkInDomain.AutoSize = true;
            this.chkInDomain.Checked = true;
            this.chkInDomain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInDomain.Location = new System.Drawing.Point(769, 321);
            this.chkInDomain.Name = "chkInDomain";
            this.chkInDomain.Size = new System.Drawing.Size(74, 17);
            this.chkInDomain.TabIndex = 4;
            this.chkInDomain.Text = "In Domain";
            this.chkInDomain.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(843, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LinkedImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 491);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkInDomain);
            this.Controls.Add(this.tsHtmlImages);
            this.Controls.Add(this.lvwLinkHierarchy);
            this.Controls.Add(this.lvwLinks);
            this.Controls.Add(this.lvwImageLinks);
            this.Name = "LinkedImageForm";
            this.Text = "HtmlImagesForm";
            this.tsHtmlImages.ResumeLayout(false);
            this.tsHtmlImages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwLinks;
        private System.Windows.Forms.ListView lvwLinkHierarchy;
        private System.Windows.Forms.ColumnHeader colhdrLink;
        private System.Windows.Forms.ColumnHeader colhdrLinkHir;
        private System.Windows.Forms.ListView lvwImageLinks;
        private System.Windows.Forms.ColumnHeader colhdrId;
        private System.Windows.Forms.ColumnHeader colhdr;
        private System.Windows.Forms.ColumnHeader colhdrReferrer;
        private System.Windows.Forms.ColumnHeader colhdrPriority;
        private System.Windows.Forms.ToolStrip tsHtmlImages;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnRemove;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveAll;
        private System.Windows.Forms.ToolStripTextBox tstxtFilter;
        private System.Windows.Forms.ToolStripButton tsbtnFilter;
        private System.Windows.Forms.ToolStripComboBox tscboPriority;
        private System.Windows.Forms.ToolStripButton tsbtnAddLinks;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.ToolStripButton tsbtnUnselect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox chkInDomain;
        private System.Windows.Forms.ColumnHeader colhdrStatus;
        private System.Windows.Forms.ColumnHeader colhdrLinkHirStatus;
        private System.Windows.Forms.ToolStripLabel tslblCount;
        private System.Windows.Forms.ToolStripComboBox tscboCategory;
        private System.Windows.Forms.ColumnHeader colhdrCategory;
        private System.Windows.Forms.StatusStrip statusStrip1;

    }
}