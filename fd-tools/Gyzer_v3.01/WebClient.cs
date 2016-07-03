using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace GTech.Olivia.Gyzer
{
	class MyWebClient : HttpHelper
	{
        public CrawlWin GrabberForm = null;
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
            string status = "unknown";
            long size = args.TotalBytes;
            long count = args.CurrentByteCount;

			if (args.Done == true)
			{
                //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Status)].Text = args.StatusCode.ToString();
                status = args.StatusCode.ToString();
                DownloadArgs a = new DownloadArgs(this.myKey, status, size, count);
                GrabberForm.UpdateProgress(currentListItem, a);

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
                size = args.TotalBytes;
                count = args.CurrentByteCount;
                //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Size)].Text = 
                //    args.CurrentByteCount.ToString();
                //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Total)].Text =
                //    args.TotalBytes.ToString();
                //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Status)].Text = 
                //    Convert.ToString((double)args.CurrentByteCount / (double)args.TotalBytes * 100) + "%";
                status = Convert.ToString((double)args.CurrentByteCount / (double)args.TotalBytes * 100) + "%";

                DownloadArgs a = new DownloadArgs(this.myKey, status, size, count);
                GrabberForm.UpdateProgress(currentListItem, a);
			}


		}

		private void DownloadNextFile()
		{
			if (State == ThreadState.Starting || State == ThreadState.Started)
			{
				this.currentListItem = GrabberForm.GetNextLink();

				if (this.currentListItem != null)
				{
                    this.URL = this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Url)].Text;

                    string tag = this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Tag)].Text.Split(new char[] {',' , ';'})[0];
                    this.SaveLocation = GetSavePath(this.URL, tag);

                    //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Size)].Text = "-1";
                    //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Status)].Text = "Unknown";
                    //this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.ThreadId)].Text = this.myKey.ToString();

                    DownloadArgs args = new DownloadArgs(this.myKey, "Unknown", -1, -1);
                    GrabberForm.UpdateProgress(this.currentListItem, args);


                    string massaged = MassageUrl(URL);
                    DownloadFileEv(massaged, this.currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Referrer)].Text, SaveLocation);
				}
				else
					State = ThreadState.Stopped;
			}
		}

        private string MassageUrl(string URL)
        {
            //if (URL.Contains("imgbox.com"))
            //{ 
            //    return "http://content
            //}

            return URL;
        }

		private string GetSavePath(string url, string tag)
		{
            //ToDo:: Optimize code
            //string returnPath = string.Empty;
            string basePath = ConfigurationSettings.AppSettings["SaveLocation"].ToString();
            string[] filepathComp = url.Split(new Char[] { '\\', '/' });

            string filenameWithExt = filepathComp[filepathComp.Length - 1];
            if (String.IsNullOrEmpty(filenameWithExt))
                filenameWithExt = filepathComp[filepathComp.Length - 2];

            string directory = url.Replace(filenameWithExt, string.Empty);
            string filename = filenameWithExt;
            string fileExt = "";

            if (filenameWithExt.LastIndexOf('.') > 0)
            {
                filename = filenameWithExt.Substring(0, filenameWithExt.LastIndexOf('.'));
                fileExt = filenameWithExt.Substring(filenameWithExt.LastIndexOf('.') + 1);
            }

			if (Convert.ToBoolean(ConfigurationSettings.AppSettings["PreservePath"]) == true)
			{
                if (directory.IndexOf("http://") < 0)
                {
                    directory = directory.Replace("/", @"\");
                }
                else
                {
                    directory = directory.Substring(7).Replace("/", @"\");
                }
			}

            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["GroupByTag"]) == true)
            {
                directory = tag + @"\" +  directory;
            }

            directory = basePath + @"\" + directory;

            int counter = 0;
            string uniqueFileName = filename;
            while (System.IO.File.Exists(directory + @"\" + uniqueFileName + "." + fileExt))
            {
                uniqueFileName = filename + "_" + counter.ToString().PadLeft(4, '0');
                counter++;
            }

            return directory + @"\" + uniqueFileName + "." + fileExt;
		}

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
		private void UpdateDatabase()
		{
			SqlConnection cn = new SqlConnection();
			SqlCommand cmd = new SqlCommand();

			string constr = ConfigurationSettings.AppSettings["ControlDatabase"];

			try
			{
				cn.ConnectionString = constr;
				cn.Open();

				cmd.Connection = cn;

                string sizeTotal = "-1";
                if (!string.IsNullOrEmpty(currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Total)].Text))
                    sizeTotal = currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Total)].Text;

				//cmd.CommandText = "update GrabList set lastModified=?, sizeGrabbed=?, sizeTotal=?, retry=retry+1, status=? where id=?";
                cmd.CommandText = "update GrabList set lastModified= '" +DateTime.Now.ToString() + "'," +
                    "sizeGrabbed=" + currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Size)].Text + "," +
                    "sizeTotal=" + sizeTotal + "," +
                    "retry=retry+1, status='" + currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Status)].Text + "' " +
                    //" originalUrl='" + currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Original)].Text + "' " +
                    "where id=" + currentListItem.SubItems[Convert.ToInt32(Global.ListColumns.Index)].Text;
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
			catch(Exception e)
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



}
