using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.WatchNode;
using SinoSysWatchService.DataBase.DBConnect;

namespace SinoSysWatchService.DataBase.SelfCheck
{
    public class Task_DataBaseSelfCheck : TaskBase
    {
        public override List<CheckInfoResult> ThreadProc()
        {
            List<CheckInfoResult> _result = new List<CheckInfoResult>();

            //Oracle数据库连接检测
            DBConnectCheck _dbc = new DBConnectCheck();       
            string chk_dbc="";
            int res_dbc = _dbc.Check(ref chk_dbc);
            _result.Add(new CheckInfoResult("OracleConnectCheck", chk_dbc, res_dbc));

            return _result;
        }
    }
}
