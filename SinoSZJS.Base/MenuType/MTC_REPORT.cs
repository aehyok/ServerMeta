using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_REPORT 的摘要说明。
	/// </summary>
	public class MTC_REPORT :MenuTypeBase
	{
		public MTC_REPORT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "缉私综合_统计报表类型";

			StringBuilder _sb = new StringBuilder();
			
			_sb.Append("<标题></标题>");
			_sb.Append("<固定月报表></固定月报表><自定义报表></自定义报表>");
			_sb.Append("<刑事统计指标></刑事统计指标><行政统计指标></行政统计指标>");
			_sb.Append("<刑事统计查询></刑事统计查询><行政统计查询></行政统计查询>");
			_sb.Append("<概要信息></概要信息><刑事统计分析></刑事统计分析><行政统计分析></行政统计分析>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"刑事统计查询",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"行政统计查询",_fxh + 20,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 30,"刑事统计指标",_fxh + 30,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 40,"行政统计指标",_fxh + 40,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 50,"固定月报表",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"查看详细信息",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"自定义报表",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"查看详细信息",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"报表分析",_fxh + 70,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 80,"常用分析",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 90,"指标分析",_fxh+90,_menuid,_fqxid);
		}
	}
}
