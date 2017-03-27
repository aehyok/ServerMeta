using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_QYXX 的摘要说明。
	/// </summary>
	public class MTC_QD_QYXX :MenuTypeBase
	{
		public MTC_QD_QYXX()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.MenuTypeName = "青岛_企业信息类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<诚信企业违法></诚信企业违法><备案企业违法></备案企业违法>");
			_sb.Append("<参数设置></参数设置>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"诚信企业违法",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"备案企业违法",_fxh + 2,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 20,"参数设置",_fxh + 20,_menuid,_fqxid);
			
		}
	}
}
