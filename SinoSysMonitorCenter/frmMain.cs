using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ServiceModel;
using SinoSystemWatch.Base.WCF;
using SinoSystemWatch.Base.Define;
using SinoSystemWatch.Base.PluginFramework;
using System.Diagnostics;

namespace SinoSysMonitorCenter
{
    public partial class frmMain : Form, IServerApplication
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //显示版本号
            Assembly SysAssembly = Assembly.GetEntryAssembly();
            AssemblyName SysAssemblyName = SysAssembly.GetName();
            this.label1.Text = string.Format("版本号：{0}", SysAssemblyName.Version.ToString());

            foreach (SystemStateItem _el in WatchSystemLib.SystemLib.Values)
            {
                safeSetText(string.Format("已加载[{0}:{2}]的配置：{1}\r\n", _el.SystemName, _el.SystemURL, _el.SystemDescription));
            }

            ServerCommon _sc = new ServerCommon();
            _sc.Init(this);
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


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (SystemStateItem _item in WatchSystemLib.SystemLib.Values)
            {
                safeSetText(string.Format("[{0}:{1}]的连接状态为:{2}\r\n", _item.SystemName, _item.SystemDescription, _item.Connected));
            }
        }

        #region 实现接口
        bool IServerApplication.WriteMessage(string _message,EventLogEntryType LogType)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(_message);
            _sb.Append("\r\n");

            safeSetText(_sb.ToString());
            return true;
        }

        public bool AddTask(string _taskName, ITaskPlugin _taskPlugin)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTask(string _taskName)
        {
            throw new NotImplementedException();
        }

        public bool AddCommandExecuter(string _commandName, ICommandPlugin _commandPlugin)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            throw new NotImplementedException();
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            throw new NotImplementedException();
        }

        public void RemoveService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public new object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
        #endregion



       
    }
}
