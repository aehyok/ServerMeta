using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_XXBL ��ժҪ˵����
	/// </summary>
	public class MTC_XXBL:MenuTypeBase
	{
		public MTC_XXBL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��˽�ۺ�_��Ϣ��¼����";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����><�о���ѡ�񰸼�ģ��></�о���ѡ�񰸼�ģ��>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"��û���벹¼",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"�����о��鲹¼",_fxh + 20,_menuid,_fqxid);
			
		}
	}
}
