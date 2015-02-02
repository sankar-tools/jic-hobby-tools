using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Crownwood.Magic.Common;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Menus;

namespace FireDragan
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1301:AvoidDuplicateAccelerators")]

  partial class MainForm : Form
  {
      NavigatorForm navForm = null;
      ImageSelectForm imgForm = null;
      SerialForm serialForm = null;
      CoolLinksForm coolForm = null;
      SeriesForm seriesForm = null;
      HtmlImagesForm htmlForm = null;

      protected int _count = 0;
      protected DockingManager _manager;
      protected VisualStyle _style;
      protected bool _captionBars = true;
      protected bool _closeButtons = true;
      protected int _colorIndex = 0;



    public MainForm()
    {
        InitializeComponent();

        // Initialize Main form
        this.StatusChanged += new StatusChanged(General_StatusChanged);

        // Initialize window manager for tabs controlling
        _windowManager = new WindowManager(this.tabControl);
        _windowManager.CommandStateChanged += new EventHandler<CommandStateEventArgs>(_windowManager_CommandStateChanged);
        _windowManager.StatusTextChanged += new EventHandler<TextChangedEventArgs>(_windowManager_StatusTextChanged);

        // Initialization of Docking functionality
        _style = VisualStyle.IDE;
        _manager = new DockingManager(this, _style);
        _manager.InnerControl = tabControl;
        _manager.HideAllContents();
        _manager.OuterControl = ssMain;

        // Navigator Form Management
        navForm = new NavigatorForm();
        navForm.UriSelected += new UriSelected(navForm_UriSelected);
        navForm.NavigatorReset += new NavigatorReset(navForm_NavigatorReset);
        _manager.AddContentWithState( _manager.Contents.Add(navForm, "Navigator"), State.Floating);

        // Image Select Form Management
        imgForm = new ImageSelectForm();
        imgForm.StatusChanged += new StatusChanged(General_StatusChanged);
        imgForm.Hide();
        _manager.AddContentWithState(_manager.Contents.Add(imgForm, "Images Selected"), State.DockBottom);

        // Serial Form Management
        serialForm = new SerialForm();
        serialForm.SerialUriChanged += new SerialUriChanged(serialForm_SerialUriChanged);
        serialForm.Hide();

        // Cool Links Form Management
        coolForm = new CoolLinksForm();
        coolForm.UriSelected += new UriSelected(navForm_UriSelected);
        coolForm.AutoScroll = true;

        seriesForm = new SeriesForm();

        htmlForm = new HtmlImagesForm();
        htmlForm.StatusChanged += new StatusChanged(General_StatusChanged);

        tabControl.SelectedIndexChanged +=new EventHandler(tabControl_SelectedIndexChanged);

        LoadConfigSettings();

    }

      protected void DefineContentState(Content c)
      {
          c.CaptionBar = _captionBars;
          c.CloseButton = _closeButtons;
      }

      protected void DefineControlColors(Content c)
      {
          // Only interested in Forms and Panels
          if ((c.Control is Form) || (c.Control is Panel))
          {
              // Starting color depends on select menu option
              switch (_colorIndex)
              {
                  case 0:
                      c.Control.BackColor = SystemColors.Control;
                      c.Control.ForeColor = SystemColors.ControlText;
                      break;
                  case 1:
                      c.Control.BackColor = Color.DarkSlateBlue;
                      c.Control.ForeColor = Color.White;
                      break;
                  case 2:
                      c.Control.BackColor = Color.Firebrick;
                      c.Control.ForeColor = Color.White;
                      break;
                  case 3:
                      c.Control.BackColor = Color.PaleGreen;
                      c.Control.ForeColor = Color.Black;
                      break;
              }
          }
      }


    // Update the status text
    void _windowManager_StatusTextChanged(object sender, TextChangedEventArgs e)
    {
        StatusEventArgs args = new StatusEventArgs(e.Text, StatusPanels.MainPanel);
        StatusChanged(this, args);
    }

    // Enable / disable buttons
    void _windowManager_CommandStateChanged(object sender, CommandStateEventArgs e)
    {
        this.forwardToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Forward) == BrowserCommands.Forward);
        this.backToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Back) == BrowserCommands.Back);
        this.printPreviewToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.PrintPreview) == BrowserCommands.PrintPreview);
        this.printPreviewToolStripMenuItem.Enabled = ((e.BrowserCommands & BrowserCommands.PrintPreview) == BrowserCommands.PrintPreview);
        this.printToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Print) == BrowserCommands.Print);
        this.printToolStripMenuItem.Enabled = ((e.BrowserCommands & BrowserCommands.Print) == BrowserCommands.Print);
        this.homeToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Home) == BrowserCommands.Home);
        this.searchToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Search) == BrowserCommands.Search);
        this.refreshToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Reload) == BrowserCommands.Reload);
        this.stopToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Stop) == BrowserCommands.Stop);
    }

    #region Tools menu
    // Executed when the user clicks on Tools -> Options
    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OptionsForm of = new OptionsForm())
      {
        of.ShowDialog(this);
      }
    }
    // Tools -> Show script errors
    private void scriptErrorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ScriptErrorManager.Instance.ShowWindow();
    }

    #endregion

    #region File Menu

    // File -> Print
    private void printToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Print();
    }

    // File -> Print Preview
    private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PrintPreview();
    }

    // File -> Exit
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    // File -> Open URL
    private void openUrlToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OpenUrlForm ouf = new OpenUrlForm())
      {
        if (ouf.ShowDialog() == DialogResult.OK)
        {
          ExtendedWebBrowser brw = _windowManager.New(false);
          brw.Navigate(ouf.Url);
        }
      }
    }

    // File -> Open File
    private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.Filter = Properties.Resources.OpenFileDialogFilter;
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          Uri url = new Uri(ofd.FileName);
          WindowManager.Open(url);
        }
      }
    }
    #endregion

    #region Help Menu
    
    // Executed when the user clicks on Help -> About
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      About();
    }

    /// <summary>
    /// Shows the AboutForm
    /// </summary>
    private void About()
    {
      using (AboutForm af = new AboutForm())
      {
        af.ShowDialog(this);
      }
    }

    #endregion


    /// <summary>
    /// The WindowManager class
    /// </summary>
    private WindowManager _windowManager;

    // This is handy when all the tabs are closed.
    private void tabControl_VisibleChanged(object sender, EventArgs e)
    {
      if (tabControl.Visible)
      {
        this.panel1.BackColor = SystemColors.Control;
      }
      else
        this.panel1.BackColor = SystemColors.AppWorkspace;
    }

    // Starting the app here...
    private void MainForm_Load(object sender, EventArgs e)
    {
      // Open a new browser window
      _windowManager.New();
    }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
          if (MessageBox.Show("Do you want to close the window?", "Confirm!", MessageBoxButtons.YesNo) == DialogResult.No)
          {
              e.Cancel = true;
          }

          SaveConfigSettings();
      }



    #region Printing & Print Preview
    private void Print()
    {
      ExtendedWebBrowser brw = _windowManager.ActiveBrowser;
      if (brw != null)
        brw.ShowPrintDialog();
    }

    private void PrintPreview()
    {
      ExtendedWebBrowser brw = _windowManager.ActiveBrowser;
      if (brw != null)
        brw.ShowPrintPreviewDialog();
    }
    #endregion

    #region Toolstrip buttons
    private void closeWindowToolStripButton_Click(object sender, EventArgs e)
    {
        int tabIndex = this.tabControl.SelectedIndex;
        this._windowManager.New();
        this.tabControl.SelectedIndex = tabIndex;
    }

    private void closeToolStripButton_Click(object sender, EventArgs e)
    {
        CloseActiveTab();
    }

      private void CloseActiveTab()
      {
          if (this._windowManager.ActiveBrowser.IsSerial == true)
          {
              if (MessageBox.Show("It is a serial tab. Do you want to close?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                  this._windowManager.Close();
          }
          else
              this._windowManager.Close();
      }

    private void printToolStripButton_Click(object sender, EventArgs e)
    {
      Print();
    }

    private void printPreviewToolStripButton_Click(object sender, EventArgs e)
    {
      PrintPreview();
    }

    private void backToolStripButton_Click(object sender, EventArgs e)
    {
      if (_windowManager.ActiveBrowser != null && _windowManager.ActiveBrowser.CanGoBack)
        _windowManager.ActiveBrowser.GoBack();
    }

    private void forwardToolStripButton_Click(object sender, EventArgs e)
    {
      if (_windowManager.ActiveBrowser != null && _windowManager.ActiveBrowser.CanGoForward)
        _windowManager.ActiveBrowser.GoForward();
    }

    private void stopToolStripButton_Click(object sender, EventArgs e)
    {
      if (_windowManager.ActiveBrowser != null)
      {
        _windowManager.ActiveBrowser.Stop();
      }
      stopToolStripButton.Enabled = false;
    }

    private void refreshToolStripButton_Click(object sender, EventArgs e)
    {
      if (_windowManager.ActiveBrowser != null)
      {
        _windowManager.ActiveBrowser.Refresh(WebBrowserRefreshOption.Normal);
      }
    }

    private void homeToolStripButton_Click(object sender, EventArgs e)
    {
      if (_windowManager.ActiveBrowser != null)
        _windowManager.ActiveBrowser.GoHome();
    }

    private void searchToolStripButton_Click(object sender, EventArgs e)
    {
      if (_windowManager.ActiveBrowser != null)
        _windowManager.ActiveBrowser.GoSearch();
    }

    #endregion

   

        public WindowManager WindowManager
        {
            get { return _windowManager; }
        }


        private void grabImageLinksToolstripButton_Click(object sender, EventArgs e)
        {
            if (_windowManager.ActiveBrowser != null)
            {
                navForm.PageLinks = _windowManager.ActiveBrowser.GetBrowsableLinks();

                navForm.Show();
                navForm.Focus();
            }
        }

        private void favsToolstripButton_Click(object sender, EventArgs e)
        {
            coolForm.CoolLink = this._windowManager.ActiveBrowser.Url.ToString();
            coolForm.Show();
            coolForm.Focus();
        }

        private void navForm_UriSelected(object sender, UriSelectedEventArgs e)
        {
            this._windowManager.New().Navigate(e.NewUri);
        }

      private void grablinksToolstripButton_Click(object sender, EventArgs e)
      {
          GrabImages(GrabPriority.None);
      }

      private void tsbtnSerialLinks_Click(object sender, EventArgs e)
      {
          if (_windowManager.ActiveBrowser != null)
          {
              if (_windowManager.ActiveBrowser.IsSerial == true)
              {
                  serialForm.SerialManager = _windowManager.ActiveBrowser.SerialManager;
              }
              else
              {
                  serialForm.SerialManager.Serial.Pattern = _windowManager.ActiveBrowser.Url.ToString();
              }
          }

          serialForm.Show();
          serialForm.Focus();
      }

      private void tsbtnLock_Click(object sender, EventArgs e)
      {
          tabControl.Visible = !tabControl.Visible;

          string message = (tabControl.Visible) ? "Unlocked" : "Locked";
          StatusEventArgs args = new StatusEventArgs("Browser Window " + message, StatusPanels.MainPanel);

          StatusChanged(this, args);
      }

      private void serialForm_SerialUriChanged(object sender, SerialUriChangedEventArgs e)
      {
          this._windowManager.ActiveBrowser.SerialManager.Serial = e.Serial;
          this._windowManager.ActiveBrowser.Navigate(e.Serial.GetNextSerialUrl());
          this._windowManager.ActiveBrowser.IsSerial = true;
          this.serialForm.Hide();

          prevSeriesToolstripButton.Enabled = (e.Serial.Direction == SeriesLinkManager.SerialDirection.Backward);
          nextSeriesToolstripButton.Enabled = (e.Serial.Direction == SeriesLinkManager.SerialDirection.Forward);
      }

      private void prevSeriesToolstripButton_Click(object sender, EventArgs e)
      {
          string nextUri = this._windowManager.ActiveBrowser.SerialManager.Serial.GetNextSerialUrl();
          this._windowManager.ActiveBrowser.Navigate(nextUri);
      }

      private void nextSeriesToolstripButton_Click(object sender, EventArgs e)
      {
          string nextUri = this._windowManager.ActiveBrowser.SerialManager.Serial.GetNextSerialUrl();
          this._windowManager.ActiveBrowser.Navigate(nextUri);
      }

      private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
      {
          prevSeriesToolstripButton.Enabled = false;
          nextSeriesToolstripButton.Enabled = false;

          if (this._windowManager.ActiveBrowser != null)
          {
              if (this._windowManager.ActiveBrowser.IsSerial == true)
              {
                  prevSeriesToolstripButton.Enabled = (this._windowManager.ActiveBrowser.SerialManager.Serial.Direction == SeriesLinkManager.SerialDirection.Backward);
                  nextSeriesToolstripButton.Enabled = (this._windowManager.ActiveBrowser.SerialManager.Serial.Direction == SeriesLinkManager.SerialDirection.Forward);
              }
          }

      }

      private void navForm_NavigatorReset(object sender, EventArgs args)
      { }

      // Statusbar event management methods
      public event StatusChanged StatusChanged;

      private void General_StatusChanged(object sender, StatusEventArgs args)
      {
          ssMain.Message(args.Message, args.Panel);
      }

      private void tsbtnSave_Click(object sender, EventArgs e)
      {
          if (_windowManager.ActiveBrowser != null)
          {
              _windowManager.ActiveBrowser.ShowSaveAsDialog();
          }
      }

      private void GrabImages(GrabPriority priority)
      {
          if (_windowManager.ActiveBrowser != null)
          {
              string category = GetCategoryListItem(tscboPageCategory.Text);
              AddDropDownItem(tscboPageCategory, tscboPageCategory.Text);

              string[] imageLinks = _windowManager.ActiveBrowser.GetImageLinks();

              imgForm.AddLinks(imageLinks, _windowManager.ActiveBrowser.Url.ToString(), priority, category);

              imgForm.Show();
              imgForm.Focus();
          }

          if(chkClose.Checked == true)
            CloseActiveTab();
      }

      private void tsmniLow_Click(object sender, EventArgs e)
      {
          GrabImages(GrabPriority.Low);
      }

      private void tsmniHigh_Click(object sender, EventArgs e)
      {
          GrabImages(GrabPriority.High);
      }

      private void tsmniMedium_Click(object sender, EventArgs e)
      {
          GrabImages(GrabPriority.Medium);
      }

      private void tsmniHtml_Click(object sender, EventArgs e)
      {
          if (_windowManager.ActiveBrowser != null)
          {
              seriesForm.SeriesParams(_windowManager.ActiveBrowser.GetHtmlLinks(), _windowManager.ActiveBrowser.Url.AbsoluteUri);

              seriesForm.Show();
              seriesForm.Focus();
          }

      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
          _windowManager.ActiveBrowser.Transform(tstxtPre.Text, tstxtPost.Text, tsdrpFn.Text == "Decode");

          AutoCompleteStringCollection dataUrlFilterPre = tstxtPre.AutoCompleteCustomSource;
          dataUrlFilterPre.Add(tstxtPre.Text);
          tstxtPre.AutoCompleteCustomSource = dataUrlFilterPre;

          AutoCompleteStringCollection dataUrlFilterPost = tstxtPost.AutoCompleteCustomSource;
          dataUrlFilterPost.Add(tstxtPost.Text);
          tstxtPost.AutoCompleteCustomSource = dataUrlFilterPost;
      }

      private void toolStripButton2_Click(object sender, EventArgs e)
      {
          _windowManager.ActiveBrowser.RemoveTransform();
      }

      private void GrabHtmlLinkedPages()
      {
          if (_windowManager.ActiveBrowser != null)
          {
              htmlForm.AddLink(_windowManager.ActiveBrowser.Url.ToString());

              htmlForm.Show();
              htmlForm.Focus();
          }
      }



      private void tsbtnHigh_Click(object sender, EventArgs e)
      {
          GrabImages(GrabPriority.High);
      }

      private void tsbtnRemoveProcessedLinks_Click(object sender, EventArgs e)
      {
          _windowManager.ActiveBrowser.RemoveTransform();
      }

      private void tsbtnReloadImages_Click(object sender, EventArgs e)
      {
          _windowManager.ActiveBrowser.ReloadImages();
      }

      private void linkedPagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GrabHtmlLinkedPages();
      }

      private void tsbtnSaveImage_Click(object sender, EventArgs e)
      {
          try
          {
              string category = GetCategoryListItem(tscboImageCate.Text);
              _windowManager.ActiveBrowser.SaveImage(category, 1);
              AddDropDownItem(tscboImageCate, tscboImageCate.Text);

                StatusEventArgs statArgs = new StatusEventArgs();
              statArgs.Message = _windowManager.ActiveBrowser.Url + " - Imaged added to que for saving...";
              statArgs.Panel = StatusPanels.MainPanel;

              StatusChanged(this, statArgs);

              if (chkClose.Checked == true)
                  CloseActiveTab();
          }
          catch (System.IO.FileNotFoundException ex)
          {
              MessageBox.Show("Cache entry not found for " + _windowManager.ActiveBrowser.Url);
          }
      }

      private void tsbtnPriorityGrab_Click(object sender, EventArgs e)
      {
          GrabImages(GrabPriority.Immediate);
      }

      private void tsbtnIEOptions_Click(object sender, EventArgs e)
      {
          _windowManager.ActiveBrowser.ShowFindDialog();
      }

      private void tstxtPre_Click(object sender, EventArgs e)
      {

      }
      
      private void tstxtPre_KeyDown(object sender, KeyEventArgs e)
      {
          if (e.KeyCode == Keys.Enter)
          {
              AddDropDownItem(tstxtPre, tstxtPre.Text);
          }
      }

      private void AddDropDownItem(ToolStripComboBox cnt, string item)
      {
          bool isExist = false;
          string category = GetCategoryListItem(item);

          for (int i = 0; i < cnt.Items.Count; i++ )
          {
              // if item exists increase the counter else add a new item
              if (GetCategoryListItem(cnt.Items[i].ToString()) == category)
              {
                  int newIndex = GetCategoryListWeight(item);
                  if (newIndex > 0) newIndex --;

                  string newItem = (newIndex).ToString() + " : " + category;

                  cnt.Items.RemoveAt(i);
                  cnt.Items.Add(newItem);
                  isExist = true;
              }
          }
          if(! isExist)
          {
              item = "9 : " + category;
              cnt.Items.Add(item);
          }
      }

      private void tstxtPost_Click(object sender, EventArgs e)
      {

      }

      private void tstxtPost_KeyDown(object sender, KeyEventArgs e)
      {
          if (e.KeyCode == Keys.Enter)
          {
              AddDropDownItem(tstxtPost, tstxtPost.Text);
          }
      }

      private void LoadConfigSettings()
      {
          string[] pres = SettingsHelper.Current.LinkProcPreString.Split(new char[] { '|' });
          string[] post = SettingsHelper.Current.LinkProcPostString.Split(new char[] { '|' });
          string[] imageCate = SettingsHelper.Current.ImageCategories.Split(new char[] { '|' });

          foreach (string str in pres)
          {
              if(str.Trim().Length >0)
                tstxtPre.Items.Add(str);
          }

          foreach (string str in post)
          {
              if (str.Trim().Length > 0) tstxtPost.Items.Add(str);
          }

          foreach (string str in imageCate)
          {
              // Chaned for feature xxx.xx
              if (str.Trim().Length > 0)
              {
                  string strItem = "9 : " + str;
                  tscboImageCate.Items.Add(strItem);
                  tscboPageCategory.Items.Add(strItem);
              }
          }
      }

      private void SaveConfigSettings()
      {
          string pres = null;
          foreach (string str in tstxtPre.Items)
          {
              pres = pres + str + "|";
          }

          string post = null;
          foreach (string str in tstxtPost.Items)
          {
              post = post + str + "|";
          }

          string imageCate = null;
          foreach (string str in tscboImageCate.Items)
          {
              //Split counter and item category
              

              imageCate = imageCate + GetCategoryListItem(str) +"|";
          }

          SettingsHelper.Current.LinkProcPreString = pres;
          SettingsHelper.Current.LinkProcPostString = post;
          SettingsHelper.Current.ImageCategories = imageCate;

          SettingsHelper.Current.Save();

      }

      private void SubToolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
      {

      }

      private void tsbtnSaveImageAlt_Click(object sender, EventArgs e)
      {

          string category = GetCategoryListItem(tscboImageCate.Text);
          _windowManager.ActiveBrowser.SaveImage(category, 2);
          AddDropDownItem(tscboImageCate, tscboImageCate.Text);

          StatusEventArgs statArgs = new StatusEventArgs();
          statArgs.Message = _windowManager.ActiveBrowser.Url + " - Image copied from cache successfully";
          statArgs.Panel = StatusPanels.MainPanel;

          StatusChanged(this, statArgs);

          if (chkClose.Checked == true)
              CloseActiveTab();

      }

      public string GetCategoryListItem(string item)
      {
          if (item.IndexOf(':') > 0)
              return item.Substring(item.IndexOf(':') + 1).Trim();
          else
          {
              return item;
          }
      }

      public int GetCategoryListWeight(string item)
      {
          if (item.IndexOf(':') > 0)
              return Convert.ToInt32(item.Substring(0, item.IndexOf(':') - 1));
          else
              return 0;
      }

      private void tscboImageCate_Click(object sender, EventArgs e)
      {
      }

      private void tsbtnShowSession_Click(object sender, EventArgs e)
      {
          FireDragan.Forms.SessionForm frmSession = new FireDragan.Forms.SessionForm();

          frmSession.Show();
      }

      LinkedImageForm linkedImageForm = new LinkedImageForm();

      private void linkedImagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GrabLinkedImages();
      }

      private void GrabLinkedImages()
      {
          //if (linkedImageForm == null)
          //    linkedImageForm = new LinkedImageForm();

          if (_windowManager.ActiveBrowser != null)
          {
              linkedImageForm.AddLink(_windowManager.ActiveBrowser.Url.ToString());

              linkedImageForm.Show();
              linkedImageForm.Focus();
          }
      }
  }
}