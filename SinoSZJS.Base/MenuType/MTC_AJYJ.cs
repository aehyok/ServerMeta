using System;
using System.Text;

namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_AJYJ 的摘要说明。
	/// </summary>
	public class MTC_AJYJ :MenuTypeBase
	{
		public MTC_AJYJ()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "缉私综合_案件预警类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<刑事办案时间预警></刑事办案时间预警><行政办案时间预警></行政办案时间预警>");
			_sb.Append("<刑事串并案预警></刑事串并案预警><行政串并案预警></行政串并案预警>");
			_sb.Append("<参数设置></参数设置><概要信息></概要信息>");
					
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"刑事办案时间预警",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"查看详细信息",_fxh + 2,_menuid,_fqxid +1);

			base.AddRightData(_rightData,_fqxid + 20,"行政办案时间预警",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"查看详细信息",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"刑事串案预警",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"查看详细信息",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"行政串案预警",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"查看详细信息",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 180,"参数设置",_fxh + 180,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 181,"修改参数",_fxh + 181,_menuid,_fqxid +180);
		}


	}
}
