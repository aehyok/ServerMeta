using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using SinoSystemWatch.Base.PluginFramework;
using System.Timers;
using SinoSystemWatch.Base.Task;
using System.ComponentModel;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSZJS.Base.Authorize;
using System.Diagnostics;

namespace SinoSysWatchService
{
    public class ServerCommon
    {
        public bool IsWinSvc; //	是作为Windows Service启动还是作为调试的WinForm程序启动(true为Windows Service)
        public IServerApplication application;
        private System.Timers.Timer TaskTimer = new System.Timers.Timer();

        public void Init(IServerApplication app, bool isWinSvc)
        {
            // 发出开始启动服务提示音           
            application = app;
            IsWinSvc = isWinSvc;
            application.WriteMessage("服务开始启动!", EventLogEntryType.Information);
            SessionClass.CurrentSinoUser = new SinoUser();
            SessionClass.CurrentSinoUser.CurrentPost = new SinoPost();
            SessionClass.CurrentSinoUser.CurrentPost.PostID = "0";
            WatchNodeCache.Init();


            // 启动任务服务
            application.WriteMessage("初始化任务服务!", EventLogEntryType.Information);
            InitTask();
            application.WriteMessage("任务服务初始化完成!", EventLogEntryType.Information);
        }

        /// <summary>
        /// 初始化任务服务
        /// </summary>
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
            //作者：林添喜 2006-01-25  说明：任务调用           
            foreach (TaskListItem _item in TaskList.Tasks.Values)
            {               
                if (_item.State == 0 && _item.NextStartTime < DateTime.Now)
                {
                    //启动任务
                    RunTask(_item);
                }
            }

        }


        //启动任务
        private void RunTask(TaskListItem _item)
        {
            //先设置任务为1;
            _item.State = 1;

            try
            {
                BackgroundWorker _worker = new BackgroundWorker();
                _worker.WorkerReportsProgress = true;
                _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
                _worker.ProgressChanged += new ProgressChangedEventHandler(_worker_ProgressChanged);
                _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
                _worker.RunWorkerAsync(_item);
            }
            catch (Exception ex)
            {
                application.WriteMessage(string.Format("启动任务[{0}]失败！{1}", _item.TaskName, ex.Message), EventLogEntryType.Error);
            }


        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is TaskRunResult)
                {
                    TaskRunResult _result = e.Result as TaskRunResult;
                    TaskListItem _task = TaskList.Tasks[_result.TaskName];
                    _task.TaskRunResult = _result;
                    _task.LastResult = 0;
                    _task.LastFinishedTime = DateTime.Now;
                    _task.State = 0;
                    application.WriteMessage(string.Format("任务[{0}]执行完毕！{1}", _task.TaskName, _result.ResultMsg), EventLogEntryType.Information);
                }
                else if (e.Result is string)
                {
                    string _ex = e.Result as string;
                    application.WriteMessage("任务执行失败！" + _ex, EventLogEntryType.Error);
                }
                else
                {
                    application.WriteMessage("任务执行失败！返回信息为null!", EventLogEntryType.Error);
                }
            }
            catch (Exception ex)
            {
                application.WriteMessage("未知错误！", EventLogEntryType.Error);
            }
        }

        void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                string _msg = e.UserState as string;
                application.WriteMessage(_msg, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                application.WriteMessage(ex.Message, EventLogEntryType.Error);
            }
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker _w = sender as BackgroundWorker;
            TaskListItem _item = e.Argument as TaskListItem;
            TaskBase _task = _item.TaskPlugin.GetTaskObject() as TaskBase;
            try
            {
                
                _w.ReportProgress(1, string.Format("开始执行[{0}]任务！", _item.TaskName));

                List<CheckInfoResult> _result = _task.ThreadProc();

                TaskRunResult _ret = CreateTaskResult(_result);
                _ret.TaskName = _item.TaskName;
                _item.NextStartTime = _task.GetNextTime();
                e.Result = _ret;
            }
            catch (Exception ex)
            {
                _item.NextStartTime = _task.GetNextTime();
                e.Result = "ERROR:" + ex.Message;
            }

        }

        private TaskRunResult CreateTaskResult(List<CheckInfoResult> _result)
        {
            TaskRunResult _ret = new TaskRunResult();
            _ret.StateFlag = 0; //暂设为未知
            foreach (CheckInfoResult _ci in _result)
            {
                _ret.StateFlag = Math.Max(_ret.StateFlag, _ci.StateFlag);
            }

            var jser = new JavaScriptSerializer();
            //序列化
            _ret.ResultMsg = jser.Serialize(_result);

            return _ret;
        }
    }
}
