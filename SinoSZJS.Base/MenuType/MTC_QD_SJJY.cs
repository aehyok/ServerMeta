using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_SJJY ��ժҪ˵����
	/// </summary>
	public class MTC_QD_SJJY:MenuTypeBase
	{
		public MTC_QD_SJJY()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			this.MenuTypeName = "�ൺ_����У������";
			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			this.MenuTypeParameters = _sb.ToString();
		}
	}
}
