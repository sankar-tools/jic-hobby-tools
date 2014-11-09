using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UsbEnabler
{
    class FileScanner
    {
        //Queue<string> q = new Queue<string>();

        public static void Init()
        {
            FileScanner scanner = new FileScanner();
            scanner.ScanFiles();
        }

        public void ScanFiles()
        {
            
            try
            {
                Config cfg = Config.Instance();
                string ext = cfg.FileExtList;
                foreach (string fileDir in cfg.ParseDirs)
                {
                    if (!System.IO.Directory.Exists(fileDir))
                        continue;

                    IEnumerable<string> allFiles = Directory.GetFiles(fileDir, "*.*", SearchOption.AllDirectories);
                    foreach(string file in allFiles)
                    {
                        foreach(string e in ext.Split(new char[] {',',';'}))
                            if(file.Contains(e))
                                FileQueue.Files.Enqueue(file);
                    }

                }
                FileQueue.ScanComplete = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Files scanned " + FileQueue.Files.Count);
        }

        //public bool MatchFileExtension(string fileName, string extensions)
        //{
        //    foreach(string ext in extensions.Split(new char[] {',',';'}))
        //        if(fileName.Contains(ext))
        //            return true;

        //    return false;
        //}

        //public IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        //{
        //    if (extensions == null)
        //        throw new ArgumentNullException("extensions");
        //    IEnumerable<FileInfo> files = dir.EnumerateFiles();
        //    return files.Where(f => extensions.Contains(f.Extension));
        //}
    }
}
