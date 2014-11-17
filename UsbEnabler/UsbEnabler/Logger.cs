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
        private System.IO.StreamWriter saveLoggerFile = null;
        private System.IO.StreamWriter scanLoggerFile = null;
        private System.IO.StreamWriter genericLoggerFile = null;
        private static Logger instance = null;

        private Logger()
        { 
            // initialize logger
            Config cfg = Config.Instance();

            string saveLogPath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\save_" + cfg.LogFile;
            string scanLogPath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\scan_" + cfg.LogFile;
            string genericLogPath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\generic_" + cfg.LogFile;

            FileHelper.EnsurePath(saveLogPath);
            FileHelper.HideFolder(cfg.StorePath);

            saveLoggerFile = new System.IO.StreamWriter(saveLogPath);
            scanLoggerFile = new System.IO.StreamWriter(scanLogPath);
            genericLoggerFile = new System.IO.StreamWriter(genericLogPath);

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

        public void Write(LogModule module, string msg)
        {
            string logMsg = String.Format("{0} :: {1}", module, msg);
            Console.WriteLine(logMsg);
            switch (module)
            {
                case LogModule.FileScanner:
                    scanLoggerFile.WriteLine(msg);
                    scanLoggerFile.Flush();
                    break;

                case LogModule.FileSaver:
                    saveLoggerFile.WriteLine(msg);
                    saveLoggerFile.Flush();
                    break;

                default:
                    genericLoggerFile.WriteLine(logMsg);
                    genericLoggerFile.Flush();
                    break;
            }
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


enum LogModule
{
    FileScanner,
    FileSaver,
    Generic
}