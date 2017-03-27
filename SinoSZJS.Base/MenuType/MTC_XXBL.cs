using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_XXBL 的摘要说明。
	/// </summary>
	public class MTC_XXBL:MenuTypeBase
	{
		public MTC_XXBL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "缉私综合_信息补录类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题><判决书选择案件模型></判决书选择案件模型>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"罚没收入补录",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"刑事判决书补录",_fxh + 20,_menuid,_fqxid);
			
		}
	}
}
