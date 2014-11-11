using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace UsbEnabler
{
    class FileSaver
    {

        public static void Init()
        {
            Logger.Instance.Write("FileSaver", "Process init");
            try
            {
                FileSaver saver = new FileSaver();
                saver.Save();
            }
            catch (ThreadAbortException ex)
            {
                Logger.Instance.Write("FileSaver", ex.ToString());
            }
        }

        public void Save()
        {
            Config cfg = Config.Instance();
            string storePath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\";

            Logger.Instance.Write("FileSaver", "Storage path " + storePath);
            while (true)
            {
                try
                {
                    string file = FileQueue.Files.Dequeue();
                    if (file != null)
                    {
                        string destFile = GetDestinationPath(storePath, file);
                        try
                        {
                            FileHelper.EnsurePath(destFile);

                            System.IO.File.Copy(file, destFile, true);
                            Logger.Instance.Write("FileSaver", file + " saved to " + destFile);
                        }
                        catch (Exception ex) 
                        {
                            Logger.Instance.Write("FileSaver", "Error saving " + file + " saved to " + destFile);
                            Logger.Instance.Write("FileSaver", ex.ToString());
                        }
                    }
                }
                catch (InvalidOperationException ) // deque failed, no more items in queue
                {
                    if (FileQueue.ScanComplete == true)
                    {
                        Logger.Instance.Write("FileSaver", "All item copied");
                        break;
                    }
                    else
                        Thread.Sleep(new TimeSpan(0, 0, 5)); // wait 5 sec for more files to scan
                }

            }
        }

        private string GetDestinationPath(string storePath, string file)
        {
            return storePath + @"\" + file.Replace(':', '\\');
        }
    }
}
