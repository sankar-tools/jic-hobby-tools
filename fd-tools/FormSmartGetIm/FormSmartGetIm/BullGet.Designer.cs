namespace FormSmartGetIm
{
    partial class BullGet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BullGet));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnStart = new System.Windows.Forms.ToolStripButton();
            this.pnlAddUrl = new System.Windows.Forms.Panel();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.txtAddUrl = new System.Windows.Forms.TextBox();
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.pnlAddUrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnStart,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(988, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(69, 22);
            this.tsbtnAdd.Text = "Url (++)";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // tsbtnStart
            // 
            this.tsbtnStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStart.Image")));
            this.tsbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStart.Name = "tsbtnStart";
            this.tsbtnStart.Size = new System.Drawing.Size(51, 22);
            this.tsbtnStart.Text = "Start";
            this.tsbtnStart.Click += new System.EventHandler(this.tsbtnStart_Click);
            // 
            // pnlAddUrl
            // 
            this.pnlAddUrl.Controls.Add(this.btnAddUrl);
            this.pnlAddUrl.Controls.Add(this.txtAddUrl);
            this.pnlAddUrl.Location = new System.Drawing.Point(98, 223);
            this.pnlAddUrl.Name = "pnlAddUrl";
            this.pnlAddUrl.Size = new System.Drawing.Size(792, 51);
            this.pnlAddUrl.TabIndex = 2;
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
            this.txtAddUrl.Text = "http://localhost:9000/gallery";
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 25);
            this.mainSplitter.Name = "mainSplitter";
            this.mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.pnlTree);
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.pnlMsg);
            this.mainSplitter.Size = new System.Drawing.Size(988, 471);
            this.mainSplitter.SplitterDistance = 357;
            this.mainSplitter.TabIndex = 4;
            // 
            // pnlTree
            // 
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(988, 357);
            this.pnlTree.TabIndex = 0;
            // 
            // pnlMsg
            // 
            this.pnlMsg.Controls.Add(this.txtLog);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMsg.Location = new System.Drawing.Point(0, 0);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(988, 110);
            this.pnlMsg.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(988, 110);
            this.txtLog.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(90, 22);
            this.toolStripButton1.Text = "Show Again";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BullGet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 496);
            this.Controls.Add(this.mainSplitter);
            this.Controls.Add(this.pnlAddUrl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BullGet";
            this.Text = "BullGet";
            this.Load += new System.EventHandler(this.BullGet_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlAddUrl.ResumeLayout(false);
            this.pnlAddUrl.PerformLayout();
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripButton tsbtnStart;
        private System.Windows.Forms.Panel pnlAddUrl;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.TextBox txtAddUrl;
        private System.Windows.Forms.SplitContainer mainSplitter;

        private System.Windows.Forms.Panel pnlMsg;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}