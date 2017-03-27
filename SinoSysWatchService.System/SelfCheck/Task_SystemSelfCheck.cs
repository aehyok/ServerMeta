using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSysWatchService.System.HardDiskSpace;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSysWatchService.System.WinService;

namespace SinoSysWatchService.System.SelfCheck
{
    public class Task_SystemSelfCheck : TaskBase
    {
        public override List<CheckInfoResult> ThreadProc()
        {
            List<CheckInfoResult> _result = new List<CheckInfoResult>();

            //硬盘空间检测
            HardDiskSpaceCheck _hdc = new HardDiskSpaceCheck();
            string res_hds = "";
            int chk_hds = _hdc.Check(ref res_hds);
            _result.Add(new CheckInfoResult("HardDiskSpaceCheck", res_hds, chk_hds));

            //服务检测
            WinServiceCheck _wsc = new WinServiceCheck();
            string res_wsc = "";
            int chk_wsc = _wsc.Check(ref res_wsc);
            _result.Add(new CheckInfoResult("WinServiceCheck", res_wsc, chk_wsc));

            return _result;
        }

        public override DateTime GetNextTime()
        {
            DateTime _nextTime = _startTime.AddMinutes(5);
            return _nextTime;
        }
    }

   
}
