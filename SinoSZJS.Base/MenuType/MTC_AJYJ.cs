using System;
using System.Text;

namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_AJYJ ��ժҪ˵����
	/// </summary>
	public class MTC_AJYJ :MenuTypeBase
	{
		public MTC_AJYJ()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��˽�ۺ�_����Ԥ������";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<���°참ʱ��Ԥ��></���°참ʱ��Ԥ��><�����참ʱ��Ԥ��></�����참ʱ��Ԥ��>");
			_sb.Append("<���´�����Ԥ��></���´�����Ԥ��><����������Ԥ��></����������Ԥ��>");
			_sb.Append("<��������></��������><��Ҫ��Ϣ></��Ҫ��Ϣ>");
					
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"���°참ʱ��Ԥ��",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"�鿴��ϸ��Ϣ",_fxh + 2,_menuid,_fqxid +1);

			base.AddRightData(_rightData,_fqxid + 20,"�����참ʱ��Ԥ��",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"�鿴��ϸ��Ϣ",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"���´���Ԥ��",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"�鿴��ϸ��Ϣ",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"��������Ԥ��",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"�鿴��ϸ��Ϣ",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 180,"��������",_fxh + 180,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 181,"�޸Ĳ���",_fxh + 181,_menuid,_fqxid +180);
		}


	}
}
