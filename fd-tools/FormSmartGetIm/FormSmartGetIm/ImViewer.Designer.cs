namespace FormSmartGetIm
{
    partial class ImViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOk = new System.Windows.Forms.ToolStripButton();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnSelectNone = new System.Windows.Forms.ToolStripButton();
            this.btnSelectInverse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.listImg = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOk,
            this.toolStripSeparator1,
            this.btnSelectAll,
            this.btnSelectNone,
            this.btnSelectInverse});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1009, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOk
            // 
            this.tsbtnOk.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOk.Image")));
            this.tsbtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOk.Name = "tsbtnOk";
            this.tsbtnOk.Size = new System.Drawing.Size(42, 22);
            this.tsbtnOk.Text = "Ok";
            this.tsbtnOk.Click += new System.EventHandler(this.tsbtnOk_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(41, 22);
            this.btnSelectAll.Text = "All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(56, 22);
            this.btnSelectNone.Text = "None";
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectInverse
            // 
            this.btnSelectInverse.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectInverse.Image")));
            this.btnSelectInverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectInverse.Name = "btnSelectInverse";
            this.btnSelectInverse.Size = new System.Drawing.Size(64, 22);
            this.btnSelectInverse.Text = "Inverse";
            this.btnSelectInverse.Click += new System.EventHandler(this.btnSelectInverse_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // listImg
            // 
            this.listImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listImg.Location = new System.Drawing.Point(0, 25);
            this.listImg.Name = "listImg";
            this.listImg.Size = new System.Drawing.Size(1009, 522);
            this.listImg.TabIndex = 2;
            this.listImg.UseCompatibleStateImageBehavior = false;
            // 
            // ImViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 547);
            this.Controls.Add(this.listImg);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ImViewer";
            this.Text = "ImViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
        private System.Windows.Forms.ToolStripButton btnSelectNone;
        private System.Windows.Forms.ToolStripButton btnSelectInverse;
        private System.Windows.Forms.ListView listImg;
    }
}