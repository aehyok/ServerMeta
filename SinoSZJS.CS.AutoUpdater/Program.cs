using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace SinoSZJS.CS.AutoUpdater
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            frmWait _f = new frmWait();
            _f.Show();
            Application.DoEvents();
            AutoUpdateStarter aus = new AutoUpdateStarter(_f);
        }
    }
}
