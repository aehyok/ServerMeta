using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.Application;

namespace SinoSysWatchService.Application.bapt
{
    public class BAPTSystemCheck : ICheckProject
    {
        public int Check(ref string json)
        {
            //    List<ApplicationStatus> DBCinfo = GetDBConnectionInfo();
            //    int _ret = CheckError(DBCinfo);
            //    var jser = new JavaScriptSerializer();
            //    //序列化
            //    json = jser.Serialize(DBCinfo);

            //    return _ret;
            return 0;
        }
    }
}
