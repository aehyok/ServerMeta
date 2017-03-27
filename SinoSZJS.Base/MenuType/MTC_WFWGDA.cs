using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_WFWGDA ��ժҪ˵����
	/// </summary>
	public class MTC_WFWGDA :MenuTypeBase
	{
		public MTC_WFWGDA()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��˽�ۺ�_Υ��Υ�浵������";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<��Ҫ��Ϣ></��Ҫ��Ϣ><�����ռ�></�����ռ�>");
			_sb.Append("<���ݱȶ�></���ݱȶ�><Ŀ��ɸѡ></Ŀ��ɸѡ>");
			_sb.Append("<���ü����ռ�></���ü����ռ�>");
			_sb.Append("<�永��ҵ����></�永��ҵ����>");
			_sb.Append("<��ҵ������ѯ></��ҵ������ѯ><��Ա������ѯ></��Ա������ѯ><���乤�ߵ�����ѯ></���乤�ߵ�����ѯ>");
			_sb.Append("<��˽̬�Ʒ���></��˽̬�Ʒ���>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"��Ϣ����",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"Υ����ҵ�����̶���ѯ",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"�鿴��ϸ��Ϣ",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"Υ����Ա�����̶���ѯ",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"�鿴��ϸ��Ϣ",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"Υ�����������̶���ѯ",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"�鿴��ϸ��Ϣ",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 50,"Υ����ҵ�����Զ����ѯ",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"�鿴��ϸ��Ϣ",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"Υ����Ա�����Զ����ѯ",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"�鿴��ϸ��Ϣ",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"Υ�����������Զ����ѯ",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 71,"�鿴��ϸ��Ϣ",_fxh + 71,_menuid,_fqxid +70);

			base.AddRightData(_rightData,_fqxid + 80,"Υ����ҵ����",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 81,"�鿴��ϸ��Ϣ",_fxh + 81,_menuid,_fqxid +80);

			base.AddRightData(_rightData,_fqxid + 90,"Υ����Ա����",_fxh + 90,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 91,"�鿴��ϸ��Ϣ",_fxh + 91,_menuid,_fqxid +90);

			base.AddRightData(_rightData,_fqxid + 100,"Υ����������",_fxh + 100,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 101,"�鿴��ϸ��Ϣ",_fxh + 101,_menuid,_fqxid +100);

			base.AddRightData(_rightData,_fqxid + 110,"Υ�����ͳ��",_fxh + 110,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 111,"�鿴��ϸ��Ϣ",_fxh + 111,_menuid,_fqxid +110);

			base.AddRightData(_rightData,_fqxid + 120,"Ŀ��ɸѡ",_fxh + 120,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 130,"���ݱȶ�",_fxh + 130,_menuid,_fqxid);
			

			
		}

	}
}
