using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

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
                string tempname = name + "_" + fileCounter.ToString().PadLeft(4, '0');
                newName = tempname + "." + ext;
                fileCounter++;
            }

            string newpath =  filepath + @"\" + newName;
            if (newpath.Length > 255)
                throw new Exception("Filepath too long");
            return filepath + @"\" + MassageFileName(newName);
        }

        private static string MassageFileName(string filepath)
        {

           
            // Remove illegal chars from file path
            
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return(r.Replace(filepath, ""));
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

        public static string GetDirectoryForFilePath(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

    }
}
