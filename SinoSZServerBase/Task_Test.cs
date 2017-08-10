using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using System.Threading;
using SinoSZJS.Base.Misc;

namespace SinoSZServerBase
{
        public class Task_Test:Task_Base
        {
                public Task_Test(string _id, string _param)
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                        _Rwid = _id;
                        string _stepstr = StrUtils.GetMetaByName("STEP", _param);	//STEP: 任务时间间隔
                        try
                        {
                                this._TimeStep = int.Parse(_stepstr);
                        }
                        catch
                        {
                                this._TimeStep = 1;
                        }
                }

                public override void ThreadProc()
                {
                        WriteRWState(); 
                        string _startTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string _log = string.Format("开始执行测试任务。任务ID：{0} 执行时间：{1}", _Rwid, _startTime);                      
                        //SystemLogWriter.WriteLog(_log,EventLogEntryType.Information);

                        Thread.Sleep(50000);

                        _log = string.Format("完成测试任务执行。任务ID：{0}　完成时间：{1}", _Rwid, DateTime.Now);
                        //SystemLogWriter.WriteLog(_log, EventLogEntryType.Information);

                        WriteResult();
                }
        }
}
