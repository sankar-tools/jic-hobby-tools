namespace FireDragan
{
    partial class NavigatorForm : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorForm));
            this.tsNavigator = new System.Windows.Forms.ToolStrip();
            this.tscmbUsageMode = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnEncode = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDecode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstxtPre = new System.Windows.Forms.ToolStripTextBox();
            this.tslblUrl = new System.Windows.Forms.ToolStripLabel();
            this.tstxtPost = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnGo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbtnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnSearchGo = new System.Windows.Forms.ToolStripButton();
            this.LinksListVw = new System.Windows.Forms.ListView();
            this.IdCol = new System.Windows.Forms.ColumnHeader();
            this.LinkCol = new System.Windows.Forms.ColumnHeader();
            this.StatusCol = new System.Windows.Forms.ColumnHeader();
            this.UseCol = new System.Windows.Forms.ColumnHeader();
            this.tsNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsNavigator
            // 
            this.tsNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmbUsageMode,
            this.tsbtnEncode,
            this.tsbtnDecode,
            this.toolStripSeparator1,
            this.tstxtPre,
            this.tslblUrl,
            this.tstxtPost,
            this.tsbtnGo,
            this.toolStripSeparator2,
            this.tsbtnSave,
            this.tsbtnRemove,
            this.tsbtnReset,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tstxtSearch,
            this.tsbtnSearchGo});
            this.tsNavigator.Location = new System.Drawing.Point(0, 0);
            this.tsNavigator.Name = "tsNavigator";
            this.tsNavigator.Size = new System.Drawing.Size(1021, 25);
            this.tsNavigator.Stretch = true;
            this.tsNavigator.TabIndex = 0;
            this.tsNavigator.Text = "toolStrip1";
            // 
            // tscmbUsageMode
            // 
            this.tscmbUsageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbUsageMode.Items.AddRange(new object[] {
            "Select",
            "Link",
            "Status"});
            this.tscmbUsageMode.Name = "tscmbUsageMode";
            this.tscmbUsageMode.Size = new System.Drawing.Size(121, 25);
            this.tscmbUsageMode.SelectedIndexChanged += new System.EventHandler(this.tscmbUsageMode_SelectedIndexChanged);
            // 
            // tsbtnEncode
            // 
            this.tsbtnEncode.Image = global::FireDragan.Properties.Resources.prio_high;
            this.tsbtnEncode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEncode.Name = "tsbtnEncode";
            this.tsbtnEncode.Size = new System.Drawing.Size(62, 22);
            this.tsbtnEncode.Text = "Encode";
            this.tsbtnEncode.Click += new System.EventHandler(this.tsbtnEncode_Click);
            // 
            // tsbtnDecode
            // 
            this.tsbtnDecode.Image = global::FireDragan.Properties.Resources.prio_low1;
            this.tsbtnDecode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDecode.Name = "tsbtnDecode";
            this.tsbtnDecode.Size = new System.Drawing.Size(63, 22);
            this.tsbtnDecode.Text = "Decode";
            this.tsbtnDecode.Click += new System.EventHandler(this.tsbtnDecode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstxtPre
            // 
            this.tstxtPre.Name = "tstxtPre";
            this.tstxtPre.Size = new System.Drawing.Size(100, 25);
            // 
            // tslblUrl
            // 
            this.tslblUrl.Name = "tslblUrl";
            this.tslblUrl.Size = new System.Drawing.Size(52, 22);
            this.tslblUrl.Text = "<<Url>>";
            // 
            // tstxtPost
            // 
            this.tstxtPost.Name = "tstxtPost";
            this.tstxtPost.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbtnGo
            // 
            this.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnGo.Image = global::FireDragan.Properties.Resources.Go;
            this.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGo.Name = "tsbtnGo";
            this.tsbtnGo.Size = new System.Drawing.Size(28, 22);
            this.tsbtnGo.Text = "Go!";
            this.tsbtnGo.Click += new System.EventHandler(this.tsbtnGo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::FireDragan.Properties.Resources.save;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "Save";
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
            this.tsbtnRemove.Click += new System.EventHandler(this.tsbtnRemove_Click);
            // 
            // tsbtnReset
            // 
            this.tsbtnReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReset.Image")));
            this.tsbtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReset.Name = "tsbtnReset";
            this.tsbtnReset.Size = new System.Drawing.Size(55, 22);
            this.tsbtnReset.Text = "Reset";
            this.tsbtnReset.ToolTipText = "Reset all navigation links";
            this.tsbtnReset.Click += new System.EventHandler(this.tsbtnReset_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel1.Text = "&Search";
            // 
            // tstxtSearch
            // 
            this.tstxtSearch.Name = "tstxtSearch";
            this.tstxtSearch.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbtnSearchGo
            // 
            this.tsbtnSearchGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSearchGo.Image = global::FireDragan.Properties.Resources.search;
            this.tsbtnSearchGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearchGo.Name = "tsbtnSearchGo";
            this.tsbtnSearchGo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSearchGo.Text = "Go!";
            this.tsbtnSearchGo.Click += new System.EventHandler(this.tsbtnSearchGo_Click);
            // 
            // LinksListVw
            // 
            this.LinksListVw.AllowColumnReorder = true;
            this.LinksListVw.CheckBoxes = true;
            this.LinksListVw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdCol,
            this.LinkCol,
            this.StatusCol,
            this.UseCol});
            this.LinksListVw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinksListVw.FullRowSelect = true;
            this.LinksListVw.GridLines = true;
            this.LinksListVw.Location = new System.Drawing.Point(0, 25);
            this.LinksListVw.Name = "LinksListVw";
            this.LinksListVw.Size = new System.Drawing.Size(1021, 374);
            this.LinksListVw.TabIndex = 1;
            this.LinksListVw.UseCompatibleStateImageBehavior = false;
            this.LinksListVw.View = System.Windows.Forms.View.Details;
            this.LinksListVw.DoubleClick += new System.EventHandler(this.LinksListVw_DoubleClick);
            this.LinksListVw.SelectedIndexChanged += new System.EventHandler(this.LinksListVw_SelectedIndexChanged);
            this.LinksListVw.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LinksListVw_ColumnClick);
            // 
            // IdCol
            // 
            this.IdCol.Text = "#";
            // 
            // LinkCol
            // 
            this.LinkCol.Text = "Link";
            this.LinkCol.Width = 250;
            // 
            // StatusCol
            // 
            this.StatusCol.Text = "Status";
            this.StatusCol.Width = 250;
            // 
            // UseCol
            // 
            this.UseCol.Text = "Use";
            this.UseCol.Width = 250;
            // 
            // NavigatorForm
            // 
            this.ClientSize = new System.Drawing.Size(1021, 399);
            this.Controls.Add(this.LinksListVw);
            this.Controls.Add(this.tsNavigator);
            this.Name = "NavigatorForm";
            this.Text = "NavigatorForm";
            this.tsNavigator.ResumeLayout(false);
            this.tsNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsNavigator;
        private System.Windows.Forms.ListView LinksListVw;
        private System.Windows.Forms.ColumnHeader IdCol;
        private System.Windows.Forms.ColumnHeader LinkCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.ColumnHeader UseCol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox tscmbUsageMode;
        private System.Windows.Forms.ToolStripButton tsbtnEncode;
        private System.Windows.Forms.ToolStripTextBox tstxtPre;
        private System.Windows.Forms.ToolStripLabel tslblUrl;
        private System.Windows.Forms.ToolStripTextBox tstxtPost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnGo;
        private System.Windows.Forms.ToolStripButton tsbtnDecode;
        private System.Windows.Forms.ToolStripButton tsbtnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstxtSearch;
        private System.Windows.Forms.ToolStripButton tsbtnSearchGo;
        private System.Windows.Forms.ToolStripButton tsbtnRemove;
    }
}