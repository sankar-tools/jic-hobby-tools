using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using fd.lib.ui.common.error;

namespace fd.lib.ui.common.db
{
    public class DbController
    {
        public static bool CheckDb(string constr)
        {
            OleDbConnection cn = new OleDbConnection();

            try
            {
                cn.ConnectionString = constr;
                cn.Open();
            }
            catch (OleDbException ex)
            {
                ErrorDialog.Show("DB Connection Error", "Error connecting to database", ex);
                return false;
            }
            finally
            {
                cn.Close();               
            }
            return true;
        }
    }
}
