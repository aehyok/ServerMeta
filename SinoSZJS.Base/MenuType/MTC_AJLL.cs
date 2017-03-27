using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_AJLL ��ժҪ˵����
	/// </summary>
	public class MTC_AJLL:MenuTypeBase
	{
		public MTC_AJLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			this.MenuTypeName = "��˽�ۺ�_�����������";
			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<�������°���></�������°���><�������°���></�������°���>");
			_sb.Append("<���´�Ҫ��></���´�Ҫ��><������Ҫ��></������Ҫ��>");
			_sb.Append("<����ר��></����ר��>");
			_sb.Append("<����ר���ж�></����ר���ж�><����ר���ж�></����ר���ж�>");
			_sb.Append("<��������></��������><��Ҫ��Ϣ></��Ҫ��Ϣ>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"�������°���",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"�鿴��ϸ��Ϣ",_fxh + 2,_menuid,_fqxid +1);

			base.AddRightData(_rightData,_fqxid + 20,"�������°���",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"�鿴��ϸ��Ϣ",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"���´�Ҫ��",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"�鿴��ϸ��Ϣ",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"������Ҫ��",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"�鿴��ϸ��Ϣ",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 50,"����ר��",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"�鿴��ϸ��Ϣ",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"����ר���ж�",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"�鿴��ϸ��Ϣ",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"����ר���ж�",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 71,"�鿴��ϸ��Ϣ",_fxh + 71,_menuid,_fqxid +70);

			base.AddRightData(_rightData,_fqxid + 80,"��������",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 81,"�޸Ĳ���",_fxh + 81,_menuid,_fqxid +80);
		}
	}
}
