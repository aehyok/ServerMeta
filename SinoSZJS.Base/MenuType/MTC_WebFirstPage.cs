using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_WebFirstPage 的摘要说明。
	/// </summary>
	public class MTC_WebFirstPage:MenuTypeBase
	{
		public MTC_WebFirstPage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "首页类型";
			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<Web页面></Web页面>");
			this.MenuTypeParameters = _sb.ToString();
		}
	}
}
