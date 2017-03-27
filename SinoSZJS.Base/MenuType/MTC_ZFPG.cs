using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_ZFPG 的摘要说明。
	/// </summary>
	public class MTC_ZFPG :MenuTypeBase
	{
		public MTC_ZFPG()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "缉私综合_执法评估类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<考评项目分析></考评项目分析><考评单位分析></考评单位分析><概要信息></概要信息>");
						
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"待考评案件",_fxh + 1,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 2,"制作结案通知书",_fxh + 2,_menuid,_fqxid+1);

			base.AddRightData(_rightData,_fqxid + 20,"个案考评结果",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"提出申诉",_fxh + 21,_menuid,_fqxid+20);

			base.AddRightData(_rightData,_fqxid + 30,"年度考评结果",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"提出申诉",_fxh + 31,_menuid,_fqxid+30);

			base.AddRightData(_rightData,_fqxid + 40,"个案考评任务",_fxh + 40,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 50,"年度考评任务",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 60,"考评档案管理",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 70,"考评项目分析",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 80,"考评单位分析",_fxh + 80,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 90,"考评组织管理",_fxh + 90,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 91,"修改资料",_fxh + 91,_menuid,_fqxid+90);

			base.AddRightData(_rightData,_fqxid + 100,"考评项目管理",_fxh + 100,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 101,"修改资料",_fxh + 101,_menuid,_fqxid+100);
		}


	}
}
