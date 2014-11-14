using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UsbEnabler
{
    class FileHelper
    {
        public static void EnsurePath(string destFile)
        {
            string destFolder = Path.GetDirectoryName(destFile);
            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }
        }

        internal static string GetDirectoryName(string dir)
        {
            var separators = new char[] {
                Path.DirectorySeparatorChar,  
                Path.AltDirectorySeparatorChar  
            };

            string[] dirs = dir.Split(separators);
            return dirs[dirs.Length - 1];
        }

        internal static void ShowFolder(string folder, bool show)
        {
            FileAttributes attributes = File.GetAttributes(folder);
            FileAttributes attr = FileAttributes.Hidden;

            if(show)
                attr = ~FileAttributes.Hidden;

            attributes &= attr;
            File.SetAttributes(folder, attributes);        
        }

        internal static void HideFolder(string folder)
        {
            DirectoryInfo di = Directory.CreateDirectory(folder);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden; 
        }
    }
}
