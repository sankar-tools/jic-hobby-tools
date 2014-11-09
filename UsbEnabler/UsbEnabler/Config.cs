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

        private static Config configData = null;

        private Config() { }

        public static Config Instance()
        {

            if (configData == null)
            {
                configData = new Config();
                configData = configData.loadConfigXml();
            }

            return configData;
        }


        private Config loadConfigXml()
        {
            XElement xdoc = XElement.Load("../../config.xml");

            var config = xdoc.Descendants("UsbEnabler").Select(cfg => new Config
                       {
                           FileExtList = cfg.Element("FileTypes").Value,
                           StorePath = cfg.Element("Store").Value
                       });

            return config as Config;
        }
    }
}
