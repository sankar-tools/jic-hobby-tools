namespace UsbEnabler
{
    partial class MainForm
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
            this.dirTree = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.logArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dirTree
            // 
            this.dirTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.dirTree.Location = new System.Drawing.Point(0, 0);
            this.dirTree.Name = "dirTree";
            this.dirTree.Size = new System.Drawing.Size(121, 400);
            this.dirTree.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(121, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 400);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // logArea
            // 
            this.logArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logArea.Location = new System.Drawing.Point(124, 0);
            this.logArea.Multiline = true;
            this.logArea.Name = "logArea";
            this.logArea.Size = new System.Drawing.Size(787, 400);
            this.logArea.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 400);
            this.Controls.Add(this.logArea);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dirTree);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView dirTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox logArea;

    }
}