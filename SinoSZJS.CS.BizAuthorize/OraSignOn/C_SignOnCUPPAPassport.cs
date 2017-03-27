using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.Authorize.CUPPA;
using SinoSZJS.Base.Misc;


namespace SinoSZJS.CS.BizAuthorize.OraSignOn
{
    public class C_SignOnCUPPAPassport : C_SignOnBase
    {
        static C_SignOnCUPPAPassport()
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
        override public bool Check(string _name, string _pass, string CheckType)
        {
            //1.通过三统一接口验证密码
            try
            {
                if (CUPPAPassportConfig.DebugMode)
                {
                    return (_name == _pass);
                }
                else
                {
                    if (CheckType == "windows")
                    {
                        string _newpass = StrUtils.DecodeByDESC(_pass, "DOMAINCK");
                        return (_newpass == _name);
                    }
#if DEBUG
                    return (_name == _pass);
#else
                     using (OguReaderClient _orc = new OguReaderClient())
                    {

                        bool _ret = _orc.CheckPwd(_name, CheckType, _pass);
                        if (CUPPAPassportConfig.CUPPA_Check_WriteLog) CUPPAPassportConfig.WriteCUPPALog(string.Format("采用三统一平台验证口令返回{0},! name={1}, CUPPA_Check_Type={2}, pass={3}",
                                _ret, _name, CheckType, _pass));
                        return _ret;
                    }
                    
#endif
                }

            }
            catch (Exception e1)
            {
                string _error = string.Format("采用三统一平台验证口令出错:{0}\n Name={1} Pass={2}", e1.Message, _name, _pass);
                OralceLogWriter.WriteSystemLog(_error, "ERROR");
                if (CUPPAPassportConfig.CUPPA_Check_WriteLog) CUPPAPassportConfig.WriteCUPPALog(_error);
                return false;
            }
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
            return -1;
        }

        /// <summary>
        /// 重置口令
        /// </summary>
        /// <param name="_uname"></param>
        /// <param name="_pass"></param>
        /// <returns></returns>
        override public int ResetPass(string _uname, string _pass)
        {
            return -1;
        }
    }
}
