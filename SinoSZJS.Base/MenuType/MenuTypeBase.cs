using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SinoSZJS.Base.MenuType
{
        public class MenuTypeBase
        {
                private string menuTypeName = "";
                private string menuTypeParameters = "";
                private string menuTypePluginName = "";
                public string MenuTypeName
                {
                        get { return menuTypeName; }
                        set { menuTypeName = value; }
                }

                public string MenuTypeParameters
                {
                        get { return menuTypeParameters; }
                        set { menuTypeParameters = value; }
                }

                public string MenuTypePluginName
                {
                        get { return menuTypePluginName; }
                        set { menuTypePluginName = value; }
                }

		public MenuTypeBase()
		{
		}

                public MenuTypeBase(string _name, string _cs)
                {
                        MenuTypeName = _name;
                        MenuTypeParameters = _cs;
                }

                /// <summary>
                /// 构造菜单类型
                /// </summary>
                /// <param name="_name">菜单类型名称</param>
                /// <param name="_cs">参数表</param>
                /// <param name="_pluginName">使用插件名称</param>
                public MenuTypeBase(string _name, string _cs,string _pluginName)
		{
			MenuTypeName = _name;
			MenuTypeParameters = _cs;
                        MenuTypePluginName = _pluginName;
		}

                virtual public void CreateChildRight(DataTable _rightData, decimal _fqxid, decimal _menuid, decimal _fxh)
                {

                }

                virtual public void AddRightData(DataTable _rightdt, decimal qxid, string qxmc, decimal xh, decimal menuid, decimal sjqxid)
                {
                        DataRow _newrow = _rightdt.NewRow();
                        _newrow["QXID"] = qxid;
                        _newrow["QXMC"] = qxmc;
                        _newrow["XH"] = xh;
                        _newrow["MENUID"] = menuid;
                        if (sjqxid != 0) _newrow["SJQXID"] = sjqxid;
                        _rightdt.Rows.Add(_newrow);
                }
        }
}
