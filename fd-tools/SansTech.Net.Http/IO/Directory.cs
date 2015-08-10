using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SansTech.IO
{
    public class Directory
    {
        public static string GetUniqueFilename(string filepath, string filename)
        {
            int fileCounter = 0;

            while (System.IO.File.Exists(filepath + @"\" + filename))
            {
                string name = filename.Substring(1, filename.LastIndexOf(".") - 1);
                string ext = filename.Substring(filename.LastIndexOf(".") + 1);

                name = name + "_" + fileCounter.ToString().PadLeft(4, '0');
                filename = name + "." + ext;
            }

            return filepath + @"\" + filename;
        }

        public static void EnsureDirectory(string path)
        {
            DirectoryInfo di = System.IO.Directory.CreateDirectory(path);
        }

    }
}
