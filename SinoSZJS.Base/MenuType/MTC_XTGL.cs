using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_XTGL ��ժҪ˵����
	/// </summary>
	public class MTC_XTGL:MenuTypeBase
	{
		public MTC_XTGL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��˽�ۺ�_ϵͳ��������";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����>ϵͳ����</����><��Ȩ��ѯģ��></��Ȩ��ѯģ��>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"��ɫ����",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"�û�����",_fxh + 20,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 30,"ȫ��Ԫ��������",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 40,"�ڵ�Ԫ��������",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 50,"ָ�궨��",_fxh + 50,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 60,"�ӿڹ���",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 70,"�û�������־����",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 80,"ϵͳ������־����",_fxh + 80,_menuid,_fqxid );
			base.AddRightData(_rightData,_fqxid + 90,"��λ����",_fxh +14,_menuid,_fqxid);
		}
	}
}
