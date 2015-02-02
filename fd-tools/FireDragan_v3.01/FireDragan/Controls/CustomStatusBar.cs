using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FireDragan
{
    public partial class CustomStatusBar : System.Windows.Forms.StatusStrip
    {
        private System.Windows.Forms.ToolStripStatusLabel sslblMain;
        private System.Windows.Forms.ToolStripStatusLabel sslblImgCounter;
        private System.Windows.Forms.ToolStripStatusLabel sslblTabCounter;

        public CustomStatusBar()
        {
            InitializeComponent();
        }

        public CustomStatusBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string StatusMessage
        {
            get { return sslblMain.Text; }
            set { sslblMain.Text = value; }
        }

        public string ImageCounter
        {
            get { return sslblImgCounter.Text; }
            set { sslblImgCounter.Text = value; }
        }

        public string TabCounter
        {
            get { return sslblTabCounter.Text; }
            set { sslblTabCounter.Text = value; }
        }

        public void Message(string message, StatusPanels panel)
        {
            switch (panel)
            {
                case StatusPanels.MainPanel:
                    sslblMain.Text = message;
                    break;
                case StatusPanels.ImageCounter:
                    sslblImgCounter.Text = message;
                    break;
                case StatusPanels.TabCounter:
                    sslblTabCounter.Text = message;
                    break;
            }
        }

        public event StatusChanged StatusChanged;
    }

    public enum StatusPanels
    { 
        MainPanel =0,
        ImageCounter = 1,
        TabCounter = 2
    }

    public class StatusEventArgs : EventArgs
    {
        protected StatusPanels panel;
        protected string message;

        public StatusEventArgs(string message, StatusPanels panel)
        {
            this.Message = message;
            this.panel = panel;
        }

        public StatusEventArgs()
        { }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public StatusPanels Panel
        {
            get { return panel; }
            set { panel = value; }
        }
    }
}
