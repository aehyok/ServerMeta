using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_SJWH ��ժҪ˵����
	/// </summary>
	public class MTC_QD_SJWH :MenuTypeBase
	{
		public MTC_QD_SJWH()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "�ൺ_����ά������";

			StringBuilder _sb = new StringBuilder();
			
			_sb.Append("<����></����>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"������ҵ���ݵ���",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"�ൺ������ҵ���ݵ���",_fxh + 2,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 3,"��û���벹¼",_fxh + 3,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 4,"ҵ��ָ������¼",_fxh + 4,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 5,"��λ������¼",_fxh + 5,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 6,"��֯����������Ϣά��",_fxh + 6,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 7,"������������ά��",_fxh+7,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 20,"����У��",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"У��������",_fxh + 21,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 22,"��ѯ��ʷ����У����",_fxh + 22,_menuid,_fqxid);
		}
	}
}
