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
            Logger.Instance.Write(LogModule.FileScanner, "Process init");
            try
            {
                FileScanner scanner = new FileScanner();
                scanner.ScanFiles();
            }
            catch (ThreadAbortException e) 
            {
                Logger.Instance.Write(LogModule.FileScanner, e.ToString());
            }
        }

        public void ScanFiles()
        {
            Logger.Instance.Write(LogModule.FileScanner, "Scanning started at " + DateTime.Now.ToString());
            try
            {
                Config cfg = Config.Instance();
                string ext = cfg.FileExtList;
                foreach (string fileDir in cfg.ParseDirs)
                {
                    if (!System.IO.Directory.Exists(fileDir))
                        continue;

                    Logger.Instance.Write(LogModule.FileScanner, "Scanning " + fileDir.ToString());

                    int fileCount = 0;

                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(fileDir);
                        FileInfo[] allFiles = di.GetFiles("*.*", SearchOption.AllDirectories);
                        //IEnumerable<string> allFiles = Directory.GetFiles(fileDir, "*.*", SearchOption.AllDirectories);

                        foreach (FileInfo file in allFiles)
                        {
                            if (file.Length < cfg.MinSizeKb * 1024)
                                continue;

                            foreach (string e in ext.Split(new char[] { ',', ';' }))
                            {
                                if (file.Name.Contains(e))
                                {
                                    FileQueue.Files.Enqueue(file.FullName);
                                    fileCount++;
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Logger.Instance.Write(LogModule.FileScanner, ex.ToString());
                    }

                    Logger.Instance.Write(LogModule.FileScanner, fileCount.ToString() + " files added for " + fileDir + ", queue length " + FileQueue.Files.Count.ToString());
                }
                FileQueue.ScanComplete = true;
                Logger.Instance.Write(LogModule.FileScanner, "... scan completed at " + DateTime.Now.ToString());
                
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(LogModule.FileScanner, ex.ToString());
            } 
        }
    }
}
