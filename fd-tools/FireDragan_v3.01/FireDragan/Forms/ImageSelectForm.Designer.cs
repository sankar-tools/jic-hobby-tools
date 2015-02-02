namespace FireDragan
{
    partial class ImageSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelectForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemoveAll = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.lvImageLinks = new System.Windows.Forms.ListView();
            this.colhdrId = new System.Windows.Forms.ColumnHeader();
            this.colhdr = new System.Windows.Forms.ColumnHeader();
            this.colhdrReferrer = new System.Windows.Forms.ColumnHeader();
            this.colhdrPriority = new System.Windows.Forms.ColumnHeader();
            this.colhdrCategory = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSave,
            this.tsbtnRemoveAll,
            this.tsbtnRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(736, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = global::FireDragan.Properties.Resources.save;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 22);
            this.tsbtnSave.Text = "&Save";
            this.tsbtnSave.ToolTipText = "Save Links to DB";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnRemoveAll
            // 
            this.tsbtnRemoveAll.Image = global::FireDragan.Properties.Resources.delete;
            this.tsbtnRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveAll.Name = "tsbtnRemoveAll";
            this.tsbtnRemoveAll.Size = new System.Drawing.Size(80, 22);
            this.tsbtnRemoveAll.Text = "Remove &All";
            this.tsbtnRemoveAll.Click += new System.EventHandler(this.tsbtnRemoveAll_Click);
            // 
            // tsbtnRemove
            // 
            this.tsbtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRemove.Image")));
            this.tsbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemove.Name = "tsbtnRemove";
            this.tsbtnRemove.Size = new System.Drawing.Size(66, 22);
            this.tsbtnRemove.Text = "Remove";
            this.tsbtnRemove.Click += new System.EventHandler(this.tsbtnRemove_Click);
            // 
            // lvImageLinks
            // 
            this.lvImageLinks.CheckBoxes = true;
            this.lvImageLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhdrId,
            this.colhdr,
            this.colhdrReferrer,
            this.colhdrPriority,
            this.colhdrCategory});
            this.lvImageLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImageLinks.FullRowSelect = true;
            this.lvImageLinks.GridLines = true;
            this.lvImageLinks.Location = new System.Drawing.Point(0, 25);
            this.lvImageLinks.Name = "lvImageLinks";
            this.lvImageLinks.Size = new System.Drawing.Size(736, 298);
            this.lvImageLinks.TabIndex = 1;
            this.lvImageLinks.UseCompatibleStateImageBehavior = false;
            this.lvImageLinks.View = System.Windows.Forms.View.Details;
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
            this.colhdrCategory.Width = 150;
            // 
            // ImageSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 323);
            this.Controls.Add(this.lvImageLinks);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ImageSelectForm";
            this.Text = "ImageSelectForm";
            this.Load += new System.EventHandler(this.ImageSelectForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ImageSelectForm_Closing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ListView lvImageLinks;
        private System.Windows.Forms.ColumnHeader colhdrId;
        private System.Windows.Forms.ColumnHeader colhdr;
        private System.Windows.Forms.ColumnHeader colhdrReferrer;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveAll;
        private System.Windows.Forms.ToolStripButton tsbtnRemove;
        private System.Windows.Forms.ColumnHeader colhdrPriority;
        private System.Windows.Forms.ColumnHeader colhdrCategory;
    }
}