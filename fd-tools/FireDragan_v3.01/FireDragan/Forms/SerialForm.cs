using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FireDragan
{
	/// <summary>
	/// Summary description for SerialForm.
	/// </summary>
	public class SerialForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblSerialLinkText;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Label lblLower;
		private System.Windows.Forms.Label lblCurrent;
		private System.Windows.Forms.Label lblUpper;
		private System.Windows.Forms.TextBox txtLower;
		private System.Windows.Forms.TextBox txtCurrent;
		private System.Windows.Forms.TextBox txtUpper;
		private System.Windows.Forms.TextBox txtSerialLink;
		private System.Windows.Forms.Label lblInnerPadLen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkForward;
		private System.Windows.Forms.TextBox txtPaddingLen;
		private System.Windows.Forms.TextBox txtPaddingChar;
		private System.Windows.Forms.CheckBox chkPadding;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnHide;

        //public int Lower
        //{
        //    get
        //    {
        //        return Convert.ToInt32(txtLower.Text);
        //    }
        //    set
        //    {
        //        txtLower.Text = value.ToString();
        //    }
        //}

        //public int Upper
        //{
        //    get
        //    {
        //        return Convert.ToInt32(txtUpper.Text);
        //    }
        //    set
        //    {
        //        txtUpper.Text = value.ToString();
        //    }
        //}

        //public int Current
        //{
        //    get
        //    {
        //        return Convert.ToInt32(txtCurrent.Text);
        //    }
        //    set
        //    {
        //        txtCurrent.Text = value.ToString();
        //    }
        //}

        //public string UrlMask
        //{
        //    get
        //    {
        //        return txtSerialLink.Text;
        //    }
        //    set
        //    {
        //        txtSerialLink.Text = value;
        //    }
        //}

        //public bool IsPadding
        //{
        //    get
        //    {
        //        return chkPadding.Checked;
        //    }
        //    set
        //    {
        //        chkPadding.Checked = value;
        //    }
        //}

        //public SerialDirection Direction
        //{
        //    get
        //    {
        //        if(chkForward.Checked)
        //            return SerialDirection.Forward;
        //        else
        //            return SerialDirection.Backward;
        //    }
        //    set
        //    {
        //        if(value == SerialDirection.Forward)
        //            chkForward.Checked = true;
        //        else
        //            chkForward.Checked =  false;
        //    }
        //}

        //public char PaddingChar
        //{
        //    get
        //    {
        //        return Convert.ToChar(txtPaddingChar.Text);
        //    }
        //    set
        //    {
        //        txtPaddingChar.Text = value.ToString();
        //    }
        //}

        //public int PaddingLength
        //{
        //    get
        //    {
        //        return Convert.ToInt32(txtPaddingLen.Text);
        //    }
        //    set
        //    {
        //        txtPaddingLen.Text = value.ToString();
        //    }
        //}


		public SerialForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //ParentForm = parent;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblSerialLinkText = new System.Windows.Forms.Label();
            this.txtSerialLink = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblLower = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblUpper = new System.Windows.Forms.Label();
            this.txtLower = new System.Windows.Forms.TextBox();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.txtUpper = new System.Windows.Forms.TextBox();
            this.lblInnerPadLen = new System.Windows.Forms.Label();
            this.txtPaddingLen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaddingChar = new System.Windows.Forms.TextBox();
            this.chkPadding = new System.Windows.Forms.CheckBox();
            this.chkForward = new System.Windows.Forms.CheckBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSerialLinkText
            // 
            this.lblSerialLinkText.AutoSize = true;
            this.lblSerialLinkText.Location = new System.Drawing.Point(8, 8);
            this.lblSerialLinkText.Name = "lblSerialLinkText";
            this.lblSerialLinkText.Size = new System.Drawing.Size(56, 13);
            this.lblSerialLinkText.TabIndex = 0;
            this.lblSerialLinkText.Text = "Serial &Link";
            // 
            // txtSerialLink
            // 
            this.txtSerialLink.Location = new System.Drawing.Point(64, 6);
            this.txtSerialLink.Name = "txtSerialLink";
            this.txtSerialLink.Size = new System.Drawing.Size(464, 20);
            this.txtSerialLink.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(534, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(32, 24);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblLower
            // 
            this.lblLower.AutoSize = true;
            this.lblLower.Location = new System.Drawing.Point(8, 35);
            this.lblLower.Name = "lblLower";
            this.lblLower.Size = new System.Drawing.Size(36, 13);
            this.lblLower.TabIndex = 3;
            this.lblLower.Text = "Lower";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(88, 35);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(41, 13);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Current";
            // 
            // lblUpper
            // 
            this.lblUpper.AutoSize = true;
            this.lblUpper.Location = new System.Drawing.Point(168, 35);
            this.lblUpper.Name = "lblUpper";
            this.lblUpper.Size = new System.Drawing.Size(36, 13);
            this.lblUpper.TabIndex = 5;
            this.lblUpper.Text = "Upper";
            // 
            // txtLower
            // 
            this.txtLower.Location = new System.Drawing.Point(48, 32);
            this.txtLower.Name = "txtLower";
            this.txtLower.Size = new System.Drawing.Size(40, 20);
            this.txtLower.TabIndex = 6;
            this.txtLower.Text = "0";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(128, 32);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(40, 20);
            this.txtCurrent.TabIndex = 7;
            this.txtCurrent.Text = "0";
            // 
            // txtUpper
            // 
            this.txtUpper.Location = new System.Drawing.Point(208, 32);
            this.txtUpper.Name = "txtUpper";
            this.txtUpper.Size = new System.Drawing.Size(40, 20);
            this.txtUpper.TabIndex = 8;
            this.txtUpper.Text = "0";
            // 
            // lblInnerPadLen
            // 
            this.lblInnerPadLen.AutoSize = true;
            this.lblInnerPadLen.Location = new System.Drawing.Point(432, 35);
            this.lblInnerPadLen.Name = "lblInnerPadLen";
            this.lblInnerPadLen.Size = new System.Drawing.Size(82, 13);
            this.lblInnerPadLen.TabIndex = 15;
            this.lblInnerPadLen.Text = "Padding Length";
            // 
            // txtPaddingLen
            // 
            this.txtPaddingLen.Location = new System.Drawing.Point(520, 32);
            this.txtPaddingLen.Name = "txtPaddingLen";
            this.txtPaddingLen.Size = new System.Drawing.Size(32, 20);
            this.txtPaddingLen.TabIndex = 14;
            this.txtPaddingLen.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Padding Char";
            // 
            // txtPaddingChar
            // 
            this.txtPaddingChar.Location = new System.Drawing.Point(400, 32);
            this.txtPaddingChar.Name = "txtPaddingChar";
            this.txtPaddingChar.Size = new System.Drawing.Size(32, 20);
            this.txtPaddingChar.TabIndex = 12;
            this.txtPaddingChar.Text = "0";
            // 
            // chkPadding
            // 
            this.chkPadding.Checked = true;
            this.chkPadding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPadding.Location = new System.Drawing.Point(256, 32);
            this.chkPadding.Name = "chkPadding";
            this.chkPadding.Size = new System.Drawing.Size(72, 24);
            this.chkPadding.TabIndex = 11;
            this.chkPadding.Text = "Padding";
            this.chkPadding.CheckedChanged += new System.EventHandler(this.chkPadding_CheckedChanged);
            // 
            // chkForward
            // 
            this.chkForward.Checked = true;
            this.chkForward.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForward.Location = new System.Drawing.Point(560, 35);
            this.chkForward.Name = "chkForward";
            this.chkForward.Size = new System.Drawing.Size(80, 16);
            this.chkForward.TabIndex = 16;
            this.chkForward.Text = "Forward";
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(574, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(56, 24);
            this.btnHide.TabIndex = 17;
            this.btnHide.Text = "Hide";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // SerialForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(640, 57);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.chkForward);
            this.Controls.Add(this.lblInnerPadLen);
            this.Controls.Add(this.txtPaddingLen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaddingChar);
            this.Controls.Add(this.txtUpper);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.txtLower);
            this.Controls.Add(this.lblUpper);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblLower);
            this.Controls.Add(this.txtSerialLink);
            this.Controls.Add(this.lblSerialLinkText);
            this.Controls.Add(this.chkPadding);
            this.Controls.Add(this.btnGo);
            this.Name = "SerialForm";
            this.Text = "SerialForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SerialForm_Closing);
            this.Load += new System.EventHandler(this.SerialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void chkPadding_CheckedChanged(object sender, System.EventArgs e)
		{
			txtPaddingChar.ReadOnly = !chkPadding.Checked;
			txtPaddingLen.ReadOnly = !chkPadding.Checked;
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
            SeriesLinks serialLink = new SeriesLinks();

            serialLink.Pattern = txtSerialLink.Text;
            if (txtLower.Text == "-1")
                serialLink.Start = Convert.ToInt32(txtCurrent.Text);
            else
                serialLink.Start = Convert.ToInt32(txtLower.Text);

            if (txtUpper.Text == "-1")
                serialLink.End = Convert.ToInt32(txtCurrent.Text);
            else
                serialLink.End = Convert.ToInt32(txtUpper.Text);

            serialLink.Current = Convert.ToInt32(txtCurrent.Text);

            serialLink.Direction = chkForward.Checked? SeriesLinkManager.SerialDirection.Forward: SeriesLinkManager.SerialDirection.Backward;
            serialLink.IsPadded = chkPadding.Checked;
            serialLink.PadLength = Convert.ToInt32(txtPaddingLen.Text);
            serialLink.PadWith = txtPaddingChar.Text.ToCharArray()[0];

            SerialUriChangedEventArgs args = new SerialUriChangedEventArgs(serialLink);

            SerialUriChanged(this, args);
		}

		private void SerialForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
            this.Hide();
		}

		private void btnHide_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

        public SeriesLinkManager SerialManager = new SeriesLinkManager();

        public void Show()
        {
            txtCurrent.Text = SerialManager.Serial.Current.ToString();
            txtLower.Text = SerialManager.Serial.Start.ToString();
            txtUpper.Text = SerialManager.Serial.End.ToString();

            txtSerialLink.Text = SerialManager.Serial.Pattern;

            chkForward.Checked = (SerialManager.Serial.Direction == SeriesLinkManager.SerialDirection.Forward);

            chkPadding.Checked = SerialManager.Serial.IsPadded;

            txtPaddingChar.Text = SerialManager.Serial.PadWith.ToString();
            txtPaddingLen.Text = SerialManager.Serial.PadLength.ToString();

            base.Show();
        }

        public event SerialUriChanged SerialUriChanged;

        private void SerialForm_Load(object sender, EventArgs e)
        {

        }

	}

    public delegate void SerialUriChanged(object sender, SerialUriChangedEventArgs e);

    public class SerialUriChangedEventArgs : System.EventArgs
    {
        private SeriesLinks serial;

        public SerialUriChangedEventArgs(SeriesLinks series)
        {
            serial = series;
        }

        public SeriesLinks Serial
        {
            get { return serial;  }
            set { serial = value; }
        }
    }
}
