using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZServerBase
{
    public class Task_Base
    {
        protected string _Rwid = "";
        protected DateTime _startTime = DateTime.Now;
        protected int _TimeStep = 60;
        public Task_Base()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Task_Base(string _id)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _Rwid = _id;
        }

        /// <summary>
        /// 任务执行过程
        /// </summary>
        public virtual void ThreadProc()
        {

        }

        /// <summary>
        /// 写任务开始状态
        /// </summary>
        public virtual void WriteRWState()
        {
            _startTime = DateTime.Now;
            SQL_TaskCommon.WriteRWState(_Rwid);
            WriteTaskLog(0, string.Format("任务[{0}]开始执行!", this._Rwid));
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
            DateTime _nextTime = GetNextTime();
            SQL_TaskCommon.WriteResult(_Rwid, _startTime, _nextTime);
        }

        /// <summary>
        /// 写任务出错结果
        /// </summary>
        /// <param name="_errorMsg"></param>
        public virtual void WriteErrorResult(string _errorMsg)
        {
            DateTime _nextTime = _startTime.AddMinutes(_TimeStep);
            SQL_TaskCommon.WriteErrorResult(_Rwid, _startTime, _nextTime, _errorMsg);
        }

        /// <summary>
        /// 写任务日志
        /// </summary>
        /// <param name="state">状态, 0:成功   1:警告  9:失败</param>
        /// <param name="_msg">消息</param>
        public virtual void WriteTaskLog(int state, string _msg)
        {
            SQL_TaskCommon.WriteTaskLog(this._Rwid, state, _msg);
        }

    }
}
