﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OliverBlogCruz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OBCMain mainForm = new OBCMain();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException); 
            Application.Run(mainForm);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
                // Do nothing
        }
    }
}
