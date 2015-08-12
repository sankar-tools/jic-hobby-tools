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
            this.listImg = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listImg
            // 
            this.listImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listImg.Location = new System.Drawing.Point(0, 0);
            this.listImg.Name = "listImg";
            this.listImg.Size = new System.Drawing.Size(806, 451);
            this.listImg.TabIndex = 0;
            this.listImg.UseCompatibleStateImageBehavior = false;
            // 
            // ImViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 451);
            this.Controls.Add(this.listImg);
            this.Name = "ImViewer";
            this.Text = "ImViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listImg;
    }
}