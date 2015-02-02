using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SansTech.IO.Stream
{
    public class FileStream
    {
        // Reads data from read stream and write it to write stream
        // readStream is the stream you need to read
        // writeStream is the stream you want to write to
        public static void ReadWriteStream(System.IO.Stream readStream, System.IO.Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        } 

    }
}
