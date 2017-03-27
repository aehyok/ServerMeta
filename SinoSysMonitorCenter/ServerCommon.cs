using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using System.Timers;
using System.ComponentModel;
using SinoSystemWatch.Base.WCF;
using SinoSystemWatch.Base.Define;
using System.ServiceModel;
using System.Diagnostics;
using SinoSZJS.DataAccess;


namespace SinoSysMonitorCenter
{
    public class ServerCommon
    {
        public IServerApplication application;
        private System.Timers.Timer TaskTimer = new System.Timers.Timer();
        private System.Timers.Timer LinkDataBaseTimer = new System.Timers.Timer();
        public static bool DataBaseConnection = false;

        public void Init(IServerApplication app)
        {
            // 发出开始启动服务提示音           
            application = app;

            InitConnectTest();
            TryDataBaseConnect();

            ServiceHost WcfHost = new ServiceHost(typeof(SinoMonitorCommand));
            try
            {
                WcfHost.Open();
                application.WriteMessage("WCF服务接口已启动！", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                application.WriteMessage(string.Format("WCF服务接口启动失败！{0}", ex.Message), EventLogEntryType.Error);
            }


            InitTask();
        }

        private void InitConnectTest()
        {
            //初始化时钟
            TaskTimer.Interval = 1000 * 60;
            TaskTimer.Elapsed += new ElapsedEventHandler(DBTaskTimer_Elapsed);           
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBTaskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TryDataBaseConnect();
        }

        private void TryDataBaseConnect()
        {
            LinkDataBaseTimer.Enabled = false;
            BackgroundWorker _dbw = new BackgroundWorker();
            _dbw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_dbw_RunWorkerCompleted);
            _dbw.DoWork += new DoWorkEventHandler(_dbw_DoWork);
            _dbw.RunWorkerAsync();
        }

        void _dbw_DoWork(object sender, DoWorkEventArgs e)
        {
            DataBaseConnection = TryConnectToDataBase();
        }

        void _dbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!DataBaseConnection)
            {
                application.WriteMessage("数据库无法连接！", EventLogEntryType.Information);
                LinkDataBaseTimer.Enabled = true;
            }
        }

      

        private bool TryConnectToDataBase()
        {
            return OracleHelper.IsReady();
        }

        private void InitTask()
        {
            //初始化时钟
            TaskTimer.Interval = 1000 * 60;
            TaskTimer.Elapsed += new System.Timers.ElapsedEventHandler(TaskTimer_Elapsed);
            TaskTimer.Enabled = true;
            application.WriteMessage("任务运行机制启动完毕！", EventLogEntryType.Information);
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //作者：林添喜 说明：任务调用           
            foreach (SystemStateItem _el in WatchSystemLib.SystemLib.Values)
            {
                BackgroundWorker _w = new BackgroundWorker();
                _w.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_w_RunWorkerCompleted);
                _w.DoWork += new DoWorkEventHandler(_w_DoWork);
                _w.RunWorkerAsync(_el);
            }

        }

        void _w_DoWork(object sender, DoWorkEventArgs e)
        {
            SystemStateItem _el = e.Argument as SystemStateItem;
            object[] _plist = new object[3]{
                "OK","GetCurrentState",null};
            try
            {
                object _ret = ExecuteWCF.ExecuteMethod<SysWatchService.ISWCommandService>(_el.SystemURL, "DoCommand", _plist);
                byte[] _byteret = _ret as byte[];
                string _msg = Encoding.Unicode.GetString(_byteret);
                _el.Connected = true;
                _el.ConnectErrorMsg = "";
                _el.NodeState = new WatchNodeState(_msg);
                e.Result = _el;

            }
            catch (Exception ex)
            {
                _el.Connected = false;
                _el.ConnectErrorMsg = ex.Message;
                _el.NodeState = new WatchNodeState("00000");
                e.Result = _el;
            }

        }

        void _w_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SystemStateItem _s = e.Result as SystemStateItem;
            if (application != null)
            {
                application.WriteMessage(string.Format("系统：{0} 的状态：{1}", _s.SystemName, _s.NodeState.ToString()), EventLogEntryType.Information);
            }
        }

    }
}
