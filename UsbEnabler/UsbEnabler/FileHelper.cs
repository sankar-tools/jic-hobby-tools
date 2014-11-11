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
    }
}
