using System;
using System.Text;


namespace SinoSZJS.Base.MenuType
{
	/// <summary>
	/// MTC_WFWGDA 的摘要说明。
	/// </summary>
	public class MTC_WFWGDA :MenuTypeBase
	{
		public MTC_WFWGDA()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			this.MenuTypeName = "缉私综合_违法违规档案类型";

			StringBuilder _sb = new StringBuilder();
			_sb.Append("<标题></标题>");
			_sb.Append("<概要信息></概要信息><检索空间></检索空间>");
			_sb.Append("<数据比对></数据比对><目标筛选></目标筛选>");
			_sb.Append("<备用检索空间></备用检索空间>");
			_sb.Append("<涉案企业排名></涉案企业排名>");
			_sb.Append("<企业档案查询></企业档案查询><人员档案查询></人员档案查询><运输工具档案查询></运输工具档案查询>");
			_sb.Append("<走私态势分析></走私态势分析>");
			
			this.MenuTypeParameters = _sb.ToString();
		}

		public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh) {
			base.AddRightData(_rightData,_fqxid + 1,"信息检索",_fxh + 1,_menuid,_fqxid);
			
			base.AddRightData(_rightData,_fqxid + 20,"违法企业档案固定查询",_fxh + 20,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 21,"查看详细信息",_fxh + 21,_menuid,_fqxid +20);

			base.AddRightData(_rightData,_fqxid + 30,"违法人员档案固定查询",_fxh + 30,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 31,"查看详细信息",_fxh + 31,_menuid,_fqxid +30);

			base.AddRightData(_rightData,_fqxid + 40,"违法车辆档案固定查询",_fxh + 40,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 41,"查看详细信息",_fxh + 41,_menuid,_fqxid +40);

			base.AddRightData(_rightData,_fqxid + 50,"违法企业档案自定义查询",_fxh + 50,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 51,"查看详细信息",_fxh + 51,_menuid,_fqxid +50);

			base.AddRightData(_rightData,_fqxid + 60,"违法人员档案自定义查询",_fxh + 60,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 61,"查看详细信息",_fxh + 61,_menuid,_fqxid +60);

			base.AddRightData(_rightData,_fqxid + 70,"违法车辆档案自定义查询",_fxh + 70,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 71,"查看详细信息",_fxh + 71,_menuid,_fqxid +70);

			base.AddRightData(_rightData,_fqxid + 80,"违法企业排名",_fxh + 80,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 81,"查看详细信息",_fxh + 81,_menuid,_fqxid +80);

			base.AddRightData(_rightData,_fqxid + 90,"违法人员排名",_fxh + 90,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 91,"查看详细信息",_fxh + 91,_menuid,_fqxid +90);

			base.AddRightData(_rightData,_fqxid + 100,"违法车辆排名",_fxh + 100,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 101,"查看详细信息",_fxh + 101,_menuid,_fqxid +100);

			base.AddRightData(_rightData,_fqxid + 110,"违法情况统计",_fxh + 110,_menuid,_fqxid);
			base.AddRightData(_rightData,_fqxid + 111,"查看详细信息",_fxh + 111,_menuid,_fqxid +110);

			base.AddRightData(_rightData,_fqxid + 120,"目标筛选",_fxh + 120,_menuid,_fqxid);

			base.AddRightData(_rightData,_fqxid + 130,"数据比对",_fxh + 130,_menuid,_fqxid);
			

			
		}

	}
}
