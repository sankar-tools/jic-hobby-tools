using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace SansTech.Net.Http
{
    public class HttpHelper
    {
        #region Class Variable

        MemoryStream oPostStream;
        BinaryWriter oPostData;

        int nPostMode = 1;

        int nConnectTimeout = 30;
        string cUserAgent = "West Wind HTTP .NET";
        string cReferrer = string.Empty;

        string cUsername = "";
        string cPassword = "";
        string cDomain = "";

        string cProxyAddress = "";
        string cProxyBypass = "";
        string cProxyUsername = "";
        string cProxyPassword = "";
        string cProxyDomain = "";

        bool bUseProxy = false;
        bool bAllowRedirect = true;

        int nBufferSize = 10000;

        bool bThrowExceptions = false;
        bool bHandleCookies = false;
        bool bUseSiteCredentials = false;
        bool bUseReferrer = true;

        string cErrorMsg = "";
        bool bError = false;
        HttpStatusCode statusCode;

        HttpWebResponse oWebResponse;
        HttpWebRequest oWebRequest;
        CookieCollection oCookies;

        string cMultiPartBoundary = "-----------------------------7cf2a327f01ae";


        #endregion

        #region Class Members

        public string Referrer
        {
            get { return this.cReferrer; }
            set { this.cReferrer = value; }
        }

        public int PostMode
        {
            get { return this.nPostMode; }
            set { this.nPostMode = value; }
        }

        public bool UseProxy
        {
            get { return this.bUseProxy; }
            set { this.bUseProxy = value; }
        }

        public bool AllowRedirect
        {
            get { return this.bAllowRedirect; }
            set { this.bAllowRedirect = value; }
        }

        public string SiteUserName
        {
            get { return this.cUsername; }
            set { cUsername = value; }
        }


        public string SitePassword
        {
            get { return this.cPassword; }
            set { this.cPassword = value; }
        }

        public string SiteDomain
        {
            get { return this.cDomain; }
            set { this.cDomain = value; }
        }

        public string ProxyAddress
        {
            get { return this.cProxyAddress; }
            set { this.cProxyAddress = value; }
        }


        public string ProxyBypass
        {
            get { return this.cProxyBypass; }
            set { this.cProxyBypass = value; }
        }


        public string ProxyUserName
        {
            get { return this.cProxyUsername; }
            set { this.cProxyUsername = value; }
        }


        public string ProxyPassword
        {
            get { return this.cProxyPassword; }
            set { this.cProxyPassword = value; }
        }

        public string ProxyDomain
        {
            get { return this.cProxyDomain; }
            set { this.cProxyDomain = value; }
        }


        public bool UseReferrer
        {
            get { return this.bUseReferrer; }
            set { this.bUseReferrer = value; }
        }


        public int TimeOut
        {
            get { return this.nConnectTimeout; }
            set { this.nConnectTimeout = value; }
        }


        public string ErrorMsg
        {
            get { return this.cErrorMsg; }
            set { this.cErrorMsg = value; }
        }

        public string UserAgent
        {
            get { return this.cUserAgent; }
            set { this.cUserAgent = value; }
        }

        public bool Error
        {
            get { return this.bError; }
            set { this.bError = value; }
        }


        public bool ThrowExceptions
        {
            get { return bThrowExceptions; }
            set { this.bThrowExceptions = value; }
        }


        public bool HandleCookies
        {
            get { return this.bHandleCookies; }
            set { this.bHandleCookies = value; }
        }


        public CookieCollection Cookies
        {
            get { return this.oCookies; }
            set { this.Cookies = value; }
        }


        public HttpWebResponse WebResponse
        {
            get { return this.oWebResponse; }
            set { this.oWebResponse = value; }
        }


        public HttpWebRequest WebRequest
        {
            get { return this.oWebRequest; }
            set { this.oWebRequest = value; }
        }

        public int BufferSize
        {
            get { return (this.nBufferSize / 1000); }
            set { this.nBufferSize = value * 1000; }
        }

        public bool UseSiteCredentials
        {
            get { return (this.bUseSiteCredentials); }
            set { this.bUseSiteCredentials = value; }
        }



        #endregion Class Methods

        public void AddPostKey(string Key, byte[] Value)
        {

            if (this.oPostData == null)
            {
                this.oPostStream = new MemoryStream();
                this.oPostData = new BinaryWriter(this.oPostStream);
            }

            if (Key == "RESET")
            {
                this.oPostStream = new MemoryStream();
                this.oPostData = new BinaryWriter(this.oPostStream);
            }

            switch (this.nPostMode)
            {
                case 1:
                    this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes(
                        Key + "=" + System.Web.HttpUtility.UrlEncode(Value) + "&"));
                    break;
                case 2:
                    this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes(
                        "--" + this.cMultiPartBoundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"" + Key + "\"\r\n\r\n"));

                    this.oPostData.Write(Value);

                    this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes("\r\n"));
                    break;
                default:
                    this.oPostData.Write(Value);
                    break;
            }
        }


        public void AddPostKey(string Key, string Value)
        {
            this.AddPostKey(Key, Encoding.GetEncoding(1252).GetBytes(Value));
        }


        public void AddPostKey(string FullPostBuffer)
        {
            this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes(FullPostBuffer));
        }


        public bool AddPostFile(string Key, string FileName)
        {
            byte[] lcFile;

            if (this.nPostMode != 2)
            {
                this.cErrorMsg = "File upload allowed only with Multi-part forms";
                this.bError = true;
                return false;
            }

            try
            {
                FileStream loFile = new FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                lcFile = new byte[loFile.Length];
                loFile.Read(lcFile, 0, (int)loFile.Length);
                loFile.Close();
            }
            catch (Exception e)
            {
                this.cErrorMsg = e.Message;
                this.bError = true;

                //MessageBox.Show(e.ToString());
                throw;
                
            }

            this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes(
                "--" + this.cMultiPartBoundary + "\r\n" +
                "Content-Disposition: form-data; name=\"" + Key + "\" filename=\"" +
                new FileInfo(FileName).Name + "\"\r\n\r\n"));

            this.oPostData.Write(lcFile);

            this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes("\r\n"));

            return true;
        }

        public void DownloadFileEv(string url, string referrer, string filePath)
        {
            StreamReader oHttpResponse;

            OnReceiveDataEventArgs oArgs = new OnReceiveDataEventArgs();

            if (bUseReferrer)
                oHttpResponse = this.GetUrlStream(url, referrer);
            else
                oHttpResponse = this.GetUrlStream(url);

            if (oHttpResponse == null)
            {
                if (bError)
                {
                    oArgs.Done = true;
                    oArgs.Error = true;
                    oArgs.StatusCode = statusCode;
                    oArgs.ErrorMsg = cErrorMsg;

                    OnReceiveData(this, oArgs);
                }

                return;
            }

            long lnSize = BufferSize;
            if (this.oWebResponse.ContentLength > 0)
                lnSize = this.oWebResponse.ContentLength;
            else
                lnSize = 0;

            Encoding enc = Encoding.GetEncoding(1252);

            StringBuilder loWriter = new StringBuilder((int)lnSize);

            byte[] lcTemp = new byte[BufferSize];

            oArgs.TotalBytes = lnSize;

            string dir = filePath.Substring(0, filePath.LastIndexOf(@"\") + 1);
            Directory.CreateDirectory(dir);

            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            //StreamWriter fileStream = new StreamWriter(filePath, false, System.Text.Encoding.Unicode );

            lnSize = 1;
            int lnCount = 0;
            long lnTotalBytes = 0;

            while (lnSize > 0)
            {
                //lnSize = oHttpResponse.Read(lcTemp, 0, (int)BufferSize);
                lnSize = oWebResponse.GetResponseStream().Read(lcTemp, 0, (int)BufferSize);
                if (lnSize > 0)
                {
                    //loWriter.Append(lcTemp, 0, (int)lnSize);
                    fileStream.Write(lcTemp, 0, (int)lnSize);

                    lnCount++;
                    lnTotalBytes += lnSize;

                    // *** Raise an event if hooked up
                    if (this.OnReceiveData != null)
                    {
                        /// *** Update the event handler
                        oArgs.CurrentByteCount = lnTotalBytes;
                        oArgs.NumberOfReads = lnCount;
                        //						oArgs.CurrentChunk = lcTemp;
                        oArgs.StatusCode = statusCode;
                        this.OnReceiveData(this, oArgs);

                        // *** Check for cancelled flag
                        if (oArgs.Cancel)
                            goto CloseDown;
                    }
                }
            } // while


            CloseDown:
            oHttpResponse.Close();
            fileStream.Close();

            // *** Send Done notification
            if (this.OnReceiveData != null && !oArgs.Cancel)
            {
                // *** Update the event handler
                oArgs.StatusCode = statusCode;
                oArgs.Done = true;
                this.OnReceiveData(this, oArgs);
            }

            //			return lcHtml;
            //return loWriter.ToString();

        }

        protected StreamReader GetUrlStream(string Url, HttpWebRequest Request)
        {
            HttpWebResponse Response = null;

            try
            {
                this.bError = false;
                this.cErrorMsg = "";

                if (Request == null)
                {
                    Request = (HttpWebRequest)System.Net.WebRequest.Create(Url);
                }

                Request.UserAgent = this.cUserAgent;
                Request.Timeout = this.nConnectTimeout * 1000;
                Request.AllowAutoRedirect = bAllowRedirect;

                // *** Save for external access
                this.oWebRequest = Request;

                // *** Handle Security for the request
                if (this.cUsername.Length > 0)
                {
                    if (this.cUsername == "AUTOLOGIN")
                        Request.Credentials = CredentialCache.DefaultCredentials;
                    else
                        Request.Credentials = new NetworkCredential(this.cUsername, this.cPassword);
                }

                InitializeProxy(Request);

                // *** Handle cookies - automatically re-assign 
                if (this.bHandleCookies)
                {
                    Request.CookieContainer = new CookieContainer();
                    if (this.oCookies != null && this.oCookies.Count > 0)
                    {
                        Request.CookieContainer.Add(this.oCookies);
                    }
                }

                // *** Deal with the POST buffer if any
                if (this.oPostData != null)
                {
                    Request.Method = "POST";
                    switch (this.nPostMode)
                    {
                        case 1:
                            Request.ContentType = "application/x-www-form-urlencoded";
                            // strip off any trailing & which can cause problems with some 
                            // http servers
                            //							if (this.cPostBuffer.EndsWith("&"))
                            //								this.cPostBuffer = this.cPostBuffer.Substring(0,this.cPostBuffer.Length-1);
                            break;
                        case 2:
                            Request.ContentType = "multipart/form-data; boundary=" + this.cMultiPartBoundary;
                            this.oPostData.Write(Encoding.GetEncoding(1252).GetBytes("--" + this.cMultiPartBoundary + "\r\n"));
                            break;
                        case 4:
                            Request.ContentType = "text/xml";
                            break;
                        default:
                            goto case 1;
                    }

                    if (!String.IsNullOrEmpty(cReferrer))
                        Request.Referer = cReferrer;

                    Stream loPostData = Request.GetRequestStream();
                    //loPostData.Write(lcPostData,0,lcPostData.Length);
                    this.oPostStream.WriteTo(loPostData);

                    //*** Close the memory stream
                    this.oPostStream.Close();
                    this.oPostStream = null;

                    //*** Close the Binary Writer
                    this.oPostData.Close();
                    this.oPostData = null;

                    //*** Close Request Stream
                    loPostData.Close();

                    // *** clear the POST buffer
                    //this.cPostBuffer = "";
                }


                // *** Retrieve the response headers 
                Response = (HttpWebResponse)Request.GetResponse();

                // ** Save cookies the server sends
                if (this.bHandleCookies)
                {
                    if (Response.Cookies.Count > 0)
                    {
                        if (this.oCookies == null)
                        {
                            this.oCookies = Response.Cookies;
                        }
                        else
                        {
                            // ** If we already have cookies update the list
                            foreach (Cookie oRespCookie in Response.Cookies)
                            {
                                bool bMatch = false;
                                foreach (Cookie oReqCookie in this.oCookies)
                                {
                                    if (oReqCookie.Name == oRespCookie.Name)
                                    {
                                        oReqCookie.Value = oRespCookie.Name;
                                        bMatch = true;
                                        break; // 
                                    }
                                } // for each ReqCookies
                                if (!bMatch)
                                    this.oCookies.Add(oRespCookie);
                            } // for each Response.Cookies
                        }  // this.Cookies == null
                    } // if Response.Cookie.Count > 0
                }  // if this.bHandleCookies = 0


                // *** Save the response object for external access
                this.oWebResponse = Response;

                Encoding enc;
                try
                {
                    if (Response.ContentEncoding.Length > 0)
                        enc = Encoding.GetEncoding(Response.ContentEncoding);
                    else
                        enc = Encoding.GetEncoding(1252);
                }
                catch
                {
                    // *** Invalid encoding passed
                    enc = Encoding.GetEncoding(1252);
                }

                // *** drag to a stream
                StreamReader strResponse =
                    new StreamReader(Response.GetResponseStream(), enc);
                return strResponse;
            }
            catch (Exception e)
            {
                if (this.bThrowExceptions)
                    throw e;

                this.cErrorMsg = e.Message;
                this.bError = true;
                return null;
            }
            finally
            {
                if (Response != null)
                    statusCode = Response.StatusCode;
                else
                    statusCode = HttpStatusCode.NotFound;
            }
        }

        /// <summary>
        /// Return a the result from an HTTP Url into a StreamReader.
        /// Client code should call Close() on the returned object when done reading.
        /// </summary>
        /// <param name="Url">Url to retrieve.</param>
        /// <returns></returns>
        public StreamReader GetUrlStream(string Url)
        {
            HttpWebRequest oHttpWebRequest = null;
            return this.GetUrlStream(Url, oHttpWebRequest);
        }

        public StreamReader GetUrlStream(string Url, string referer)
        {
            HttpWebRequest oHttpWebRequest = null;

            oHttpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(Url);
            oHttpWebRequest.Referer = cReferrer;

            return this.GetUrlStream(Url, oHttpWebRequest);
        }

        /// <summary>
        /// Return a the result from an HTTP Url into a StreamReader.
        /// Client code should call Close() on the returned object when done reading.
        /// </summary>
        /// <param name="Request">A Request object</param>
        /// <returns></returns>
        public StreamReader GetUrlStream(HttpWebRequest Request)
        {
            return this.GetUrlStream(Request.RequestUri.AbsoluteUri, Request);
        }



        /// <summary>
        /// Return a the result from an HTTP Url into a string.
        /// </summary>
        /// <param name="Url">Url to retrieve.</param>
        /// <returns></returns>
        public string GetUrl(string Url)
        {
            StreamReader oHttpResponse = this.GetUrlStream(Url);
            if (oHttpResponse == null)
                return "";

            string lcResult = oHttpResponse.ReadToEnd();
            oHttpResponse.Close();

            return lcResult;
        }

        /// <summary>
        /// Return a the result from an HTTP Url into a string.
        /// </summary>
        /// <param name="Url">Url to retrieve.</param>
        /// <returns></returns>
        public byte[] GetUrlBytes(string Url)
        {
            StreamReader oHttpResponse = this.GetUrlStream(Url);

            if (oHttpResponse == null)
            {
                return null;
            }

            string lcResult = oHttpResponse.ReadToEnd();
            oHttpResponse.Close();

            return null;
        }

        /// <summary>
        /// Retrieves URL with events in the OnReceiveData event.
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="BufferSize"></param>
        /// <returns></returns>
        public string GetUrlEvents(string Url, long BufferSize)
        {

            StreamReader oHttpResponse = this.GetUrlStream(Url);
            if (oHttpResponse == null)
                return "";

            long lnSize = BufferSize;
            if (this.oWebResponse.ContentLength > 0)
                lnSize = this.oWebResponse.ContentLength;
            else
                lnSize = 0;

            Encoding enc = Encoding.GetEncoding(1252);

            StringBuilder loWriter = new StringBuilder((int)lnSize);

            char[] lcTemp = new char[BufferSize];

            OnReceiveDataEventArgs oArgs = new OnReceiveDataEventArgs();
            oArgs.TotalBytes = lnSize;

            lnSize = 1;
            int lnCount = 0;
            long lnTotalBytes = 0;

            while (lnSize > 0)
            {
                lnSize = oHttpResponse.Read(lcTemp, 0, (int)BufferSize);
                if (lnSize > 0)
                {
                    loWriter.Append(lcTemp, 0, (int)lnSize);
                    lnCount++;
                    lnTotalBytes += lnSize;

                    // *** Raise an event if hooked up
                    if (this.OnReceiveData != null)
                    {
                        /// *** Update the event handler
                        oArgs.CurrentByteCount = lnTotalBytes;
                        oArgs.NumberOfReads = lnCount;
                        oArgs.CurrentChunk = lcTemp;
                        oArgs.Params.ContentType = this.oWebResponse.ContentType;
                        oArgs.DocumentType = HttpHelper.GetDocType(oArgs.Params.ContentType);
                        oArgs.Params.Url = Url;
                        oArgs.Params.Size = lnTotalBytes;
                        this.OnReceiveData(this, oArgs);

                        // *** Check for cancelled flag
                        if (oArgs.Cancel)
                            goto CloseDown;
                    }
                }
            } // while


            CloseDown:
            oHttpResponse.Close();

            // *** Send Done notification
            if (this.OnReceiveData != null && !oArgs.Cancel)
            {
                // *** Update the event handler
                oArgs.Done = true;
                oArgs.Document = loWriter.ToString();
                oArgs.Params.Title = GetDocTitle(oArgs.Document);
                this.OnReceiveData(this, oArgs);
            }

            //			return lcHtml;
            return loWriter.ToString();
        }

        protected String GetDocTitle(string contents)
        {
            Regex titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string title = "unknown";
            Match m = titleCheck.Match(contents);

            if (m.Success)
            {
                // we found a <title></title> match =]
                title = m.Groups[1].Value.ToString();
            }

            return title;
        }
        protected void InitializeProxy(HttpWebRequest Request)
        {
            // *** Handle Proxy Server configuration
            if (this.cProxyAddress.Length > 0)
            {
                if (this.cProxyAddress == "DEFAULTPROXY")
                {
                    Request.Proxy = new WebProxy();
                    Request.Proxy = WebProxy.GetDefaultProxy();
                }
                else
                {
                    WebProxy loProxy = new WebProxy(this.cProxyAddress, true);
                    if (this.cProxyBypass.Length > 0)
                    {
                        loProxy.BypassList = this.cProxyBypass.Split(';');
                    }

                    if (this.cProxyUsername.Length > 0)
                        loProxy.Credentials = new NetworkCredential(this.cProxyUsername, this.cProxyPassword, "satyam");

                    Request.Proxy = loProxy;
                }
            }
        }

        public event OnReceiveDataHandler OnReceiveData;

        public delegate void OnReceiveDataHandler(object sender, OnReceiveDataEventArgs e);

        public class OnReceiveDataEventArgs
        {
            public string Document = string.Empty;
            public UrlParams Params = null;
            public DocType DocumentType = DocType.unknown;
            public long CurrentByteCount = 0;
            public long TotalBytes = 0;
            public int NumberOfReads = 0;
            public char[] CurrentChunk;
            public bool Done = false;
            public bool Cancel = false;
            public bool Error = false;
            public HttpStatusCode StatusCode;
            public string ErrorMsg = string.Empty;

            public OnReceiveDataEventArgs()
            {
                Params = new UrlParams();
            }
        }

        public static DocType GetDocType(string contentType)
        { 
            if(contentType.Contains("image"))
                return DocType.image;

            if (contentType.Contains("html"))
                return DocType.html;

            return DocType.unknown;
        }

        public enum DocType
        { 
            html,
            image,
            script,
            style,
            unknown
        }

        public static UrlParams Ping(string url)
        {
            UrlParams oparams = new UrlParams();
            oparams.Url = url;
            oparams.Title = "To be implemented";
            oparams.ContentType = "Unknown";
            oparams.Size = -1;

            return oparams;
        }
    }
}
