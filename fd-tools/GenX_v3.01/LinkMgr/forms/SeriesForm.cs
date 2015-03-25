using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

using Oliva.GenX.LinkMgr.Helper;
namespace LinkMgr
{
	public class SeriesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblOuterBegin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkOuterPad;
		private System.Windows.Forms.TextBox txtOuterPad;
		private System.Windows.Forms.Label lblOuterPad;
		private System.Windows.Forms.GroupBox grpInner;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkInnerLoop;
		private System.Windows.Forms.TextBox txtOuterBegin;
		private System.Windows.Forms.TextBox txtOuterEnd;
		private System.Windows.Forms.TextBox txtInnerPad;
		private System.Windows.Forms.CheckBox chkInnerPad;
		private System.Windows.Forms.TextBox txtInnerEnd;
        private System.Windows.Forms.TextBox txtInnerBegin;
		private System.Windows.Forms.Label lblOuterPadLen;
		private System.Windows.Forms.TextBox txtOuterPadLen;
		private System.Windows.Forms.Label lblInnerPadLen;
		private System.Windows.Forms.TextBox txtInnerPadLen;
		private System.Windows.Forms.TextBox txtReferrer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtUrl;
        private Label label7;
        private ComboBox cboPriority;

        private string url;
        private string referrer;

        public string Referrer
        {
            get { return referrer; }
            set { referrer = value; }
        }
        private int count;
        private ToolStripButton tsbtnGenerate;
        private ToolStripButton tsbtnClearImages;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbtnSave;
        private ToolStripButton tsbtnClearList;
        private ToolStripButton tsbtnFetch;
        private StatusStrip ssThis;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label8;
        private TextBox txtDomain;
        private Button btnI;
        private Button btnJ;
        private Label label9;
        private TextBox txtCategories;
        private Button btnPaste;
        private ListView linksList;
        private ColumnHeader hdrcolId;
        private ColumnHeader hdrcolHtmlLink;
        private ColumnHeader hdrcolImageLink;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }


		private System.ComponentModel.Container components = null;

		public SeriesForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        enum HtmlElementType
        {
            HRef,
            Image
        }


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblOuterPadLen = new System.Windows.Forms.Label();
            this.txtOuterPadLen = new System.Windows.Forms.TextBox();
            this.chkInnerLoop = new System.Windows.Forms.CheckBox();
            this.grpInner = new System.Windows.Forms.GroupBox();
            this.lblInnerPadLen = new System.Windows.Forms.Label();
            this.txtInnerPadLen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInnerPad = new System.Windows.Forms.TextBox();
            this.chkInnerPad = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInnerEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInnerBegin = new System.Windows.Forms.TextBox();
            this.lblOuterPad = new System.Windows.Forms.Label();
            this.txtOuterPad = new System.Windows.Forms.TextBox();
            this.chkOuterPad = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOuterEnd = new System.Windows.Forms.TextBox();
            this.lblOuterBegin = new System.Windows.Forms.Label();
            this.txtOuterBegin = new System.Windows.Forms.TextBox();
            this.txtReferrer = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tsbtnGenerate = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClearImages = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClearList = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFetch = new System.Windows.Forms.ToolStripButton();
            this.ssThis = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btnI = new System.Windows.Forms.Button();
            this.btnJ = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCategories = new System.Windows.Forms.TextBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.linksList = new System.Windows.Forms.ListView();
            this.hdrcolId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrcolHtmlLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrcolImageLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.grpInner.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ssThis.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboPriority);
            this.groupBox1.Controls.Add(this.lblOuterPadLen);
            this.groupBox1.Controls.Add(this.txtOuterPadLen);
            this.groupBox1.Controls.Add(this.chkInnerLoop);
            this.groupBox1.Controls.Add(this.grpInner);
            this.groupBox1.Controls.Add(this.lblOuterPad);
            this.groupBox1.Controls.Add(this.txtOuterPad);
            this.groupBox1.Controls.Add(this.chkOuterPad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOuterEnd);
            this.groupBox1.Controls.Add(this.lblOuterBegin);
            this.groupBox1.Controls.Add(this.txtOuterBegin);
            this.groupBox1.Location = new System.Drawing.Point(9, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 198);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outer Loop";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Priority";
            // 
            // cboPriority
            // 
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.ItemHeight = 13;
            this.cboPriority.Items.AddRange(new object[] {
            "None",
            "High",
            "Medium",
            "Low"});
            this.cboPriority.Location = new System.Drawing.Point(302, 26);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(134, 21);
            this.cboPriority.TabIndex = 13;
            this.cboPriority.Text = "High";
            // 
            // lblOuterPadLen
            // 
            this.lblOuterPadLen.AutoSize = true;
            this.lblOuterPadLen.Location = new System.Drawing.Point(248, 61);
            this.lblOuterPadLen.Name = "lblOuterPadLen";
            this.lblOuterPadLen.Size = new System.Drawing.Size(82, 13);
            this.lblOuterPadLen.TabIndex = 15;
            this.lblOuterPadLen.Text = "Padding Length";
            // 
            // txtOuterPadLen
            // 
            this.txtOuterPadLen.Location = new System.Drawing.Point(336, 61);
            this.txtOuterPadLen.Name = "txtOuterPadLen";
            this.txtOuterPadLen.Size = new System.Drawing.Size(56, 20);
            this.txtOuterPadLen.TabIndex = 16;
            this.txtOuterPadLen.Text = "2";
            // 
            // chkInnerLoop
            // 
            this.chkInnerLoop.Location = new System.Drawing.Point(11, 74);
            this.chkInnerLoop.Name = "chkInnerLoop";
            this.chkInnerLoop.Size = new System.Drawing.Size(104, 24);
            this.chkInnerLoop.TabIndex = 17;
            this.chkInnerLoop.Text = "Inner Loop";
            this.chkInnerLoop.CheckedChanged += new System.EventHandler(this.chkInnerLoop_CheckedChanged);
            // 
            // grpInner
            // 
            this.grpInner.Controls.Add(this.lblInnerPadLen);
            this.grpInner.Controls.Add(this.txtInnerPadLen);
            this.grpInner.Controls.Add(this.label2);
            this.grpInner.Controls.Add(this.txtInnerPad);
            this.grpInner.Controls.Add(this.chkInnerPad);
            this.grpInner.Controls.Add(this.label3);
            this.grpInner.Controls.Add(this.txtInnerEnd);
            this.grpInner.Controls.Add(this.label4);
            this.grpInner.Controls.Add(this.txtInnerBegin);
            this.grpInner.Enabled = false;
            this.grpInner.Location = new System.Drawing.Point(6, 104);
            this.grpInner.Name = "grpInner";
            this.grpInner.Size = new System.Drawing.Size(472, 88);
            this.grpInner.TabIndex = 9;
            this.grpInner.TabStop = false;
            this.grpInner.Text = "Inner Loop";
            // 
            // lblInnerPadLen
            // 
            this.lblInnerPadLen.AutoSize = true;
            this.lblInnerPadLen.Location = new System.Drawing.Point(240, 48);
            this.lblInnerPadLen.Name = "lblInnerPadLen";
            this.lblInnerPadLen.Size = new System.Drawing.Size(82, 13);
            this.lblInnerPadLen.TabIndex = 25;
            this.lblInnerPadLen.Text = "Padding Length";
            // 
            // txtInnerPadLen
            // 
            this.txtInnerPadLen.Enabled = false;
            this.txtInnerPadLen.Location = new System.Drawing.Point(323, 48);
            this.txtInnerPadLen.Name = "txtInnerPadLen";
            this.txtInnerPadLen.Size = new System.Drawing.Size(56, 20);
            this.txtInnerPadLen.TabIndex = 26;
            this.txtInnerPadLen.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Padding Char";
            // 
            // txtInnerPad
            // 
            this.txtInnerPad.Enabled = false;
            this.txtInnerPad.Location = new System.Drawing.Point(168, 48);
            this.txtInnerPad.Name = "txtInnerPad";
            this.txtInnerPad.Size = new System.Drawing.Size(56, 20);
            this.txtInnerPad.TabIndex = 24;
            this.txtInnerPad.Text = "0";
            // 
            // chkInnerPad
            // 
            this.chkInnerPad.Location = new System.Drawing.Point(8, 40);
            this.chkInnerPad.Name = "chkInnerPad";
            this.chkInnerPad.Size = new System.Drawing.Size(72, 24);
            this.chkInnerPad.TabIndex = 22;
            this.chkInnerPad.Text = "Padding";
            this.chkInnerPad.CheckedChanged += new System.EventHandler(this.chkInnerPad_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Stop Index";
            // 
            // txtInnerEnd
            // 
            this.txtInnerEnd.Location = new System.Drawing.Point(208, 16);
            this.txtInnerEnd.Name = "txtInnerEnd";
            this.txtInnerEnd.Size = new System.Drawing.Size(100, 20);
            this.txtInnerEnd.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Start Index";
            // 
            // txtInnerBegin
            // 
            this.txtInnerBegin.Location = new System.Drawing.Point(72, 16);
            this.txtInnerBegin.Name = "txtInnerBegin";
            this.txtInnerBegin.Size = new System.Drawing.Size(56, 20);
            this.txtInnerBegin.TabIndex = 2;
            this.txtInnerBegin.Text = "1";
            this.txtInnerBegin.GotFocus += new System.EventHandler(this.txtInnerBegin_GotFocus);
            // 
            // lblOuterPad
            // 
            this.lblOuterPad.AutoSize = true;
            this.lblOuterPad.Location = new System.Drawing.Point(96, 58);
            this.lblOuterPad.Name = "lblOuterPad";
            this.lblOuterPad.Size = new System.Drawing.Size(71, 13);
            this.lblOuterPad.TabIndex = 13;
            this.lblOuterPad.Text = "Padding Char";
            // 
            // txtOuterPad
            // 
            this.txtOuterPad.Location = new System.Drawing.Point(176, 58);
            this.txtOuterPad.Name = "txtOuterPad";
            this.txtOuterPad.Size = new System.Drawing.Size(56, 20);
            this.txtOuterPad.TabIndex = 14;
            this.txtOuterPad.Text = "0";
            // 
            // chkOuterPad
            // 
            this.chkOuterPad.Checked = true;
            this.chkOuterPad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOuterPad.Location = new System.Drawing.Point(11, 53);
            this.chkOuterPad.Name = "chkOuterPad";
            this.chkOuterPad.Size = new System.Drawing.Size(72, 24);
            this.chkOuterPad.TabIndex = 12;
            this.chkOuterPad.Text = "Padding";
            this.chkOuterPad.CheckedChanged += new System.EventHandler(this.chkOuterPad_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stop Index";
            // 
            // txtOuterEnd
            // 
            this.txtOuterEnd.Location = new System.Drawing.Point(200, 28);
            this.txtOuterEnd.Name = "txtOuterEnd";
            this.txtOuterEnd.Size = new System.Drawing.Size(52, 20);
            this.txtOuterEnd.TabIndex = 10;
            this.txtOuterEnd.Text = "15";
            this.txtOuterEnd.GotFocus += new System.EventHandler(this.txtOuterEnd_GotFocus);
            // 
            // lblOuterBegin
            // 
            this.lblOuterBegin.AutoSize = true;
            this.lblOuterBegin.Location = new System.Drawing.Point(8, 30);
            this.lblOuterBegin.Name = "lblOuterBegin";
            this.lblOuterBegin.Size = new System.Drawing.Size(58, 13);
            this.lblOuterBegin.TabIndex = 3;
            this.lblOuterBegin.Text = "Start Index";
            // 
            // txtOuterBegin
            // 
            this.txtOuterBegin.Location = new System.Drawing.Point(72, 27);
            this.txtOuterBegin.Name = "txtOuterBegin";
            this.txtOuterBegin.Size = new System.Drawing.Size(56, 20);
            this.txtOuterBegin.TabIndex = 9;
            this.txtOuterBegin.Text = "1";

            this.txtOuterBegin.GotFocus += new System.EventHandler(this.txtOuterBegin_GotFocus);
            // 
            // txtReferrer
            // 
            this.txtReferrer.Location = new System.Drawing.Point(59, 52);
            this.txtReferrer.Name = "txtReferrer";
            this.txtReferrer.Size = new System.Drawing.Size(645, 20);
            this.txtReferrer.TabIndex = 6;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(59, 28);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(645, 20);
            this.txtUrl.TabIndex = 2;

            this.txtUrl.GotFocus += new System.EventHandler(this.txtUrl_GotFocus);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "&URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "&Referrer";
            // 
            // tsbtnGenerate
            // 
            this.tsbtnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGenerate.Image")));
            this.tsbtnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGenerate.Name = "tsbtnGenerate";
            this.tsbtnGenerate.Size = new System.Drawing.Size(74, 22);
            this.tsbtnGenerate.Text = "Generate";
            // 
            // tsbtnClearImages
            // 
            this.tsbtnClearImages.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClearImages.Image")));
            this.tsbtnClearImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClearImages.Name = "tsbtnClearImages";
            this.tsbtnClearImages.Size = new System.Drawing.Size(95, 22);
            this.tsbtnClearImages.Text = "Clear Images";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGenerate,
            this.tsbtnClearList,
            this.tsbtnClearImages,
            this.tsbtnSave,
            this.tsbtnFetch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnClearList
            // 
            this.tsbtnClearList.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClearList.Image")));
            this.tsbtnClearList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClearList.Name = "tsbtnClearList";
            this.tsbtnClearList.Size = new System.Drawing.Size(75, 22);
            this.tsbtnClearList.Text = "Clear List";
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 22);
            this.tsbtnSave.Text = "&Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnFetch
            // 
            this.tsbtnFetch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFetch.Image")));
            this.tsbtnFetch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFetch.Name = "tsbtnFetch";
            this.tsbtnFetch.Size = new System.Drawing.Size(56, 22);
            this.tsbtnFetch.Text = "Fetch";
            // 
            // ssThis
            // 
            this.ssThis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.ssThis.Location = new System.Drawing.Point(0, 450);
            this.ssThis.Name = "ssThis";
            this.ssThis.Size = new System.Drawing.Size(773, 22);
            this.ssThis.TabIndex = 13;
            this.ssThis.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(758, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Ready...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "&Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(59, 76);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(645, 20);
            this.txtDomain.TabIndex = 8;
            // 
            // btnI
            // 
            this.btnI.Location = new System.Drawing.Point(707, 26);
            this.btnI.Name = "btnI";
            this.btnI.Size = new System.Drawing.Size(28, 23);
            this.btnI.TabIndex = 3;
            this.btnI.Text = "I";
            this.btnI.UseVisualStyleBackColor = true;
            this.btnI.Click += new System.EventHandler(this.btnI_Click);
            // 
            // btnJ
            // 
            this.btnJ.Location = new System.Drawing.Point(736, 26);
            this.btnJ.Name = "btnJ";
            this.btnJ.Size = new System.Drawing.Size(28, 23);
            this.btnJ.TabIndex = 4;
            this.btnJ.Text = "J";
            this.btnJ.UseVisualStyleBackColor = true;
            this.btnJ.Click += new System.EventHandler(this.btnJ_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(504, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "&Keywords";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtCategories
            // 
            this.txtCategories.Location = new System.Drawing.Point(507, 124);
            this.txtCategories.Multiline = true;
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.Size = new System.Drawing.Size(257, 171);
            this.txtCategories.TabIndex = 17;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(707, 52);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(28, 23);
            this.btnPaste.TabIndex = 18;
            this.btnPaste.Text = "^V";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // linksList
            // 
            this.linksList.AllowColumnReorder = true;
            this.linksList.CheckBoxes = true;
            this.linksList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrcolId,
            this.hdrcolHtmlLink,
            this.hdrcolImageLink});
            this.linksList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linksList.FullRowSelect = true;
            this.linksList.GridLines = true;
            this.linksList.Location = new System.Drawing.Point(0, 303);
            this.linksList.Name = "linksList";
            this.linksList.Size = new System.Drawing.Size(773, 147);
            this.linksList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.linksList.TabIndex = 19;
            this.linksList.UseCompatibleStateImageBehavior = false;
            this.linksList.View = System.Windows.Forms.View.Details;
            // 
            // hdrcolId
            // 
            this.hdrcolId.Text = "Id";
            this.hdrcolId.Width = 50;
            // 
            // hdrcolHtmlLink
            // 
            this.hdrcolHtmlLink.Text = "Link Html";
            this.hdrcolHtmlLink.Width = 400;
            // 
            // hdrcolImageLink
            // 
            this.hdrcolImageLink.Text = "Link Image";
            this.hdrcolImageLink.Width = 200;
            // 
            // SeriesForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(773, 472);
            this.Controls.Add(this.linksList);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.txtCategories);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnJ);
            this.Controls.Add(this.btnI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.ssThis);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtReferrer);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeriesForm";
            this.Text = "SeriesForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpInner.ResumeLayout(false);
            this.grpInner.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ssThis.ResumeLayout(false);
            this.ssThis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        void txtInnerEnd_GotFocus(object sender, EventArgs e)
        {
            txtInnerEnd.SelectAll();
        }

        void txtInnerBegin_GotFocus(object sender, EventArgs e)
        {
            txtInnerBegin.SelectAll();
        }

        void txtOuterEnd_GotFocus(object sender, EventArgs e)
        {
            txtOuterEnd.SelectAll();
        }

        void txtOuterBegin_GotFocus(object sender, EventArgs e)
        {
            txtOuterBegin.SelectAll();  
        }

        void txtUrl_GotFocus(object sender, EventArgs e)
        {
            txtUrl.SelectAll();
        }
		#endregion

		private void chkInnerLoop_CheckedChanged(object sender, System.EventArgs e)
		{
			grpInner.Enabled = chkInnerLoop.Checked;
		}

		private void chkInnerPad_CheckedChanged(object sender, System.EventArgs e)
		{
			txtInnerPad.Enabled = chkInnerPad.Checked;
			txtInnerPadLen.Enabled = chkInnerPad.Checked;
		}

		private void chkOuterPad_CheckedChanged(object sender, System.EventArgs e)
		{
			txtOuterPad.Enabled = chkOuterPad.Checked;
			txtOuterPadLen.Enabled = chkOuterPad.Checked;
		}

		private bool ValidateLinkPattern()
		{
            if (chkInnerLoop.Checked)
            {
                if (txtUrl.Text.IndexOf("[i]") < 0 || txtUrl.Text.IndexOf("[j]") < 0)
                {
                    MessageBox.Show("Incorrect Url format");
                    return false;
                }
            }
            else 
            {
                if (txtUrl.Text.IndexOf("[i]") < 0)
                {
                    MessageBox.Show("Incorrect Url format");
                    return false;
                }
            }
            return true;
		}

        private void SaveLinks()
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string constr = SettingsHelper.Current.DBConnection;

            int count = 0;
            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority, created, status, category) values(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("referrer", OleDbType.VarChar);
                cmd.Parameters.Add("priority", OleDbType.VarChar);
                cmd.Parameters.Add("created", OleDbType.Date);
                cmd.Parameters.Add("status", OleDbType.VarChar);
                cmd.Parameters.Add("category", OleDbType.VarChar);

                if (chkInnerLoop.Checked)
                {
                    if (txtUrl.Text.IndexOf("[i]") < 0 || txtUrl.Text.IndexOf("[j]") < 0)
                        MessageBox.Show("Incorrect Url format");

                    for (int i = Convert.ToInt32(txtOuterBegin.Text);
                        i <= Convert.ToInt32(txtOuterEnd.Text);
                        i++)
                    {
                        for (int j = Convert.ToInt32(txtInnerBegin.Text);
                            j <= Convert.ToInt32(txtInnerEnd.Text);
                            j++)
                        {
                            count++;
                            string url;
                            if (chkOuterPad.Checked)
                            {
                                url = txtUrl.Text.Replace("[i]", i.ToString().PadLeft(Convert.ToInt32(txtOuterPadLen.Text), Convert.ToChar(txtOuterPad.Text)));
                            }
                            else
                            {
                                url = txtUrl.Text.Replace("[i]", i.ToString());
                            }

                            if (chkInnerPad.Checked)
                            {
                                url = url.Replace("[j]", j.ToString().PadLeft(Convert.ToInt32(txtInnerPadLen.Text), Convert.ToChar(txtInnerPad.Text)));
                            }
                            else
                            {
                                url = url.Replace("[j]", j.ToString());
                            }

                            cmd.Parameters[0].Value = url;
                            cmd.Parameters[1].Value = txtReferrer.Text;
                            cmd.Parameters[2].Value = cboPriority.Text;
                            cmd.Parameters[3].Value = DateTime.Now;
                            cmd.Parameters[4].Value = "New";
                            cmd.Parameters[5].Value = txtCategories.Text;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    if (txtUrl.Text.IndexOf("[i]") < 0)
                        MessageBox.Show("Incorrect Url format");

                    for (int i = Convert.ToInt32(txtOuterBegin.Text);
                        i <= Convert.ToInt32(txtOuterEnd.Text);
                        i++)
                    {
                        string url; //= txtUrl.Text.Replace("[i]",i.ToString());
                        //						url = txtUrl.Text.Replace("[i]",i.ToString().PadLeft(Convert.ToInt32(txtOuterPadLen.Text), Convert.ToChar(txtOuterPad.Text)));
                        if (chkOuterPad.Checked)
                        {
                            url = txtUrl.Text.Replace("[i]", i.ToString().PadLeft(Convert.ToInt32(txtOuterPadLen.Text), Convert.ToChar(txtOuterPad.Text)));
                        }
                        else
                        {
                            url = txtUrl.Text.Replace("[i]", i.ToString());
                        }

                        cmd.Parameters[0].Value = url;
                        cmd.Parameters[1].Value = txtReferrer.Text;
                        cmd.Parameters[2].Value = cboPriority.Text;
                        cmd.Parameters[3].Value = DateTime.Now;
                        cmd.Parameters[4].Value = "New";
                        cmd.Parameters[5].Value = txtCategories.Text;

                        cmd.ExecuteNonQuery();
                        count++;
                    }

                }
                //MessageBox.Show("Series Generated Successfully");
                toolStripStatusLabel1.Text = "[" + count.ToString() + "] links added to DB with ref:" + txtReferrer.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //private void btnCancel_Click(object sender, System.EventArgs e)
        //{
        //    this.Close();
        //}

        //private void tsbtnClearList_Click(object sender, EventArgs e)
        //{
        //    linksList.Items.Clear();
        //}

        //private void tsbtnClearImages_Click(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem item in linksList.Items)
        //    {
        //        item.SubItems[2].Text = "";
        //    }
        //}

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not Implemented");
            //SaveLinksToDB();
            if (ValidateControls() == false)
                return;

            if (ValidateLinkPattern() == false)
                return;

            SaveLinks();

        }

        private bool ValidateControls()
        {

            if (txtCategories.Text.Length <= 0)
            {
                if (MessageBox.Show("Categories is empty\nWould you like to continue?", "Invalid data...", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    txtCategories.Focus();
                    return false;
                }
                    
            }

            return true;
        }

        //private void SaveLinksToDB()
        //{
        //    OleDbConnection cn = new OleDbConnection();
        //    OleDbCommand cmd = new OleDbCommand();

        //    string constr = ConfigurationSettings.AppSettings["ControlDatabase"];

        //    try
        //    {
        //        cn.ConnectionString = constr;
        //        cn.Open();

        //        cmd.Connection = cn;

        //        cmd.CommandText = "insert into GrabList (url, referrer, priority) values(?,?, ?)";
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.Add("url", OleDbType.VarChar);
        //        cmd.Parameters.Add("referrer", OleDbType.VarChar);
        //        cmd.Parameters.Add("priority", OleDbType.VarChar);

        //        cmd.Parameters[1].Value = txtReferrer.Text;
        //        cmd.Parameters[2].Value = cboPriority.Text;

        //        foreach(ListViewItem item in linksList.Items)
        //        {
        //            cmd.Parameters[0].Value = url;

        //            cmd.ExecuteNonQuery();
        //        }
        //        ssThis.Text = "xxx added to DB successfully";

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }

        //    //MessageBox.Show("Series Generated Successfully");
        //}

        //private void tsbtnGenerate_Click(object sender, EventArgs e)
        //{
        //    GenerateLinks();
        //}

        //private void linksList_DoubleClick(object sender, EventArgs e)
        //{
        //    txtUrl.Text = linksList.SelectedItems[0].SubItems[1].Text;
        //}

        //public void SeriesParams(string[] links, string referrer)
        //{
        //    linksList.Items.Clear();
        //    for (int i = 1; i <= links.Length; i++)
        //    {
        //        if (IsSameDomain(new Uri(referrer), new Uri(links[i - 1])))
        //        {
        //        ListViewItem item = linksList.Items.Add(i.ToString());
        //        item.SubItems.Add(links[i - 1]);
        //        }
        //    }

        //    txtUrl.Text = links[0];
        //    txtReferrer.Text = referrer;
        //    //txtOuterEnd.Text = (links.Length+1).ToString();
        //    txtDomain.Text = new Uri(referrer).Host;
        //    toolStripStatusLabel1.Text = "Ready...";
        //}

        //private bool IsSameDomain(Uri url1, Uri url2)
        //{
        //    return (url1.Host == url2.Host);
        //}

        //private void linksList_DoubleClick(object sender, EventArgs e)
        //{
        //    txtUrl.Text = linksList.SelectedItems[0].SubItems[1].Text;
        //}

        //private void tsbtnFetch_Click(object sender, EventArgs e)
        //{
        //    myBros.Navigate(linksList.CheckedItems[0].SubItems[1].Text);
        //}

        //WebBrowser myBros = new WebBrowser();
        //private void SeriesForm_Load(object sender, EventArgs e)
        //{
        //    myBros.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(myBros_DocumentCompleted);
        //    toolStripStatusLabel1.Text = "Ready...";

        //    ResetCategories();
        //}

        //private void myBros_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    int index = linksList.CheckedItems[0].Index;

        //    foreach (string lnk in GetHtmlElementPaths(myBros.Document, HtmlElementType.Image))
        //    {
        //        ListViewItem item = linksList.Items.Add( "----" );
        //        item.SubItems.Add(lnk);
        //    }
        //}

        //private string[] GetHtmlElementPaths(HtmlDocument myDoc, HtmlElementType type)
        //{
        //    System.Collections.ArrayList arr = new System.Collections.ArrayList();

        //    try
        //    {
        //        switch (type)
        //        {
        //            case HtmlElementType.HRef:
        //                foreach (HtmlElement lnkElement in myDoc.Links)
        //                {
        //                    arr.Add(lnkElement.GetAttribute("Href"));
        //                }

        //                break;

        //            case HtmlElementType.Image:
        //                foreach (HtmlElement lnkElement in myDoc.Images)
        //                {
        //                    arr.Add(lnkElement.GetAttribute("Src"));
        //                }

        //                foreach (HtmlElement lnkElement in myDoc.Links)
        //                {
        //                    if (IsImageUrl(lnkElement.GetAttribute("Href")))
        //                        arr.Add(lnkElement.GetAttribute("Href"));
        //                }


        //                break;
        //        }

        //    }
        //    catch (InvalidCastException ex)
        //    {
        //        MessageBox.Show("Invalidcast : " + ex.ToString());
        //    }

        //    string[] urls = new string[arr.Count];

        //    arr.CopyTo(urls, 0);
        //    return (urls);
        //}

        //public Boolean IsImageUrl(string uri)
        //{
        //    string fileExt = uri.Substring(uri.LastIndexOf(".") + 1).ToLower();

        //    if (fileExt.Length > 0)
        //    {
        //        string imageExtensions = SettingsHelper.Current.ImageExpression;
        //        return (!(imageExtensions.IndexOf(fileExt) < 0));
        //    }
        //    else
        //        return false;
        //}

        private void btnI_Click(object sender, EventArgs e)
        {
            if (txtUrl.SelectedText.Length > 0)
            {
                txtUrl.Text = txtUrl.Text.Replace(txtUrl.SelectedText, "[i]");
            }
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            if (txtUrl.SelectedText.Length > 0)
            {
                txtUrl.Text = txtUrl.Text.Replace(txtUrl.SelectedText, "[j]");

                if (chkInnerLoop.Checked == false)
                {
                    chkInnerLoop.Checked = true;
                }
            }
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void label9_Click(object sender, EventArgs e)
        {
            ResetCategories();
        }

        private void ResetCategories()
        {
            SettingsHelper helper = SettingsHelper.Current;
            txtCategories.Text = helper.Categories;
        }


        private void btnPaste_Click(object sender, EventArgs e)
        {
            string currentUrl = Clipboard.GetText();
            txtUrl.Text = currentUrl;

            txtReferrer.Text = currentUrl;
            txtUrl.SelectAll();
        }

        //private void txtUrl_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtOuterBegin_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtOuterEnd_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtInnerBegin_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtInnerEnd_TextChanged(object sender, EventArgs e)
        //{

        //}


	}
}
