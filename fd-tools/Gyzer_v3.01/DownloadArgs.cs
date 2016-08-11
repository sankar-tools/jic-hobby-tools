using System;
using System.Collections.Generic;
using System.Text;

namespace GTech.Olivia.Gyzer
{
    public enum ThreadState
    {
        New = 0,
        Starting = 1,
        Started = 2,
        Pausing = 3,
        Paused = 4,
        Stopping = 5,
        Stopped = 6
    }

    public class DownloadArgs
    {
        public int Id;
        public string Status;
        public double Size;
        public double Downloaded;
        //public int ProgressPercent;

        //public DownloadArgs(string status, double size, double count)
        //{
        //    this.Status = status;
        //    this.Size = size;
        //    this.Downloaded = count;
        //}

        public DownloadArgs(int id, string status, double size, double count)
        {
            this.Id = id;
            this.Status = status;
            this.Size = size;
            this.Downloaded = count;
        }
    }
}
