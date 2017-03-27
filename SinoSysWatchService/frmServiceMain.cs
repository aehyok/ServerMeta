using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.PluginFramework;
using System.ComponentModel.Design;
using System.Reflection;
using SinoSystemWatch.Base.Task;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;

namespace SinoSysWatchService
{
    public partial class frmServiceMain : Form, IServerApplication
    {
        private ServerPluginService serverPluginService;
        private ServiceContainer serviceContainer = new ServiceContainer();

        public frmServiceMain()
        {
            InitializeComponent();
        }

        private void safeSetText(string msg)
        {
            if (this.InvokeRequired)
            {
                _SafeSetTextCall call = delegate(string s)
                {
                    this.textBox1.AppendText(s);
                };

                this.Invoke(call, msg);
            }
            else
                this.textBox1.AppendText(msg);
        }

        private delegate void _SafeSetTextCall(string text);

        #region 实现IServerApplication接口

        public bool WriteMessage(string _message, EventLogEntryType LogType)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(string.Format("[{0}]", DateTime.Now.ToString("yyyyMMdd HH:mm:ss")));
            _sb.Append(_message);
            _sb.Append("\r\n");
            safeSetText(_sb.ToString());
            return true;
        }

        public bool AddTask(string _taskName, ITaskPlugin _taskPlugin)
        {
            TaskList.AddByTaskplugin(_taskPlugin);
            WriteMessage(string.Format("任务[{0}]加载成功！", _taskName), EventLogEntryType.Information);
            return true;
        }

        public bool RemoveTask(string _taskName)
        {
            TaskList.RemoveTask(_taskName);
            WriteMessage(string.Format("任务[{0}]卸载成功！", _taskName), EventLogEntryType.Information);
            return true;
        }

        public bool AddCommandExecuter(string _commandName, ICommandPlugin _commandPlugin)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region IServiceContainer Members

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
        {
            serviceContainer.AddService(serviceType, callback, promote);
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback)
        {
            serviceContainer.AddService(serviceType, callback);
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            serviceContainer.AddService(serviceType, serviceInstance, promote);
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            serviceContainer.AddService(serviceType, serviceInstance);
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            serviceContainer.RemoveService(serviceType, promote);
        }

        public void RemoveService(Type serviceType)
        {
            serviceContainer.RemoveService(serviceType);
        }

        public new object GetService(Type serviceType)
        {
            return serviceContainer.GetService(serviceType);
        }

        #endregion

        private void frmServiceMain_Load(object sender, EventArgs e)
        {
            EventLogSystemLog _log = new EventLogSystemLog("SinoSysWatchServiceLog");
            _log.WriteLog("缉私系统运行监控维护服务开始启动（程序方式)!", EventLogEntryType.Information);

            serverPluginService = new ServerPluginService(this);
            serviceContainer.AddService(typeof(IServerPluginService), serverPluginService);

            Assembly SysAssembly = Assembly.GetEntryAssembly();
            AssemblyName SysAssemblyName = SysAssembly.GetName();
            this.label1.Text = string.Format("版本号:{0}", SysAssemblyName.Version.ToString());

            //启动所有的WCF服务
            serverPluginService.LoadAllPlugin();
            serverPluginService.LoadPluginDescript();
            ServerCommon _sc = new ServerCommon();
            _sc.Init(this as IServerApplication, false);
        }

    }
}
