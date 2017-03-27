using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.CS.BizAuthorize
{
        /// <summary>
        /// 身份认证功能基类,所有身份认证功能均继承此类
        /// </summary>
        public class C_SignOnBase
        {
                public C_SignOnBase()
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
                virtual public bool Check(string _name, string _pass,string CheckType)
                {
                        return true;
                }

                /// <summary>
                /// 修改口令
                /// </summary>
                /// <param name="_name"></param>
                /// <param name="_oldpass"></param>
                /// <param name="_newpass"></param>
                /// <returns></returns>
                virtual public int ChangePassword(string _name, string _oldpass, string _newpass)
                {
                        //1.读取数据库中的用户信息，验证密码
                        return 1;
                }

                /// <summary>
                /// 重置口令
                /// </summary>
                /// <param name="_uname"></param>
                /// <param name="_pass"></param>
                /// <returns></returns>
                virtual public int ResetPass(string _uname, string _pass)
                {
                        //重设口令
                        return 1;
                }
        }
}
