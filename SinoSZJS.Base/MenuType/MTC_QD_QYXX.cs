using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_QYXX ��ժҪ˵����
	/// </summary>
	public class MTC_QD_QYXX :MenuTypeBase
	{
		public MTC_QD_QYXX()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			this.MenuTypeName = "�ൺ_��ҵ��Ϣ����";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<������ҵΥ��></������ҵΥ��><������ҵΥ��></������ҵΥ��>");
			_sb.Append("<��������></��������>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"������ҵΥ��",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"������ҵΥ��",_fxh + 2,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 20,"��������",_fxh + 20,_menuid,_fqxid);
			
		}
	}
}
