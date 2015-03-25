using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web
{
    class WebException: Exception
    {
        string errorMessage;
        public string ErrorMessage
        {
          get { return errorMessage; }
          //set { errorMessage = value; }
        }

        public WebException(string errorMessage) : this(errorMessage, null) { }

        public WebException(string errorMessage, Exception innerException): base(errorMessage, innerException) 
        {
            this.errorMessage = errorMessage;
        }
    }
}
