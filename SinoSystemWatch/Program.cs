using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SinoSystemWatch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SessionCache.CurrentTokenString = "";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm _f = new LoginForm();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}