using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UsbEnabler
{
    class Logger
    {
        public TextBox logArea;
        private System.IO.StreamWriter file = null;
        private static Logger instance = null;

        private Logger()
        { 
            // initialize logger
            Config cfg = Config.Instance();
            string logPath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\" + cfg.LogFile;
            FileHelper.EnsurePath(logPath);
            file = new System.IO.StreamWriter(logPath);


        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();

                return instance;
            }
        }

        public void Write(string module, string msg)
        {
            string logMsg = String.Format("{0} :: {1}", module, msg);
            Console.WriteLine(logMsg);
            file.WriteLine(logMsg);
            file.Flush();
            UpdateLoggerNote(logMsg);
        }

        public delegate void UpdateTextCallback(string text);

        private void UpdateLoggerNote(string text)
        {
            //logArea.Invoke(new UpdateTextCallback(this.UpdateText), 
            //    new object[]{text});
            this.UpdateText(text);
        }

        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        private void UpdateText(string text)
        {
            // Set the textbox text.
            logArea.Text += "\r\n" + text;
        }
    }
}
