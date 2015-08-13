using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SansTech.IO
{
    public class Directory
    {
        public static string GetUniqueFilename(string filepath, string filename, string defaultExtension=null)
        {
            int fileCounter = 0;

            string name = filename;
            string ext = string.Empty;

            if (filename.LastIndexOf(".") > 1)
            {
                name = filename.Substring(1, filename.LastIndexOf(".") - 1);
                ext = filename.Substring(filename.LastIndexOf(".") + 1);
            }

            if (string.IsNullOrEmpty(ext) && defaultExtension != null)
                ext = defaultExtension;

            string newName = name + "." + ext;
            while (System.IO.File.Exists(filepath + @"\" + newName))
            {
                name = name + "_" + fileCounter.ToString().PadLeft(4, '0');
                newName = name + "." + ext;
            }

            return filepath + @"\" + newName;
        }

        public static string GetUniqueDirectory(string dirpath, string dirname)
        {
            int fileCounter = 0;

            while (System.IO.Directory.Exists(dirpath + @"\" + dirname))
            {
                string name = dirname;//.Substring(1, dirname.LastIndexOf(".") - 1);
                //string ext = dirname.Substring(dirname.LastIndexOf(".") + 1);

                //if (string.IsNullOrEmpty(ext) && defaultExtension != null)
                //    ext = defaultExtension;

                name = name + "_" + fileCounter.ToString().PadLeft(4, '0');
                dirname = name;// +"." + ext;
            }

            return dirpath + @"\" + dirname;
        }

        public static void EnsureDirectory(string path)
        {
            DirectoryInfo di = System.IO.Directory.CreateDirectory(path);
        }

    }
}
