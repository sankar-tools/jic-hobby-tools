using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web
{
    class WebProxy1
    {
        string cProxyAddress = "DEFAULTPROXY";
        public string Address
        {
            get { return cProxyAddress; }
            set { cProxyAddress = value; }
        }

        string cProxyBypass = "";
        public string ProxyByPassList
        {
            get { return cProxyBypass; }
            set { cProxyBypass = value; }
        }

        string cProxyUsername = "";
        public string UserName
        {
            get { return cProxyUsername; }
            set { cProxyUsername = value; }
        }

        string cProxyPassword = "";
        public string Password
        {
            get { return cProxyPassword; }
            set { cProxyPassword = value; }
        }

        string cProxyDomain = "";
        public string Domain
        {
            get { return cProxyDomain; }
            set { cProxyDomain = value; }
        }
    }
}
