using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Misc;
using System.Data;
using SinoSZJS.DataAccess;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizAuthorize.OraSignOn
{
        /// <summary>
        /// 超级管理员的业务逻辑类
        /// </summary>
        public class C_SignOnAdmin : C_SignOnBase
        {
                public C_SignOnAdmin()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }

                /// <summary>
                /// 验证口令
                /// </summary>
                /// <param name="_name"></param>
                /// <param name="_pass"></param>
                /// <returns></returns>
                override public bool Check(string _name, string _pass,string CheckType)
                {
                        //1.读取数据库中的用户信息，验证密码
                        string CheckStr = string.Format("SELECT count(*) FROM zhtj_csb WHERE CSNAME='AdminPass' and CSDATA='{0}' ", MD5Base64.Encode(_pass));
                        decimal _ret = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile,CommandType.Text,CheckStr);
                        return (_ret > 0);
                }

                /// <summary>
                /// 修改口令
                /// </summary>
                /// <param name="_name"></param>
                /// <param name="_oldpass"></param>
                /// <param name="_newpass"></param>
                /// <returns></returns>
                override public int ChangePassword(string _name, string _oldpass, string _newpass)
                {
                        //1.读取数据库中的用户信息，验证密码
                        string CheckStr = string.Format("SELECT count(*) FROM zhtj_csb WHERE CSNAME='AdminPass' and CSDATA='{0}' ", MD5Base64.Encode(_oldpass));
                        decimal _ret = (decimal)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, CheckStr);
                        if (_ret < 1)
                        {
                                return -1;
                        }
                        string Changepass = string.Format("Update ZHTJ_CSB set CSDATA='{0}' where CSNAME='AdminPass'", MD5Base64.Encode(_newpass));
                        try
                        {
                                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, Changepass);
                                return 1;
                        }
                        catch (Exception e)
                        {
                                throw new Exception(string.Format("修改口令出错:{0}", e.Message));                               
                        }
                }

                /// <summary>
                /// 重置口令
                /// </summary>
                /// <param name="_uname"></param>
                /// <param name="_pass"></param>
                /// <returns></returns>
                override public int ResetPass(string _uname, string _pass)
                {
                        string Changepass = string.Format("Update ZHTJ_CSB set CSDATA='{0}' where CSNAME='AdminPass'", MD5Base64.Encode(_pass));
                        try
                        {
                                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, Changepass);
                                return 1;
                        }
                        catch (Exception e)
                        {
                                throw new Exception(string.Format("重设口令出错:{0}", e.Message));  
                               
                        }
                }
        }
}
