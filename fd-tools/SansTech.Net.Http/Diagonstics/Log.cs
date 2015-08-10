using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansTech.Diagonstics
{
    public class Log
    {
        string logPath = string.Empty;

        public Log(string path)
        {
            logPath = path;
            InitLog();
        }

        public void InitLog()
        {
            string[] header = {     
                                  "Sanstech diagnostics logging system",
                                  string.Format("Initialized at {0}", DateTime.Now),
                                  "-------------------------------------------------",
                                  " "
                              };

            SansTech.IO.File.WriteLines(logPath, header);
        }

        public void Write(string line)
        {
            SansTech.IO.File.WriteLines(logPath, new[] { line }); 
        }
    }
}
