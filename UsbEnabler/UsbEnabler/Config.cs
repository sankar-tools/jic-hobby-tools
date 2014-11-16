using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.Collections.Specialized;

namespace UsbEnabler
{
    class Config
    {
        public string FileExtList { get; set; }
        public List<string> ParseDirs {get;set;}
        public string StorePath { get; set; }
        public string LogFile { get; set; }
        public List<string> SkipDirs { get; set; }
        public bool ScanAllDirs { get; set; }
        public bool ScanOnly { get; set; }
        public bool ShowUI { get; set; }
        public long MinSizeKb { get; set; }

        private static Config configData = null;

        private Config() { }

        public static Config Instance()
        {

            if (configData == null)
            {
                configData = new Config();
                configData.loadConfigXml();
            }

            return configData;
        }


        private void loadConfigXml()
        {
            //XElement xdoc = XElement.Load("../../config.xml");

            //var config = xdoc.Descendants("UsbEnabler").Select(cfg => new Config
            //           {
            //               FileExtList = cfg.Element("FileTypes").Value,
            //               StorePath = cfg.Element("Store").Value
            //           });

            configData.ParseDirs = Properties.Settings.Default.ParseDirs.Cast<string>().ToList();
            configData.SkipDirs = Properties.Settings.Default.SkipDirs.Cast<string>().ToList();
            configData.FileExtList = Properties.Settings.Default.FileExtList;
            configData.StorePath = Properties.Settings.Default.StorePath;
            configData.LogFile = Properties.Settings.Default.LogFile;
            configData.ShowUI = Properties.Settings.Default.ShowUI;
            configData.ScanAllDirs = Properties.Settings.Default.ScanAllDirs;
            configData.ScanOnly = Properties.Settings.Default.ScanOnly;
            configData.MinSizeKb = Properties.Settings.Default.MinSizeKb;

            //configData.StorePath = @".\store";
            //configData.FileExtList = "jpg;png";
            //configData.ParseDirs = new List<string> { @"d:\dump\imgs", @"d:\dump\memories", "$desktop" };
            //configData.LogFile = "~temp12.log";
            //configData.ScanAllDirs = false;
            //configData.ScanOnly = false;
            //configData.ShowUI = true;
            //configData.SkipDirs = new List<string> 
            //    { "$Recycle.Bin","boot","bPowerTemp","config.Msi","Documents and Settings",
            //        "MSOCache","PerfLogs","Program Files","Program Files (x86)", "ProgramData",
            //        "Recovery","System Volume Information","Windows"};
        }
    }
}
