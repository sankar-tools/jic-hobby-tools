using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsbEnabler
{
    class FileQueue
    {
        public static Queue<string> Files = new Queue<string>();
        public static bool ScanComplete = false;
    }
}
