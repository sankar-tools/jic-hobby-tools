namespace FormSmartGetIm
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddUrl = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRun = new System.Windows.Forms.ToolStripButton();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.split = new System.Windows.Forms.SplitContainer();
            this.pnlAddUrl = new System.Windows.Forms.Panel();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.txtAddUrl = new System.Windows.Forms.TextBox();
            this.lvwUrls = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwProcess = new System.Windows.Forms.ListView();
            this.colId2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUrl2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMsg = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.pnlAddUrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddUrl,
            this.tsbtnRun,
            this.btnMsg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAddUrl
            // 
            this.tsbtnAddUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnAddUrl.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddUrl.Image")));
            this.tsbtnAddUrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddUrl.Name = "tsbtnAddUrl";
            this.tsbtnAddUrl.Size = new System.Drawing.Size(42, 22);
            this.tsbtnAddUrl.Text = "Url++";
            this.tsbtnAddUrl.Click += new System.EventHandler(this.tsbtnAddUrl_Click);
            // 
            // tsbtnRun
            // 
            this.tsbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnRun.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRun.Image")));
            this.tsbtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRun.Name = "tsbtnRun";
            this.tsbtnRun.Size = new System.Drawing.Size(35, 22);
            this.tsbtnRun.Text = "Start";
            this.tsbtnRun.Click += new System.EventHandler(this.tsbtnRun_Click);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 376);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1024, 124);
            this.txtLog.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 351);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(3, 25);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.pnlAddUrl);
            this.split.Panel1.Controls.Add(this.lvwUrls);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.lvwProcess);
            this.split.Size = new System.Drawing.Size(1021, 351);
            this.split.SplitterDistance = 198;
            this.split.TabIndex = 3;
            // 
            // pnlAddUrl
            // 
            this.pnlAddUrl.Controls.Add(this.btnAddUrl);
            this.pnlAddUrl.Controls.Add(this.txtAddUrl);
            this.pnlAddUrl.Location = new System.Drawing.Point(117, 144);
            this.pnlAddUrl.Name = "pnlAddUrl";
            this.pnlAddUrl.Size = new System.Drawing.Size(792, 51);
            this.pnlAddUrl.TabIndex = 1;
            // 
            // btnAddUrl
            // 
            this.btnAddUrl.Location = new System.Drawing.Point(691, 15);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(98, 23);
            this.btnAddUrl.TabIndex = 1;
            this.btnAddUrl.Text = "Add";
            this.btnAddUrl.UseVisualStyleBackColor = true;
            this.btnAddUrl.Click += new System.EventHandler(this.btnAddUrl_Click);
            // 
            // txtAddUrl
            // 
            this.txtAddUrl.Location = new System.Drawing.Point(12, 17);
            this.txtAddUrl.Name = "txtAddUrl";
            this.txtAddUrl.Size = new System.Drawing.Size(673, 20);
            this.txtAddUrl.TabIndex = 0;
            this.txtAddUrl.TextChanged += new System.EventHandler(this.txtAddUrl_TextChanged);
            // 
            // lvwUrls
            // 
            this.lvwUrls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colUrl,
            this.colTitle,
            this.colSize,
            this.colStatus});
            this.lvwUrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwUrls.GridLines = true;
            this.lvwUrls.Location = new System.Drawing.Point(0, 0);
            this.lvwUrls.Name = "lvwUrls";
            this.lvwUrls.Size = new System.Drawing.Size(1021, 198);
            this.lvwUrls.TabIndex = 0;
            this.lvwUrls.UseCompatibleStateImageBehavior = false;
            this.lvwUrls.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "#";
            // 
            // colUrl
            // 
            this.colUrl.Text = "Url";
            this.colUrl.Width = 200;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 250;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // lvwProcess
            // 
            this.lvwProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId2,
            this.colUrl2,
            this.colStatus2});
            this.lvwProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwProcess.GridLines = true;
            this.lvwProcess.Location = new System.Drawing.Point(0, 0);
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new System.Drawing.Size(1021, 149);
            this.lvwProcess.TabIndex = 0;
            this.lvwProcess.UseCompatibleStateImageBehavior = false;
            this.lvwProcess.View = System.Windows.Forms.View.Details;
            // 
            // colId2
            // 
            this.colId2.Text = "#";
            // 
            // colUrl2
            // 
            this.colUrl2.Text = "Url";
            this.colUrl2.Width = 200;
            // 
            // colStatus2
            // 
            this.colStatus2.Text = "Status";
            // 
            // btnMsg
            // 
            this.btnMsg.CheckOnClick = true;
            this.btnMsg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMsg.Image = ((System.Drawing.Image)(resources.GetObject("btnMsg.Image")));
            this.btnMsg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.Size = new System.Drawing.Size(94, 22);
            this.btnMsg.Text = "Show Messages";
            this.btnMsg.Click += new System.EventHandler(this.btnMsg_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 500);
            this.Controls.Add(this.split);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Main";
            this.Text = "FormSmartGetIm - Main";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.pnlAddUrl.ResumeLayout(false);
            this.pnlAddUrl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAddUrl;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ListView lvwUrls;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colUrl;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ListView lvwProcess;
        private System.Windows.Forms.ColumnHeader colId2;
        private System.Windows.Forms.ColumnHeader colUrl2;
        private System.Windows.Forms.ColumnHeader colStatus2;
        private System.Windows.Forms.Panel pnlAddUrl;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.TextBox txtAddUrl;
        private System.Windows.Forms.ToolStripButton tsbtnRun;
        private System.Windows.Forms.ToolStripButton btnMsg;
    }
}

