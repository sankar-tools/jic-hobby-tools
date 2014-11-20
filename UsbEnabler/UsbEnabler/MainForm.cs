using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace UsbEnabler
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public MainForm()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            Logger.Instance.logArea = this.logArea;

            AddSpecialFolders(); 
            BuildDirTree();


            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Show", OnShow);
            trayMenu.MenuItems.Add("Lock", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "UsbEnable";
            trayIcon.Icon = BitmapAsIcon(UsbEnabler.Properties.Resources.AppIcon);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            this.Icon = BitmapAsIcon(UsbEnabler.Properties.Resources.AppIcon);

            StartProcess();

            (new Login()).ShowDialog();

        }

        private void AddSpecialFolders()
        {
            Logger.Instance.Write(LogModule.FileScanner, "Start scanning special files...");

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Config.Instance().ParseDirs.Add(desktop);
            Logger.Instance.Write(LogModule.FileScanner, desktop);

            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Config.Instance().ParseDirs.Add(docs);
            Logger.Instance.Write(LogModule.FileScanner, docs);

            string pics = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Config.Instance().ParseDirs.Add(pics);
            Logger.Instance.Write(LogModule.FileScanner, pics);

            Logger.Instance.Write(LogModule.FileScanner, "... end scanning special files");
        }

        private Icon BitmapAsIcon(Bitmap img)
        {
            Bitmap Cbitmap = img;

            Cbitmap.MakeTransparent(Color.White);
            System.IntPtr icH = Cbitmap.GetHicon();
            return Icon.FromHandle(icH);
        }

        private void StartProcess()
        {
            Logger.Instance.Write(LogModule.Generic, "Process started at " + DateTime.Now.ToString());
            ThreadStart scanThreadPointer = new ThreadStart(FileScanner.Init);
            ThreadStart saveThreadPointer = new ThreadStart(FileSaver.Init);

            Thread scanThread = new Thread(scanThreadPointer);
            Thread saveThread = new Thread(saveThreadPointer);

            scanThread.Start();
            scanThread.IsBackground = true;
            Thread.Sleep(new TimeSpan(0, 0, 2));            // wait 15 secs before starting the save thread

            if (!Config.Instance().ScanOnly)
            {
                saveThread.Start();
                saveThread.IsBackground = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = Config.Instance().ShowUI;             // Hide form window.
            ShowInTaskbar = false;                          // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnShow(object sender, EventArgs e)
        {
            Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void BuildDirTree()
        {
            Config cfg = Config.Instance();
            if (cfg.ScanAllDirs)
                Logger.Instance.Write(LogModule.FileScanner, "Init scan all directories...");

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string driveCaption = string.Format("{0} [{1}]", drive.Name, drive.DriveType.ToString());
                TreeNode rootNode = new TreeNode(driveCaption);
                dirTree.Nodes.Add(rootNode);

                if (drive.DriveType == DriveType.Fixed)
                {
                    string[] dirs = Directory.GetDirectories(drive.Name);
                    foreach(string dir in dirs)
                    {
                        if (cfg.ScanAllDirs)
                        {
                            string folder = FileHelper.GetDirectoryName(dir);
                            if (!cfg.SkipDirs.Contains(folder, StringComparer.OrdinalIgnoreCase))
                            {
                                cfg.ParseDirs.Add(dir);
                                Logger.Instance.Write(LogModule.FileScanner, dir);
                            }
                        }

                        string dirCaption = dir;

                        TreeNode dirNode = new TreeNode(dirCaption);
                        rootNode.Nodes.Add(dirNode);
                    }
                }

            }

            if (cfg.ScanAllDirs)
                Logger.Instance.Write(LogModule.FileScanner, "... scan all directories ended");
        }
    }
}
