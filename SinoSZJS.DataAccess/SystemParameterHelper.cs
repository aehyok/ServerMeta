using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SinoSZJS.DataAccess
{
    public class SystemParameterHelper
    {
        private const string SQL_GetZHTJ_CSB = @"select t.csdata from  ZHTJ_CSB t where t.csname=:CSNAME";
        public static string GetSystemParms(string _CSNAME)
        {
            string str = "";
            try
            {
                OracleParameter[] _param = { 
                                               new OracleParameter(":CSNAME",OracleDbType.Varchar2)
                                               };
                _param[0].Value = _CSNAME;
                OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, System.Data.CommandType.Text, SQL_GetZHTJ_CSB, _param);
                while (dr.Read())
                {
                    str = dr.IsDBNull(0) ? "" : dr.GetString(0).ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                OralceLogWriter.WriteSystemLog(string.Format("从zhtj_csb中取参数{0}时出错：{1}", _CSNAME, ex.Message), "ERROR");
                str = "";
            }
            return str;
        }
    }
}
