using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UsbEnabler
{
    class Program
    {
        //Queue<string> files = new Queue<string>();
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm());
                Logger.Instance.Write(LogModule.Generic, "Application started at " + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(LogModule.Generic, "Unhandled exception");
                Logger.Instance.Write(LogModule.Generic, ex.StackTrace);
            }
        }
    }
}
