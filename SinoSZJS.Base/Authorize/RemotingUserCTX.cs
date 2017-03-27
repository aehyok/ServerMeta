using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Authorize
{
        public class RemotingUserCTX : IUserInfoCTX
        {

                #region IUserInfoCTX Members

                public SinoUser GetCurrentUser()
                {
                        return HgjsPrincipal.CurUserInfo;
                }

                /// <summary>
                /// 设置当前用户上下文的当前用户ID。
                /// </summary>
                /// <param name="userInfo">当前用户信息</param>
                public static void SetCurUser(SinoUser userInfo)
                {
                        //将用户身份存放在CallContext中
                        new HgjsPrincipal(userInfo).SaveToCallCtx();
                }

                #endregion
        }
}
