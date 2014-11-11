using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace UsbEnabler
{
    class FileScanner
    {
        public static void Init()
        {
            Logger.Write("FileScanner", "Process init");
            try
            {
                FileScanner scanner = new FileScanner();
                scanner.ScanFiles();
            }
            catch (ThreadAbortException e) 
            {
                Logger.Write("FileScanner", e.ToString());
            }
        }

        public void ScanFiles()
        {
            Logger.Write("FileScanner", "Start Scan");
            try
            {
                Config cfg = Config.Instance();
                string ext = cfg.FileExtList;
                foreach (string fileDir in cfg.ParseDirs)
                {
                    if (!System.IO.Directory.Exists(fileDir))
                        continue;

                    Logger.Write("FileScanner", "Scanning " + fileDir.ToString());

                    IEnumerable<string> allFiles = Directory.GetFiles(fileDir, "*.*", SearchOption.AllDirectories);
                    int fileCount = 0;
                    foreach(string file in allFiles)
                    {
                        foreach (string e in ext.Split(new char[] { ',', ';' }))
                        {
                            if (file.Contains(e))
                            {
                                FileQueue.Files.Enqueue(file);
                                fileCount++;
                            }
                        }
                    }

                    Logger.Write("FileScanner", fileCount.ToString() + " files added for " + fileDir + ", queue length " + FileQueue.Files.Count.ToString());
                }
                FileQueue.ScanComplete = true;
                Logger.Write("FileScanner", "Scan complete");
            }
            catch (Exception ex)
            {
                Logger.Write("FileScanner", ex.ToString());
            } 
        }
    }
}
