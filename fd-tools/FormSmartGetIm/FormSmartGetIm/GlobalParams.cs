using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormSmartGetIm
{
    public static class GlobalParams
    {
        public static SansTech.Diagonstics.Log ActivityLog;
        public static SansTech.Diagonstics.Log LinksList;

        public static int Counter = 1;
        public static string Referrer = "";

        public static RunState State = RunState.Stopped;

        public static int CurrentLevel = 1;
        public static CommonTools.Node CurrentNode = null;

        public static string GetIgnoreList()
        {
            return SansTech.IO.File.ReadComplete(Properties.Settings.Default.ignoreList);
        }

    }

    public enum RunState
    {
        Start,
        Running,
        Pause,
        Stopped
    }
}
