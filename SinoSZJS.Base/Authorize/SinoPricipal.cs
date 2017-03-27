using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

////#warning ���ǵ�һ���˿������ڶ�����ţ�Ӧ�ý���¼�Ĳ���IDҲ�ŵ�HgjsPrincipal��

namespace SinoSZJS.Base.Authorize
{
	/// <summary>
	/// HgjsPrincipal : ��ǰ�û���ʶ��Ϣ, ����CallContext�У������Կ�ԽAppDomain
	/// </summary>
	public class HgjsPrincipal : ILogicalThreadAffinative
	{
		private const string CallCtxSlot = "HgjsPrincipal";
		
		public SinoUser UserInfo; //��ǰ�û�ID
		
		/// <summary>
		/// ���췽�������õ�ǰ�û���Ϣ
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
		/// ��ȡ��ǰ�û���Ϣ��
		/// </summary>
		public static  SinoUser CurUserInfo
		{
			get{ return CurPrincipal.UserInfo;}
		}

		/// <summary>
		/// ���汾��Ķ��󵽵�ǰ�̵߳��̱߳��ش洢��
		/// </summary>
		public void SaveToCallCtx()
		{
			CallContext.SetData(CallCtxSlot, this);
		}
		

		/// <summary>
		/// ��ȡ��ǰ�̵߳��̱߳��ش洢��HgjsPrincipal����
		/// </summary>
		public static HgjsPrincipal	CurPrincipal
		{ 
			get 
			{
				object obj = CallContext.GetData(CallCtxSlot);
				Debug.Assert(obj != null, "�û���ݶ�ʧ�����������������,��������������");
				return (HgjsPrincipal)obj; 
			} 
		}
		

		/// <summary>
		/// ��ȡ��ǰ�̵߳��̱߳��ش洢��HgjsPrincipal�����������Ϊ�գ��򷵻�null��
		/// Release����CurPrincipal������ͬ��
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