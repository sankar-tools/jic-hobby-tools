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
            this.Hide();
            UnhideFolders();

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
    }
}
