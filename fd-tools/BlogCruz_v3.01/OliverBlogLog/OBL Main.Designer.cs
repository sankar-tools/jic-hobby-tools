namespace OliverBlogLog
{
    partial class OBLMain
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
            this.controlsGroup = new System.Windows.Forms.GroupBox();
            this.btnExplore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBros = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtEndIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.gridsGroup = new System.Windows.Forms.GroupBox();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.sbtMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.gridsSplitter = new System.Windows.Forms.SplitContainer();
            this.lvwLogEntries = new System.Windows.Forms.ListView();
            this.detailTabs = new System.Windows.Forms.TabControl();
            this.linksTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwLogSessions = new System.Windows.Forms.ListView();
            this.lvwStats = new System.Windows.Forms.ListView();
            this.allLinksTab = new System.Windows.Forms.TabPage();
            this.lvwAllLinks = new System.Windows.Forms.ListView();
            this.statsTab = new System.Windows.Forms.TabPage();
            this.txtStats = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.controlsGroup.SuspendLayout();
            this.gridsGroup.SuspendLayout();
            this.statusMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridsSplitter)).BeginInit();
            this.gridsSplitter.Panel1.SuspendLayout();
            this.gridsSplitter.Panel2.SuspendLayout();
            this.gridsSplitter.SuspendLayout();
            this.detailTabs.SuspendLayout();
            this.linksTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.allLinksTab.SuspendLayout();
            this.statsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsGroup
            // 
            this.controlsGroup.Controls.Add(this.btnExplore);
            this.controlsGroup.Controls.Add(this.label2);
            this.controlsGroup.Controls.Add(this.btnReload);
            this.controlsGroup.Controls.Add(this.txtKeywords);
            this.controlsGroup.Controls.Add(this.btnSave);
            this.controlsGroup.Controls.Add(this.btnRefresh);
            this.controlsGroup.Controls.Add(this.btnBros);
            this.controlsGroup.Controls.Add(this.label8);
            this.controlsGroup.Controls.Add(this.txtID);
            this.controlsGroup.Controls.Add(this.txtUrl);
            this.controlsGroup.Controls.Add(this.txtEndIndex);
            this.controlsGroup.Controls.Add(this.label5);
            this.controlsGroup.Controls.Add(this.label1);
            this.controlsGroup.Controls.Add(this.txtRating);
            this.controlsGroup.Controls.Add(this.label4);
            this.controlsGroup.Controls.Add(this.label3);
            this.controlsGroup.Controls.Add(this.txtStartIndex);
            this.controlsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlsGroup.Location = new System.Drawing.Point(0, 0);
            this.controlsGroup.Name = "controlsGroup";
            this.controlsGroup.Size = new System.Drawing.Size(1028, 68);
            this.controlsGroup.TabIndex = 23;
            this.controlsGroup.TabStop = false;
            // 
            // btnExplore
            // 
            this.btnExplore.Location = new System.Drawing.Point(983, 10);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(55, 24);
            this.btnExplore.TabIndex = 65;
            this.btnExplore.Text = "&Explore";
            this.btnExplore.UseVisualStyleBackColor = true;
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "&Keywords";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(963, 35);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(55, 24);
            this.btnReload.TabIndex = 63;
            this.btnReload.Text = "&Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(237, 38);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeywords.Size = new System.Drawing.Size(486, 20);
            this.txtKeywords.TabIndex = 58;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(922, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 24);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1019, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(55, 24);
            this.btnRefresh.TabIndex = 55;
            this.btnRefresh.Text = "&B ID";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnBlogID_Click);
            // 
            // btnBros
            // 
            this.btnBros.Location = new System.Drawing.Point(922, 10);
            this.btnBros.Name = "btnBros";
            this.btnBros.Size = new System.Drawing.Size(55, 24);
            this.btnBros.TabIndex = 53;
            this.btnBros.Text = "&Browse";
            this.btnBros.UseVisualStyleBackColor = true;
            this.btnBros.Click += new System.EventHandler(this.btnBros_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "&ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(38, 37);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(145, 20);
            this.txtID.TabIndex = 52;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(38, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(881, 20);
            this.txtUrl.TabIndex = 38;
            // 
            // txtEndIndex
            // 
            this.txtEndIndex.Location = new System.Drawing.Point(817, 38);
            this.txtEndIndex.Name = "txtEndIndex";
            this.txtEndIndex.Size = new System.Drawing.Size(36, 20);
            this.txtEndIndex.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(854, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "&Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "&Url";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(883, 38);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(36, 20);
            this.txtRating.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(724, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "&Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(791, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "&End";
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Location = new System.Drawing.Point(753, 38);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(36, 20);
            this.txtStartIndex.TabIndex = 42;
            // 
            // gridsGroup
            // 
            this.gridsGroup.Controls.Add(this.statusMain);
            this.gridsGroup.Controls.Add(this.gridsSplitter);
            this.gridsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridsGroup.Location = new System.Drawing.Point(0, 68);
            this.gridsGroup.Name = "gridsGroup";
            this.gridsGroup.Size = new System.Drawing.Size(1028, 415);
            this.gridsGroup.TabIndex = 24;
            this.gridsGroup.TabStop = false;
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbtMain});
            this.statusMain.Location = new System.Drawing.Point(3, 390);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(1022, 22);
            this.statusMain.TabIndex = 27;
            this.statusMain.Text = "Ready...";
            // 
            // sbtMain
            // 
            this.sbtMain.Name = "sbtMain";
            this.sbtMain.Size = new System.Drawing.Size(48, 17);
            this.sbtMain.Text = "Ready...";
            // 
            // gridsSplitter
            // 
            this.gridsSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridsSplitter.Location = new System.Drawing.Point(3, 16);
            this.gridsSplitter.MinimumSize = new System.Drawing.Size(0, 20);
            this.gridsSplitter.Name = "gridsSplitter";
            this.gridsSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // gridsSplitter.Panel1
            // 
            this.gridsSplitter.Panel1.Controls.Add(this.lvwLogEntries);
            // 
            // gridsSplitter.Panel2
            // 
            this.gridsSplitter.Panel2.Controls.Add(this.detailTabs);
            this.gridsSplitter.Size = new System.Drawing.Size(1022, 396);
            this.gridsSplitter.SplitterDistance = 236;
            this.gridsSplitter.TabIndex = 26;
            // 
            // lvwLogEntries
            // 
            this.lvwLogEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLogEntries.FullRowSelect = true;
            this.lvwLogEntries.GridLines = true;
            this.lvwLogEntries.Location = new System.Drawing.Point(0, 0);
            this.lvwLogEntries.Name = "lvwLogEntries";
            this.lvwLogEntries.Size = new System.Drawing.Size(1022, 236);
            this.lvwLogEntries.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwLogEntries.TabIndex = 24;
            this.lvwLogEntries.UseCompatibleStateImageBehavior = false;
            this.lvwLogEntries.View = System.Windows.Forms.View.Details;
            this.lvwLogEntries.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwLogEntries_ColumnClick);
            this.lvwLogEntries.SelectedIndexChanged += new System.EventHandler(this.lvwLogEntries_SelectedIndexChanged);
            this.lvwLogEntries.DoubleClick += new System.EventHandler(this.lvwLogEntries_DoubleClick);
            // 
            // detailTabs
            // 
            this.detailTabs.Controls.Add(this.linksTab);
            this.detailTabs.Controls.Add(this.allLinksTab);
            this.detailTabs.Controls.Add(this.statsTab);
            this.detailTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTabs.Location = new System.Drawing.Point(0, 0);
            this.detailTabs.Name = "detailTabs";
            this.detailTabs.SelectedIndex = 0;
            this.detailTabs.Size = new System.Drawing.Size(1022, 156);
            this.detailTabs.TabIndex = 0;
            // 
            // linksTab
            // 
            this.linksTab.Controls.Add(this.splitContainer1);
            this.linksTab.Location = new System.Drawing.Point(4, 22);
            this.linksTab.Name = "linksTab";
            this.linksTab.Padding = new System.Windows.Forms.Padding(3);
            this.linksTab.Size = new System.Drawing.Size(1014, 130);
            this.linksTab.TabIndex = 0;
            this.linksTab.Text = "Grouped";
            this.linksTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwLogSessions);
            this.splitContainer1.Panel1MinSize = 30;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwStats);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 124);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvwLogSessions
            // 
            this.lvwLogSessions.CheckBoxes = true;
            this.lvwLogSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLogSessions.GridLines = true;
            this.lvwLogSessions.Location = new System.Drawing.Point(0, 0);
            this.lvwLogSessions.Name = "lvwLogSessions";
            this.lvwLogSessions.Size = new System.Drawing.Size(432, 124);
            this.lvwLogSessions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwLogSessions.TabIndex = 27;
            this.lvwLogSessions.UseCompatibleStateImageBehavior = false;
            this.lvwLogSessions.View = System.Windows.Forms.View.Details;
            this.lvwLogSessions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwLogSessions_ColumnClick);
            // 
            // lvwStats
            // 
            this.lvwStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwStats.GridLines = true;
            this.lvwStats.Location = new System.Drawing.Point(0, 0);
            this.lvwStats.Name = "lvwStats";
            this.lvwStats.Size = new System.Drawing.Size(572, 124);
            this.lvwStats.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwStats.TabIndex = 27;
            this.lvwStats.UseCompatibleStateImageBehavior = false;
            this.lvwStats.View = System.Windows.Forms.View.Details;
            // 
            // allLinksTab
            // 
            this.allLinksTab.Controls.Add(this.lvwAllLinks);
            this.allLinksTab.Location = new System.Drawing.Point(4, 22);
            this.allLinksTab.Name = "allLinksTab";
            this.allLinksTab.Size = new System.Drawing.Size(1072, 130);
            this.allLinksTab.TabIndex = 2;
            this.allLinksTab.Text = "All";
            this.allLinksTab.UseVisualStyleBackColor = true;
            // 
            // lvwAllLinks
            // 
            this.lvwAllLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwAllLinks.GridLines = true;
            this.lvwAllLinks.Location = new System.Drawing.Point(0, 0);
            this.lvwAllLinks.Name = "lvwAllLinks";
            this.lvwAllLinks.Size = new System.Drawing.Size(1072, 174);
            this.lvwAllLinks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwAllLinks.TabIndex = 28;
            this.lvwAllLinks.UseCompatibleStateImageBehavior = false;
            this.lvwAllLinks.View = System.Windows.Forms.View.Details;
            // 
            // statsTab
            // 
            this.statsTab.Controls.Add(this.txtStats);
            this.statsTab.Controls.Add(this.textBox1);
            this.statsTab.Location = new System.Drawing.Point(4, 22);
            this.statsTab.Name = "statsTab";
            this.statsTab.Padding = new System.Windows.Forms.Padding(3);
            this.statsTab.Size = new System.Drawing.Size(1072, 130);
            this.statsTab.TabIndex = 1;
            this.statsTab.Text = "Stats";
            this.statsTab.UseVisualStyleBackColor = true;
            // 
            // txtStats
            // 
            this.txtStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStats.Location = new System.Drawing.Point(3, 3);
            this.txtStats.Multiline = true;
            this.txtStats.Name = "txtStats";
            this.txtStats.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStats.Size = new System.Drawing.Size(1066, 124);
            this.txtStats.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // OBLMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 483);
            this.Controls.Add(this.gridsGroup);
            this.Controls.Add(this.controlsGroup);
            this.Name = "OBLMain";
            this.Text = "Form1";
            this.controlsGroup.ResumeLayout(false);
            this.controlsGroup.PerformLayout();
            this.gridsGroup.ResumeLayout(false);
            this.gridsGroup.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.gridsSplitter.Panel1.ResumeLayout(false);
            this.gridsSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridsSplitter)).EndInit();
            this.gridsSplitter.ResumeLayout(false);
            this.detailTabs.ResumeLayout(false);
            this.linksTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.allLinksTab.ResumeLayout(false);
            this.statsTab.ResumeLayout(false);
            this.statsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlsGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtEndIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.GroupBox gridsGroup;
        private System.Windows.Forms.SplitContainer gridsSplitter;
        internal System.Windows.Forms.ListView lvwLogEntries;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBros;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel sbtMain;
        private System.Windows.Forms.TabControl detailTabs;
        private System.Windows.Forms.TabPage linksTab;
        private System.Windows.Forms.TabPage statsTab;
        private System.Windows.Forms.TextBox txtStats;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ListView lvwLogSessions;
        internal System.Windows.Forms.ListView lvwStats;
        private System.Windows.Forms.TabPage allLinksTab;
        internal System.Windows.Forms.ListView lvwAllLinks;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExplore;

    }
}

