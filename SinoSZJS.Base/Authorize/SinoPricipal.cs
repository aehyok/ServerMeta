using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

////#warning 考虑到一个人可能属于多个部门，应该将登录的部门ID也放到HgjsPrincipal中

namespace SinoSZJS.Base.Authorize
{
	/// <summary>
	/// HgjsPrincipal : 当前用户标识信息, 放在CallContext中，并可以跨越AppDomain
	/// </summary>
	public class HgjsPrincipal : ILogicalThreadAffinative
	{
		private const string CallCtxSlot = "HgjsPrincipal";
		
		public SinoUser UserInfo; //当前用户ID
		
		/// <summary>
		/// 构造方法。设置当前用户信息
		/// </summary>
		public HgjsPrincipal(SinoUser _userInfo)
		{
			UserInfo		= _userInfo;
		}
		
		public HgjsPrincipal()
		{
			UserInfo		= null;
		}

		

		/// <summary>
		/// 获取当前用户信息。
		/// </summary>
		public static  SinoUser CurUserInfo
		{
			get{ return CurPrincipal.UserInfo;}
		}

		/// <summary>
		/// 保存本身的对象到当前线程的线程本地存储。
		/// </summary>
		public void SaveToCallCtx()
		{
			CallContext.SetData(CallCtxSlot, this);
		}
		

		/// <summary>
		/// 获取当前线程的线程本地存储的HgjsPrincipal对象。
		/// </summary>
		public static HgjsPrincipal	CurPrincipal
		{ 
			get 
			{
				object obj = CallContext.GetData(CallCtxSlot);
				Debug.Assert(obj != null, "用户身份丢失或服务器被重新启动,请重新启动程序！");
				return (HgjsPrincipal)obj; 
			} 
		}
		

		/// <summary>
		/// 获取当前线程的线程本地存储的HgjsPrincipal对象，如果对象为空，则返回null。
		/// Release版与CurPrincipal属性相同。
		/// </summary>
		/// <returns></returns>
		public static HgjsPrincipal TryGetCurPrincipal()
		{
			object obj = CallContext.GetData(CallCtxSlot);
			if (obj != null)
				return (HgjsPrincipal)obj; 
			else
				return null;
		}
	

	}
}