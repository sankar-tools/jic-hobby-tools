using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FireDragan.Forms
{
    public partial class SessionForm : Form
    {
        public SessionForm()
        {
            InitializeComponent();
        }

        private void tsbtnSessionSave_Click(object sender, EventArgs e)
        {
            SessionManager.Current.Session.Save();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadTabs();
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {
            LoadTabs();
        }

        private void LoadTabs()
        {
            LoadCurrentSessionTab();
            LoadAllSessionsTab();
        }

        private void LoadCurrentSessionTab()
        {
            lstSessionCurrent.Items.Clear();

            ArrayList links = SessionManager.Current.Session.SessionLinks;

            for (int i = 0; i < links.Count; i++)
            {
                SessionLink link = (SessionLink) links[i];
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, link.Link));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, link.Visited.ToString()));

                lstSessionCurrent.Items.Add(item);
            }
        }

        private void LoadAllSessionsTab()
        {
            lstSessionAll.Items.Clear();

            DataTable dt = SessionManager.Current.GetSessions();

            foreach (DataRow drow in dt.Rows)
            {
                ListViewItem item = new ListViewItem(drow[0].ToString());
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, drow[1].ToString()));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, drow[2].ToString()));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, drow[3].ToString()));

                lstSessionAll.Items.Add(item);
            }
        }
    }
}
