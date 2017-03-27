using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSZJS.Base.SystemLog;

namespace SinoSysWatchService
{
    partial class SysWatchService : ServiceBase
    {
        private ServiceServer CurrentServer;
        public SysWatchService()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            ServiceServer CurrentServer = new ServiceServer();
            CurrentServer.Start();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            if (CurrentServer != null)
            {

            }
            EventLogSystemLog _log = new EventLogSystemLog("SinoSysWatchServiceLog");
            _log.WriteLog("缉私系统运行监控维护服务停止！", EventLogEntryType.Information);
        }
    }
}
