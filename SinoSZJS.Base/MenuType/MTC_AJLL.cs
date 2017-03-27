using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_AJLL 的摘要说明。
	/// </summary>
	public class MTC_AJLL:MenuTypeBase
	{
		public MTC_AJLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.MenuTypeName = "缉私综合_案件浏览类型";
			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<刑事最新案件></刑事最新案件><行政最新案件></行政最新案件>");
			_sb.Append("<刑事大要案></刑事大要案><行政大要案></行政大要案>");
			_sb.Append("<刑事专案></刑事专案>");
			_sb.Append("<刑事专项行动></刑事专项行动><行政专项行动></行政专项行动>");
			_sb.Append("<参数设置></参数设置><概要信息></概要信息>");
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"刑事最新案件",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"查看详细信息",_fxh + 2,_menuid,_fqxid +1);

			base.AddRightData(_rightData,_fqxid + 20,"行政最新案件",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"查看详细信息",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"刑事大要案",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"查看详细信息",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"行政大要案",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"查看详细信息",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 50,"刑事专案",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"查看详细信息",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"刑事专项行动",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"查看详细信息",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"行政专项行动",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 71,"查看详细信息",_fxh + 71,_menuid,_fqxid +70);

			base.AddRightData(_rightData,_fqxid + 80,"参数设置",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 81,"修改参数",_fxh + 81,_menuid,_fqxid +80);
		}
	}
}
