using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_NAMESPACE ��ժҪ˵����
	/// </summary>
	public class MTC_NAMESPACE :MenuTypeBase
	{
		public MTC_NAMESPACE()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//

			this.MenuTypeName = "�����ռ��ۺ�����";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<�����ռ�></�����ռ�><����>0</����><�����ռ�></�����ռ�><���ü����ռ�></���ü����ռ�>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"��Ϣ����",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"�̶���ѯ",_fxh + 20,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 30,"�Զ����ѯ",_fxh + 30,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 40,"ָ���ѯ",_fxh + 40,_menuid,_fqxid);
			
		}
	}
}
