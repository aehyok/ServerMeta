using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ServerPlugin;
using System.ComponentModel.Design;
using System.Reflection;
using SinoSZJS.Base.Misc;
using System.IO;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using System.ServiceModel;

namespace SinoSZServerBase
{
    public partial class frmMain : Form, IServerApplication
    {
        private ServerPluginService serverPluginService;
        private ServiceContainer serviceContainer = new ServiceContainer();

        private string _showType = "SYSTEM";
        private Dictionary<string, ServiceHost> WcfHostLib = null;


        public frmMain()
        {
            InitializeComponent();
            InitForm();
        }


        public frmMain(string _serverTitle, Dictionary<string, ServiceHost> hostLib)
        {
            InitializeComponent();
            this.Text = _serverTitle;
            WcfHostLib = hostLib;
            InitForm();
        }


        private void InitForm()
        {
            serverPluginService = new ServerPluginService(this);
            serviceContainer.AddService(typeof(IServerPluginService), serverPluginService);

        }


        #region IServerApplication Members

        public bool WriteUserLog(object UserObj, string _log)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("[");
            _sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _sb.Append("] ");
            _sb.Append(_log);

            if (this._showType == "USER")
            {
                this.textBox1.AppendText(_sb.ToString());
                this.textBox1.AppendText("\r\n");
            }
            //WriteToUserLog(_sb.ToString());
            return true;
        }



        public bool WriteMessage(string _message)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("[");
            _sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _sb.Append("] ");
            _sb.Append(_message);

            if (this._showType == "SYSTEM")
            {
                this.textBox1.AppendText(_sb.ToString());
                this.textBox1.AppendText("\r\n");
            }
            SystemLogWriter.WriteLog(_sb.ToString(), EventLogEntryType.Information);
            return true;
        }



        public bool AddRemotingService(string _serviceName, IServerPlugin _plugin)
        {
            //ServiceLib.AddService(_serviceName, _plugin);
            //WriteMessage(string.Format("{0}的服务接口注册成功!", _serviceName));
            return true;
        }

        public bool AddTask(string _plugInName, ITaskPlugin _taskPlugin)
        {
            TaskLib.AddTask(_plugInName, _taskPlugin);
            WriteMessage(string.Format("[ {0} ]的任务注册成功!", _taskPlugin.Description));
            return true;
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            Assembly SysAssembly = Assembly.GetEntryAssembly();
            AssemblyName SysAssemblyName = SysAssembly.GetName();
            this.toolStripStatusLabel1.Text = string.Format("版本号:{0}", SysAssemblyName.Version.ToString());
            ServerCommon.Init(this as IServerApplication, false);

            //启动所有的WCF服务
            serverPluginService.LoadAllPlugin();
            serverPluginService.LoadAllWCFService(this.WcfHostLib);


        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteMessage("服务程序中止运行!");
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            if (this._showType != "SYSTEM")
            {
                this.textBox1.Clear();
                //if (File.Exists(SystemLogFileName))
                //{
                //        try
                //        {
                //                reader = new StreamReader(SystemLogFileName);
                //                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                //                {
                //                        this.textBox1.AppendText(line);
                //                        this.textBox1.AppendText("\r\n");
                //                };
                //        }
                //        catch (IOException exp)
                //        {
                //                Console.WriteLine(exp.Message);
                //        }
                //        finally
                //        {
                //                if (reader != null)
                //                        reader.Close();
                //        }
                //}
                this._showType = "SYSTEM";
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            if (this._showType != "USER")
            {
                this.textBox1.Clear();
                //if (File.Exists(UserLogFileName))
                //{
                //        try
                //        {
                //                reader = new StreamReader(UserLogFileName);
                //                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                //                {
                //                        this.textBox1.AppendText(line);
                //                        this.textBox1.AppendText("\r\n");
                //                };
                //        }
                //        catch (IOException exp)
                //        {
                //                Console.WriteLine(exp.Message);
                //        }
                //        finally
                //        {
                //                if (reader != null)
                //                        reader.Close();
                //        }
                //}
                this._showType = "USER";

            }
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}