using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormSmartGetIm
{
    public partial class FileViewer : Form
    {
        public FileViewer()
        {
            InitializeComponent();
        }

        public void Show(string s)
        {
            txtContent.Text = s;
            this.Show();
        }
    }
}
