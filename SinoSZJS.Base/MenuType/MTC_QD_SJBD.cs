using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_SJBD 的摘要说明。
	/// </summary>
	public class MTC_QD_SJBD:MenuTypeBase
	{
		public MTC_QD_SJBD()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "青岛_数据比对类型";

			StringBuilder _sb = new StringBuilder();
			
			_sb.Append("<标题></标题>");
			_sb.Append("<刑事结案></刑事结案><行政结案></行政结案>");
			_sb.Append("<刑事全部></刑事全部><行政全部></行政全部>");
			_sb.Append("<诚信企业></诚信企业><青岛关区备案企业></青岛关区备案企业>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"刑事结案案件",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"行政结案案件",_fxh + 2,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 20,"刑事全部案件",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"行政全部案件",_fxh + 21,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 30,"诚信企业信息",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"备案企业信息",_fxh + 31,_menuid,_fqxid);
		}
	}
}
