using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace DataModel
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

        public static void SaveLinks(List<Entities.PageInfo> pages)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                cn.ConnectionString = DBController.DatabaseConnectionString;
                cn.Open();

                cmd.Connection = cn;

                cmd.CommandText = "insert into GrabList (url, referrer, priority, category) values(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("url", OleDbType.VarChar);
                cmd.Parameters.Add("referrer", OleDbType.VarChar);
                cmd.Parameters.Add("Priority", OleDbType.VarChar);
                cmd.Parameters.Add("Category", OleDbType.VarChar);

                foreach (Entities.PageInfo page in pages)
                {
                    foreach (Entities.LinkInfo link in page.imageUrl)
                    {
                        cmd.Parameters[0].Value = link.Url;
                        cmd.Parameters[1].Value = page.Url;
                        cmd.Parameters[2].Value = "High";
                        cmd.Parameters[3].Value = "Exbi";

                        cmd.ExecuteNonQuery();
                    }
                }
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
