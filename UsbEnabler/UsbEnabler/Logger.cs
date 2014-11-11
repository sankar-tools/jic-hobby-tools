using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsbEnabler
{
    class Logger
    {
        static System.IO.StreamWriter file = null;
        static Logger()
        { 
            // initialize logger
            Config cfg = Config.Instance();
            string logPath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\" + cfg.LogFile;
            FileHelper.EnsurePath(logPath);
            file = new System.IO.StreamWriter(logPath);
        }

        public static void Write(string module, string msg)
        {
            Console.WriteLine(String.Format("{0} :: {1}", module, msg));
            file.WriteLine(String.Format("{0} :: {1}", module, msg));
        }
    }
}
