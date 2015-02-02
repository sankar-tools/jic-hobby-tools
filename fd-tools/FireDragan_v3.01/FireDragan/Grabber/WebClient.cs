using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

using SansTech.Net.Http;

namespace FireDragan
{
	class MyWebClient : HttpHelper
	{
		public PixGrabberForm GrabberForm = null;
		public string URL = string.Empty;
		public ThreadState State = ThreadState.New;

		public string SaveLocation = string.Empty;

		private int myKey = -1;
		private ListViewItem currentListItem = null;

		public int Key
		{
			get { return myKey; }
			set { myKey = value; }
		}

		public void StartDownload()
		{
			this.OnReceiveData += new HttpHelper.OnReceiveDataHandler(Grabber_DownloadProgressChanged);

			DownloadNextFile();
			State = ThreadState.Started;
		}

		public void ResumeDownload()
		{
			DownloadNextFile();
			State = ThreadState.Started;
		}

		public void Grabber_DownloadProgressChanged(object sender, HttpHelper.OnReceiveDataEventArgs args)
		{
			MyWebClient thisClient = (MyWebClient) sender;

			if (args.Done == true)
			{
				this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Status)].Text = args.StatusCode.ToString();

				UpdateDatabase();

				switch (State)
				{
					case ThreadState.Pausing:
						State = ThreadState.Paused;
						break;

					case ThreadState.Stopping:
						State = ThreadState.Stopped;
						break;

					default:
						DownloadNextFile();
						break;
				}
			}
			else
			{
				this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Size)].Text = 
					args.CurrentByteCount.ToString();
				this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Total)].Text =
					args.TotalBytes.ToString();
				this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Status)].Text = 
					Convert.ToString((double)args.CurrentByteCount / (double)args.TotalBytes * 100) + "%";
			}
		}

		private void DownloadNextFile()
		{
			if (State == ThreadState.Starting || State == ThreadState.Started)
			{
				this.currentListItem = GrabberForm.GetNextLink();

				if (this.currentListItem != null)
				{
					this.URL = this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Url)].Text;

					this.SaveLocation = GetSavePath(this.URL);

					this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Size)].Text = "-1";
					this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Status)].Text = "Unknown";
					this.currentListItem.SubItems[Convert.ToInt32(ListColumns.ThreadId)].Text = this.myKey.ToString();

					//GetUrlEvents(URL, 10240);
					DownloadFileEv(URL, this.currentListItem.SubItems[Convert.ToInt32(ListColumns.Referrer)].Text, SaveLocation);
				}
				else
					State = ThreadState.Stopped;
			}
		}

		private string GetSavePath(string str)
		{
			if (SettingsHelper.Current.PreservePath == true)
			{
				if (str.IndexOf("http://") < 0)
				{
					return SettingsHelper.Current.GrabberSaveLocation + @"\" + str.Replace("/", @"\");
				}
				else
				{
                    return SettingsHelper.Current.GrabberSaveLocation + "\\" +
						str.Substring(7).Replace("/", @"\");
				}
			}
			else
			{
                return SettingsHelper.Current.GrabberSaveLocation + @"\" + str.Substring(str.LastIndexOf(@"\") + 1);
			}
		}

        private void UpdateDatabase()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            string constr = SettingsHelper.Current.DBConnection;

            try
            {
                cn.ConnectionString = constr;
                cn.Open();

                cmd.Connection = cn;

                //cmd.CommandText = "update GrabList set lastModified=?, sizeGrabbed=?, sizeTotal=?, retry=retry+1, status=? where id=?";
                cmd.CommandText = "update GrabList set lastModified= '" + DateTime.Now.ToString() + "'," +
                    "sizeGrabbed=" + currentListItem.SubItems[Convert.ToInt32(ListColumns.Size)].Text + "," +
                    "sizeTotal=" + currentListItem.SubItems[Convert.ToInt32(ListColumns.Total)].Text + "," +
                    "retry=retry+1, status='" + currentListItem.SubItems[Convert.ToInt32(ListColumns.Status)].Text + "' " +
                    "where id=" + currentListItem.SubItems[Convert.ToInt32(ListColumns.Index)].Text;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.Add("lastModified", SqlDbType.DateTime);
                //cmd.Parameters.Add("sizeGrabbed", SqlDbType.Decimal);
                //cmd.Parameters.Add("sizeTotal", SqlDbType.Decimal);
                //cmd.Parameters.Add("status", SqlDbType.VarChar);
                //cmd.Parameters.Add("id", SqlDbType.Decimal);

                //cmd.Parameters[0].Value = DateTime.Now.ToString();
                //cmd.Parameters[1].Value = currentListItem.SubItems[Convert.ToInt32(PixGrabber.ListColumns.Size)].Text;
                //cmd.Parameters[2].Value = currentListItem.SubItems[Convert.ToInt32(PixGrabber.ListColumns.Total)].Text;
                //cmd.Parameters[3].Value = currentListItem.SubItems[Convert.ToInt32(PixGrabber.ListColumns.Status)].Text;
                //cmd.Parameters[4].Value = currentListItem.SubItems[Convert.ToInt32(PixGrabber.ListColumns.Index)].Text;

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

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

	public enum ThreadState
	{
		New = 0,
		Starting = 1,
		Started = 2,
		Pausing = 3,
		Paused = 4,
		Stopping = 5,
		Stopped = 6
	}
}
