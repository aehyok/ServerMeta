using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;
using System.ComponentModel;

namespace SinoSZClientReport
{
    [Description("中科富星报表插件!")]
    public class SinoSZClientReportPlugin : IPlugin, IMenuCommand
    {
        private IApplication application = null;
        private string name = "SinoSZClientReport";
        private string description = "报表插件";

        #region 实现IMenuCommand 接口

        public bool DoCommand(string _menuID, string _commandName, string _commandTitle, object _commandParam)
        {
            return MenuController.DoCommand(_menuID, _commandName, _commandTitle, _commandParam as string, application);
        }

        #endregion

        #region 实现IPlugin接口

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

        }

        public void UnLoad()
        {

        }

        public event EventHandler<EventArgs> Loading;

        public void Load(FrmMenuGroup _menuGroup, string _xmlparam)
        {

        }

        /// <summary>
        /// 取插件中提供的功能菜单定义元数据
        /// </summary>
        /// <returns></returns>
        public List<MenuType> GetMenuDefines()
        {
            List<MenuType> _ret = new List<MenuType>();
            MenuType _mtItem = new MenuType("报表生成", string.Format("{0}.CreateReport", this.Name), "<标题></标题><报表名称>名称,名称</报表名称><报表类型>自定义报表,RS报表</报表类型><统计类型>年报表,月报表,季报表,半年报表,自定义</统计类型>");
            _mtItem.ChildRightItem.Add(new MenuRightItem(1, "生成报表"));
            _mtItem.ChildRightItem.Add(new MenuRightItem(2, "报表审核"));
            _ret.Add(_mtItem);
            _ret.Add(new MenuType("报表浏览", string.Format("{0}.BrowseReport", this.Name), "<标题></标题><报表名称>名称,名称</报表名称><报表类型>自定义报表,RS报表</报表类型><统计类型>年报表,月报表,季报表,半年报表,自定义</统计类型><统计单位根ID></统计单位根ID><是否显示未审核报表>YES,NO</是否显示未审核报表>"));
            _ret.Add(new MenuType("报表指标查询", string.Format("{0}.ReportGuideLineQuery", this.Name), "<标题></标题><报表名称>名称,名称</报表名称><报表类型>自定义报表,RS报表</报表类型>"));

            _ret.Add(new MenuType("数据审核", string.Format("{0}.DataCheck", this.Name), "<标题></标题><审核分组>分组ID1:标题,分组ID2:标题</审核分组><审核模型>查询模型1,显示标题,分组ID</审核模型><审核模型>查询模型2,显示标题,分组ID</审核模型>"));
            _ret.Add(new MenuType("审核公告", string.Format("{0}.DataCheckBoard", this.Name), "<标题></标题>"));

            return _ret;
        }

        /// <summary>
        /// 通过用户名取菜单
        /// </summary>
        /// <param name="_commandName"></param>
        /// <param name="_displayTitle"></param>
        /// <param name="_param"></param>
        /// <returns></returns>
        public FrmMenuItem GetMenuItem(string _commandName, string _displayTitle, string _param)
        {
            MenuCommandDefine _md;
            FrmMenuItem _menuItem = null;
            switch (_commandName)
            {
                case "CreateReport":  //报表生成
                    _md = new MenuCommandDefine("CreateReport", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "CreateReport",
                    global::SinoSZClientReport.Properties.Resources.d2, 80, _md);
                    break;
                case "BrowseReport": //报表浏览
                    _md = new MenuCommandDefine("BrowseReport", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "BrowseReport",
                    global::SinoSZClientReport.Properties.Resources.d3, 80, _md);
                    break;
              
                case "ReportGuideLineQuery": //报表指标查询
                    _md = new MenuCommandDefine("ReportGuideLineQuery", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "ReportGuideLineQuery",
                    global::SinoSZClientReport.Properties.Resources.d11, 80, _md);
                    break;

                case "DataCheck": //数据审核
                    _md = new MenuCommandDefine("DataCheck", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "DataCheck",
                    global::SinoSZClientReport.Properties.Resources.b15, 80, _md);
                    break;
                   
                case "DataCheckBoard": //审核公告
                    _md = new MenuCommandDefine("DataCheckBoard", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "DataCheckBoard",
                    global::SinoSZClientReport.Properties.Resources.x2, 80, _md);
                    break;
            }
            return _menuItem;
        }


        public object LoadPortalItem(string _portalItemName, string _param)
        {
            return null;
        }

        #endregion
    }
}
