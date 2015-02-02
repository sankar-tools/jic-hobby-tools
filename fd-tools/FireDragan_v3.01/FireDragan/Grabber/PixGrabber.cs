using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace FireDragan
{
	public class PixGrabberForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label selectedLabel;
		private System.ComponentModel.IContainer components;

		private int maxThreads;
		private Boolean useProxy;
        private Boolean checkConnectivity;
		private WebProxy myProxy = null;

		private Boolean pauseGrab = false;
		private int grabCount = 0;

		private MyWebClient[] myClients;
		private Thread[] myThreads;
		private System.Windows.Forms.ToolBar mainToolbar;
		private System.Windows.Forms.ListView selectedList;
		private System.Windows.Forms.ColumnHeader selectedIndex;
		private System.Windows.Forms.ColumnHeader selectedThread;
		private System.Windows.Forms.ColumnHeader selectedListURLCol;
		private System.Windows.Forms.ColumnHeader selectedListReferrerCol;
		private System.Windows.Forms.ColumnHeader selectedSize;
		private System.Windows.Forms.ColumnHeader selectedStatus;
		private System.Windows.Forms.ToolBarButton seperator1;
		private System.Windows.Forms.ToolBarButton seperator2;
		private System.Windows.Forms.ImageList pixImageList;
		private System.Windows.Forms.ToolBarButton seperator3;
		private System.Windows.Forms.ColumnHeader selectedTotalSize;
		private System.Windows.Forms.ToolBarButton tlbtnSeriesGen;
		private System.Windows.Forms.ToolBarButton tlbtnCheckAll;
		private System.Windows.Forms.ToolBarButton tlbtnPlay;
		private System.Windows.Forms.ToolBarButton tlbtnStop;
		private System.Windows.Forms.ToolBarButton tlbtnPause;
		private System.Windows.Forms.ToolBarButton tlbtnRemoveSelect;
		private System.Windows.Forms.ToolBarButton tlbtnCleanDoneList;
		private System.Windows.Forms.ToolBarButton tlbtnRefresh;
		private System.Windows.Forms.ToolBarButton tlbtnExport;
		private System.Windows.Forms.ToolBarButton tlbtnUncheckAll;
		private System.Windows.Forms.ToolBarButton tlbtnToggleChecked;
		private System.Windows.Forms.TabPage tpInprogress;
		private System.Windows.Forms.TabPage tpDone;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.ListView lvwDone;
		private System.Windows.Forms.ColumnHeader lvcDoneId;
		private System.Windows.Forms.ColumnHeader lvcDoneThreadId;
		private System.Windows.Forms.ColumnHeader lvcDoneUrl;
		private System.Windows.Forms.ColumnHeader lvcDoneReferrer;
		private System.Windows.Forms.ColumnHeader lvcDoneSize;
		private System.Windows.Forms.ColumnHeader lvcDoneTotal;
		private System.Windows.Forms.ColumnHeader lvcDoneStatus;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.StatusBar sbPix;
		private System.Windows.Forms.StatusBarPanel sbpReady;
		private System.Windows.Forms.StatusBarPanel sbpCount;
		private ThreadStart[] myThreadDelegates;

		public PixGrabberForm()
		{
			InitializeComponent();

            InitializeGrabber();
		}

        private void InitializeGrabber()
        {
            maxThreads = SettingsHelper.Current.MaxGrabThreads;

            useProxy = SettingsHelper.Current.UseProxy;

            //checkConnectivity = Convert.ToBoolean(ConfigurationSettings.AppSettings["CheckConnectivity"]);

            InitializeSelectedList();

            LoadLinks();

            //if (useProxy == true)
            //{
            //    myProxy = new WebProxy();
            //    myProxy.Address = new Uri(ConfigurationSettings.AppSettings["ProxyUri"]);
            //    myProxy.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["ProxyUser"],
            //        ConfigurationSettings.AppSettings["ProxyPassword"],
            //        ConfigurationSettings.AppSettings["ProxyDomain"]);
            //}

            ThreadRunning(false);
        }

		private void InitializeSelectedList()
		{
			MenuItem mniCopyLink = new MenuItem("Copy &Link");
			mniCopyLink.Click += new EventHandler(mniCopyLink_Click);

			MenuItem mniCopyUrl = new MenuItem("Copy &Url");
			mniCopyUrl.Click += new EventHandler(mniCopyUrl_Click);

			ContextMenu myContextMenu = new ContextMenu(new MenuItem[]{mniCopyLink, mniCopyUrl});

			selectedList.ContextMenu = myContextMenu;
		}

		#region "Context Menu Events"

		private void mniCopyLink_Click(object sender, EventArgs e)
		{
			string link = selectedList.SelectedItems[0].SubItems[Convert.ToInt32(ListColumns.Referrer)].Text;
			Clipboard.SetDataObject(link);
		}

		private void mniCopyUrl_Click(object sender, EventArgs e)
		{
			string link = selectedList.SelectedItems[0].SubItems[Convert.ToInt32(ListColumns.Url)].Text;
			Clipboard.SetDataObject(link);
		}
		#endregion

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PixGrabberForm));
			this.selectedLabel = new System.Windows.Forms.Label();
			this.mainToolbar = new System.Windows.Forms.ToolBar();
			this.tlbtnCheckAll = new System.Windows.Forms.ToolBarButton();
			this.tlbtnUncheckAll = new System.Windows.Forms.ToolBarButton();
			this.tlbtnToggleChecked = new System.Windows.Forms.ToolBarButton();
			this.seperator1 = new System.Windows.Forms.ToolBarButton();
			this.tlbtnPlay = new System.Windows.Forms.ToolBarButton();
			this.tlbtnPause = new System.Windows.Forms.ToolBarButton();
			this.tlbtnStop = new System.Windows.Forms.ToolBarButton();
			this.tlbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.seperator2 = new System.Windows.Forms.ToolBarButton();
			this.tlbtnRemoveSelect = new System.Windows.Forms.ToolBarButton();
			this.tlbtnCleanDoneList = new System.Windows.Forms.ToolBarButton();
			this.seperator3 = new System.Windows.Forms.ToolBarButton();
			this.tlbtnExport = new System.Windows.Forms.ToolBarButton();
			this.tlbtnSeriesGen = new System.Windows.Forms.ToolBarButton();
			this.pixImageList = new System.Windows.Forms.ImageList(this.components);
			this.selectedList = new System.Windows.Forms.ListView();
			this.selectedIndex = new System.Windows.Forms.ColumnHeader();
			this.selectedThread = new System.Windows.Forms.ColumnHeader();
			this.selectedListURLCol = new System.Windows.Forms.ColumnHeader();
			this.selectedListReferrerCol = new System.Windows.Forms.ColumnHeader();
			this.selectedSize = new System.Windows.Forms.ColumnHeader();
			this.selectedTotalSize = new System.Windows.Forms.ColumnHeader();
			this.selectedStatus = new System.Windows.Forms.ColumnHeader();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpInprogress = new System.Windows.Forms.TabPage();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.sbPix = new System.Windows.Forms.StatusBar();
			this.tpDone = new System.Windows.Forms.TabPage();
			this.lvwDone = new System.Windows.Forms.ListView();
			this.lvcDoneId = new System.Windows.Forms.ColumnHeader();
			this.lvcDoneThreadId = new System.Windows.Forms.ColumnHeader();
			this.lvcDoneUrl = new System.Windows.Forms.ColumnHeader();
			this.lvcDoneReferrer = new System.Windows.Forms.ColumnHeader();
			this.lvcDoneSize = new System.Windows.Forms.ColumnHeader();
			this.lvcDoneTotal = new System.Windows.Forms.ColumnHeader();
			this.lvcDoneStatus = new System.Windows.Forms.ColumnHeader();
			this.sbpReady = new System.Windows.Forms.StatusBarPanel();
			this.sbpCount = new System.Windows.Forms.StatusBarPanel();
			this.tcMain.SuspendLayout();
			this.tpInprogress.SuspendLayout();
			this.tpDone.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sbpReady)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).BeginInit();
			this.SuspendLayout();
			// 
			// selectedLabel
			// 
			this.selectedLabel.AutoSize = true;
			this.selectedLabel.Location = new System.Drawing.Point(3, 216);
			this.selectedLabel.Name = "selectedLabel";
			this.selectedLabel.Size = new System.Drawing.Size(48, 16);
			this.selectedLabel.TabIndex = 4;
			this.selectedLabel.Text = "&Selected";
			// 
			// mainToolbar
			// 
			this.mainToolbar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.tlbtnCheckAll,
																						   this.tlbtnUncheckAll,
																						   this.tlbtnToggleChecked,
																						   this.seperator1,
																						   this.tlbtnPlay,
																						   this.tlbtnPause,
																						   this.tlbtnStop,
																						   this.tlbtnRefresh,
																						   this.seperator2,
																						   this.tlbtnRemoveSelect,
																						   this.tlbtnCleanDoneList,
																						   this.seperator3,
																						   this.tlbtnExport,
																						   this.tlbtnSeriesGen});
			this.mainToolbar.DropDownArrows = true;
			this.mainToolbar.ImageList = this.pixImageList;
			this.mainToolbar.Location = new System.Drawing.Point(0, 0);
			this.mainToolbar.Name = "mainToolbar";
			this.mainToolbar.ShowToolTips = true;
			this.mainToolbar.Size = new System.Drawing.Size(784, 28);
			this.mainToolbar.TabIndex = 15;
			this.mainToolbar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.mainToolbar_ButtonClick);
			// 
			// tlbtnCheckAll
			// 
			this.tlbtnCheckAll.ImageIndex = 0;
			this.tlbtnCheckAll.ToolTipText = "Select All Rows";
			// 
			// tlbtnUncheckAll
			// 
			this.tlbtnUncheckAll.ImageIndex = 1;
			this.tlbtnUncheckAll.ToolTipText = "Uncheck all the selected rows";
			// 
			// tlbtnToggleChecked
			// 
			this.tlbtnToggleChecked.ImageIndex = 2;
			this.tlbtnToggleChecked.ToolTipText = "Toggle the selected rows";
			// 
			// seperator1
			// 
			this.seperator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbtnPlay
			// 
			this.tlbtnPlay.ImageIndex = 3;
			this.tlbtnPlay.ToolTipText = "Start Grabbing Images";
			// 
			// tlbtnPause
			// 
			this.tlbtnPause.ImageIndex = 4;
			this.tlbtnPause.ToolTipText = "Pause Grabbing Images";
			// 
			// tlbtnStop
			// 
			this.tlbtnStop.ImageIndex = 5;
			this.tlbtnStop.ToolTipText = "Stop Grabbing Images";
			// 
			// tlbtnRefresh
			// 
			this.tlbtnRefresh.Enabled = false;
			this.tlbtnRefresh.ImageIndex = 6;
			this.tlbtnRefresh.ToolTipText = "Refresh list from database";
			// 
			// seperator2
			// 
			this.seperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbtnRemoveSelect
			// 
			this.tlbtnRemoveSelect.ImageIndex = 7;
			this.tlbtnRemoveSelect.ToolTipText = "Remove checked rows";
			// 
			// tlbtnCleanDoneList
			// 
			this.tlbtnCleanDoneList.ImageIndex = 8;
			this.tlbtnCleanDoneList.ToolTipText = "Clean up the done list";
			// 
			// seperator3
			// 
			this.seperator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbtnExport
			// 
			this.tlbtnExport.ImageIndex = 9;
			this.tlbtnExport.ToolTipText = "Export list";
			// 
			// tlbtnSeriesGen
			// 
			this.tlbtnSeriesGen.ImageIndex = 10;
			this.tlbtnSeriesGen.ToolTipText = "Open series generator";
			// 
			// pixImageList
			// 
			this.pixImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.pixImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pixImageList.ImageStream")));
			this.pixImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// selectedList
			// 
			this.selectedList.CheckBoxes = true;
			this.selectedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.selectedIndex,
																						   this.selectedThread,
																						   this.selectedListURLCol,
																						   this.selectedListReferrerCol,
																						   this.selectedSize,
																						   this.selectedTotalSize,
																						   this.selectedStatus});
			this.selectedList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedList.GridLines = true;
			this.selectedList.Location = new System.Drawing.Point(0, 0);
			this.selectedList.Name = "selectedList";
			this.selectedList.Size = new System.Drawing.Size(776, 441);
			this.selectedList.TabIndex = 1;
			this.selectedList.View = System.Windows.Forms.View.Details;
			// 
			// selectedIndex
			// 
			this.selectedIndex.Text = "#";
			this.selectedIndex.Width = 35;
			// 
			// selectedThread
			// 
			this.selectedThread.Text = "Id";
			this.selectedThread.Width = 25;
			// 
			// selectedListURLCol
			// 
			this.selectedListURLCol.Text = "URL";
			this.selectedListURLCol.Width = 300;
			// 
			// selectedListReferrerCol
			// 
			this.selectedListReferrerCol.Text = "Referrer";
			this.selectedListReferrerCol.Width = 200;
			// 
			// selectedSize
			// 
			this.selectedSize.Text = "Size";
			this.selectedSize.Width = 80;
			// 
			// selectedTotalSize
			// 
			this.selectedTotalSize.Text = "Total";
			this.selectedTotalSize.Width = 80;
			// 
			// selectedStatus
			// 
			this.selectedStatus.Text = "Status";
			this.selectedStatus.Width = 150;
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpInprogress);
			this.tcMain.Controls.Add(this.tpDone);
			this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcMain.Location = new System.Drawing.Point(0, 28);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(784, 467);
			this.tcMain.TabIndex = 16;
			// 
			// tpInprogress
			// 
			this.tpInprogress.Controls.Add(this.pnlMain);
			this.tpInprogress.Controls.Add(this.selectedList);
			this.tpInprogress.Location = new System.Drawing.Point(4, 22);
			this.tpInprogress.Name = "tpInprogress";
			this.tpInprogress.Size = new System.Drawing.Size(776, 441);
			this.tpInprogress.TabIndex = 0;
			this.tpInprogress.Text = "Inprogress";
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(776, 441);
			this.pnlMain.TabIndex = 3;
			this.pnlMain.Controls.Add(selectedList);
			// 
			// sbPix
			// 
			this.sbPix.Location = new System.Drawing.Point(0, 495);
			this.sbPix.Name = "sbPix";
			this.sbPix.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					 this.sbpReady,
																					 this.sbpCount});
			this.sbPix.ShowPanels = true;
			this.sbPix.Size = new System.Drawing.Size(784, 22);
			this.sbPix.TabIndex = 2;
			this.sbPix.Text = "statusBar1";
			// 
			// tpDone
			// 
			this.tpDone.Controls.Add(this.lvwDone);
			this.tpDone.Location = new System.Drawing.Point(4, 22);
			this.tpDone.Name = "tpDone";
			this.tpDone.Size = new System.Drawing.Size(776, 441);
			this.tpDone.TabIndex = 1;
			this.tpDone.Text = "Done";
			// 
			// lvwDone
			// 
			this.lvwDone.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.lvcDoneId,
																					  this.lvcDoneThreadId,
																					  this.lvcDoneUrl,
																					  this.lvcDoneReferrer,
																					  this.lvcDoneSize,
																					  this.lvcDoneTotal,
																					  this.lvcDoneStatus});
			this.lvwDone.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwDone.GridLines = true;
			this.lvwDone.Location = new System.Drawing.Point(0, 0);
			this.lvwDone.Name = "lvwDone";
			this.lvwDone.Size = new System.Drawing.Size(776, 441);
			this.lvwDone.TabIndex = 0;
			this.lvwDone.View = System.Windows.Forms.View.Details;
			// 
			// lvcDoneId
			// 
			this.lvcDoneId.Text = "#";
			this.lvcDoneId.Width = 35;
			// 
			// lvcDoneThreadId
			// 
			this.lvcDoneThreadId.Text = "Thread Id";
			this.lvcDoneThreadId.Width = 25;
			// 
			// lvcDoneUrl
			// 
			this.lvcDoneUrl.Text = "Url";
			this.lvcDoneUrl.Width = 300;
			// 
			// lvcDoneReferrer
			// 
			this.lvcDoneReferrer.Text = "Referrer";
			this.lvcDoneReferrer.Width = 200;
			// 
			// lvcDoneSize
			// 
			this.lvcDoneSize.Text = "Size";
			this.lvcDoneSize.Width = 80;
			// 
			// lvcDoneTotal
			// 
			this.lvcDoneTotal.Text = "Total";
			this.lvcDoneTotal.Width = 80;
			// 
			// lvcDoneStatus
			// 
			this.lvcDoneStatus.Text = "Status";
			this.lvcDoneStatus.Width = 150;
			// 
			// sbpReady
			// 
			this.sbpReady.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpReady.Width = 568;
			// 
			// sbpCount
			// 
			this.sbpCount.Width = 200;
			// 
			// PixGrabberForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 517);
			this.Controls.Add(this.tcMain);
			this.Controls.Add(this.mainToolbar);
			this.Controls.Add(this.sbPix);
			this.Name = "PixGrabberForm";
			this.Text = "Pix Grabber";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.PixGrabberForm_Closing);
			this.Load += new System.EventHandler(this.PixGrabberForm_Load);
			this.tcMain.ResumeLayout(false);
			this.tpInprogress.ResumeLayout(false);
			this.tpDone.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sbpReady)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void selectOneButton_Click(object sender, System.EventArgs e)
		{
		}

		private void selectAllButton_Click(object sender, System.EventArgs e)
		{
		}

		private void removeAllButton_Click(object sender, System.EventArgs e)
		{
		}

		private void removeOneButton_Click(object sender, System.EventArgs e)
		{
			//			foreach (ListViewItem lvw in selectedList.SelectedItems)
			//			{
			//				ListViewItem myListItem = availableList.Items.Add(lvw.Text);
			//				myListItem.SubItems.Add(lvw.SubItems[1].Text);
			//
			//				lvw.Remove();
			//			}
		}

		private void startGrabButton_Click(object sender, System.EventArgs e)
		{
			StartThreads();
		}

		private void stopGrabButton_Click(object sender, System.EventArgs e)
		{
			StopThreads();		
		}

		private void pauseGrabButton_Click(object sender, System.EventArgs e)
		{
			PauseThreads();
		}

		private void PixGrabberForm_Load(object sender, System.EventArgs e)
		{
		
		}

		private void PixGrabberForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            //if (MessageBox.Show("Do you really want to close?","Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
		}

		private void StartThreads()
		{
			myClients = new MyWebClient[maxThreads];
			myThreads = new Thread[maxThreads];
			myThreadDelegates = new ThreadStart[maxThreads];

			for (int i = 0; i < maxThreads; i++)
			{
				myClients[i] = new MyWebClient();
				myClients[i].Key = i;
				myClients[i].GrabberForm = this;

                //if (useProxy == true)
                //{
                //    myClients[i].UseProxy = true;
                //    myClients[i].ProxyAddress = ConfigurationSettings.AppSettings["ProxyUri"];
                //    myClients[i].ProxyUserName = ConfigurationSettings.AppSettings["ProxyUser"];
                //    myClients[i].ProxyPassword = ConfigurationSettings.AppSettings["ProxyPassword"];
                //    myClients[i].ProxyDomain = ConfigurationSettings.AppSettings["ProxyDomain"];
                //}

                myClients[i].BufferSize = SettingsHelper.Current.BufferSize;
                myClients[i].UserAgent = SettingsHelper.Current.UserAgent;

                myClients[i].UseReferrer = SettingsHelper.Current.UseReferrer;
				myClients[i].AllowRedirect = false;

                //myClients[i].UseSiteCredentials = Convert.ToBoolean(ConfigurationSettings.AppSettings["UseSiteCredentials"]);
                //myClients[i].SiteUserName = ConfigurationSettings.AppSettings["SiteUserName"];
                //myClients[i].SitePassword = ConfigurationSettings.AppSettings["SitePassword"];
                //myClients[i].SiteDomain = ConfigurationSettings.AppSettings["SiteDomain"];
				myClients[i].TimeOut = 10;

				myClients[i].State = ThreadState.Starting;

				myThreadDelegates[i] = new ThreadStart(myClients[i].StartDownload);
				myThreads[i] = new Thread(myThreadDelegates[i]);
				myThreads[i].Start();
			}

			pauseGrab = false;
			tlbtnRefresh.Enabled = true;
		}

		private void StopThreads()
		{
			for (int i = 0; i < maxThreads; i++)
			{
				myClients[i].State = ThreadState.Stopping;
			}
		}

		private void PauseThreads()
		{
			for (int i = 0; i < maxThreads; i++)
			{
				//				if (myClients[i].State == ThreadState.Pausing)
				myClients[i].State = ThreadState.Paused;
				//				else
				//					myClients[i].State = ThreadState.Pausing;
			}
			pauseGrab = true;
		}

		private void ResumeThreads()
		{
			for (int i = 0; i < maxThreads; i++)
			{
				myClients[i].State = ThreadState.Starting;
				myClients[i].ResumeDownload();
			}
			pauseGrab = false;
		}

		private void ThreadRunning(bool isRunning)
		{
			tlbtnPlay.Enabled = !isRunning;
			tlbtnStop.Enabled = isRunning;
			tlbtnPause.Enabled = isRunning;
		}

		private void mainToolbar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == tlbtnCheckAll)
			{
				CheckListItems(true);
			}
			else if (e.Button == tlbtnUncheckAll)
			{
				CheckListItems(false);
			}
			else if (e.Button == tlbtnToggleChecked)
			{
				ToggleListItems();
			}
			else if (e.Button == tlbtnPlay)
			{
				if (pauseGrab== false)
				{
					StartThreads();
					ThreadRunning(true);
				}
				else
				{
					ResumeThreads();
					ThreadRunning(true);
				}
			}
			else if (e.Button == tlbtnPause)
			{
				PauseThreads();
				ThreadRunning(false);
			}
			else if (e.Button == tlbtnStop)
			{
				StopThreads();
				ThreadRunning(false);
			}
			else if (e.Button == tlbtnRemoveSelect)
			{
				foreach (ListViewItem lvw in selectedList.CheckedItems)
				{
					lvw.Remove();
				}
			}
			else if (e.Button == tlbtnRefresh)
			{
				bool reload = true;
				for (int i = 0; i < maxThreads; i++)
				{
					if (myClients[i].State != ThreadState.Paused)
					{
						reload = false;
						break;
					}
				}

				if (reload)
				{
					selectedList.Items.Clear();
					LoadLinks();
				}
				else
					MessageBox.Show("Cannot reload when threads are running");
			}
			else if (e.Button == tlbtnExport)
			{
				ExportListView(selectedList);
			}
			else if (e.Button == tlbtnSeriesGen)
			{
				SeriesForm mySeries = new SeriesForm();
				mySeries.Show();
			}
		}

		private void ExportListView(ListView lv)
		{
			SaveFileDialog _saveFileDialog = new SaveFileDialog();
			_saveFileDialog.Filter = "Text Files|*.txt";
			_saveFileDialog.FilterIndex = 2 ;
			_saveFileDialog.RestoreDirectory = true ;

			if(_saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = File.Create(_saveFileDialog.FileName); 
				StreamWriter sw = new StreamWriter(fs); 
				
				foreach (ListViewItem lvw in lv.Items)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();

					for(int i=0; i<lvw.SubItems.Count; i++)
					{
						if (i!=0)
							sb.Append(",");
						sb.Append(lvw.SubItems[i].Text);
					}

					sw.WriteLine(sb.ToString());
				}
				sw.Close(); 
				fs.Close();

				MessageBox.Show("List exported successfully");
			}
		}

        // Load links from string array
        public void LoadLinks(string[] links, string referrer)
        {
            int id = selectedList.Items.Count + 1;

            for (int i = 0; i < links.Length; i++,id++)
            {
                ListViewItem lvw = new ListViewItem(id.ToString());

                lvw.SubItems.Add("New");               // DB Id used for DB Saving
                lvw.SubItems.Add(links[id]);        // Image Link
                lvw.SubItems.Add(referrer);         // Referrer Link
                lvw.SubItems.Add("");               // Size Grabbed
                lvw.SubItems.Add("");               // Total Sizee
                lvw.SubItems.Add("New");            // Status

                selectedList.Items.Add(lvw);
            }

            newcount = newcount + selectedList.Items.Count;

            if (newcount > SettingsHelper.Current.AlterImageLevel)  //auto save limit
                SaveLinks(true);

            ResumeThreads();
            ThreadRunning(true);
        }

        // Load database table links to list view
        private void LoadLinks()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            string constr = ConfigurationSettings.AppSettings["ControlDatabase"];

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from GrabListVw1", cn);

                DataSet ds = new DataSet();
                adp.Fill(ds);

                cn.Close();
                cn.Dispose();

                //Split the dataset of links to into an array of data tables [no of tables depends on max buckets]
                DataTable[] dt = SplitTable(ds.Tables[0]);

                //Find the size of biggest bucket
                int maxRows = ds.Tables[0].Rows.Count;

                for (int i = 1; i < dt.Length; i++)
                    if (dt[i].Rows.Count > maxRows)
                        maxRows = dt[i].Rows.Count;

                //Run thru all the tables and interleave the rows from all the tables
                for (int i = 0; i < maxRows; i++)
                {
                    for (int j = 0; j < dt.Length; j++)
                    {
                        if (i < dt[j].Rows.Count)
                        {
                            ListViewItem lvw = new ListViewItem(dt[j].Rows[i][0].ToString());

                            lvw.SubItems.Add("");
                            lvw.SubItems.Add(dt[j].Rows[i][3].ToString());
                            lvw.SubItems.Add(dt[j].Rows[i][4].ToString());
                            lvw.SubItems.Add(dt[j].Rows[i][5].ToString());
                            lvw.SubItems.Add(dt[j].Rows[i][6].ToString());
                            lvw.SubItems.Add(dt[j].Rows[i][8].ToString());

                            selectedList.Items.Add(lvw);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                sbpCount.Text = Convert.ToString(grabCount) + "/" + Convert.ToString(selectedList.Items.Count);
                sbpReady.Text = "Ready to grab...";

                selectedList.FullRowSelect = true;
                selectedList.Show();
                selectedList.Visible = true;

            }

        }

		[MethodImplAttribute(MethodImplOptions.Synchronized)]
		public ListViewItem GetNextLink()
		{
            //bool bContinueGrab = true;

            //// Check if the DialUp is connect when the configuration item is set
            //if (checkConnectivity)
            //{
            //    if (DialUpHelper.IsConnectedToInternet())
            //        bContinueGrab = true;
            //    else
            //        bContinueGrab = false;
            //}
            //else
            //    bContinueGrab = true;

            //MessageBox.Show("Contine grab: " + bContinueGrab.ToString());
            //// Return next link if ok to continue grab
            //// else stop grabbing and return null link
            ListViewItem lvw = null;
            //if (bContinueGrab)
            //{
                grabCount++;
                //Following line is make thread safe through SetControlValue method
                //sbpCount.Text = Convert.ToString(grabCount) + "/" + Convert.ToString(selectedList.Items.Count);
                //SetControlPropertyValue((Control) sbpCount, "Text", Convert.ToString(grabCount) + "/" + Convert.ToString(selectedList.Items.Count));
                for (int i = 0; i < selectedList.Items.Count; i++)
                {
                    if (GetListViewItem(i).SubItems[Convert.ToInt32(ListColumns.Status)].Text == "New")
                    {
                        lvw = GetListViewItem(i);
                        break;
                    }
                }
            //}
            //else
            //{
            //    StopThreads();
            //    ThreadRunning(false);
            //    MessageBox.Show("Dialup Not Connected. Please connect!!!");
            //}
            
            return lvw;
		}

		private void CheckListItems(bool chk)
		{
			foreach (ListViewItem lvw in selectedList.Items)
			{
				lvw.Checked = chk;
			}
		}

		private void ToggleListItems()
		{
			foreach (ListViewItem lvw in selectedList.Items)
			{
				lvw.Checked = !lvw.Checked;
			}
		}

        // Split one data table data in n data tables
        // n is th custom parameter max grab buckets
        private DataTable[] SplitTable(DataTable dtIn)
        {
            int maxBuckets = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["MaxGrabBuckets"]);
            DataTable[] dt = new DataTable[maxBuckets];

            for (int i = 0; i < maxBuckets; i++)
            {
                dt[i] = dtIn.Clone();
            }

            DataTable dtSites = Distinct(dtIn, "site");

            CopyFilteredRows(dt[0], dtIn, dtSites.Rows[0][0].ToString());

            for (int i = 1; i < dtSites.Rows.Count; i++)
            {
                int selected = 0;
                for (int j = 0; j < maxBuckets; j++)
                {
                    if (dt[selected].Rows.Count > dt[j].Rows.Count)
                    {
                        selected = j;
                    }
                }

                CopyFilteredRows(dt[selected], dtIn, dtSites.Rows[i][0].ToString());
            }

            return dt;
        }

		private void CopyFilteredRows(DataTable dt, DataTable dtAll, string str)
		{
			DataView dv = new DataView(dtAll, "site='" + str + "'","url", DataViewRowState.CurrentRows);
            
			for(int i=0; i<dv.Count; i++)
			{
				DataRow rw = dt.NewRow();
	
				for(int j=0;j<rw.ItemArray.Length; j++)
				{
					rw[j] = dv[i][j];
				}

				dt.Rows.Add(rw);
			}
		}

		private DataTable Distinct(DataTable dt, string distCol)
		{
			DataTable dtclone = new DataTable("Sites");
			dtclone.Columns.Add("site");

			DataView dv = new DataView(dt);

			dv.Sort = distCol;

			string myselold = string.Empty;
			for(int i=0; i<dv.Count; i++)
			{
				string site = (dv[i][distCol].ToString());
				if(myselold != site)
				{
					DataRow rw = dtclone.NewRow();

					rw[0] = site;
					myselold = site;
					dtclone.Rows.Add(rw);
				}
			}

			return dtclone;
		}

		private string GetSite(string str)
		{
			return(str.Substring(1, str.IndexOf("/",8)));
		}

        // SetControlValueCallback delegate and SetControlPropertyValue are implemented to make the contorl access thread safe
        // To avoid [cross thread operations not valid] error
        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }
        private delegate ListViewItem GetListViewItemDelegate(int index);

        private ListViewItem GetListViewItem(int index)
        {
            ListViewItem lvwItem;

            if (this.selectedList.InvokeRequired)    
            {        
                // This is a worker thread so delegate the task.        
                lvwItem = (ListViewItem) this.selectedList.Invoke(new GetListViewItemDelegate(this.GetListViewItem), index);    
            }    
            else    
            {        
                // This is the UI thread so perform the task.        
                lvwItem = this.selectedList.Items[index];    
            }

            return lvwItem;
        }

        private void SaveLinks(bool autoSave)
        {
            int counter = selectedList.Items.Count;

            SettingsHelper helper = SettingsHelper.Current;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            string constr = helper.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority) values(?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", SqlDbType.VarChar);
                cmd.Parameters.Add("referrer", SqlDbType.VarChar);
                cmd.Parameters.Add("Priority", SqlDbType.VarChar);

                foreach (ListViewItem lvw in selectedList.Items)
                {
                    if (lvw.SubItems[ListColumns.Index] == "New")
                    {
                        cmd.Parameters[0].Value = lvw.SubItems[ListColumns.Url].Text;
                        cmd.Parameters[1].Value = lvw.SubItems[ListColumns.Referrer].Text;
                        cmd.Parameters[2].Value = "Top";

                        lvw.SubItems[ListColumns.Index] = "Saved";

                        cmd.ExecuteNonQuery();
                    }
                    //lvw.Remove();
                }

                StatusEventArgs args = new StatusEventArgs();

                if (autoSave)
                    args.Message = "[AutoSave Active] " + counter.ToString() + " row(s) added to DB successfully";
                else
                    args.Message = counter.ToString() + " row(s) added to DB successfully";

                args.Panel = StatusPanels.MainPanel;
                //StatusChanged(this, args);


                args.Message = "Count :: 0";
                args.Panel = StatusPanels.ImageCounter;
                //StatusChanged(this, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //LogHelper.WriteLog(LogLevel.Verbose, "Exception : " + e.Message);

            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        
	}

	public enum ListColumns
	{
		Index = 0,
		ThreadId = 1,
		Url = 2,
		Referrer = 3,
		Size = 4,
		Total = 5,
		Status = 6
	}
}
