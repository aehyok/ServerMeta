using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZJS.Base.Misc;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.SystemLog;
using SinoSZJS.Base.UserLog;
using System.Data;
using System.Timers;
using System.Diagnostics;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;
using System.ServiceProcess;
using System.Threading;

namespace SinoSZServerBase
{
    public class ServerCommon
    {
        public static bool IsWinSvc; //	是作为Windows Service启动还是作为调试的WinForm程序启动(true为Windows Service)
        public static IServerApplication application;
        private static System.Timers.Timer TaskTimer = new System.Timers.Timer();
        private static bool WriteTaskInfo = false;
        public static void Init(IServerApplication app, bool isWinSvc)
        {
            // 发出开始启动服务提示音
            ServerCommon.SvcBeep(SvcAction.Starting);
            application = app;
            IsWinSvc = isWinSvc;
            WriteTaskInfo = ConfigFile.WriteTaskStartInfo;
            //加载ZHTJ_CSB中的参数

            #region 查看ORACLE服务是否已经成功运行

            int TestTimes = 10;
            int SleepTime = 60000;
#if DEBUG
            SleepTime = 100;
#endif
            while (!OracleHelper.IsReady() && TestTimes-- > 0)
            {
                Thread.Sleep(SleepTime);
            }
            if (TestTimes < 1)
            {
                EventLogSystemLog _event = new EventLogSystemLog("SinoSZJSLog");
                string _log = "因数据库无法连接，启动服务失败！";
                _event.WriteLog(_log, EventLogEntryType.Error);
                throw new Exception();
            }
            #endregion

            ConfigFile.Client_ShowPendingAlert = LoadDB_CSB_Bool("Client_ShowPendingAlert");



            //建立系统日志和用户日志的写入器
            SystemLogWriter.ICS_SystemLog = new OraSysLogWriter();
            UserLogWriter.ICS_UserLog = new OraUserLogWriter();

            application.WriteMessage("服务开始启动!");

            //清除验证票据缓存
            TicketLib.Clear();
            // 加载代码表Cache
            application.WriteMessage("开始加载代码表缓存!");
            InitRefCodeCache();
            application.WriteMessage("代码表缓存加载完毕!");


            // 加载授权信息Cache
            application.WriteMessage("开始加载授权信息缓存!");
            InitPermissionCache();
            application.WriteMessage("授权信息缓存加载完毕!");

            // 初始化Remoting服务
            application.WriteMessage("初始化Remoting服务!");
            //RemotingServerSvc.Init();
            application.WriteMessage("Remoting服务初始化完毕!");

            application.WriteMessage("注册Remoting服务工厂!");
            //RemotingServerSvc.RegisterService(typeof(IServiceFactory), typeof(BizServiceFactory));
            application.WriteMessage("Remoting服务工厂注册完毕!");




            // 启动任务服务
            application.WriteMessage("初始化任务服务!");
            InitTask();
            application.WriteMessage("任务服务初始化完成!");

            // 发出启动成功提示音
            ServerCommon.SvcBeep(SvcAction.Started);



        }
        private const string SQL_GetCSB = @"select CSDATA from zhtj_csb where CSNAME=:CSNAME";
        private static bool LoadDB_CSB_Bool(string pName)
        {
            string _res = LoadDB_CSB_String(pName);
            _res = _res.ToUpper().Trim();
            if (_res == "Y" || _res == "YES" || _res == "T" || _res == "TRUE")
            {
                return true;
            }
            else return false;
        }

        private static string LoadDB_CSB_String(string pName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetCSB, cn);
                _cmd.Parameters.Add(":CSNAME", pName);
                object _ret = _cmd.ExecuteScalar();
                if (_ret == null) return "";
                return _ret.ToString();
            }
        }

        /// <summary>
        /// 初始化任务服务
        /// </summary>
        private static void InitTask()
        {
            //添加测试任务插件
            Task_Test_Plugin _testPlugin = new Task_Test_Plugin();
            application.AddTask(_testPlugin.Name, _testPlugin as ITaskPlugin);

            //作者：林添喜 2006-02-03  说明：初始化任务
            //将所有未处理完的任务设置为错误
            SQL_TaskCommon.InitAllTaskState();

            //初始化时钟
            if (ConfigFile.RunTask)
            {
                ServerCommon.TaskTimer.Interval = 1000 * 60;
                ServerCommon.TaskTimer.Elapsed += new System.Timers.ElapsedEventHandler(TaskTimer_Elapsed);
                ServerCommon.TaskTimer.Enabled = true;
                application.WriteMessage("任务运行机制启动完毕！");
            }
            else
            {
                application.WriteMessage("未设置RUNTASK参数为YES! 不启动任务运行机制！");
            }
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TaskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //作者：林添喜 2006-01-25  说明：任务调用
            string _log2 = string.Format("任务调用开始！");
            if (WriteTaskInfo)
            {
                OralceLogWriter.WriteSystemLog(_log2, "INFO");
            }

            //获取任务列表
            DataTable _rwdata = SQL_TaskCommon.GetTaskList();
            if (_rwdata != null)
            {
                foreach (DataRow _dr in _rwdata.Rows)
                {
                    try
                    {
                        string _rwid = _dr["RWID"].ToString();
                        string _lb = _dr["RZLB"].ToString();
                        string _ml = _dr["RWML"].ToString();
                        TaskController.RunTask(_rwid, _lb, _ml);
                    }
                    catch (Exception ex)
                    {
                        string _log = string.Format("任务调用时出现错误：{0}", ex.Message);
                        OralceLogWriter.WriteSystemLog(_log, "ERROR");
                    }
                }
            }


        }

        /// <summary>
        /// 授权缓存
        /// </summary>
        private static void InitPermissionCache()
        {
            //暂未实现
        }

        /// <summary>
        ///　代码表缓存
        /// </summary>
        private static void InitRefCodeCache()
        {
            //暂未实现
        }

        //	为Service发出声音
        public static void SvcBeep(SvcAction action)
        {
            if (!ConfigFile.BeepOnSvcAction)
                return;
            switch (action)
            {
                case SvcAction.Starting:
                    Win32API.Beep(4000, 200);
                    break; //	Service开始启动
                case SvcAction.Started:
                    Win32API.Beep(1000, 400);
                    Win32API.Beep(4000, 400);
                    break; //	Service启动完毕
                case SvcAction.Stopping:
                    Win32API.Beep(1000, 200);
                    break; //	Service开始停止
                case SvcAction.Stopped:
                    Win32API.Beep(4000, 200);
                    break; //	Service停止完毕
            }
        }
    }

    public enum SvcAction
    {
        Starting,
        Started,
        Stopping,
        Stopped,
    }

}
