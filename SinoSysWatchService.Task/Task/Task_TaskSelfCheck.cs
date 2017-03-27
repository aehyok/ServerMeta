using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.WatchNode;

namespace SinoSysWatchService.Task.Task
{
    public class Task_TaskSelfCheck : TaskBase
    {
        public override List<CheckInfoResult> ThreadProc()
        {
            List<CheckInfoResult> _result = new List<CheckInfoResult>();

            SystemTaskCheck _stc = new SystemTaskCheck();
            string chk_stc = "";
            int res_stc = _stc.Check(ref chk_stc);
            _result.Add(new CheckInfoResult("SystemTaskCheck", chk_stc, res_stc));
            
            return _result;

        }
    }
}
