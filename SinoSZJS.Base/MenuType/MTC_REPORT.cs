using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_REPORT ��ժҪ˵����
	/// </summary>
	public class MTC_REPORT :MenuTypeBase
	{
		public MTC_REPORT()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��˽�ۺ�_ͳ�Ʊ�������";

			StringBuilder _sb = new StringBuilder();
			
			_sb.Append("<����></����>");
			_sb.Append("<�̶��±���></�̶��±���><�Զ��屨��></�Զ��屨��>");
			_sb.Append("<����ͳ��ָ��></����ͳ��ָ��><����ͳ��ָ��></����ͳ��ָ��>");
			_sb.Append("<����ͳ�Ʋ�ѯ></����ͳ�Ʋ�ѯ><����ͳ�Ʋ�ѯ></����ͳ�Ʋ�ѯ>");
			_sb.Append("<��Ҫ��Ϣ></��Ҫ��Ϣ><����ͳ�Ʒ���></����ͳ�Ʒ���><����ͳ�Ʒ���></����ͳ�Ʒ���>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"����ͳ�Ʋ�ѯ",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"����ͳ�Ʋ�ѯ",_fxh + 20,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 30,"����ͳ��ָ��",_fxh + 30,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 40,"����ͳ��ָ��",_fxh + 40,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 50,"�̶��±���",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"�鿴��ϸ��Ϣ",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"�Զ��屨��",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"�鿴��ϸ��Ϣ",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"�������",_fxh + 70,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 80,"���÷���",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 90,"ָ�����",_fxh+90,_menuid,_fqxid);
		}
	}
}
