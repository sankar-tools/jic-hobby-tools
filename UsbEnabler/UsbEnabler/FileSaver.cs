using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UsbEnabler
{
    class FileSaver
    {

        public static void Init()
        {
            FileSaver saver = new FileSaver();
            saver.Save();
        }

        public void Save()
        {
            Config cfg = Config.Instance();
            string storePath = cfg.StorePath + @"\" + System.Environment.MachineName + @"\";

            if (!System.IO.Directory.Exists(storePath))
            {
                System.IO.Directory.CreateDirectory(storePath);
            }

            while (true)
            {
                string file = FileQueue.Files.Dequeue();
                if (file != null)
                {
                    string destFile = GetDestinationPath(storePath, file);
                    try
                    {
                        EnsurePath(destFile);

                        System.IO.File.Copy(file, destFile, true);
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    if (FileQueue.ScanComplete == false)
                        break;
                    else
                        break;
                        //wait for further files to be scanned by file scanner
                }

            }
        }

        private static void EnsurePath(string destFile)
        {
            string destFolder = Path.GetDirectoryName(destFile);
            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }
        }

        private string GetDestinationPath(string storePath, string file)
        {
            return storePath + @"\" + file.Replace(':', '\\');
        }
    }
}
