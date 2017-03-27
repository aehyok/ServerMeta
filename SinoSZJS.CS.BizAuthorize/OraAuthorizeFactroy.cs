using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Runtime.Remoting.Messaging;
using System.Net;
using SinoSZJS.Base.Misc;
using Oracle.DataAccess.Client;
using System.Data;
using SinoSZJS.Base.Config;
using SinoSZJS.Base.UserLog;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using SinoSZJS.DataAccess;
using SinoSZJS.CS.BizAuthorize.Cuppa;
using SinoSZJS.CS.BizAuthorize.OraSignOn;
using SinoSZJS.Base.WCF.Service;

namespace SinoSZJS.CS.BizAuthorize
{
    /// <summary>
    /// Oracle 数据库的认证接口实现
    /// </summary>
    public class OraAuthorizeFactroy : IAuthorize
    {
        #region IAuthorize Members

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="_sysid"></param>
        /// <param name="_name"></param>
        /// <param name="_mwpass"></param>
        /// <returns></returns>
        public SinoUser LoginSys(string _sysid, string _name, string _mwpass, string CheckType)
        {
            //暂未实现
            C_SignOnBase _SignOnControler = new C_SignOnBase();
            string _pass = _mwpass;
            string _ipaddr = WCFClientInfo.IPAddr;
            string _hostName = "";
            try
            {
                _hostName = Dns.GetHostEntry(_ipaddr).HostName;
            }
            catch (Exception ex)
            {
                string _err = ex.Message;
                _hostName = _ipaddr;
            }

            SinoUser _su = new SinoUser();
            _su.LoginName = _name;
            _su.UserName = "测试用户";
            _su.DwName = "海关总署缉私局";

            string _yhid = "";
            if (_name.ToLower() != "administrator")
            {
                switch (ConfigFile.LoginType)
                {
                    case "NONE":
                        break;

                    case "TESTPASS":
                        _SignOnControler = new C_SignOnTestPass();
                        break;

                    case "BASE":     //采用综合系统验证功能
                        _SignOnControler = new C_SignOnFromJS();
                        break;

                    case "CUPPAPASSPORT":
                        _SignOnControler = new C_SignOnCUPPAPassport();
                        break;
                    default:
                        _SignOnControler = new C_SignOnFromJS();
                        break;
                }
            }
            else
            {
                _SignOnControler = new C_SignOnAdmin();
            }

            bool _signOn = _SignOnControler.Check(_name, _pass, CheckType);


            if (_signOn)
            {
                //写入用户操作日志               
            }
            else
            {
                //写入用户操作日志
                throw new Exception("用户名/口令不正确!");
            }



            if (_name.ToLower() != "administrator")
            {
                switch (ConfigFile.LoginType)
                {
                    case "CUPPAPASSPORT":
#if DEBUG
                        _yhid = C_GetUserInfo.GetYHIDByName(_name, _pass);
#else
                        _yhid = C_GetUserInfo_Cuppa.GetYHIDByName(_name, CheckType);
#endif
                        break;
                    default:
                        _yhid = C_GetUserInfo.GetYHIDByName(_name, _pass);
                        break;
                }
            }
            else
            {
                _yhid = "0";
            }

            if (_yhid != "-1")
            {
                _su = C_GetUserInfo.GetUserInfoByYHID(_yhid);
            }
            else
            {
                _su = C_GetUserInfo.GetNoRegisterUserByUserName(_name);
            }

            //SystemLogWriter.WriteLog(string.Format("取{0}的用户信息成功！", _name), EventLogEntryType.Information);

            //写入用户操作日志
            //SQLCommon.WriteUserLog(decimal.Parse(_yhid), "系统登录", string.Format("{1}使用用户名{0}登录成功！", _name, _su.UserName), 1, _ipaddr, _hostName);
            //CreateTicket(ref _su, _ipaddr);

            _su.EncryptedTicket = TicketLib.AddTicket(_yhid, _ipaddr);
            //SystemLogWriter.WriteLog(string.Format("生成{0}的验证票据成功！", _name), EventLogEntryType.Information);

            _su.IPAddress = _ipaddr;
            _su.SystemID = ConfigFile.SystemID;
            LogonUserLib.AddUserInfo(_su.UserID, _su);
            //SystemLogWriter.WriteLog(string.Format("添加用户{0}到验证用户列表成功！", _name), EventLogEntryType.Information);

            return _su;
        }

        /// <summary>
        /// 通过缉私系统取用户信息
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static SinoUser GetUserInfoByJSXT(string _name)
        {
            string _yhid;
            if (_name.ToLower() != "administrator")
            {
                _yhid = C_GetUserInfo.GetYHIDByName(_name, "");
            }
            else
            {
                _yhid = "0";
            }

            SinoUser _ret = C_GetUserInfo.GetUserInfoByYHID(_yhid);
            return _ret;
        }

        /// <summary>
        /// 修改口令
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="old_pass"></param>
        /// <param name="new_pass"></param>
        /// <returns></returns>
        public bool ChangePassWord(string uname, string old_pass, string new_pass)
        {
            C_SignOnBase _SignOnControler = new C_SignOnBase();
            if (CheckPassword(uname, old_pass, ""))
            {
                if (uname.ToLower() != "administrator")
                {
                    switch (ConfigFile.LoginType)
                    {
                        case "NONE":
                            break;

                        case "TESTPASS":
                            _SignOnControler = new C_SignOnTestPass();
                            break;

                        case "BASE":     //采用综合系统验证功能
                            _SignOnControler = new C_SignOnFromJS();
                            break;


                        default:
                            _SignOnControler = new C_SignOnFromJS();
                            break;
                    }

                }
                else
                {
                    _SignOnControler = new C_SignOnAdmin();
                }

                return (_SignOnControler.ChangePassword(uname, old_pass, new_pass) == 1);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取指定单位下的组织机构列表
        /// </summary>
        /// <param name="_rootDwid"></param>
        /// <param name="_levelNum"></param>
        /// <returns></returns>
        public List<SinoOrganize> GetRootDwList(string _rootDwid, decimal _levelNum)
        {
            string _sql = "zhtj_zzjg2.get_tree_js_qx";
            OracleParameter[] _param = {
                              new OracleParameter("nParent",OracleDbType.Decimal),
                               new OracleParameter("nLevel",OracleDbType.Decimal),
                               new OracleParameter("curTree",OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)
                           };
            _param[0].Value = decimal.Parse(_rootDwid);
            _param[1].Value = _levelNum;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure, _sql, _param);
            List<SinoOrganize> _ret = new List<SinoOrganize>();

            while (dr.Read())
            {
                SinoOrganize _so = new SinoOrganize(dr.IsDBNull(0) ? 0 : dr.GetDecimal(0),
                        dr.IsDBNull(5) ? 0 : dr.GetDecimal(5),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        "",
                        dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDecimal(7))

                        );
                _ret.Add(_so);
            }

            dr.Close();

            return _ret;
        }


        public decimal GetDWIDByDWDM(string _dwdm)
        {
            string _sql = "select zhtj_zzjg2.GETDWID_hgjs(:DWDM) from dual";
            OracleParameter[] _param = { new OracleParameter("nParent", OracleDbType.Decimal) };
            _param[0].Value = _dwdm;
            object _ret = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            if (_ret == DBNull.Value) return -1;
            return (decimal)_ret;
        }


        public SinoSZJS.Base.Config.ServerConfig GetServerConfig()
        {
            return new ServerConfig();
        }


        /// <summary>
        /// 验证当前口令
        /// </summary>
        /// <param name="_uname"></param>
        /// <param name="old_pass"></param>
        /// <returns></returns>
        public bool CheckPassword(string _uname, string old_pass, string CheckType)
        {
            C_SignOnBase _SignOnControler = new C_SignOnBase();
            string _pass = old_pass;

            if (_uname.ToLower() != "administrator")
            {
                switch (ConfigFile.LoginType)
                {
                    case "NONE":
                        break;

                    case "TESTPASS":
                        _SignOnControler = new C_SignOnTestPass();
                        break;

                    case "BASE":     //采用综合系统验证功能
                        _SignOnControler = new C_SignOnFromJS();
                        break;

                    default:
                        _SignOnControler = new C_SignOnFromJS();
                        break;
                }

            }
            else
            {
                _SignOnControler = new C_SignOnAdmin();
            }

            return _SignOnControler.Check(_uname, old_pass, CheckType);

        }



        public List<SinoOrganize> GetRootDwListEx(string _rootDwid, decimal _levelNum, string _type)
        {
            string _sql = "zhtj_zzjg2.get_tree_qx2jg";
            OracleParameter[] _param = {
                              new OracleParameter("nParent",OracleDbType.Decimal),
                               new OracleParameter("nLevel",OracleDbType.Decimal),
				new OracleParameter("strcs",OracleDbType.Varchar2),
                               new OracleParameter("curTree",OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output)
                           };
            _param[0].Value = decimal.Parse(_rootDwid);
            _param[1].Value = _levelNum;
            _param[2].Value = _type;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure, _sql, _param);
            List<SinoOrganize> _ret = new List<SinoOrganize>();

            while (dr.Read())
            {
                SinoOrganize _so = new SinoOrganize(dr.IsDBNull(0) ? 0 : dr.GetDecimal(0),
                        dr.IsDBNull(5) ? 0 : dr.GetDecimal(5),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        "",
                        dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDecimal(7)),
                        dr.IsDBNull(8) ? true : (dr.GetDecimal(8) > 0)
                        );
                _ret.Add(_so);
            }

            dr.Close();

            return _ret;
        }




        public void WriteExportLog(int _exportRowCount, string ExportDataMsg)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _ipaddr = WCFClientInfo.IPAddr;
                    string _hostName = _ipaddr;

                    if (ExportDataMsg == null || ExportDataMsg.Trim() == "")
                    {
                        OralceLogWriter.WriteUserLog(decimal.Parse(SinoUserCtx.CurUser.UserID), "导出数据", string.Format("导了数据成功! 导出记录数：{0}", _exportRowCount),
                         1, _ipaddr, _hostName, ConfigFile.SystemID);
                    }
                    else
                    {
                        OralceLogWriter.WriteUserLog(decimal.Parse(SinoUserCtx.CurUser.UserID), "导出数据", string.Format("导了数据成功! 导出记录数：{0}  导出数据说明：{1}", _exportRowCount, ExportDataMsg),
                      1, _ipaddr, _hostName, ConfigFile.SystemID);
                    }
                }
                catch (Exception ex)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("写入导出日志失败！导出内容：{0} 导出行数：{1} 错误信息：{2}", ExportDataMsg, _exportRowCount, ex.Message), "ERROR");
                }
            }
        }

        #endregion


        public void WriteClientUserLog(string Message, string LogType)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _ipaddr = WCFClientInfo.IPAddr;

                    OralceLogWriter.WriteUserLog(decimal.Parse(SinoUserCtx.CurUser.UserID), "客户端日志", Message, 1, _ipaddr, _ipaddr, ConfigFile.SystemID);

                }
                catch (Exception ex)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("写入客户端日志失败！日志内容：{0} 类型：{1} 错误信息：{2}", Message, LogType, ex.Message), "ERROR");
                }
            }
        }
    }
}
