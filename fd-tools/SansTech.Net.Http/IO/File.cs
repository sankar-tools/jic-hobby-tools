using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansTech.IO
{
    public class File
    {
        public static void WriteLines(string path, string[] lines)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path, true))
            {
                foreach(string line in lines)
                    file.WriteLine(line);
            }
        }
    }
}
