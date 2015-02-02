namespace FireDragan.Forms
{
    partial class SessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSessionSave = new System.Windows.Forms.ToolStripButton();
            this.sessionTabs = new System.Windows.Forms.TabControl();
            this.tabCurrent = new System.Windows.Forms.TabPage();
            this.lstSessionCurrent = new System.Windows.Forms.ListView();
            this.lstSessionCurrentID = new System.Windows.Forms.ColumnHeader();
            this.lstSessionCurrentColLink = new System.Windows.Forms.ColumnHeader();
            this.lstSessionCurrentColVisit = new System.Windows.Forms.ColumnHeader();
            this.tabAllSession = new System.Windows.Forms.TabPage();
            this.lstSessionAll = new System.Windows.Forms.ListView();
            this.lstSessionAllColID = new System.Windows.Forms.ColumnHeader();
            this.lstSessionAllColDesc = new System.Windows.Forms.ColumnHeader();
            this.lstSessionAllColLinks = new System.Windows.Forms.ColumnHeader();
            this.lstSessionAllColUnvisitLinks = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.sessionTabs.SuspendLayout();
            this.tabCurrent.SuspendLayout();
            this.tabAllSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnSessionSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(640, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(49, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnSessionSave
            // 
            this.tsbtnSessionSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSessionSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSessionSave.Image")));
            this.tsbtnSessionSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSessionSave.Name = "tsbtnSessionSave";
            this.tsbtnSessionSave.Size = new System.Drawing.Size(35, 22);
            this.tsbtnSessionSave.Text = "Save";
            this.tsbtnSessionSave.Click += new System.EventHandler(this.tsbtnSessionSave_Click);
            // 
            // sessionTabs
            // 
            this.sessionTabs.Controls.Add(this.tabCurrent);
            this.sessionTabs.Controls.Add(this.tabAllSession);
            this.sessionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionTabs.Location = new System.Drawing.Point(0, 25);
            this.sessionTabs.Name = "sessionTabs";
            this.sessionTabs.SelectedIndex = 0;
            this.sessionTabs.Size = new System.Drawing.Size(640, 293);
            this.sessionTabs.TabIndex = 1;
            // 
            // tabCurrent
            // 
            this.tabCurrent.Controls.Add(this.lstSessionCurrent);
            this.tabCurrent.Location = new System.Drawing.Point(4, 22);
            this.tabCurrent.Name = "tabCurrent";
            this.tabCurrent.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrent.Size = new System.Drawing.Size(632, 267);
            this.tabCurrent.TabIndex = 1;
            this.tabCurrent.Text = "Current";
            this.tabCurrent.UseVisualStyleBackColor = true;
            // 
            // lstSessionCurrent
            // 
            this.lstSessionCurrent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstSessionCurrentID,
            this.lstSessionCurrentColLink,
            this.lstSessionCurrentColVisit});
            this.lstSessionCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSessionCurrent.GridLines = true;
            this.lstSessionCurrent.Location = new System.Drawing.Point(3, 3);
            this.lstSessionCurrent.Name = "lstSessionCurrent";
            this.lstSessionCurrent.Size = new System.Drawing.Size(626, 261);
            this.lstSessionCurrent.TabIndex = 0;
            this.lstSessionCurrent.UseCompatibleStateImageBehavior = false;
            this.lstSessionCurrent.View = System.Windows.Forms.View.Details;
            // 
            // lstSessionCurrentID
            // 
            this.lstSessionCurrentID.Text = "ID";
            // 
            // lstSessionCurrentColLink
            // 
            this.lstSessionCurrentColLink.Text = "Link";
            this.lstSessionCurrentColLink.Width = 400;
            // 
            // lstSessionCurrentColVisit
            // 
            this.lstSessionCurrentColVisit.Text = "Visited";
            // 
            // tabAllSession
            // 
            this.tabAllSession.Controls.Add(this.lstSessionAll);
            this.tabAllSession.Location = new System.Drawing.Point(4, 22);
            this.tabAllSession.Name = "tabAllSession";
            this.tabAllSession.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllSession.Size = new System.Drawing.Size(632, 267);
            this.tabAllSession.TabIndex = 0;
            this.tabAllSession.Text = "AllSession";
            this.tabAllSession.UseVisualStyleBackColor = true;
            // 
            // lstSessionAll
            // 
            this.lstSessionAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstSessionAllColID,
            this.lstSessionAllColDesc,
            this.lstSessionAllColLinks,
            this.lstSessionAllColUnvisitLinks});
            this.lstSessionAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSessionAll.GridLines = true;
            this.lstSessionAll.Location = new System.Drawing.Point(3, 3);
            this.lstSessionAll.Name = "lstSessionAll";
            this.lstSessionAll.Size = new System.Drawing.Size(626, 261);
            this.lstSessionAll.TabIndex = 1;
            this.lstSessionAll.UseCompatibleStateImageBehavior = false;
            this.lstSessionAll.View = System.Windows.Forms.View.Details;
            // 
            // lstSessionAllColID
            // 
            this.lstSessionAllColID.Text = "ID";
            // 
            // lstSessionAllColDesc
            // 
            this.lstSessionAllColDesc.Text = "Desc";
            this.lstSessionAllColDesc.Width = 255;
            // 
            // lstSessionAllColLinks
            // 
            this.lstSessionAllColLinks.Text = "Total Links";
            // 
            // lstSessionAllColUnvisitLinks
            // 
            this.lstSessionAllColUnvisitLinks.Text = "Unvisited Links";
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 318);
            this.Controls.Add(this.sessionTabs);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SessionForm";
            this.Text = "SessionForm";
            this.Load += new System.EventHandler(this.SessionForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.sessionTabs.ResumeLayout(false);
            this.tabCurrent.ResumeLayout(false);
            this.tabAllSession.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.TabControl sessionTabs;
        private System.Windows.Forms.TabPage tabCurrent;
        private System.Windows.Forms.TabPage tabAllSession;
        private System.Windows.Forms.ListView lstSessionCurrent;
        private System.Windows.Forms.ColumnHeader lstSessionCurrentColLink;
        private System.Windows.Forms.ColumnHeader lstSessionCurrentColVisit;
        private System.Windows.Forms.ListView lstSessionAll;
        private System.Windows.Forms.ColumnHeader lstSessionAllColID;
        private System.Windows.Forms.ColumnHeader lstSessionAllColDesc;
        private System.Windows.Forms.ColumnHeader lstSessionAllColLinks;
        private System.Windows.Forms.ColumnHeader lstSessionAllColUnvisitLinks;
        private System.Windows.Forms.ToolStripButton tsbtnSessionSave;
        private System.Windows.Forms.ColumnHeader lstSessionCurrentID;
    }
}