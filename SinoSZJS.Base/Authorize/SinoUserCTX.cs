using System;

namespace SinoSZJS.Base.Authorize
{      
	/// <summary>
	/// SinoUserCtx
	/// 用于Remoting的 UserCtx信息
	/// </summary>
	public class SinoUserCtx
	{
                private static IUserInfoCTX userInfoCTX = new WCFUserCTX();

		/// <summary>
		/// 获取当前用户的用户ID。
		/// </summary>
		public static SinoUser CurUser
		{
                        get { return UserInfoCTX.GetCurrentUser(); }
		}

               /// <summary>
               /// 用户信息接口
               /// </summary>
                public static IUserInfoCTX UserInfoCTX
                {
                        get { return userInfoCTX; }
                        set { userInfoCTX = value; }
                }
                

	}
}