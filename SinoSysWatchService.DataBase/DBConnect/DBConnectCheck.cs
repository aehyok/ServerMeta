using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.DataBaseCheck;
using System.Web.Script.Serialization;
using System.Configuration;
using Oracle.DataAccess.Client;

namespace SinoSysWatchService.DataBase.DBConnect
{
    public class DBConnectCheck : ICheckProject
    {
        public int Check(ref string json)
        {
            List<DBConnectStatus> DBCinfo = GetDBConnectionInfo();
            int _ret = CheckError(DBCinfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(DBCinfo);

            //反序列化
            //EntryHeadExtend = jser.Deserialize<ICS_ENTRY_HEAD_EXTEND>(json);

            //判断处于错误状态还是警告状态

            return _ret;
        }

        private int CheckError(List<DBConnectStatus> DBCinfo)
        {
            int _ret = 0;
            foreach (DBConnectStatus _st in DBCinfo)
            {
                _ret = Math.Max(_ret, _st.ConnectResult);
            }
            return _ret;
        }

        private List<DBConnectStatus> GetDBConnectionInfo()
        {
            List<DBConnectStatus> _ret = new List<DBConnectStatus>();
            foreach (ConnectionStringSettings _cstr in ConfigurationManager.ConnectionStrings)
            {
                if (_cstr.ProviderName == "System.Data.OracleClient")
                {
                    DBConnectStatus _st = new DBConnectStatus();
                    _st.ConnectionName = _cstr.Name;
                    CheckConnect(_st, _cstr.ConnectionString);
                    _ret.Add(_st);
                }
            }
            return _ret;
        }

        private void CheckConnect(DBConnectStatus _st, string connString)
        {
            int _result = 0;
            using (OracleConnection cn = new OracleConnection(connString))
            {
                try
                {
                    cn.Open();
                    cn.Close();
                    _result = 1;
                    _st.ResultMessage = "";
                }
                catch (Exception ex)
                {
                    _result = 3;
                    _st.ResultMessage = ex.Message;
                }
            }
            _st.ConnectResult = _result;
        }

    }
}
