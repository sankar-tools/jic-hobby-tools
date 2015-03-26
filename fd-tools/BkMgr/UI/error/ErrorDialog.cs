using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fd.lib.ui.common.error
{
    public partial class ErrorDialog : Form
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public string Technical { get; set; }

        public ErrorDialog()
        {
            InitializeComponent();
        }

        public static void Show(string title, string message, Exception ex)
        {
            ErrorDialog dlg = new ErrorDialog();
            dlg.ShowErrorDialog(title, message, ex);
        }

        private void ShowErrorDialog(string title, string message, Exception ex)
        {
            lblError.Text = "Error: " + message;

            this.Title = title;
            this.Message = message;

            if (ex != null)
            {
                this.Exception = ex.ToString();
                this.StackTrace = ex.StackTrace;
            }

            this.Text = this.Title;
            StringBuilder str = new StringBuilder();
            str.AppendLine("Message: " + ex.Message);
            str.AppendLine("Stack Trace...");
            str.AppendLine(ex.StackTrace);

            this.txtStackTrace.Text = str.ToString();
            this.ShowDialog();
        }
    }
}
