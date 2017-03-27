using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;

namespace SinoSystemWatch.Base.PluginFramework
{
    public class TaskBase
    {
        protected DateTime _startTime = DateTime.Now;
        protected int _TimeStep = 10;
        public TaskBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 任务执行过程
        /// </summary>
        public virtual List<CheckInfoResult> ThreadProc()
        {
            return new List<CheckInfoResult>();
        }

        /// <summary>
        /// 写任务开始状态
        /// </summary>
        public virtual void WriteRWState()
        {

        }

        public virtual DateTime GetNextTime()
        {
            DateTime _nextTime = _startTime.AddMinutes(_TimeStep);
            return _nextTime;
        }
        /// <summary>
        /// 写任务结果
        /// </summary>
        public virtual void WriteResult()
        {

        }

        /// <summary>
        /// 写任务出错结果
        /// </summary>
        /// <param name="_errorMsg"></param>
        public virtual void WriteErrorResult(string _errorMsg)
        {

        }

        /// <summary>
        /// 写任务日志
        /// </summary>
        /// <param name="state">状态, 0:成功   1:警告  9:失败</param>
        /// <param name="_msg">消息</param>
        public virtual void WriteTaskLog(int state, string _msg)
        {

        }
    }
}
