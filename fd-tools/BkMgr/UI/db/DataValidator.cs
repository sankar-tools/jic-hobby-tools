using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fd.lib.ui.common.db
{
    public class DataValidator
    {
        public static bool IsString(TextBox txt, string name)
        {
            if(String.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show("Data entry error!!!", "Data not correct for " + name);
                txt.Focus();
                return false;
            }

            return true;
        }

        public static bool IsString(ComboBox txt, string name)
        {
            if (String.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show("Data entry error!!!", "Data not correct for " + name);
                txt.Focus();
                return false;
            }

            return true;
        }
    }
}
