namespace fd.lib.ui.common.db
{
    partial class ConfigForm
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
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProvider = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConnStr
            // 
            this.txtConnStr.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtConnStr.Location = new System.Drawing.Point(0, 0);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnStr.Size = new System.Drawing.Size(541, 77);
            this.txtConnStr.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnSave);
            this.pnlControls.Controls.Add(this.btnTest);
            this.pnlControls.Controls.Add(this.txtPwd);
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.txtUser);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.txtDB);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.txtSource);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.txtProvider);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 77);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(541, 160);
            this.pnlControls.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provider";
            // 
            // txtProvider
            // 
            this.txtProvider.Location = new System.Drawing.Point(96, 12);
            this.txtProvider.Name = "txtProvider";
            this.txtProvider.Size = new System.Drawing.Size(343, 20);
            this.txtProvider.TabIndex = 1;
            this.txtProvider.Text = "SQLOLEDB.1";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(96, 41);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(343, 20);
            this.txtSource.TabIndex = 3;
            this.txtSource.Text = "./SQLExpress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(96, 69);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(343, 20);
            this.txtDB.TabIndex = 5;
            this.txtDB.Text = "Biz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "DB";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(96, 97);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(343, 20);
            this.txtUser.TabIndex = 7;
            this.txtUser.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "User";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(96, 123);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(343, 20);
            this.txtPwd.TabIndex = 9;
            this.txtPwd.Text = "openopen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(445, 14);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(93, 46);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(445, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 46);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 237);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.txtConnStr);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.Text = "Config";
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProvider;
        private System.Windows.Forms.Label label1;
    }
}