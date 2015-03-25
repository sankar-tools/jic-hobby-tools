using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace OliverBlogCore.Data
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

                cmd.CommandText = "select * from BlogList";
                cmd.CommandType = CommandType.Text;

                adp.SelectCommand = cmd;
                adp.Fill(ds, "BlogList");

                cmd.CommandText = "select * from BlogTrack";
                cmd.CommandType = CommandType.Text;

                adp.Fill(ds, "BlogTrack");

                
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

            return ds;
        }


        public static DataSet SaveLogItem(LogItem item)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            int totalLinks = 0;

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cn.Open();

                cmd.Connection = cn;

                if (RecordExists(item.BloId))
                {
                    cmd.CommandText = "update bloglist set url=?, maxThreads=?, keys=?, rating = ? where BlogId=?";
                }
                else
                {
                    cmd.CommandText = "insert into BlogList (url, maxThreads, keys, rating,blogId) values(?,?,?,?,?)";
                }

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("maxThreads", OleDbType.VarChar);
                cmd.Parameters.Add("keys", OleDbType.VarChar);
                cmd.Parameters.Add("rating", OleDbType.VarChar);
                cmd.Parameters.Add("blogId", OleDbType.VarChar);

                cmd.Parameters[0].Value = MessageUrl(link.Url);
                cmd.Parameters[1].Value = page.Url;
                cmd.Parameters[2].Value = "High";
                cmd.Parameters[3].Value = page.BlogId + ",Exbi";
                cmd.Parameters[4].Value = "New";

            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

        }

        private bool RecordExists(string blogId)
        {
            OleDbConnection cn = new OleDbConnection();
            
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            try
            {
                cmd.CommandText = "select count(*) from bloglist where blogId=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("BlogId", OleDbType.VarChar);
                cmd.Parameters[0].Value = blogId;

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
