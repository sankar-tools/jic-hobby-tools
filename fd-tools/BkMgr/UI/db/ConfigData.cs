using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fd.lib.ui.common.db
{
    public static class ConfigData
    {
        public static string ConnectionString { get; set; }

        static ConfigData()
        {
            LoadConfigData();
        }

        public static void LoadConfigData()
        {
            // Load database connection string form Db.config
            System.IO.StreamReader file = new System.IO.StreamReader("Db.config");
            ConnectionString = file.ReadLine();
            file.Close();

            //ToDo:: Load other config parameter from config store (may be DB)

        }

        public static void SaveConfigData()
        {
            //ToDo:: Save other config parameter from config store (may be DB)
            //  to be called from Config form
        }

    }
}
