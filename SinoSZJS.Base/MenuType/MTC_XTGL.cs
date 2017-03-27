using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_XTGL 的摘要说明。
	/// </summary>
	public class MTC_XTGL:MenuTypeBase
	{
		public MTC_XTGL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "缉私综合_系统管理类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题>系统管理</标题><授权查询模型></授权查询模型>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"角色管理",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"用户管理",_fxh + 20,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 30,"全局元数据设置",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 40,"节点元数据设置",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 50,"指标定义",_fxh + 50,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 60,"接口管理",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 70,"用户操作日志管理",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 80,"系统运行日志管理",_fxh + 80,_menuid,_fqxid );
			base.AddRightData(_rightData,_fqxid + 90,"岗位管理",_fxh +14,_menuid,_fqxid);
		}
	}
}
