using System;
using System.Security;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
//using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Security.Permissions;

using mshtml = MSHTML;
using SansTech.Net.Http;

namespace FireDragan
{
  /// <summary>
  /// An extended version of the <see cref="WebBrowser"/> control.
  /// </summary>
  class ExtendedWebBrowser : System.Windows.Forms.WebBrowser
  {

      [DllImport("User32.dll", EntryPoint = "FindWindowA")]
      private static extern long FindWindow(string lpClassName, string lpWindowName);
      [DllImport("User32.dll", EntryPoint = "FindWindowExA")]
      private static extern long FindWindowEx(long hWnd1, long hWnd2, string lpsz1, string lpsz2);
      [DllImport("User32.dll", EntryPoint = "SendMessageA")]
      private static extern long SendMessage(long hwnd, long wMsg, long wParam, object lParam);
      private const int BM_CLICK = 0xF5;

      private Timer timer1;
      private IContainer components;
    private UnsafeNativeMethods.IWebBrowser2 axIWebBrowser2;

        FileDownloadQueue que = new FileDownloadQueue();

      public ExtendedWebBrowser()
      {
          InitializeComponent();
      }
    /// <summary>
    /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code. 
    /// Called by the control when the underlying ActiveX control is created. 
    /// </summary>
    /// <param name="nativeActiveXObject"></param>
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    protected override void AttachInterfaces(object nativeActiveXObject)
    {
      this.axIWebBrowser2 = (UnsafeNativeMethods.IWebBrowser2)nativeActiveXObject;
      base.AttachInterfaces(nativeActiveXObject);
    }

    /// <summary>
    /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code. 
    /// Called by the control when the underlying ActiveX control is discarded. 
    /// </summary>
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    protected override void DetachInterfaces()
    {
      this.axIWebBrowser2 = null;
      base.DetachInterfaces();
    }

    /// <summary>
    /// Returns the automation object for the web browser
    /// </summary>
    public object Application
    {
      get { return axIWebBrowser2.Application; }
    }


    System.Windows.Forms.AxHost.ConnectionPointCookie cookie;
    WebBrowserExtendedEvents events;

    /// <summary>
    /// This method will be called to give you a chance to create your own event sink
    /// </summary>
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    protected override void CreateSink()
    {
      // Make sure to call the base class or the normal events won't fire
      base.CreateSink();
      events = new WebBrowserExtendedEvents(this);
      cookie = new AxHost.ConnectionPointCookie(this.ActiveXInstance, events, typeof(UnsafeNativeMethods.DWebBrowserEvents2));
    }

    /// <summary>
    /// Detaches the event sink
    /// </summary>
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    protected override void DetachSink()
    {
      if (null != cookie)
      {
        cookie.Disconnect();
        cookie = null;
      }
    }

    /// <summary>
    /// Fires when downloading of a document begins
    /// </summary>
    public event EventHandler Downloading;
    
    /// <summary>
    /// Raises the <see cref="Downloading"/> event
    /// </summary>
    /// <param name="e">Empty <see cref="EventArgs"/></param>
    /// <remarks>
    /// You could start an animation or a notification that downloading is starting
    /// </remarks>
    protected void OnDownloading(EventArgs e)
    {
      if (Downloading != null)
        Downloading(this, e);
    }

    /// <summary>
    /// Fires when downloading is completed
    /// </summary>
    /// <remarks>
    /// Here you could start monitoring for script errors. 
    /// </remarks>
    public event EventHandler DownloadComplete;
    /// <summary>
    /// Raises the <see cref="DownloadComplete"/> event
    /// </summary>
    /// <param name="e">Empty <see cref="EventArgs"/></param>
    protected virtual void OnDownloadComplete(EventArgs e)
    {
      if (DownloadComplete != null)
        DownloadComplete(this, e);
    }


    /// <summary>
    /// Fires before navigation occurs in the given object (on either a window or frameset element).
    /// </summary>
    public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNavigate;
    /// <summary>
    /// Raised when a new window is to be created. Extends DWebBrowserEvents2::NewWindow2 with additional information about the new window.
    /// </summary>
    public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNewWindow;
 
    /// <summary>
    /// Raises the <see cref="StartNewWindow"/> event
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
    protected void OnStartNewWindow(BrowserExtendedNavigatingEventArgs e)
    {
      if (e == null)
        throw new ArgumentNullException("e");

      if (this.StartNewWindow != null)
        this.StartNewWindow(this, e);

    }

    /// <summary>
    /// Raises the <see cref="StartNavigate"/> event
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
    protected void OnStartNavigate(BrowserExtendedNavigatingEventArgs e)
    {
      if (e == null)
        throw new ArgumentNullException("e");
        
      if (this.StartNavigate != null)
        this.StartNavigate(this, e);
    }

    #region The Implementation of DWebBrowserEvents2 for firing extra events

    //This class will capture events from the WebBrowser
    class WebBrowserExtendedEvents : UnsafeNativeMethods.DWebBrowserEvents2
    {
      public WebBrowserExtendedEvents() { }

      ExtendedWebBrowser _Browser;
      public WebBrowserExtendedEvents(ExtendedWebBrowser browser) { _Browser = browser; }

      #region DWebBrowserEvents2 Members

      //Implement whichever events you wish
      public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
      {
          Uri urlUri = new Uri(URL.ToString());

        string tFrame = null;
        if (targetFrameName != null)
          tFrame = targetFrameName.ToString();

        BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(pDisp, urlUri, tFrame, UrlContext.None);
        _Browser.OnStartNavigate(args);

        cancel = args.Cancel;
        pDisp = args.AutomationObject;
      }

      //The NewWindow2 event, used on Windows XP SP1 and below
        public void NewWindow2(ref object pDisp, ref bool cancel)
        {
            BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(pDisp, null, null, UrlContext.None);
            _Browser.OnStartNewWindow(args);
            cancel = args.Cancel;
            pDisp = args.AutomationObject;
        }

        private string newUrl = string.Empty;
        private uint _dwFlags;
      // NewWindow3 event, used on Windows XP SP2 and higher
      public void NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
      {
          _dwFlags = dwFlags;

        BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(ppDisp, new Uri(bstrUrl), null, (UrlContext)dwFlags);
        _Browser.OnStartNewWindow(args);
        Cancel = args.Cancel;
        ppDisp = args.AutomationObject;
      }

      // Fired when downloading begins
      public void DownloadBegin()
      {
        _Browser.OnDownloading(EventArgs.Empty);
      }

      // Fired when downloading is completed
      public void DownloadComplete()
      {
        _Browser.OnDownloadComplete(EventArgs.Empty);
      }

      #region Unused events

      // This event doesn't fire. 
      [DispId(0x00000107)]
      public void WindowClosing(bool isChildWindow, ref bool cancel)
      {
      }

      public void OnQuit()
      {
        
      }

      public void StatusTextChange(string text)
      {
      }

      public void ProgressChange(int progress, int progressMax)
      {
      }

      public void TitleChange(string text)
      {
      }

      public void PropertyChange(string szProperty)
      {
      }

      public void NavigateComplete2(object pDisp, ref object URL)
      {
      }

      public void DocumentComplete(object pDisp, ref object URL)
      {
      }

      public void OnVisible(bool visible)
      {
      }

      public void OnToolBar(bool toolBar)
      {
      }

      public void OnMenuBar(bool menuBar)
      {
      }

      public void OnStatusBar(bool statusBar)
      {
      }

      public void OnFullScreen(bool fullScreen)
      {
      }

      public void OnTheaterMode(bool theaterMode)
      {
      }

      public void WindowSetResizable(bool resizable)
      {
      }

      public void WindowSetLeft(int left)
      {
      }

      public void WindowSetTop(int top)
      {
      }

      public void WindowSetWidth(int width)
      {
      }

      public void WindowSetHeight(int height)
      {
      }
      
      public void SetSecureLockIcon(int secureLockIcon)
      {
      }

      public void FileDownload(ref bool cancel)
      {
      }

      public void NavigateError(object pDisp, ref object URL, ref object frame, ref object statusCode, ref bool cancel)
      {
      }

      public void PrintTemplateInstantiation(object pDisp)
      {
      }

      public void PrintTemplateTeardown(object pDisp)
      {
      }

      public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
      {
      }

      public void PrivacyImpactedStateChange(bool bImpacted)
      {
      }

      public void CommandStateChange(int Command, bool Enable)
      {
      }

      public void ClientToHostWindow(ref int CX, ref int CY)
      {

      }
      #endregion

      #endregion
    }

    #endregion

    #region Raises the Quit event when the browser window is about to be destroyed

    /// <summary>
    /// Overridden
    /// </summary>
    /// <param name="m">The <see cref="Message"/> send to this procedure</param>
    [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")] 
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == (int)WindowsMessages.WM_PARENTNOTIFY)
      {
        //int lp = m.LParam.ToInt32();
        int wp = m.WParam.ToInt32();

        int X = wp & 0xFFFF;
        //int Y = (wp >> 16) & 0xFFFF;
        if (X == (int)WindowsMessages.WM_DESTROY)
          this.OnQuit();
      }

      base.WndProc(ref m);
    }

    /// <summary>
    /// A list of all the available window messages
    /// </summary>
    enum WindowsMessages
    {
      WM_ACTIVATE = 0x6,
      WM_ACTIVATEAPP = 0x1C,
      WM_AFXFIRST = 0x360,
      WM_AFXLAST = 0x37F,
      WM_APP = 0x8000,
      WM_ASKCBFORMATNAME = 0x30C,
      WM_CANCELJOURNAL = 0x4B,
      WM_CANCELMODE = 0x1F,
      WM_CAPTURECHANGED = 0x215,
      WM_CHANGECBCHAIN = 0x30D,
      WM_CHAR = 0x102,
      WM_CHARTOITEM = 0x2F,
      WM_CHILDACTIVATE = 0x22,
      WM_CLEAR = 0x303,
      WM_CLOSE = 0x10,
      WM_COMMAND = 0x111,
      WM_COMPACTING = 0x41,
      WM_COMPAREITEM = 0x39,
      WM_CONTEXTMENU = 0x7B,
      WM_COPY = 0x301,
      WM_COPYDATA = 0x4A,
      WM_CREATE = 0x1,
      WM_CTLCOLORBTN = 0x135,
      WM_CTLCOLORDLG = 0x136,
      WM_CTLCOLOREDIT = 0x133,
      WM_CTLCOLORLISTBOX = 0x134,
      WM_CTLCOLORMSGBOX = 0x132,
      WM_CTLCOLORSCROLLBAR = 0x137,
      WM_CTLCOLORSTATIC = 0x138,
      WM_CUT = 0x300,
      WM_DEADCHAR = 0x103,
      WM_DELETEITEM = 0x2D,
      WM_DESTROY = 0x2,
      WM_DESTROYCLIPBOARD = 0x307,
      WM_DEVICECHANGE = 0x219,
      WM_DEVMODECHANGE = 0x1B,
      WM_DISPLAYCHANGE = 0x7E,
      WM_DRAWCLIPBOARD = 0x308,
      WM_DRAWITEM = 0x2B,
      WM_DROPFILES = 0x233,
      WM_ENABLE = 0xA,
      WM_ENDSESSION = 0x16,
      WM_ENTERIDLE = 0x121,
      WM_ENTERMENULOOP = 0x211,
      WM_ENTERSIZEMOVE = 0x231,
      WM_ERASEBKGND = 0x14,
      WM_EXITMENULOOP = 0x212,
      WM_EXITSIZEMOVE = 0x232,
      WM_FONTCHANGE = 0x1D,
      WM_GETDLGCODE = 0x87,
      WM_GETFONT = 0x31,
      WM_GETHOTKEY = 0x33,
      WM_GETICON = 0x7F,
      WM_GETMINMAXINFO = 0x24,
      WM_GETOBJECT = 0x3D,
      WM_GETTEXT = 0xD,
      WM_GETTEXTLENGTH = 0xE,
      WM_HANDHELDFIRST = 0x358,
      WM_HANDHELDLAST = 0x35F,
      WM_HELP = 0x53,
      WM_HOTKEY = 0x312,
      WM_HSCROLL = 0x114,
      WM_HSCROLLCLIPBOARD = 0x30E,
      WM_ICONERASEBKGND = 0x27,
      WM_IME_CHAR = 0x286,
      WM_IME_COMPOSITION = 0x10F,
      WM_IME_COMPOSITIONFULL = 0x284,
      WM_IME_CONTROL = 0x283,
      WM_IME_ENDCOMPOSITION = 0x10E,
      WM_IME_KEYDOWN = 0x290,
      WM_IME_KEYLAST = 0x10F,
      WM_IME_KEYUP = 0x291,
      WM_IME_NOTIFY = 0x282,
      WM_IME_REQUEST = 0x288,
      WM_IME_SELECT = 0x285,
      WM_IME_SETCONTEXT = 0x281,
      WM_IME_STARTCOMPOSITION = 0x10D,
      WM_INITDIALOG = 0x110,
      WM_INITMENU = 0x116,
      WM_INITMENUPOPUP = 0x117,
      WM_INPUTLANGCHANGE = 0x51,
      WM_INPUTLANGCHANGEREQUEST = 0x50,
      WM_KEYDOWN = 0x100,
      WM_KEYFIRST = 0x100,
      WM_KEYLAST = 0x108,
      WM_KEYUP = 0x101,
      WM_KILLFOCUS = 0x8,
      WM_LBUTTONDBLCLK = 0x203,
      WM_LBUTTONDOWN = 0x201,
      WM_LBUTTONUP = 0x202,
      WM_MBUTTONDBLCLK = 0x209,
      WM_MBUTTONDOWN = 0x207,
      WM_MBUTTONUP = 0x208,
      WM_MDIACTIVATE = 0x222,
      WM_MDICASCADE = 0x227,
      WM_MDICREATE = 0x220,
      WM_MDIDESTROY = 0x221,
      WM_MDIGETACTIVE = 0x229,
      WM_MDIICONARRANGE = 0x228,
      WM_MDIMAXIMIZE = 0x225,
      WM_MDINEXT = 0x224,
      WM_MDIREFRESHMENU = 0x234,
      WM_MDIRESTORE = 0x223,
      WM_MDISETMENU = 0x230,
      WM_MDITILE = 0x226,
      WM_MEASUREITEM = 0x2C,
      WM_MENUCHAR = 0x120,
      WM_MENUCOMMAND = 0x126,
      WM_MENUDRAG = 0x123,
      WM_MENUGETOBJECT = 0x124,
      WM_MENURBUTTONUP = 0x122,
      WM_MENUSELECT = 0x11F,
      WM_MOUSEACTIVATE = 0x21,
      WM_MOUSEFIRST = 0x200,
      WM_MOUSEHOVER = 0x2A1,
      WM_MOUSELAST = 0x20A,
      WM_MOUSELEAVE = 0x2A3,
      WM_MOUSEMOVE = 0x200,
      WM_MOUSEWHEEL = 0x20A,
      WM_MOVE = 0x3,
      WM_MOVING = 0x216,
      WM_NCACTIVATE = 0x86,
      WM_NCCALCSIZE = 0x83,
      WM_NCCREATE = 0x81,
      WM_NCDESTROY = 0x82,
      WM_NCHITTEST = 0x84,
      WM_NCLBUTTONDBLCLK = 0xA3,
      WM_NCLBUTTONDOWN = 0xA1,
      WM_NCLBUTTONUP = 0xA2,
      WM_NCMBUTTONDBLCLK = 0xA9,
      WM_NCMBUTTONDOWN = 0xA7,
      WM_NCMBUTTONUP = 0xA8,
      WM_NCMOUSEHOVER = 0x2A0,
      WM_NCMOUSELEAVE = 0x2A2,
      WM_NCMOUSEMOVE = 0xA0,
      WM_NCPAINT = 0x85,
      WM_NCRBUTTONDBLCLK = 0xA6,
      WM_NCRBUTTONDOWN = 0xA4,
      WM_NCRBUTTONUP = 0xA5,
      WM_NEXTDLGCTL = 0x28,
      WM_NEXTMENU = 0x213,
      WM_NOTIFY = 0x4E,
      WM_NOTIFYFORMAT = 0x55,
      WM_NULL = 0x0,
      WM_PAINT = 0xF,
      WM_PAINTCLIPBOARD = 0x309,
      WM_PAINTICON = 0x26,
      WM_PALETTECHANGED = 0x311,
      WM_PALETTEISCHANGING = 0x310,
      WM_PARENTNOTIFY = 0x210,
      WM_PASTE = 0x302,
      WM_PENWINFIRST = 0x380,
      WM_PENWINLAST = 0x38F,
      WM_POWER = 0x48,
      WM_PRINT = 0x317,
      WM_PRINTCLIENT = 0x318,
      WM_QUERYDRAGICON = 0x37,
      WM_QUERYENDSESSION = 0x11,
      WM_QUERYNEWPALETTE = 0x30F,
      WM_QUERYOPEN = 0x13,
      WM_QUEUESYNC = 0x23,
      WM_QUIT = 0x12,
      WM_RBUTTONDBLCLK = 0x206,
      WM_RBUTTONDOWN = 0x204,
      WM_RBUTTONUP = 0x205,
      WM_RENDERALLFORMATS = 0x306,
      WM_RENDERFORMAT = 0x305,
      WM_SETCURSOR = 0x20,
      WM_SETFOCUS = 0x7,
      WM_SETFONT = 0x30,
      WM_SETHOTKEY = 0x32,
      WM_SETICON = 0x80,
      WM_SETREDRAW = 0xB,
      WM_SETTEXT = 0xC,
      WM_SETTINGCHANGE = 0x1A,
      WM_SHOWWINDOW = 0x18,
      WM_SIZE = 0x5,
      WM_SIZECLIPBOARD = 0x30B,
      WM_SIZING = 0x214,
      WM_SPOOLERSTATUS = 0x2A,
      WM_STYLECHANGED = 0x7D,
      WM_STYLECHANGING = 0x7C,
      WM_SYNCPAINT = 0x88,
      WM_SYSCHAR = 0x106,
      WM_SYSCOLORCHANGE = 0x15,
      WM_SYSCOMMAND = 0x112,
      WM_SYSDEADCHAR = 0x107,
      WM_SYSKEYDOWN = 0x104,
      WM_SYSKEYUP = 0x105,
      WM_TCARD = 0x52,
      WM_TIMECHANGE = 0x1E,
      WM_TIMER = 0x113,
      WM_UNDO = 0x304,
      WM_UNINITMENUPOPUP = 0x125,
      WM_USER = 0x400,
      WM_USERCHANGED = 0x54,
      WM_VKEYTOITEM = 0x2E,
      WM_VSCROLL = 0x115,
      WM_VSCROLLCLIPBOARD = 0x30A,
      WM_WINDOWPOSCHANGED = 0x47,
      WM_WINDOWPOSCHANGING = 0x46,
      WM_WININICHANGE = 0x1A
    }

    /// <summary>
    /// Raises the <see cref="Quit"/> event
    /// </summary>
    protected void OnQuit()
    {
      EventHandler h = Quit;
      if (null != h)
        h(this, EventArgs.Empty);
    }

    /// <summary>
    /// Raised when the browser application quits
    /// </summary>
    /// <remarks>
    /// Do not confuse this with DWebBrowserEvents2.Quit... That's something else.
    /// </remarks>
    public event EventHandler Quit;


    #endregion

      #region "Link management functions"

      PageLinkManager pgLinks = new PageLinkManager();


      public PageLinkManager GetBrowsableLinks()
      {
          if (pgLinks.IsGarbage == true)
          {
              HtmlDocument myDoc = null; 
              myDoc = (HtmlDocument)this.Document;

              try
              {
                  foreach (HtmlElement lnkElement in myDoc.Links)
                  {
                      pgLinks.AddLink(lnkElement.GetAttribute("Href"), lnkElement.GetAttribute("Title"));
                  }
                  pgLinks.IsGarbage = false;
              }
              catch (InvalidCastException ex)
              {
                  MessageBox.Show("Invalidcast : " + ex.ToString());
              }
          }

          return pgLinks;
      }

      public string[] GetImageLinks()
      {
          HtmlDocument myDoc = null; 
          myDoc = (HtmlDocument)this.Document;

          System.Collections.ArrayList arr = new System.Collections.ArrayList();

          try
          {
              foreach (HtmlElement lnkElement in myDoc.Links)
              {
                  if (IsImageUrl(lnkElement.GetAttribute("Href")))
                      arr.Add(lnkElement.GetAttribute("Href"));
              }
          }
          catch (InvalidCastException ex)
          {
              MessageBox.Show("Invalidcast : " + ex.ToString());
          }

          string[] urls = new string[arr.Count];

          arr.CopyTo(urls, 0);
          return (urls);
      }

      public string[] GetHtmlLinks()
      {
          HtmlDocument myDoc = null;
          myDoc = (HtmlDocument)this.Document;

          System.Collections.ArrayList arr = new System.Collections.ArrayList();

          try
          {
              foreach (HtmlElement lnkElement in myDoc.Links)
              {
                  arr.Add(lnkElement.GetAttribute("Href"));
              }
          }
          catch (InvalidCastException ex)
          {
              MessageBox.Show("Invalidcast : " + ex.ToString());
          }

          string[] urls = new string[arr.Count];

          arr.CopyTo(urls, 0);
          return (urls);
      }

      public Boolean IsImageUrl(string uri)
      {
          string fileExt = uri.Substring(uri.LastIndexOf(".") + 1).ToLower();

          if (fileExt.Length > 0)
          {
              string imageExtensions = SettingsHelper.Current.ImageExpression;
              return (!(imageExtensions.IndexOf(fileExt) < 0));
          }
          else
              return false;
      }

    #endregion

      #region "Serial Link Management methods

      public SeriesLinkManager SerialManager = new SeriesLinkManager();
      public bool IsSerial = false;


      #endregion

      public void Transform(string pre, string post, bool decode)
      {
          HtmlDocument myDoc = null;
          myDoc = (HtmlDocument)this.Document;

          // To make sure that page is not double process, we are using he marker <<SansWebProcMarker>>

          // Check if the marker is already available in page. 
          HtmlElementCollection returnedElems = myDoc.All.GetElementsByName("SansWebProcMarker");
          if ((returnedElems != null) && (returnedElems.Count > 0))
          {
              return;
          }

          // Insert marker
          HtmlElement divElem = myDoc.CreateElement("DIV");
          divElem.Name = "SansWebProcMarker";
          divElem.Style = "background-color:black;color:white;font-weight:bold;width:100%;";
          divElem.InnerText = "This page is processed with href markers";

          divElem = myDoc.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, divElem);


          try
          {
              foreach (HtmlElement lnkElement in myDoc.Links)
              {
                  string orignalLink = lnkElement.GetAttribute("Href");
                  string newLink = ProcessLink(orignalLink, pre, post, decode);

                  //MessageBox.Show("<a href='" + newLink + "'></a>");
                  divElem = myDoc.CreateElement("<a href='"+ newLink + "'> Sans Link</a>");
                  divElem.Name = "SansWebProcLink";
                  divElem.Style = "background-color:teal;color:white;";
                  divElem.SetAttribute("href", newLink);
                  //lnkElement.SetAttribute("Href", newLink);
                  divElem.InnerText = "Sans Link";

                  divElem = lnkElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, divElem);
              }
          }
          catch (InvalidCastException ex)
          {
              MessageBox.Show("Invalidcast : " + ex.ToString());
          }

      }

      public void RemoveTransform()
      {
          HtmlDocument myDoc = null;
          myDoc = (HtmlDocument)this.Document;

          // If the page is already process, we should have the marker <<SansWebProcMarker>>

          // Check for the marker, if not found exit
          HtmlElementCollection returnedElems = myDoc.All.GetElementsByName("SansWebProcMarker");
          if ((returnedElems == null) || (returnedElems.Count == 0))
          {
              return;
          }

          try
          {
              // Remove the marker <<SansWebProcMarker>>
              foreach(HtmlElement returnedEle in returnedElems)
              {
                  returnedEle.OuterHtml = "";
              }

              // Remove the processed links <<SansWebProcLink>>
              foreach (HtmlElement lnkElement in myDoc.Links)
              {
                  if (lnkElement.GetAttribute("Name").Contains("SansWebProcLink"))
                  {
                      lnkElement.OuterHtml = "";
                  }
              }
          }
          catch (InvalidCastException ex)
          {
              MessageBox.Show("Invalidcast : " + ex.ToString());
          }

      }

      private string ProcessLink(string link, string pre, string post, bool decode)
      {
          if (decode == true)
          {
              link = Uri.UnescapeDataString(link);
          }

          // Chop all the string till the first occurance of pre string
          if (pre.Length != 0)
          {
                  string text = link.ToLower();
                  int firstOccurance = text.IndexOf(pre.ToLower());
                  int startPoint = 0;

                  if (firstOccurance > 0)
                  {
                      startPoint = firstOccurance + pre.Length;
                  }

                  link = link.Substring(startPoint);
          }

          // Chop all the string from the last occurance of the post string
          if (post.Length != 0)
          {
                  string text = link.ToLower();
                  int lastOccurance = text.LastIndexOf(post.ToLower());
                  int newlength = text.Length;

                  if (lastOccurance > 0)
                  {
                      newlength = lastOccurance;
                  }

                  link = text.Substring(0, newlength);
          }

          return link;
      }

      public void ClickFormButton(string buttonId)
      {
          HtmlElement el = this.Document.All[buttonId];
          object obj = el.DomElement;
          System.Reflection.MemberInfo mi = obj.GetType().GetMethod("click");
          //mi.

          mshtml.HTMLInputElement el2 = (mshtml.HTMLInputElement)el.DomElement;
          el2.click();

      }
      //This function reloads all unloaded images due to timeout
      //Logic: Use javascript to swipe the image src attribute
      public void ReloadImages()
      {
          HtmlDocument myDoc = null;
          myDoc = (HtmlDocument) this.Document;

          // To make sure that page is not double process, we are using he marker <<SansImgProcMarker>>

          // Check if the marker is already available in page. 
          HtmlElementCollection returnedElems = myDoc.All.GetElementsByName("SansImgProcMarker");
          if ((returnedElems != null) && (returnedElems.Count > 0))
          {
          }
          else
          {

              // Insert marker
              HtmlElement divElem = myDoc.CreateElement("DIV");
              divElem.Name = "SansImgProcMarker";
              divElem = myDoc.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, divElem);

              HtmlElement buttonElem = myDoc.CreateElement("<input id='SansImgProcButton' type='button' onclick='alert(\"Reload\");for (var i = 0; i < images.length; i++){var oldsrc = images.item(i).src;images.item(i).src =\"None\";images.item(i).src = oldsrc;}'  value='Click2Reload' />");
              buttonElem = myDoc.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, buttonElem);
          }

          ClickFormButton("SansImgProcButton");
          //Junk code left for reference
          //  *** --- ****

          //divElem = myDoc.CreateElement("<script langugage='javascript'>");
          //////divElem.InnerText += "<script langugage='javascript'>";
          //divElem.InnerHtml = "function ShowImages(){";
          //divElem.InnerHtml += "alert('show');";
          //divElem.InnerHtml += "var images = document.images;";
          //divElem.InnerHtml += "if (images != null){";
          //divElem.InnerHtml += "        for (var i = 0; i < images.length; i++){ ";
          //divElem.InnerHtml += "            var img = images.item(i);";
          //divElem.InnerHtml += "            var oldsrc = img.src;";
          //divElem.InnerHtml += "            img.src = 'none'";
          //divElem.InnerHtml += "            img.src = oldsrc;";
          //divElem.InnerHtml += "}   }   }";
          ////divElem.InnerHtml += "</script>";
          //divElem = myDoc.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, divElem);
          
          //  *** --- ****
      }

      // This function saves the image in the window to save folder under a unique name
      // Logic: To define

      public void SaveImage(string category, int logic)
      {
          if (category == string.Empty)
          {
              MessageBox.Show("select category");
              return;
          }
          
          if (this.DocumentType.ToUpper().Contains("Image".ToUpper()))
          {
              SaveImageLogic(category, this.Url.ToString(), logic);
          }
          else // It is a web page
          {
              string[] links = GetImageLinks();
              foreach (string str in links)
              {
                  SaveImageLogic(category, str, logic);
              }

          }
      }

      private void SaveImageLogic(string category, string url, int logic)
      {
          try
          {
              string filepath = SettingsHelper.Current.ImageSaveLocation + @"\" + category.Replace(',','\\');

              if (Directory.Exists(filepath) == false)
                  Directory.CreateDirectory(filepath);

              string filename = url;

              filename = filename.Substring(filename.LastIndexOf('/') + 1);

              string filefullname = filepath + @"\" + filename;
              if (File.Exists(filefullname))
              {
                  string newfilefullname = GetUniqueFilename(filepath, filename);
                  File.Move(filefullname, newfilefullname);
              }

              if (logic ==1)
              // Logic 1: Use http helper class to re-download the file and save to the location with multithreading
              //   Solution works fine
              //   Known Issues:
              //      Not working with sites that use referrer check; file download logic can use the referrer; but with 
              //      the current version of IE it is becoming difficult to find the current page referrer; when
              //      that is solved this is good solution as it is implemented with multithreading; but ofcourse
              //      unnecessary bandwidth consumption due to redownload of a file that is already displayed in IE
              {
                  que.Enqueue(this.Url.ToString(), this.Url.Host, filefullname);
              }

              if (logic == 2) 
              // Logic 2: As the file is already downloaded by IE and is displayed in the current window; 
              // directly copy the file from IE cache to the save location
              //    Known Issues:
              //       For some entries, cache entry may not be found; donot know why
              {
                  SaveIECacheFile(url, filefullname);
              }
          }
          catch (Exception ex)
          {
              throw;
          }
      }

      private void que_DownloadCompleted(object sender, FileDownloadQueueEventArgs args)
      {
          if (args.StatusCode == System.Net.HttpStatusCode.OK)
            MessageBox.Show(args.File.Url + "\r\n" + args.StatusMessage);
          else
            MessageBox.Show("Error downloading file" + "\r\n" + args.File.Url + "\r\n" + args.StatusCode.ToString());
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
          long r;
          long BtnSave;

          r = FindWindow("#32770", "Save Image");
          if (r > 0)
          {
              timer1.Enabled = false;
              BtnSave = FindWindowEx(r, 0, "Button", "&Save");
              if (BtnSave > 0)
                  SendMessage(BtnSave, BM_CLICK, 0, 0);
          }
      }

      public void myHttpHelper_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
      {
          if (args.Done == true)
          {
              MessageBox.Show("Image Saved!");
          }
          else
          {
              if (args.Error)
                  MessageBox.Show(args.ErrorMsg);
          }
      }


      // Nb: Temporarily used due to storng name issues
      public static string GetUniqueFilename(string filepath, string filename)
      {
          int fileCounter = 0;

          string newfilename = filename;

          while (File.Exists(filepath + @"\" + newfilename))
          {
              string name = filename.Substring(0, filename.LastIndexOf("."));
              string ext = filename.Substring(filename.LastIndexOf(".") + 1);

              name = name + "_" + fileCounter.ToString().PadLeft(4, '0');
              newfilename = name + "." + ext;
              fileCounter++;
          }

          return filepath + @"\" + newfilename;
      }



      /*
 * Author: Danny Battison
 * Contact: gabehabe@googlemail.com
 */

      ///// <summary>
      ///// A method to capture a webpage as a System.Drawing.Bitmap
      ///// </summary>
      ///// <param name="URL">The URL of the webpage to capture</param>
      ///// <returns>A System.Drawing.Bitmap of the entire page</returns>
      //public System.Drawing.Bitmap CaptureWebPage(string URL)
      //{
      //    // create a hidden web browser, which will navigate to the page
      //    System.Windows.Forms.WebBrowser web = new System.Windows.Forms.WebBrowser();
      //    web.ScrollBarsEnabled = false; // we don't want scrollbars on our image
      //    web.ScriptErrorsSuppressed = true; // don't let any errors shine through
      //    web.Navigate(URL); // let's load up that page!

      //    // wait until the page is fully loaded
      //    while (web.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
      //        System.Windows.Forms.Application.DoEvents();
      //    System.Threading.Thread.Sleep(1500); // allow time for page scripts to update
      //    // the appearance of the page

      //    // set the size of our web browser to be the same size as the page
      //    int width = web.Document.Body.ScrollRectangle.Width;
      //    int height = web.Document.Body.ScrollRectangle.Height;
      //    web.Width = width;
      //    web.Height = height;
      //    // a bitmap that we will draw to
      //    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(width, height);
      //    // draw the web browser to the bitmap
      //    web.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, width, height));

      //    return bmp; // return the bitmap for processing

      //private Guid cmdGuid = new Guid("ED016940-BD5B-11CF-BA4E-00C04FD70816");

      //private enum MiscCommandTarget { Find = 1, ViewSource, Options }

      //public void ShowSource()
      //{
      //    IOleCommandTarget cmdt;
      //    Object o = new object();
      //    try
      //    {
      //        this.Document.ExecCommand("Find"
      //        cmdt = (IOleCommandTarget)GetDocument();
      //        cmdt.Exec(ref cmdGuid, (uint)MiscCommandTarget.ViewSource,
      //        (uint)SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
      //    }
      //    catch (Exception e)
      //    {
      //        System.Windows.Forms.MessageBox.Show(e.Message);
      //    }
      //}

      public void ShowFindDialog()
      {
          System.Object nullObject = 0;
          string str = "";
          System.Object nullObjStr = str;

          try
          {
              this.axIWebBrowser2.ExecWB(NativeMethods.OLECMDID.OLECMDID_IEOPTIONS,
                  NativeMethods.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref nullObjStr, System.IntPtr.Zero);

          }
          catch (Exception e)
          {
              System.Windows.Forms.MessageBox.Show(e.Message);
          }
      }

      private void InitializeComponent()
      {
          this.components = new System.ComponentModel.Container();
          this.timer1 = new System.Windows.Forms.Timer(this.components);
          this.SuspendLayout();
          // 
          // timer1
          // 
          this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

          que.DownloadCompleted += new FileDownloadQueue.FileDownloadComplete(que_DownloadCompleted);

          this.ResumeLayout(false);

      }

      //  public void ShowInternetOptionsDialog()
      //  {
      //      IOleCommandTarget cmdt;
      //      Object o = new object();
      //      try
      //      {
      //          this.axIWebBrowser2.
      //          cmdt = (IOleCommandTarget)GetDocument();
      //          cmdt.Exec(ref cmdGuid, (uint)MiscCommandTarget.Options,
      //          (uint) SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
      //      }
      //      catch
      //      {
      //          // NOTE: Because of the way that this CMDID is handled in Internet Explorer,
      //          // this catch block will always fire, even though the dialog box
      //          // and its operations completed successfully. You can suppress this
      //          // error without causing any damage to your host.
      //      }
      //  }

      #region Save file from IE Cached to file system

      [DllImport("Wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
      public static extern Boolean GetUrlCacheEntryInfo(String lpxaUrlName, IntPtr lpCacheEntryInfo, 
          ref int lpdwCacheEntryInfoBufferSize);

      const int ERROR_FILE_NOT_FOUND = 2;
      struct LPINTERNET_CACHE_ENTRY_INFO
      {
          public int dwStructSize;
          IntPtr lpszSourceUrlName;
          public IntPtr lpszLocalFileName;
          int CacheEntryType;
          int dwUseCount;
          int dwHitRate;
          int dwSizeLow;
          int dwSizeHigh;
          FILETIME LastModifiedTime;
          FILETIME Expiretime;
          FILETIME LastAccessTime;
          FILETIME LastSyncTime;
          IntPtr lpHeaderInfo;
          int dwheaderInfoSize;
          IntPtr lpszFileExtension;
          int dwEemptDelta;
      }

      ////// Returns local cache location for a url recently visited by IE

      private string GetPathForCachedFile(string fileUrl)
      {
          int cacheEntryInfoBufferSize = 0;
          IntPtr cacheEntryInfoBuffer = IntPtr.Zero;
          int lastError; Boolean result;
          try
          {
              // call to see how big the buffer needs to be
              result = GetUrlCacheEntryInfo(fileUrl, IntPtr.Zero, ref cacheEntryInfoBufferSize);
              lastError = Marshal.GetLastWin32Error();
              if (result == false)
              {
                  if (lastError == ERROR_FILE_NOT_FOUND) return null;
              }
              // allocate the necessary amount of memory
              cacheEntryInfoBuffer = Marshal.AllocHGlobal(cacheEntryInfoBufferSize);

              // make call again with properly sized buffer
              result = GetUrlCacheEntryInfo(fileUrl, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSize);
              lastError = Marshal.GetLastWin32Error();
              if (result == true)
              {
                  Object strObj = Marshal.PtrToStructure(cacheEntryInfoBuffer, typeof(LPINTERNET_CACHE_ENTRY_INFO));
                  LPINTERNET_CACHE_ENTRY_INFO internetCacheEntry = (LPINTERNET_CACHE_ENTRY_INFO)strObj;
                  String localFileName = Marshal.PtrToStringAuto(internetCacheEntry.lpszLocalFileName); return localFileName;
              }
              else return null;// file not found
          }
          //catch (Exception ex)
          //{
          //    throw;
          //}
          finally
          {
              if (!cacheEntryInfoBuffer.Equals(IntPtr.Zero)) Marshal.FreeHGlobal(cacheEntryInfoBuffer);
          }
      }

      public void SaveIECacheFile(string url, string destinationFile)
      { 
          string sourceFile = GetPathForCachedFile(url);
          if (sourceFile != null)
              System.IO.File.Copy(sourceFile, destinationFile);
          else
              throw new FileNotFoundException();
      }

      #endregion

  }
}
