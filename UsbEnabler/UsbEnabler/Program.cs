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
            //ThreadStart scanThreadPointer = new ThreadStart(FileScanner.Init);
            //ThreadStart saveThreadPointer = new ThreadStart(FileSaver.Init);

            //Thread scanThread = new Thread(scanThreadPointer);
            //Thread saveThread = new Thread(saveThreadPointer);

            //scanThread.Start();
            //Thread.Sleep(new TimeSpan(0, 0, 15));   // wait 15 secs before starting the save thread
            //saveThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}
