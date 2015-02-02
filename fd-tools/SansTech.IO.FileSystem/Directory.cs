using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SansTech.IO.FileSystem
{
    public class Directory
    {
        public static string GetUniqueFilename(string filepath, string filename)
        {
            int fileCounter = 0;

            while (File.Exists(filepath + @"\" + filename))
            {
                string name = filename.Substring(1, filename.LastIndexOf(".") - 1);
                string ext = filename.Substring(filename.LastIndexOf(".") + 1);

                name = name + "_" + fileCounter.ToString().PadLeft(4, '0');
                filename = name + "." + ext;
            }

            return filepath + @"\" + filename;
        }

    }
}
