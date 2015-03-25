using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.IO
{
    public class Directory
    {
        public static string CreateUniqueDirectory(string path, string name)
        {
            string newPath = path + @"\" + name;
            int index = 1;
            while (System.IO.Directory.Exists(newPath) && index < 999)
            {
                newPath = path + @"\" + name + "_" + index.ToString().PadLeft(3, '0');
                index++;
            }

            return newPath;
        }
    }
}
