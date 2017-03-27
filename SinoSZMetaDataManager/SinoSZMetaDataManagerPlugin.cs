using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.Reflection;
using System.Resources;
using System.Drawing;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZMetaDataManager
{
        [Description("This is SinoSZMetaData Manager Plugin!")]
        public class SinoSZMetaDataManagerPlugin : IPlugin, IMenuCommand
        {
                private IApplication application = null;
                private String name = "SinoSZMetaDataManager";
                private String description = "";


                #region IPlugin Members

                public IApplication Application
                {
                        get
                        {
                                return application;
                        }
                        set
                        {
                                application = value;
                        }
                }

                public string Name
                {
                        get
                        {
                                return name;
                        }
                        set
                        {
                                name = value;
                        }
                }

                public string Description
                {
                        get
                        {
                                return description;
                        }
                        set
                        {
                                description = value;
                        }
                }

                public void Load()
                {


                }

                public void SuperLoad()
                {
                        if (application != null && application.MainRibbon != null)
                        {
                                //添加一个主菜单                                
                                IMenuService menuService = (IMenuService)application.GetService(typeof(IMenuService));
                                if (menuService != null)
                                {
                                        FrmMenuPage _menuPage = new FrmMenuPage("MetaDataManagerPage", "元数据管理");
                                        menuService.AddMainMenuPage(_menuPage);
                                        FrmMenuGroup _menuGroup = new FrmMenuGroup("MetaDataManager", "元数据定义");
                                        menuService.AddMenuGroup(_menuPage, _menuGroup);
                                        //全局定义                      
                                        MenuCommandDefine _md = new MenuCommandDefine("GlobalDefine", "全局定义", this as IMenuCommand, null);
                                        FrmMenuItem _menuItem = new FrmMenuItem("全局定义", "GlobalDefine",
                                                global::SinoSZMetaDataManager.Properties.Resources.g1, 80, _md);
                                        menuService.AddMenuItem(_menuPage, _menuGroup, _menuItem);
                                        //节点定义
                                        _md = new MenuCommandDefine("NodeDefine", "节点定义", this as IMenuCommand, null);
                                        _menuItem = new FrmMenuItem("节点定义", "NodeDefine", global::SinoSZMetaDataManager.Properties.Resources.g2, 80, _md);
                                        menuService.AddMenuItem(_menuPage, _menuGroup, _menuItem);
                                        //指标定义
                                        _md = new MenuCommandDefine("GuideLineDefine", "指标定义", this as IMenuCommand, null);
                                        _menuItem = new FrmMenuItem("指标定义", "GuideLineDefine", global::SinoSZMetaDataManager.Properties.Resources.g3, 80, _md);
                                        menuService.AddMenuItem(_menuPage, _menuGroup, _menuItem);
                                }
                        }
                }

                /// <summary>
                /// 以参数方式加载
                /// </summary>
                /// <param name="_xmlparam"></param>                
                public void Load(FrmMenuGroup _menuGroup, string _xmlparam)
                {
                        if (application != null && application.MainRibbon != null)
                        {
                                //添加一个主菜单                                
                                IMenuService menuService = (IMenuService)application.GetService(typeof(IMenuService));
                                if (menuService != null)
                                {
                                        //全局定义                      
                                        MenuCommandDefine _md = new MenuCommandDefine("GlobalDefine", "全局定义", this as IMenuCommand, null);
                                        FrmMenuItem _menuItem = new FrmMenuItem("全局定义", "GlobalDefine",
                                                global::SinoSZMetaDataManager.Properties.Resources.g1, 80, _md);
                                        menuService.AddMenuItem(_menuGroup, _menuItem);


                                        //节点定义
                                        _md = new MenuCommandDefine("NodeDefine", "节点定义", this as IMenuCommand, null);
                                        _menuItem = new FrmMenuItem("节点定义", "NodeDefine", global::SinoSZMetaDataManager.Properties.Resources.g2, 80, _md);
                                        menuService.AddMenuItem(_menuGroup, _menuItem);

                                        //指标定义
                                        _md = new MenuCommandDefine("GuideLineDefine", "指标定义", this as IMenuCommand, null);
                                        _menuItem = new FrmMenuItem("指标定义", "GuideLineDefine", global::SinoSZMetaDataManager.Properties.Resources.g25, 80, _md);
                                        menuService.AddMenuItem(_menuGroup, _menuItem);

                                     
                                }
                        }
                }

                public FrmMenuItem GetMenuItem(string _commandName,string _displayTitle,string _param)
                {
                        MenuCommandDefine _md;
                        FrmMenuItem _menuItem = null;
                        switch (_commandName)
                        {
                                case "GlobalDefine":
                                        _md = new MenuCommandDefine("GlobalDefine", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GlobalDefine",
                                                global::SinoSZMetaDataManager.Properties.Resources.g1, 80, _md);                                        
                                        break;
                                case "NodeDefine":
                                        _md = new MenuCommandDefine("NodeDefine",_displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "NodeDefine", global::SinoSZMetaDataManager.Properties.Resources.g2, 80, _md);                                        
                                        break;
                                case "GuideLineDefine":
                                        _md = new MenuCommandDefine("GuideLineDefine", _displayTitle,this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GuideLineDefine", global::SinoSZMetaDataManager.Properties.Resources.g25, 80, _md);                                        
                                        break;
                                case "QueryModelEditor":
                                        _md = new MenuCommandDefine("QueryModelEditor", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "QueryModelEditor", global::SinoSZMetaDataManager.Properties.Resources.g25, 80, _md);
                                        break;
                        }
                        return _menuItem;
                }

                public void UnLoad()
                {
                        //清除菜单
                }

                public event EventHandler<EventArgs> Loading;

                public List<MenuType> GetMenuDefines()
                {
                        List<MenuType> _ret = new List<MenuType>();
                        _ret.Add(new MenuType("全局配置功能", string.Format("{0}.GlobalDefine", this.Name), ""));
                        _ret.Add(new MenuType("节点配置功能", string.Format("{0}.NodeDefine", this.Name), ""));
                        _ret.Add(new MenuType("指标定义功能", string.Format("{0}.GuideLineDefine", this.Name), ""));
                        _ret.Add(new MenuType("查询模型配置", string.Format("{0}.QueryModelEditor", this.Name), "<标题></标题><查询模型>查询模型1,查询模型2</查询模型>"));
                        return _ret;
                }

                #endregion


                #region IMenuCommand Members

                public bool DoCommand(string _menuID,string _commandName,string _commandTitle, object _commandParam)
                {
                        return MenuController.DoCommand(_menuID,_commandName, _commandTitle,application,_commandParam);
                }


                public object LoadPortalItem(string _portalItemName, string _param)
                {
                        return null;
                }

                #endregion
        }
}
