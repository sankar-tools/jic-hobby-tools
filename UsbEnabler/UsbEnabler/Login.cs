using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UsbEnabler
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == Config.Instance().aCode)
            {
                this.Hide();
                UnhideFolders();
            }
            else
                MessageBox.Show("Enter proper password");

        }

        private void UnhideFolders()
        {
            string[] dirs = Directory.GetDirectories(".");
            foreach (string dir in dirs)
            {
                FileAttributes attributes = File.GetAttributes(dir);
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    attributes &= ~FileAttributes.Hidden;
                    File.SetAttributes(dir, attributes);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }
    }
}
