using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_QD_SJWH 的摘要说明。
	/// </summary>
	public class MTC_QD_SJWH :MenuTypeBase
	{
		public MTC_QD_SJWH()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "青岛_数据维护类型";

			StringBuilder _sb = new StringBuilder();
			
			_sb.Append("<标题></标题>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"诚信企业数据导入",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"青岛备案企业数据导入",_fxh + 2,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 3,"罚没收入补录",_fxh + 3,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 4,"业务指标任务补录",_fxh + 4,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 5,"单位人数补录",_fxh + 5,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 6,"组织机构附加信息维护",_fxh + 6,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 7,"线索移往部门维护",_fxh+7,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 20,"数据校验",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"校验规则管理",_fxh + 21,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 22,"查询历史发布校验结果",_fxh + 22,_menuid,_fqxid);
		}
	}
}
