using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;
using SysWatchServiceLib;
using SinoSystemWatch.Base.WatchNode;
using SinoSZJS.Base.SystemLog;
using SinoSZJS.Base.Misc;
using System.Diagnostics;

namespace SinoSysWatchService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //清理主状态缓冲区
            WatchNodeCache.Init();
            try
            {
                //启动WCF服务
                ServiceHost WcfHost = new ServiceHost(typeof(SWCommandService));
                WcfHost.Open();
            
                if (args.Length == 0)
                {
#if DEBUG                    
                    Application.Run(new frmServiceMain());
#else

                    System.ServiceProcess.ServiceBase[] ServicesToRun;
                    ServicesToRun = new System.ServiceProcess.ServiceBase[] { new SysWatchService() };
                    System.ServiceProcess.ServiceBase.Run(ServicesToRun);
#endif

                }
                else if (args[0].ToLower() == "/f" || args[0].ToLower() == "-f")
                {
                    Application.Run(new frmServiceMain());
                }

            }
            catch (Exception ex)
            {
                EventLogSystemLog _log = new EventLogSystemLog("SinoSysWatchServiceLog");
                _log.WriteLog(ex.Message, EventLogEntryType.Error);
            }       
        }
    }
}