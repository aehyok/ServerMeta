using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
        public class FrmMenuGroup
        {
                private string _groupName;
                private string _displayTitle;
                private IList<FrmMenuItem> _menuItems;
                private bool _canUse = true;
                private object _tag = null;

                /// <summary>
                /// 可否使用
                /// </summary>
                public bool CanUse
                {
                        get { return _canUse; }
                        set { _canUse = value; }
                }

                /// <summary>
                /// 对象
                /// </summary>
                public object Tag
                {
                        get { return _tag; }
                        set { _tag = value; }
                }

                /// <summary>
                /// 组名称
                /// </summary>
                public string GroupName
                {
                        get { return _groupName; }
                        set { _groupName = value; }
                }

                /// <summary>
                /// 包含的菜单项
                /// </summary>
                public IList<FrmMenuItem> MenuItems
                {
                        get { return _menuItems; }
                        set { _menuItems = value; }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public string DisplayTitle
                {
                        get { return _displayTitle; }
                        set { _displayTitle = value; }
                }

                /// <summary>
                /// 构造菜单组
                /// </summary>
                /// <param name="_gname"></param>
                public FrmMenuGroup(string _gname)
                {
                        this._displayTitle = _gname;
                        this._groupName = _gname;
                }

                /// <summary>
                /// 构造菜单组
                /// </summary>
                /// <param name="_gname"></param>
                /// <param name="_display"></param>
                public FrmMenuGroup(string _gname,string _display)
                {
                        this._groupName = _gname;
                        this._displayTitle = _display;
                }

                /// <summary>
                /// 构造菜单组
                /// </summary>
                /// <param name="_gname"></param>
                /// <param name="_display"></param>
                /// <param name="_can"></param>
                public FrmMenuGroup(string _gname, string _display,bool _can)
                {
                        this._groupName = _gname;
                        this._displayTitle = _display;
                        this.CanUse = _can;
                }
        }
}
