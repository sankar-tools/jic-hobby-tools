using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GTech.Olivia.Gyzer
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
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOkay;
		private System.Windows.Forms.Label lblOuterPadLen;
		private System.Windows.Forms.TextBox txtOuterPadLen;
		private System.Windows.Forms.Label lblInnerPadLen;
		private System.Windows.Forms.TextBox txtInnerPadLen;
		private System.Windows.Forms.TextBox txtReferrer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtUrl;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOkay = new System.Windows.Forms.Button();
			this.txtReferrer = new System.Windows.Forms.TextBox();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.grpInner.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
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
			this.groupBox1.Location = new System.Drawing.Point(8, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(488, 192);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Outer Loop";
			// 
			// lblOuterPadLen
			// 
			this.lblOuterPadLen.AutoSize = true;
			this.lblOuterPadLen.Location = new System.Drawing.Point(248, 64);
			this.lblOuterPadLen.Name = "lblOuterPadLen";
			this.lblOuterPadLen.Size = new System.Drawing.Size(83, 16);
			this.lblOuterPadLen.TabIndex = 12;
			this.lblOuterPadLen.Text = "Padding Length";
			// 
			// txtOuterPadLen
			// 
			this.txtOuterPadLen.Enabled = false;
			this.txtOuterPadLen.Location = new System.Drawing.Point(336, 64);
			this.txtOuterPadLen.Name = "txtOuterPadLen";
			this.txtOuterPadLen.Size = new System.Drawing.Size(56, 20);
			this.txtOuterPadLen.TabIndex = 11;
			this.txtOuterPadLen.Text = "2";
			// 
			// chkInnerLoop
			// 
			this.chkInnerLoop.Location = new System.Drawing.Point(16, 80);
			this.chkInnerLoop.Name = "chkInnerLoop";
			this.chkInnerLoop.TabIndex = 10;
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
			this.grpInner.Location = new System.Drawing.Point(8, 104);
			this.grpInner.Name = "grpInner";
			this.grpInner.Size = new System.Drawing.Size(472, 80);
			this.grpInner.TabIndex = 9;
			this.grpInner.TabStop = false;
			this.grpInner.Text = "Inner Loop";
			// 
			// lblInnerPadLen
			// 
			this.lblInnerPadLen.AutoSize = true;
			this.lblInnerPadLen.Location = new System.Drawing.Point(240, 48);
			this.lblInnerPadLen.Name = "lblInnerPadLen";
			this.lblInnerPadLen.Size = new System.Drawing.Size(83, 16);
			this.lblInnerPadLen.TabIndex = 10;
			this.lblInnerPadLen.Text = "Padding Length";
			// 
			// txtInnerPadLen
			// 
			this.txtInnerPadLen.Enabled = false;
			this.txtInnerPadLen.Location = new System.Drawing.Point(323, 48);
			this.txtInnerPadLen.Name = "txtInnerPadLen";
			this.txtInnerPadLen.Size = new System.Drawing.Size(56, 20);
			this.txtInnerPadLen.TabIndex = 9;
			this.txtInnerPadLen.Text = "2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(88, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Padding Char";
			// 
			// txtInnerPad
			// 
			this.txtInnerPad.Enabled = false;
			this.txtInnerPad.Location = new System.Drawing.Point(168, 48);
			this.txtInnerPad.Name = "txtInnerPad";
			this.txtInnerPad.Size = new System.Drawing.Size(56, 20);
			this.txtInnerPad.TabIndex = 7;
			this.txtInnerPad.Text = "0";
			// 
			// chkInnerPad
			// 
			this.chkInnerPad.Location = new System.Drawing.Point(8, 40);
			this.chkInnerPad.Name = "chkInnerPad";
			this.chkInnerPad.Size = new System.Drawing.Size(72, 24);
			this.chkInnerPad.TabIndex = 6;
			this.chkInnerPad.Text = "Padding";
			this.chkInnerPad.CheckedChanged += new System.EventHandler(this.chkInnerPad_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(136, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Stop Index";
			// 
			// txtInnerEnd
			// 
			this.txtInnerEnd.Location = new System.Drawing.Point(208, 16);
			this.txtInnerEnd.Name = "txtInnerEnd";
			this.txtInnerEnd.TabIndex = 4;
			this.txtInnerEnd.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Start Index";
			// 
			// txtInnerBegin
			// 
			this.txtInnerBegin.Location = new System.Drawing.Point(72, 16);
			this.txtInnerBegin.Name = "txtInnerBegin";
			this.txtInnerBegin.Size = new System.Drawing.Size(56, 20);
			this.txtInnerBegin.TabIndex = 2;
			this.txtInnerBegin.Text = "";
			// 
			// lblOuterPad
			// 
			this.lblOuterPad.AutoSize = true;
			this.lblOuterPad.Location = new System.Drawing.Point(96, 64);
			this.lblOuterPad.Name = "lblOuterPad";
			this.lblOuterPad.Size = new System.Drawing.Size(73, 16);
			this.lblOuterPad.TabIndex = 8;
			this.lblOuterPad.Text = "Padding Char";
			// 
			// txtOuterPad
			// 
			this.txtOuterPad.Enabled = false;
			this.txtOuterPad.Location = new System.Drawing.Point(176, 64);
			this.txtOuterPad.Name = "txtOuterPad";
			this.txtOuterPad.Size = new System.Drawing.Size(56, 20);
			this.txtOuterPad.TabIndex = 7;
			this.txtOuterPad.Text = "0";
			// 
			// chkOuterPad
			// 
			this.chkOuterPad.Location = new System.Drawing.Point(8, 48);
			this.chkOuterPad.Name = "chkOuterPad";
			this.chkOuterPad.Size = new System.Drawing.Size(72, 24);
			this.chkOuterPad.TabIndex = 6;
			this.chkOuterPad.Text = "Padding";
			this.chkOuterPad.CheckedChanged += new System.EventHandler(this.chkOuterPad_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(136, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Stop Index";
			// 
			// txtOuterEnd
			// 
			this.txtOuterEnd.Location = new System.Drawing.Point(208, 32);
			this.txtOuterEnd.Name = "txtOuterEnd";
			this.txtOuterEnd.TabIndex = 4;
			this.txtOuterEnd.Text = "";
			// 
			// lblOuterBegin
			// 
			this.lblOuterBegin.AutoSize = true;
			this.lblOuterBegin.Location = new System.Drawing.Point(8, 32);
			this.lblOuterBegin.Name = "lblOuterBegin";
			this.lblOuterBegin.Size = new System.Drawing.Size(59, 16);
			this.lblOuterBegin.TabIndex = 3;
			this.lblOuterBegin.Text = "Start Index";
			// 
			// txtOuterBegin
			// 
			this.txtOuterBegin.Location = new System.Drawing.Point(72, 32);
			this.txtOuterBegin.Name = "txtOuterBegin";
			this.txtOuterBegin.Size = new System.Drawing.Size(56, 20);
			this.txtOuterBegin.TabIndex = 2;
			this.txtOuterBegin.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(420, 261);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOkay
			// 
			this.btnOkay.Location = new System.Drawing.Point(340, 261);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.TabIndex = 5;
			this.btnOkay.Text = "Okay";
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// txtReferrer
			// 
			this.txtReferrer.Location = new System.Drawing.Point(64, 32);
			this.txtReferrer.Name = "txtReferrer";
			this.txtReferrer.Size = new System.Drawing.Size(432, 20);
			this.txtReferrer.TabIndex = 6;
			this.txtReferrer.Text = "";
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(64, 8);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(432, 20);
			this.txtUrl.TabIndex = 7;
			this.txtUrl.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "URL";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Referrer";
			// 
			// SeriesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 294);
			this.ControlBox = false;
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.txtReferrer);
			this.Controls.Add(this.btnOkay);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox1);
			this.Name = "SeriesForm";
			this.Text = "SeriesForm";
			this.groupBox1.ResumeLayout(false);
			this.grpInner.ResumeLayout(false);
			this.ResumeLayout(false);

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

		private void btnOkay_Click(object sender, System.EventArgs e)
		{
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

			string constr = ConfigurationSettings.AppSettings["ControlDatabase"];

			try
			{
				cn.ConnectionString = constr;
				cn.Open();

				cmd.Connection = cn;

				cmd.CommandText = "insert into GrabList (url, referrer) values(?,?)";
				cmd.CommandType = CommandType.Text;
			
				cmd.Parameters.Add("url", SqlDbType.VarChar);
                cmd.Parameters.Add("referrer", SqlDbType.VarChar);

				if (chkInnerLoop.Checked)
				{
					if (txtUrl.Text.IndexOf("[i]") < 0 || txtUrl.Text.IndexOf("[j]") < 0)
						MessageBox.Show("Incorrect Url format");

					for(int i=Convert.ToInt32(txtOuterBegin.Text);
						i<=Convert.ToInt32(txtOuterEnd.Text);
						i++)
					{
						for(int j=Convert.ToInt32(txtInnerBegin.Text);
							j<=Convert.ToInt32(txtInnerEnd.Text);
							j++)
						{
							string url;
							if (chkOuterPad.Checked)
							{
								url = txtUrl.Text.Replace("[i]",i.ToString().PadLeft(Convert.ToInt32(txtOuterPadLen.Text), Convert.ToChar(txtOuterPad.Text)));
							}
							else
							{
								url = txtUrl.Text.Replace("[i]",i.ToString());
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

							cmd.ExecuteNonQuery();
						}
					}
				}
				else
				{
					if (txtUrl.Text.IndexOf("[i]") < 0)
						MessageBox.Show("Incorrect Url format");

					for(int i=Convert.ToInt32(txtOuterBegin.Text);
						i<=Convert.ToInt32(txtOuterEnd.Text);
						i++)
					{
						string url; //= txtUrl.Text.Replace("[i]",i.ToString());
//						url = txtUrl.Text.Replace("[i]",i.ToString().PadLeft(Convert.ToInt32(txtOuterPadLen.Text), Convert.ToChar(txtOuterPad.Text)));
						if (chkOuterPad.Checked)
						{
							url = txtUrl.Text.Replace("[i]",i.ToString().PadLeft(Convert.ToInt32(txtOuterPadLen.Text), Convert.ToChar(txtOuterPad.Text)));
						}
						else
						{
							url = txtUrl.Text.Replace("[i]",i.ToString());
						}

						cmd.Parameters[0].Value = url;
						cmd.Parameters[1].Value = txtReferrer.Text;

						cmd.ExecuteNonQuery();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
                //LogHelper.WriteLog(LogLevel.Verbose, "Exception : " + ex.Message);

			}
			finally
			{
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}

			MessageBox.Show("Series Generated Successfully");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
