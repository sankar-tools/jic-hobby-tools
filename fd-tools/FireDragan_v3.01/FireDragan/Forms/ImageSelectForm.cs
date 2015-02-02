using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace FireDragan
{
    public partial class ImageSelectForm : Form
    {
        public event StatusChanged StatusChanged;

        public ImageSelectForm()
        {
            InitializeComponent();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveLinks(false);
        }

        private void SaveLinks(bool autoSave)
        {
            int counter = lvImageLinks.Items.Count;

            SettingsHelper helper = SettingsHelper.Current;

            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string constr = helper.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority, category) values(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("referrer", OleDbType.VarChar);
                cmd.Parameters.Add("Priority", OleDbType.VarChar);
                cmd.Parameters.Add("Category", OleDbType.VarChar);

                foreach (ListViewItem lvw in lvImageLinks.Items)
                {
                    cmd.Parameters[0].Value = lvw.SubItems[1].Text;
                    cmd.Parameters[1].Value = lvw.SubItems[2].Text;
                    cmd.Parameters[2].Value = lvw.SubItems[3].Text;
                    cmd.Parameters[3].Value = lvw.SubItems[4].Text;

                    cmd.ExecuteNonQuery();

                    lvw.Remove();
                }

                StatusEventArgs args = new StatusEventArgs();

                if (autoSave)
                    args.Message = "[AutoSave Active] " + counter.ToString() + " row(s) added to DB successfully";
                else
                    args.Message = counter.ToString() + " row(s) added to DB successfully";

                args.Panel = StatusPanels.MainPanel;
                StatusChanged(this, args);


                args.Message = "Count :: 0";
                args.Panel = StatusPanels.ImageCounter;
                StatusChanged(this, args);
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

        public void AddLinks(string[] links, string url, GrabPriority priority, string category)
        {
            int counter = lvImageLinks.Items.Count;

            for (int i = 0; i < links.Length; i++)
            {
                ListViewItem item = lvImageLinks.Items.Add((++counter).ToString());

                item.SubItems.Add(links[i]);
                item.SubItems.Add(url);

                item.SubItems.Add(priority.ToString());
                item.SubItems.Add(category);
            }

            this.Show();

            StatusEventArgs args = new StatusEventArgs();

            args.Message = links.Length.ToString() + " row(s) added successfully";
            args.Panel = StatusPanels.MainPanel;
            StatusChanged(this, args);


            args.Message = "Count :: " + lvImageLinks.Items.Count.ToString();
            args.Panel = StatusPanels.ImageCounter;
            StatusChanged(this, args);

            int autoSaveLimit = SettingsHelper.Current.AlterImageLevel;

            if (lvImageLinks.Items.Count > autoSaveLimit)
            {
                SaveLinks(true);
            }
        }

        private void ImageSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void ImageSelectForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbtnRemoveAll_Click(object sender, EventArgs e)
        {
            lvImageLinks.Items.Clear();
        }

        private void tsbtnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvImageLinks.Items)
            {
                if (item.Checked)
                {
                    item.Remove();
                }
            }
        }

    }
}