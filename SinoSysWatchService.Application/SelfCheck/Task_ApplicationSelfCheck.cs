using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.WatchNode;
using SinoSysWatchService.Application.bapt;
using SinoSysWatchService.Application.IISLog;
using SinoSysWatchService.Application.SystemLog;

namespace SinoSysWatchService.Application.SelfCheck
{
    public class Task_ApplicationSelfCheck : TaskBase
    {
        public override List<CheckInfoResult> ThreadProc()
        {
            List<CheckInfoResult> _result = new List<CheckInfoResult>();

            #region 办案平台、分平台检测
            //检测WCF服务连接           
            WCFServiceCheck _dbc = new WCFServiceCheck();
            string chk_wcf = "";
            int res_wcf = _dbc.Check(ref chk_wcf);
            _result.Add(new CheckInfoResult("WCFStatusCheck", chk_wcf, res_wcf));

            //检测Web应用访问(通过IIS日志）
            IISLogCheck _iisc = new IISLogCheck();
            string chk_iis = "";
            int res_iis = _iisc.Check(ref chk_iis);
            _result.Add(new CheckInfoResult("IISLogCheck", chk_iis, res_iis));

            //检测应用目录授权

            //检测自动更新目录

            //检测应用日志 系统操作、接口日志
            SystemLogCheck _slc = new SystemLogCheck();
            string chk_slc = "";
            int res_slc = _slc.Check(ref chk_slc);
            _result.Add(new CheckInfoResult("SystemLogCheck", chk_slc, res_slc));

            UserLogCheck _ulc = new UserLogCheck();
            string chk_ulc = "";
            int res_ulc = _ulc.Check(ref chk_ulc);
            _result.Add(new CheckInfoResult("UserLogCheck", chk_ulc, res_ulc));

            QueryLogCheck _qlc = new QueryLogCheck();
            string chk_qlc = "";
            int res_qlc = _qlc.Check(ref chk_qlc);
            _result.Add(new CheckInfoResult("QueryLogCheck", chk_qlc, res_qlc));

            #endregion


            return _result;

        }
    }
}