using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace OliverBlogLog
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

        public static DataSet GetBlogList()
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            
            DataSet ds = new DataSet();

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cn.Open();

                cmd.Connection = cn;
                adp.SelectCommand = cmd;

                cmd.CommandText = "select * from BlogList";
                cmd.CommandType = CommandType.Text;

                adp.Fill(ds, "BlogList");

                cmd.CommandText = "select * from BlogTrack";
                cmd.CommandType = CommandType.Text;

                adp.Fill(ds, "BlogTrack");

                cmd.CommandText = "select * from BlogCounters order by category";
                cmd.CommandType = CommandType.Text;

                adp.Fill(ds, "BlogCounters");

                cmd.CommandText = "select * from BlogStats order by category";
                cmd.CommandType = CommandType.Text;

                adp.Fill(ds, "BlogStats");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

            return ds;
        }


        public static string SaveLogItem(LogItem item)
        {
            string action = string.Empty;
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;

                cmd.Connection = cn;
                
                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("maxThreads", OleDbType.VarChar);
                cmd.Parameters.Add("keys", OleDbType.VarChar);
                cmd.Parameters.Add("rate", OleDbType.VarChar);

                cmd.Parameters["url"].Value = item.Link;
                cmd.Parameters["maxThreads"].Value = item.TotalThreads;
                cmd.Parameters["keys"].Value = item.Keywords;
                cmd.Parameters["rate"].Value = item.Rating;


                if (RecordExists(item.BlogId))
                {
                    cmd.CommandText = "update bloglist set url=?, maxThreads=?, keys=?, rate = ?, updated=? where BlogId=?";
                    cmd.Parameters.Add("updated", OleDbType.VarChar);
                    cmd.Parameters.Add("blogId", OleDbType.VarChar);
                    cmd.Parameters["updated"].Value = DateTime.Now;

                    action = "updated";

                }
                else
                {
                    cmd.CommandText = "insert into BlogList (url, maxThreads, keys, rate, blogId) values(?,?,?,?,?)";
                    cmd.Parameters.Add("blogId", OleDbType.VarChar);
                    //cmd.Parameters.Add("created", OleDbType.DBDate);
                    //cmd.Parameters["created"].Value = DateTime.Now;
                    //cmd.Parameters.Add(new OleDbParameter() { ParameterName = "createdOn", Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DbType = DbType.DateTime });
                    action = "created"; 
                }

                cmd.CommandType = CommandType.Text;
                cmd.Parameters["blogId"].Value = item.BlogId;

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return action;

        }

        private static bool RecordExists(string blogId)
        {
            OleDbConnection cn = new OleDbConnection();
            
            OleDbCommand cmd = new OleDbCommand();
            
            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cmd.Connection = cn;
                cmd.CommandText = "select count(*) from bloglist where blogId=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("BlogId", OleDbType.VarChar);
                cmd.Parameters[0].Value = blogId;

                cn.Open();
                int count = (int)cmd.ExecuteScalar();

                return (count > 0);
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
