using System;

namespace SinoSZJS.Base.Authorize
{
	/// <summary>
	/// CSSinoRole 的摘要说明。
	/// 用在客户端的角色类，其基类是SinoRole
	/// </summary>
	/// 
	[Serializable()]
	public class CSSinoRole:SinoRole
	{
		public CSSinoRole()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public override string ToString()
		{
			return string.Format("{0} [{1}]",RoleName,(RoleDwid == "")?"通用角色":"私有角色");
		}

	}
}
