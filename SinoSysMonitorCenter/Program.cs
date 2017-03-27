using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using SinoSystemWatch.Base.Define;
using System.Diagnostics;
using SinoSZJS.Base.SystemLog;


namespace SinoSysMonitorCenter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                SystemConfigSection CurrentSysList = (SystemConfigSection)ConfigurationManager.GetSection("SystemList");
                foreach (SystemConfigurationElement _el in CurrentSysList.PluginCollection)
                {
                    SystemStateItem _item = new SystemStateItem(_el.Name, _el.URL, _el.Description);
                    WatchSystemLib.AddSystem(_item);
                }

                if (args.Length == 0)
                {
#if DEBUG
                    Application.Run(new frmMain());
#else

                    System.ServiceProcess.ServiceBase[] ServicesToRun;
                    ServicesToRun = new System.ServiceProcess.ServiceBase[] { new SinoMonitorCenterService() };
                    System.ServiceProcess.ServiceBase.Run(ServicesToRun);
#endif

                }
                else if (args[0].ToLower() == "/f" || args[0].ToLower() == "-f")
                {
                    Application.Run(new frmMain());
                }

            }
            catch (Exception ex)
            {
                EventLogSystemLog _log = new EventLogSystemLog("SinoMonitorCenterServiceLog");
                _log.WriteLog(ex.Message, EventLogEntryType.Error);
            }
          
        }
    }
}
