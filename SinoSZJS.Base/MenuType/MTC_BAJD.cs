using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_BAJD ��ժҪ˵����
	/// </summary>
	public class MTC_BAJD :MenuTypeBase
	{
		public MTC_BAJD()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			this.MenuTypeName = "��˽�ۺ�_�참�ල����";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<���¸߷���></���¸߷���><�����߷���></�����߷���>");
			_sb.Append("<���³���></���³���><��������></��������>");
			_sb.Append("<��������></��������><��������></��������>");
			_sb.Append("<���³���></���³���><��������></��������>");
			_sb.Append("<���³�¼></���³�¼><������¼></������¼>");
			_sb.Append("<��������></��������><��Ҫ��Ϣ></��Ҫ��Ϣ>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"���³��üල",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"�鿴��ϸ��Ϣ",_fxh + 2,_menuid,_fqxid +1);

			base.AddRightData(_rightData,_fqxid + 20,"�������üල",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"�鿴��ϸ��Ϣ",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"���¸߷��հ���",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"�鿴��ϸ��Ϣ",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"�����߷��հ���",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"�鿴��ϸ��Ϣ",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 50,"���³��ڰ���",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"�鿴��ϸ��Ϣ",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"�������ڰ���",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"�鿴��ϸ��Ϣ",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"���·�������ල",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 71,"�鿴��ϸ��Ϣ",_fxh + 71,_menuid,_fqxid +70);

			base.AddRightData(_rightData,_fqxid + 80,"������������ල",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 81,"�鿴��ϸ��Ϣ",_fxh + 81,_menuid,_fqxid +80);

			base.AddRightData(_rightData,_fqxid + 90,"���³�¼�����ල",_fxh + 90,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 91,"�鿴��ϸ��Ϣ",_fxh + 91,_menuid,_fqxid +90);

			base.AddRightData(_rightData,_fqxid + 100,"������¼�����ල",_fxh + 100,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 101,"�鿴��ϸ��Ϣ",_fxh + 101,_menuid,_fqxid +100);

                        base.AddRightData(_rightData,_fqxid + 180,"��������",_fxh + 180,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 181,"�޸Ĳ���",_fxh + 181,_menuid,_fqxid +180);
		}
	}
}
