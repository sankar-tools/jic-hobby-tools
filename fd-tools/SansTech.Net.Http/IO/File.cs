using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

        public static void WriteBinary(string savePath, string p)
        {
            BinaryWriter bw;

            bw = new BinaryWriter(new FileStream(savePath, FileMode.Create));
            bw.Write(p);

            bw.Close();
        }

        public static string ReadComplete(string path)
        {
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(path))
                return file.ReadToEnd();

            return string.Empty;
        }
    }
}
