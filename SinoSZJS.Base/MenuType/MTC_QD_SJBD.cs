using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_SJBD ��ժҪ˵����
	/// </summary>
	public class MTC_QD_SJBD:MenuTypeBase
	{
		public MTC_QD_SJBD()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "�ൺ_���ݱȶ�����";

			StringBuilder _sb = new StringBuilder();
			
			_sb.Append("<����></����>");
			_sb.Append("<���½᰸></���½᰸><�����᰸></�����᰸>");
			_sb.Append("<����ȫ��></����ȫ��><����ȫ��></����ȫ��>");
			_sb.Append("<������ҵ></������ҵ><�ൺ����������ҵ></�ൺ����������ҵ>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"���½᰸����",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"�����᰸����",_fxh + 2,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 20,"����ȫ������",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"����ȫ������",_fxh + 21,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 30,"������ҵ��Ϣ",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"������ҵ��Ϣ",_fxh + 31,_menuid,_fqxid);
		}
	}
}
