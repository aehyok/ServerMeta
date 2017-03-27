using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_BAJD 的摘要说明。
	/// </summary>
	public class MTC_BAJD :MenuTypeBase
	{
		public MTC_BAJD()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.MenuTypeName = "缉私综合_办案监督类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<刑事高风险></刑事高风险><行政高风险></行政高风险>");
			_sb.Append("<刑事超期></刑事超期><行政超期></行政超期>");
			_sb.Append("<刑事文书></刑事文书><行政文书></行政文书>");
			_sb.Append("<刑事常用></刑事常用><行政常用></行政常用>");
			_sb.Append("<刑事迟录></刑事迟录><行政迟录></行政迟录>");
			_sb.Append("<参数设置></参数设置><概要信息></概要信息>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"刑事常用监督",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"查看详细信息",_fxh + 2,_menuid,_fqxid +1);

			base.AddRightData(_rightData,_fqxid + 20,"行政常用监督",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"查看详细信息",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"刑事高风险案件",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"查看详细信息",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"行政高风险案件",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"查看详细信息",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 50,"刑事超期案件",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"查看详细信息",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"行政超期案件",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"查看详细信息",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"刑事法律文书监督",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 71,"查看详细信息",_fxh + 71,_menuid,_fqxid +70);

			base.AddRightData(_rightData,_fqxid + 80,"行政法律文书监督",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 81,"查看详细信息",_fxh + 81,_menuid,_fqxid +80);

			base.AddRightData(_rightData,_fqxid + 90,"刑事迟录案件监督",_fxh + 90,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 91,"查看详细信息",_fxh + 91,_menuid,_fqxid +90);

			base.AddRightData(_rightData,_fqxid + 100,"行政迟录案件监督",_fxh + 100,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 101,"查看详细信息",_fxh + 101,_menuid,_fqxid +100);

                        base.AddRightData(_rightData,_fqxid + 180,"参数设置",_fxh + 180,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 181,"修改参数",_fxh + 181,_menuid,_fqxid +180);
		}
	}
}
