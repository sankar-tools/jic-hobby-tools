using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fd.lib.ui.common.error;
using System.Diagnostics;

namespace fd.lib.ui.common
{
    public class Sys
    {
        public static void OpenInBrowser(string p)
        {
            Process myProcess = new Process();

            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = p;
                myProcess.Start();
            }
            catch (Exception e)
            {
                ErrorDialog.Show("Process error", "Failed to launch default browser", e);
            }
        }
    }
}
