namespace FireDragan
{
    partial class CustomStatusBar
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.sslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslblImgCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslblTabCounter = new System.Windows.Forms.ToolStripStatusLabel();

            // 
            // ssMain
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblMain,
            this.sslblImgCounter,
            this.sslblTabCounter});
            this.Name = "ssMain";

            // 
            // sslblMain
            // 
            this.sslblMain.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslblMain.Name = "sslblMain";
            this.sslblMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sslblMain.Text = "Ready...";
            this.sslblMain.Spring = true;

            // 
            // sslblImgCounter
            // 
            this.sslblImgCounter.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslblImgCounter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sslblImgCounter.Name = "sslblImgCounter";
            this.sslblImgCounter.Text = "<ImgCntr>";

            // 
            // sslblTabCounter
            // 
            this.sslblTabCounter.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslblTabCounter.Name = "sslblTabCounter";
            this.sslblTabCounter.Text = "<TabCntr>";
        }

        #endregion
    }
}
