using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsbEnabler
{
    class Program
    {
        Queue<string> files = new Queue<string>();
        static void Main(string[] args)
        {
            System.Console.Out.WriteLine("Hello World!!!");

            string saveTo = Config.Instance().StorePath;
        }
    }
}
