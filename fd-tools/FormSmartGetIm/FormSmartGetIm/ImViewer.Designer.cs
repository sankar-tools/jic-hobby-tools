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
            this.listImg = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOk = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listImg
            // 
            this.listImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listImg.GridLines = true;
            this.listImg.Location = new System.Drawing.Point(0, 0);
            this.listImg.Name = "listImg";
            this.listImg.Size = new System.Drawing.Size(806, 451);
            this.listImg.TabIndex = 0;
            this.listImg.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOk});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOk
            // 
            this.tsbtnOk.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOk.Image")));
            this.tsbtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOk.Name = "tsbtnOk";
            this.tsbtnOk.Size = new System.Drawing.Size(40, 22);
            this.tsbtnOk.Text = "Ok";
            this.tsbtnOk.Click += new System.EventHandler(this.tsbtnOk_Click);
            // 
            // ImViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 451);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listImg);
            this.Name = "ImViewer";
            this.Text = "ImViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listImg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOk;
    }
}