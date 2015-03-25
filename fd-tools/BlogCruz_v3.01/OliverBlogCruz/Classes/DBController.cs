using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace OliverBlogCruz
{
    public class DBController
    {
        #region Singleton
        private static DBController instance;

        private DBController() { }

        public static DBController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBController();
                }
                return instance;
            }
        }
        #endregion singleton

        #region Static Members

        public static string DatabaseConnectionString = string.Empty;

        #endregion

        public static int SaveLinks(List<PageProperties> pages)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            int totalLinks = 0;

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority, category, status) values(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("referrer", OleDbType.VarChar);
                cmd.Parameters.Add("Priority", OleDbType.VarChar);
                cmd.Parameters.Add("Category", OleDbType.VarChar);
                cmd.Parameters.Add("Status", OleDbType.VarChar);

                foreach (PageProperties page in pages)
                {
                    foreach (LinkProperties link in page.imageCollection)
                    {
                        if(LinkFilter.Instance.IsValid(link))
                        {
                            cmd.Parameters[0].Value = MessageUrl(link.Url);
                            cmd.Parameters[1].Value = page.Url;
                            cmd.Parameters[2].Value = "High";
                            cmd.Parameters[3].Value = page.BlogId + ",Exbi";
                            cmd.Parameters[4].Value = "New";

                            cmd.ExecuteNonQuery();

                            totalLinks++;
                        }
                    }
                }
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

            return totalLinks;
        }

        private static string MessageUrl(string url)
        {
            if (url.Contains("pzy.be"))
            {
                if (url.Contains("/t/"))
                    url = url.Replace("/t/", "/i/");

                if(url.Contains("/v/"))
                {
                    string tempUrl = url.Replace("/v/", "/i/");
                    string[] urlcomps = url.Split(new char[] { '/' });

                    if (urlcomps[urlcomps.Length-1].LastIndexOf('.') <= 0)
                    {
                        tempUrl += ".jpg";
                        
                    }
                    url = tempUrl;

                }
            }

            return url;
        }



        internal static int SaveLinks(Dictionary<string, List<LinkProperties>> groupedLinks, List<string> keys, string BlogId)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            int totalLinks = 0;

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority, category, status) values(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("referrer", OleDbType.VarChar);
                cmd.Parameters.Add("Priority", OleDbType.VarChar);
                cmd.Parameters.Add("Category", OleDbType.VarChar);
                cmd.Parameters.Add("Status", OleDbType.VarChar);

                foreach (string key in keys)
                {
                    foreach (LinkProperties link in groupedLinks[key])
                    {
                        //if (LinkFilter.Instance.IsValid(link))
                        {
                            cmd.Parameters[0].Value = MessageUrl(link.Url);
                            cmd.Parameters[1].Value = link.Referrer;
                            cmd.Parameters[2].Value = "High";
                            cmd.Parameters[3].Value = BlogId + ",Exbi";
                            cmd.Parameters[4].Value = "New";

                            cmd.ExecuteNonQuery();

                            totalLinks++;
                        }
                    }
                }
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

            return totalLinks;
        }

        internal static void SaveSession(LogListSession session, string blogId)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into BlogTrack (blogId, created, startIndex, endIndex, step, images) values(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("blogId", OleDbType.VarChar);
                cmd.Parameters.Add("created", OleDbType.Date);
                cmd.Parameters.Add("startIndex", OleDbType.Integer);
                cmd.Parameters.Add("endIndex", OleDbType.Integer);
                cmd.Parameters.Add("step", OleDbType.Integer);
                cmd.Parameters.Add("images", OleDbType.Integer);

                cmd.Parameters[0].Value = blogId;
                cmd.Parameters[1].Value = DateTime.Now;
                cmd.Parameters[2].Value = session.StartIndex;
                cmd.Parameters[3].Value = session.EndIndex;
                cmd.Parameters[4].Value = session.StepIndex;
                cmd.Parameters[5].Value = session.Images;

                cmd.ExecuteNonQuery();
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
