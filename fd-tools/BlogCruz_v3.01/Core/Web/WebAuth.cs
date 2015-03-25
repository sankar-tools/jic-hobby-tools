using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web
{
    public class WebAuth
    {
        #region Class Properties
        string cUsername = "";
        public string UserName
        {
            get { return cUsername; }
            set { cUsername = value; }
        }
        
        string cPassword = "";
        public string Password
        {
            get { return cPassword; }
            set { cPassword = value; }
        }

        string cDomain = "";
        public string Domain
        {
            get { return cDomain; }
            set { cDomain = value; }
        }
        #endregion

        #region ~ctor
        public WebAuth(string userName, string password, string domain)
        {
            this.cUsername = userName;
            this.cPassword = password;
            this.cDomain = domain;
        }
        #endregion
    }
}
