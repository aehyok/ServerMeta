using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.MenuType
{
        public class SinoMTC_MetaDataManager : MenuTypeBase
        {
                public SinoMTC_MetaDataManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.MenuTypeName = "综合系统_元数据管理类型";
                        this.MenuTypePluginName = "SinoSZMetaDataManager";
			StringBuilder _sb = new StringBuilder();
			
			this.MenuTypeParameters = _sb.ToString();
		}

                public override void CreateChildRight(System.Data.DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh)
                {
                     
                        base.AddRightData(_rightData, _fqxid + 10, "全局元数据设置", _fxh + 10, _menuid, _fqxid);
                        base.AddRightData(_rightData, _fqxid + 20, "节点元数据设置", _fxh + 20, _menuid, _fqxid);
                        base.AddRightData(_rightData, _fqxid + 30, "指标定义", _fxh + 30, _menuid, _fqxid);

                }
        }
}
