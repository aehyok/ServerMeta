using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_ZFPG ��ժҪ˵����
	/// </summary>
	public class MTC_ZFPG :MenuTypeBase
	{
		public MTC_ZFPG()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "��˽�ۺ�_ִ����������";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<����></����>");
			_sb.Append("<������Ŀ����></������Ŀ����><������λ����></������λ����><��Ҫ��Ϣ></��Ҫ��Ϣ>");
						
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"����������",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"�����᰸֪ͨ��",_fxh + 2,_menuid,_fqxid+1);

			base.AddRightData(_rightData,_fqxid + 20,"�����������",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"�������",_fxh + 21,_menuid,_fqxid+20);

			base.AddRightData(_rightData,_fqxid + 30,"��ȿ������",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"�������",_fxh + 31,_menuid,_fqxid+30);

			base.AddRightData(_rightData,_fqxid + 40,"������������",_fxh + 40,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 50,"��ȿ�������",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 60,"������������",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 70,"������Ŀ����",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 80,"������λ����",_fxh + 80,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 90,"������֯����",_fxh + 90,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 91,"�޸�����",_fxh + 91,_menuid,_fqxid+90);

			base.AddRightData(_rightData,_fqxid + 100,"������Ŀ����",_fxh + 100,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 101,"�޸�����",_fxh + 101,_menuid,_fqxid+100);
		}


	}
}
