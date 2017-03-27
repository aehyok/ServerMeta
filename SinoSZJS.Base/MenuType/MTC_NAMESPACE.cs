using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_NAMESPACE 的摘要说明。
	/// </summary>
	public class MTC_NAMESPACE :MenuTypeBase
	{
		public MTC_NAMESPACE()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "命名空间综合类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<命名空间></命名空间><类型>0</类型><检索空间></检索空间><备用检索空间></备用检索空间>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"信息检索",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"固定查询",_fxh + 20,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 30,"自定义查询",_fxh + 30,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 40,"指标查询",_fxh + 40,_menuid,_fqxid);
			
		}
	}
}
