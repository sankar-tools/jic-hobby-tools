using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormSmartGetIm
{
    public static class Params
    {
        public static int Counter = 1;
        public static string Referrer = "";

        public static RunState State = RunState.Stopped;
    }

    public enum RunState
    {
        Start,
        Running,
        Pause,
        Stopped
    }
}
