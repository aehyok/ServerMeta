using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZJS.Base.MenuType;
using SinoSZJS.Base.Authorize;
using System.Windows.Forms;
using System.Drawing;
using SinoSZJS.Base;
using System.Linq;

namespace SinoSZClientBase
{
    /// <summary>
    /// SinoSZ 菜单服务
    /// </summary>
    public class SinoMenuService : MenuService
    {
        protected Dictionary<string, FrmMenuItem> MenuDict = new Dictionary<string, FrmMenuItem>();
        protected List<SinoMenuItem> UserMenuList = null;
        public SinoMenuService(IApplication _application)
            : base(_application)
        {
        }

        /// <summary>
        /// 当加载菜单时发生错误
        /// </summary>
        public event EventHandler<CommonEventArgs> LoadError;
        virtual protected void RaiseLoadErrord(CommonEventArgs _args)
        {
            if (LoadError != null)
            {
                LoadError(this, _args);
            }
        }

        /// <summary>
        /// 通过元数据加载菜单
        /// </summary>
        public void LoadMenus()
        {
            //IMenuService menuService = (IMenuService)application.GetService(typeof(IMenuService));
            MainMenuPages.Clear();
            MenuDict.Clear();

            using (CommonService.CommonServiceClient _cs = new CommonService.CommonServiceClient())
            {
                UserMenuList = _cs.GetAllMenus(SessionClass.CurrentSinoUser.CurrentPost.PostID).ToList<SinoMenuItem>();
            }
            if (UserMenuList != null)
            {

                var _TopLevelMenuList = from _c in UserMenuList
                                        where _c.FatherID == "0"
                                        orderby _c.DisplayOrder
                                        select _c;
                foreach (SinoMenuItem _smi in _TopLevelMenuList)
                {
                    if (_smi.MenuType.Length > 3 && _smi.MenuType.Substring(0, 3) == "WEB")
                    {
                        //这是WEB的菜单

                    }
                    else if (_smi.MenuType.Length > 3 && _smi.MenuType.Substring(0, 3) == "SL_")
                    {
                        //这是Silverlight的菜单 
                    }
                    else
                    {
                        FrmMenuPage _fmp = new FrmMenuPage(_smi.MenuID, _smi.MenuTitle, _smi.CanUse);
                        this.AddMainMenuPage(_fmp);
                        AddSubMenu(_smi, UserMenuList, _fmp);
                    }
                }
            }
        }
        private void AddSubMenu(SinoMenuItem _fmenuitem, List<SinoMenuItem> _menuList, FrmMenuPage _fmp)
        {
            //SinoMenuFatherFinder _finder = new SinoMenuFatherFinder(_fmenuitem.MenuID);
            //List<SinoMenuItem> _subMenuList = _menuList.FindAll(new Predicate<SinoMenuItem>(_finder.FindByFather));
            //_subMenuList.Sort(new SinoMenuComparer());

            var _subMenuList = from _c in _menuList
                               where _c.FatherID == _fmenuitem.MenuID
                               orderby _c.DisplayOrder
                               select _c;
            foreach (SinoMenuItem _smi in _subMenuList)
            {
                FrmMenuGroup _fmg = new FrmMenuGroup(_smi.MenuID, _smi.MenuTitle, _smi.CanUse);
                this.AddMenuGroup(_fmp, _fmg);
                if (_smi.MenuType != "")
                {
                    MenuTypeBase _mtype = MenuTypeCreator.CreateMenuType(_smi.MenuType);
                    IPluginService pluginService = (IPluginService)application.GetService(typeof(IPluginService));
                    IPlugin _plugin = pluginService.GetPluginInstance(_mtype.MenuTypePluginName);
                    if (_plugin == null)
                    {
                        RaiseLoadErrord(new CommonEventArgs(string.Format("未找到组菜单定义:{0}", _mtype)));
                    }
                    else
                    {
                        _plugin.Load(_fmg, _smi.MenuParameter);
                    }
                }
                else
                {
                    this.AddSubMenuItem(_smi, _menuList, _fmg);
                }

            }
        }

        private void AddSubMenuItem(SinoMenuItem _fmenuitem, List<SinoMenuItem> _menuList, FrmMenuGroup _fmg)
        {

            //SinoMenuFatherFinder _finder = new SinoMenuFatherFinder(_fmenuitem.MenuID);
            //List<SinoMenuItem> _subMenuList = _menuList.FindAll(new Predicate<SinoMenuItem>(_finder.FindByFather));
            //_subMenuList.Sort(new SinoMenuComparer());

            var _subMenuList = from _c in _menuList
                               where _c.FatherID == _fmenuitem.MenuID
                               orderby _c.DisplayOrder
                               select _c;
            foreach (SinoMenuItem _smi in _subMenuList)
            {
                if (_smi.CanUse)
                {
                    FrmMenuItem _mitem = null;
                    if (_smi.MenuType == "")
                    {
                        _mitem = new FrmMenuItem(_smi.MenuID, _smi.MenuTitle, "", global::SinoSZClientBase.Properties.Resources.foward2, _smi.CanUse, null);

                    }
                    else
                    {
                        #region 有类型定义

                        string[] _typeStrs = _smi.MenuType.Split('.');
                        if (_typeStrs.Length > 1)
                        {
                            string _pluginName = _typeStrs[0];
                            string _commandName = _typeStrs[1];
                            IPluginService pluginService = (IPluginService)application.GetService(typeof(IPluginService));
                            IPlugin _plugin = pluginService.GetPluginInstance(_pluginName);
                            if (_plugin == null)
                            {
                                RaiseLoadErrord(new CommonEventArgs(string.Format("未找到菜单定义用的插件:{0}", _pluginName)));
                                _mitem = new FrmMenuItem(_smi.MenuID, _smi.MenuTitle, "", global::SinoSZClientBase.Properties.Resources.foward2, _smi.CanUse, null);

                            }
                            else
                            {
                                _mitem = _plugin.GetMenuItem(_commandName, _smi.MenuTitle, _smi.MenuParameter);
                                if (_mitem == null)
                                {
                                    RaiseLoadErrord(new CommonEventArgs(string.Format("插件{1}中未找到菜单定义用的:{0}", _commandName, _pluginName)));
                                    _mitem = new FrmMenuItem(_smi.MenuID, _smi.MenuTitle, "", global::SinoSZClientBase.Properties.Resources.foward2, _smi.CanUse, null);

                                }
                                else
                                {
                                    _mitem.MenuID = _smi.MenuID;
                                }
                            }
                        }
                        #endregion
                    }

                    if (_mitem != null)
                    {
                        MenuDict.Add(_smi.MenuID, _mitem);
                        if (_smi.IconName != "-1")
                        {
                            Image _mIcon = SinoSZResources.GetIcon(_smi.IconName);
                            if (_mIcon != null)
                            {
                                _mitem.MenuIcon = _mIcon;
                            }
                        }
                        this.AddMenuItem(_fmg, _mitem);
                        _mitem.ChildMenus = CreateChildItems(_mitem, _menuList);
                    }
                }
            }
        }

        /// <summary>
        /// 建三级子菜单记录
        /// </summary>
        /// <param name="_mitem"></param>
        /// <param name="_menuList"></param>
        /// <returns></returns>
        private List<FrmMenuItem> CreateChildItems(FrmMenuItem _fmenuitem, List<SinoMenuItem> _menuList)
        {
            FrmMenuItem _mitem = null;
            List<FrmMenuItem> _ret = new List<FrmMenuItem>();
            //SinoMenuFatherFinder _finder = new SinoMenuFatherFinder(_fmenuitem.MenuID);
            //List<SinoMenuItem> _subMenuList = _menuList.FindAll(new Predicate<SinoMenuItem>(_finder.FindByFather));
            //_subMenuList.Sort(new SinoMenuComparer());
            var _subMenuList = from _c in _menuList
                               where _c.FatherID == _fmenuitem.MenuID
                               orderby _c.DisplayOrder
                               select _c;
            foreach (SinoMenuItem _smi in _subMenuList)
            {
                if (_smi.CanUse)
                {
                    if (_smi.MenuType == "")
                    {
                        _mitem = new FrmMenuItem(_smi.MenuID, _smi.MenuTitle, "", global::SinoSZClientBase.Properties.Resources.foward2, _smi.CanUse, null);

                    }
                    else
                    {
                        #region 有类型定义

                        string[] _typeStrs = _smi.MenuType.Split('.');
                        if (_typeStrs.Length > 1)
                        {
                            string _pluginName = _typeStrs[0];
                            string _commandName = _typeStrs[1];
                            IPluginService pluginService = (IPluginService)application.GetService(typeof(IPluginService));
                            IPlugin _plugin = pluginService.GetPluginInstance(_pluginName);
                            if (_plugin == null)
                            {
                                RaiseLoadErrord(new CommonEventArgs(string.Format("未找到菜单定义用的插件:{0}", _pluginName)));
                                _mitem = new FrmMenuItem(_smi.MenuID, _smi.MenuTitle, "", global::SinoSZClientBase.Properties.Resources.foward2, _smi.CanUse, null);

                            }
                            else
                            {
                                _mitem = _plugin.GetMenuItem(_commandName, _smi.MenuTitle, _smi.MenuParameter);
                                _mitem.MenuID = _smi.MenuID;
                            }
                        }
                        #endregion
                    }
                    _ret.Add(_mitem);
                    _mitem.ChildMenus = CreateChildItems(_mitem, _menuList);
                }
            }
            return _ret;
        }



        public void LoadStartupPage()
        {
            List<firstPageItem> _startupMenus;
            using (CommonService.CommonServiceClient _cs = new CommonService.CommonServiceClient())
            {
                _startupMenus = _cs.GetfirstPage().ToList<firstPageItem>();
            }
            foreach (firstPageItem _menu in _startupMenus)
            {
                if (MenuDict.ContainsKey(_menu.ItemParam))
                {
                    FrmMenuItem _mitem = MenuDict[_menu.ItemParam];
                    if (_mitem.MenuCommand != null) _mitem.MenuCommand.RunCommand(_mitem.MenuID);
                }
            }

        }
    }
}
