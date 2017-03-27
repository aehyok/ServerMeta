using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_SJJY 的摘要说明。
	/// </summary>
	public class MTC_QD_SJJY:MenuTypeBase
	{
		public MTC_QD_SJJY()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.MenuTypeName = "青岛_数据校验类型";
			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			this.MenuTypeParameters = _sb.ToString();
		}
	}
}
