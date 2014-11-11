using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace UsbEnabler
{
    class Config
    {
        public string FileExtList { get; set; }
        public string[] ParseDirs {get;set;}
        public string StorePath { get; set; }
        public string LogFile { get; set; }

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
            XElement xdoc = XElement.Load("../../config.xml");

            //var config = xdoc.Descendants("UsbEnabler").Select(cfg => new Config
            //           {
            //               FileExtList = cfg.Element("FileTypes").Value,
            //               StorePath = cfg.Element("Store").Value
            //           });

            //configData = config as Config;
            configData.StorePath = @"d:\temp\store";
            configData.FileExtList = "jpg;png";
            configData.ParseDirs = new string[] { @"d:\dump", @"c:\dump", "$desktop" };
            configData.LogFile = "~temp12.log";

            //return config as Config;
        }
    }
}
