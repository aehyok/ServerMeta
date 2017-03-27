using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;

namespace ZHXTWebServiceV3.DAL
{
    public class AJDataCommon
    {
        private const string SQL_CheckUser = @"select count(*) from jsods.sjjh_yhb where YHM=:YHM and KL=:KL ";
        public static decimal CheckUser(string UserName, string Password)
        {
            decimal _FindRes = 0;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_CheckUser, cn);
                _cmd.Parameters.Add(":YHM", UserName);
                _cmd.Parameters.Add(":KL", Password);

                _FindRes = (decimal)_cmd.ExecuteScalar();
            }
            return _FindRes;

        }

        private const string SQL_GetUserID = @"select a.yhid from jsods.sjjh_yhb a where a.yhm = :YHM and a.kl = :KL";
        public static decimal GetUserID(string UserName, string Password)
        {
            decimal _FindRes = 0;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetUserID, cn);
                _cmd.Parameters.Add(":YHM", UserName);
                _cmd.Parameters.Add(":KL", Password);

                _FindRes = (decimal)_cmd.ExecuteScalar();
            }
            return _FindRes;
            
        }
    }
}