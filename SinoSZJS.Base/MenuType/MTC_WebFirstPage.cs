using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_WebFirstPage ��ժҪ˵����
	/// </summary>
	public class MTC_WebFirstPage:MenuTypeBase
	{
		public MTC_WebFirstPage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��ҳ����";
			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<Webҳ��></Webҳ��>");
			this.MenuTypeParameters = _sb.ToString();
		}
	}
}
