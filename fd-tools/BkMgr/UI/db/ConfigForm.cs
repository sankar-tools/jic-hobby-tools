using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using fd.lib.ui.common.error;

namespace fd.lib.ui.common.db
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            txtConnStr.Text = ConfigData.ConnectionString;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (DbController.CheckDb(txtConnStr.Text))
                MessageBox.Show("Db connection OK");
        }
    }
}
