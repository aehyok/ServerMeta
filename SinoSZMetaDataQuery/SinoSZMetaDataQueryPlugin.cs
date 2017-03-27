using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using System.ComponentModel;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZMetaDataQuery
{
        [Description("中科富星基于元数据的查询插件!")]
        public class SinoSZMetaDataQueryPlugin : IPlugin, IMenuCommand
        {
                private IApplication application = null;
                private string name = "SinoSZMetaDataQuery";
                private string description = "基于元数据的查询";

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
                                description = value ;
                        }
                }

                public void Load()
                {
                       
                }

                public void UnLoad()
                {
                        
                }

                public void SuperLoad()
                {
                        
                }

                public event EventHandler<EventArgs> Loading;

                public void Load(FrmMenuGroup _menuGroup, string _xmlparam)
                {
                       
                }

                #endregion

                #region IMenuCommand Members

                public bool DoCommand(string _menuID,string _commandName,string _commandTitle,object _commandParam)
                {
                        return MenuController.DoCommand(_menuID,_commandName, _commandTitle,_commandParam as string,application);
                }

                #endregion

                #region IPlugin Members


                public List<MenuType> GetMenuDefines()
                {
                        List<MenuType> _ret = new List<MenuType>();
                        _ret.Add(new MenuType("固定查询功能", string.Format("{0}.FixQuery", this.Name), "<标题></标题><查询模型></查询模型>"));          
                        _ret.Add(new MenuType("自定义查询功能", string.Format("{0}.RelationQuery", this.Name), "<标题></标题><查询模型></查询模型>"));                       
                        _ret.Add(new MenuType("任务式自定义查询功能", string.Format("{0}.RelationQueryTask", this.Name), "<标题></标题><查询模型></查询模型>"));
                        _ret.Add(new MenuType("查询任务列表", string.Format("{0}.QueryTaskList", this.Name), ""));
			_ret.Add(new MenuType("数据比对功能", string.Format("{0}.DataCompare", this.Name), "<标题></标题><查询模型></查询模型>"));
                        _ret.Add(new MenuType("信息检索功能", string.Format("{0}.DataSearch", this.Name), "<查询模型></查询模型>"));
                        _ret.Add(new MenuType("指标查询功能", string.Format("{0}.GuideLineQuery", this.Name), "<指标ID></指标ID>"));
                        _ret.Add(new MenuType("指标查询功能(单指标)", string.Format("{0}.SingleGuideLineQuery", this.Name), "<标题></标题><指标ID></指标ID><默认值>变量名:值,变量名:值</默认值><合并列></合并列>"));
                        _ret.Add(new MenuType("指标查询功能(扩展)", string.Format("{0}.GuideLineQueryEx", this.Name), "<标题></标题><指标ID></指标ID>"));
                        _ret.Add(new MenuType("指标展示功能", string.Format("{0}.GuideLineShow", this.Name), "<指标ID></指标ID><参数></参数><可分组>true</可分组><标题></标题>"));
                        _ret.Add(new MenuType("指标分组展示功能", string.Format("{0}.GuideLineGroupShow", this.Name), "<分组>组名:组标题,组名2:组标题2</分组><指标>指标ID:指标标题:组名:图标名:参数</指标><指标>指标ID2:指标标题2:组名:图标名:参数</指标><标题></标题>"));
                        _ret.Add(new MenuType("指标分组展示功能(扩展)", string.Format("{0}.GuideLineGroupShow2", this.Name), "<分组>组名:组标题,组名2:组标题2</分组><指标>指标ID:指标标题:组名:图标名:参数</指标><指标>指标ID2:指标标题2:组名:图标名:参数</指标><标题></标题>"));
                        _ret.Add(new MenuType("门户展示功能", string.Format("{0}.PortalShow", this.Name), "<标题></标题><项目>项目1标题:项目指标ID:链接对象:参数</项目><项目>项目2标题:项目指标ID:链接对象:参数</项目>"));
                        _ret.Add(new MenuType("组合门户展示功能", string.Format("{0}.TreeComboPortalShow", this.Name), "<标题></标题><项目>序号:项目1标题:项目指标ID:链接对象:参数:父项目</项目><项目>序号:项目2标题:项目指标ID:链接对象:参数:父项目</项目>"));
                        _ret.Add(new MenuType("预警监督功能", string.Format("{0}.AlertMonitor", this.Name), "<标题></标题><指标ID></指标ID><参数>变量:变量名称:类型:顺序:宽度</参数><默认值>变量名:值,变量名:值</默认值>"));
                        _ret.Add(new MenuType("指标参数设置功能", string.Format("{0}.ParameterSetting", this.Name), "<标题></标题><指标ID></指标ID>"));

                        return _ret;
                }

                public FrmMenuItem GetMenuItem(string _commandName, string _displayTitle,string _param)
                {
                        MenuCommandDefine _md;
                        FrmMenuItem _menuItem = null;
                        switch (_commandName)
                        {
                                case "QueryTaskList":
                                        _md = new MenuCommandDefine("QueryTaskList", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "QueryTaskList",
                                        global::SinoSZMetaDataQuery.Properties.Resources.x2, 80, _md);
                                        break;
                                case "RelationQuery":
                                        _md = new MenuCommandDefine("RelationQuery", _displayTitle,this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "RelationQuery",
                                        global::SinoSZMetaDataQuery.Properties.Resources.x2, 80, _md);
                                        break;
                                case "FixQuery":
                                        _md = new MenuCommandDefine("FixQuery", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "FixQuery",
                                        global::SinoSZMetaDataQuery.Properties.Resources.x2, 80, _md);
                                        break;
                                case "RelationQueryTask":
                                        _md = new MenuCommandDefine("RelationQueryTask", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "RelationQueryTask",
                                        global::SinoSZMetaDataQuery.Properties.Resources.x2, 80, _md);
                                        break;
                                case "DataCompare":
                                        _md = new MenuCommandDefine("DataCompare", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "DataCompare",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b2, 80, _md);
                                        break;
                                case "DataSearch":
                                        _md = new MenuCommandDefine("DataSearch", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "DataSearch",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b, 80, _md);
                                        break;
                                case "GuideLineQuery":
                                        _md = new MenuCommandDefine("GuideLineQuery", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GuideLineQuery",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "SingleGuideLineQuery":
                                        _md = new MenuCommandDefine("SingleGuideLineQuery", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "SingleGuideLineQuery",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "GuideLineQueryEx":
                                        _md = new MenuCommandDefine("GuideLineQueryEx", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GuideLineQueryEx",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "GuideLineShow":
                                        _md = new MenuCommandDefine("GuideLineShow", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GuideLineShow",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "GuideLineGroupShow":
                                        _md = new MenuCommandDefine("GuideLineGroupShow", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GuideLineGroupShow",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "GuideLineGroupShow2":
                                        _md = new MenuCommandDefine("GuideLineGroupShow2", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "GuideLineGroupShow2",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "PortalShow":
                                        _md = new MenuCommandDefine("PortalShow", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "PortalShow",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "TreeComboPortalShow":
                                        _md = new MenuCommandDefine("TreeComboPortalShow", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "TreeComboPortalShow",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "AlertMonitor":
                                        _md = new MenuCommandDefine("AlertMonitor", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "AlertMonitor",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                                case "ParameterSetting":
                                        _md = new MenuCommandDefine("ParameterSetting", _displayTitle, this as IMenuCommand, _param);
                                        _menuItem = new FrmMenuItem(_displayTitle, "ParameterSetting",
                                        global::SinoSZMetaDataQuery.Properties.Resources.b28, 80, _md);
                                        break;
                        }
                        return _menuItem;
                }


                public object LoadPortalItem(string _portalItemName, string _param)
                {
                        return null;
                }
                #endregion



                #region IPlugin Members


         

                #endregion
        }
}
