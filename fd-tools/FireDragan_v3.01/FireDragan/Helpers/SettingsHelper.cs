using System;
using System.Collections.Generic;
using System.Text;
using FireDragan.Properties;

namespace FireDragan
{
  /// <summary>
  /// This class is used for obtaining and storing settings
  /// </summary>
  /// <remarks>
  /// This is a single instance class, so that there is only one
  /// instance needed of the <see cref="Settings"/> class
  /// </remarks>
  class SettingsHelper
  {
    /// <summary>
    /// Creates a new instance of the <see cref="SettingsHelper"/> class
    /// </summary>
    private SettingsHelper()
    {
      _mySettings = new Settings();
    }

    /// <summary>
    /// Stores the instance of the <see cref="Settings"/> class
    /// </summary>
    private Settings _mySettings;

    /// <summary>
    /// Stores the instance of the <see cref="SettingsHelper"/> class
    /// </summary>
    private static SettingsHelper _instance;
    
    /// <summary>
    /// An object for locking the thread, when needed
    /// </summary>
    private static object _lockObject = new object();

    /// <summary>
    /// Obtains the current instance of the <see cref="SettingsHelper"/> class.
    /// </summary>
    /// <remarks>
    /// If there is no instance of the <see cref="SettingsHelper"/> class, one will be created
    /// </remarks>
    public static SettingsHelper Current
    {
      get 
      {
        if (_instance == null)
        {
          lock (_lockObject)
          {
            if (_instance == null)
              _instance = new SettingsHelper();
          }
        }
        return _instance; 
      }
    }

    /// <summary>
    /// Gets or sets the <see cref="PopupBlockerFilterLevel"/>
    /// </summary>
    public PopupBlockerFilterLevel FilterLevel
    {
      get { return _mySettings.FilterLevel; }
      set { _mySettings.FilterLevel = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating if script errors should be shown
    /// </summary>
    public bool ShowScriptErrors
    {
      get { return _mySettings.ShowScriptErrors; }
      set { _mySettings.ShowScriptErrors = value; }
    }

      public string DBConnection
      {
          get { return _mySettings.DBConnection; }
          set { _mySettings.DBConnection = value; }
      }

      public bool OnOpenNewFocusTab
      {
          get { return _mySettings.OnOpenNewFocusTab; }
          set { _mySettings.OnOpenNewFocusTab = value; }
      }

      public string ImageExpression
      {
          get { return _mySettings.ImageExpression; }
          set { _mySettings.ImageExpression = value; }
      }

      public string PageExpression
      {
          get { return _mySettings.PageExpression; }
          set { _mySettings.PageExpression = value; }
      }

      public string StyleExpression
      {
          get { return _mySettings.StyleExpression; }
          set { _mySettings.StyleExpression = value; }
      }

      public string JavascriptExpression
      {
          get { return _mySettings.JavascriptExpression; }
          set { _mySettings.JavascriptExpression = value; }
      }

      public string GrabberSaveLocation
      {
          get { return _mySettings.GrabberSaveLocation; }
          set { _mySettings.GrabberSaveLocation = value; }
      }

      public string ImageSaveLocation
      {
          get { return _mySettings.ImageSaveLocation; }
          set { _mySettings.ImageSaveLocation = value; }
      }

      public string UserAgent
      {
          get { return _mySettings.UserAgent; }
          set { _mySettings.UserAgent = value; }
      }

      public int BufferSize
      {
          get { return _mySettings.BufferSize; }
          set { _mySettings.BufferSize = value; }
      }

      public int AlterImageLevel
      {
          get { return _mySettings.AlterImageLevel; }
          set { _mySettings.AlterImageLevel = value; }
      }

      public bool PreservePath
      {
          get { return _mySettings.PreservePath; }
          set { _mySettings.PreservePath = value; }
      }

      public bool UseReferrer
      {
          get { return _mySettings.UseReferrer; }
          set { _mySettings.UseReferrer = value; }
      }

      public bool UseProxy
      {
          get { return _mySettings.UseProxy; }
          set { _mySettings.UseProxy = value; }
      }

      public int MaxGrabThreads
      {
          get { return _mySettings.MaxGrabThreads;}
          set { _mySettings.MaxGrabThreads = value;}
      }

      public int MaxGrabBuckets
      {
          get { return _mySettings.MaxGrabBuckets; }
          set { _mySettings.MaxGrabBuckets = value; }
      }

      public string LinkProcPreString
      {
          get { return _mySettings.LinkProcPreString; }
          set { _mySettings.LinkProcPreString = value; }
      }

      public string LinkProcPostString
      {
          get { return _mySettings.LinkProcPostString; }
          set { _mySettings.LinkProcPostString=value; }
      }

      public string ImageCategories
      {
          get { return _mySettings.ImageCategories; }
          set { _mySettings.ImageCategories = value; }
      }

      public string IndentityDB
      {
          get { return _mySettings.IdentityDB; }
          set { _mySettings.IdentityDB= value; }
      }

      public int MaxTabs
      {
          get { return _mySettings.MaxTabs; }
          set { _mySettings.MaxTabs = value; }
      }

    /// <summary>
    /// Saves the <see cref="Settings"/>
    /// </summary>
    public void Save()
    {
      _mySettings.Save();
    }

  }
}
