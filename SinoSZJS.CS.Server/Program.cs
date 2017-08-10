using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using SinoSZServerBase;
using System.ServiceModel;
using SinoSZJS.WCF.Lib;
using SinoSZJS.Base.SystemLog;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.UserLog;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.Server
{
    static class Program
    {
        static void LogUnhandledException(object exceptionobj)
        {              //Log the exception here or report it to developer          }  
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("抱歉，您的操作没有能够完成，请再试一次或者联系软件提供商");
            LogUnhandledException(e.ExceptionObject);
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("抱歉，您的操作没有能够完成，请再试一次或者联系软件提供商");
            LogUnhandledException(e.Exception);
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //	初始化服务器端配置        
            //建立系统日志和用户日志的写入器

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Dictionary<string, ServiceHost> hostLib = new Dictionary<string, ServiceHost>();
            hostLib.Add("AuthorizeService", new ServiceHost(typeof(AuthorizeService)));
            hostLib.Add("CommonService", new ServiceHost(typeof(CommonService)));
            hostLib.Add("MetaDataService", new ServiceHost(typeof(MetaDataService)));
            hostLib.Add("UserManagerService", new ServiceHost(typeof(UserManagerService)));
            hostLib.Add("MetaDataQueryService", new ServiceHost(typeof(MetaDataQueryService)));
            hostLib.Add("ReportService", new ServiceHost(typeof(ReportService)));
            if (ConfigFile.WindowsService)
            {
                //启动服务
                LogWriter.WriteSystemLog("开始启动服务！", "Info");
                System.ServiceProcess.ServiceBase.Run(new SinoSZMainService(hostLib));
                LogWriter.WriteSystemLog("服务结束！", "Info");
            }
            else
            {//启动程序
                LogWriter.WriteSystemLog("启动程序完成！", "Info");
                Application.Run(new frmMain("系统服务程序监控端", hostLib));
                LogWriter.WriteSystemLog("程序结束！", "Info");
            }

        }
    }
}
