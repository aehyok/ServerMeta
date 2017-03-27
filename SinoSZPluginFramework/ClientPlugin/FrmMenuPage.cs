using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
        public class FrmMenuPage
        {
                private string _pageName;
                private string _pageTitle;
                private IList<FrmMenuGroup> _menuGroups;
                private object _tag = null;
                private bool _canUse = true;

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
                /// 页名称
                /// </summary>
                public string PageName
                {
                        get { return _pageName; }
                        set { _pageName = value; }
                }

                /// <summary>
                /// 菜单页显示名称
                /// </summary>
                public string PageTitle
                {
                        get { return _pageTitle; }
                        set { _pageTitle = value;}
                }

                /// <summary>
                /// 包含的下级菜单组
                /// </summary>
                public IList<FrmMenuGroup> MenuGroups
                {
                        get { return this._menuGroups; }
                        set { this._menuGroups = value; }
                }

                /// <summary>
                /// 构造菜单页
                /// </summary>
                /// <param name="_name">名称</param>
                public FrmMenuPage(string _name)
                {
                        this._pageName = _name;
                        this._pageTitle = _name;
                }

                /// <summary>
                /// 构造菜单页
                /// </summary>
                /// <param name="_name">名称</param>
                /// <param name="_text">显示名称</param>
                public FrmMenuPage(string _name,string _text)
                {
                        this._pageName = _name;
                        this._pageTitle = _text;

                }

                /// <summary>
                /// 构造菜单页
                /// </summary>
                /// <param name="_name">名称</param>
                /// <param name="_text">显示名称</param>
                /// <param name="_can">可否使用</param>
                public FrmMenuPage(string _name, string _text,bool _can)
                {
                        this._pageName = _name;
                        this._pageTitle = _text;
                        this._canUse = _can;
                }

                
        }
}
