using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;
using System.ComponentModel;
using SinoSZClientSysManager.Notify;

namespace SinoSZClientSysManager
{
    [Description("中科富星系统管理插件!")]
    public class SinoSZClientSysManagerPlugin : IPlugin, IMenuCommand
    {
        private IApplication application = null;
        private string name = "SinoSZClientSysManager";
        private string description = "系统管理插件";

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
            _ret.Add(new MenuType("系统运行日志", string.Format("{0}.SystemLog", this.Name), ""));
            _ret.Add(new MenuType("用户操作日志", string.Format("{0}.UserLog", this.Name), ""));
            _ret.Add(new MenuType("数据查询日志", string.Format("{0}.QueryLog", this.Name), ""));
            _ret.Add(new MenuType("通知通告", string.Format("{0}.Notify", this.Name), ""));
            _ret.Add(new MenuType("数据交换接口管理", string.Format("{0}.InterfaceManager_SJJH", this.Name), ""));
            _ret.Add(new MenuType("组织机构扩展信息管理", string.Format("{0}.OrganizeExtInfo", this.Name), "<标题></标题><扩展字段>字段名:显示名:类型,字段名2:显示名2:类型2</扩展字段>"));
            _ret.Add(new MenuType("数据加载监控提示邮件设置", string.Format("{0}.FSDataLoadAlertMailSet", this.Name), "<标题></标题><类型></类型>"));
            _ret.Add(new MenuType("后台工作任务管理", string.Format("{0}.TaskManager", this.Name), "<标题></标题><任务ID></任务ID><参数说明></参数说明>"));
            _ret.Add(new MenuType("工作日历", string.Format("{0}.WorkCalendar", this.Name), ""));
            _ret.Add(new MenuType("后台服务控制", string.Format("{0}.WinServiceWatch", this.Name), "<TITLE></TITLE><ServiceName></ServiceName>"));
            _ret.Add(new MenuType("IIS应用内存回收", string.Format("{0}.IISRecycle", this.Name), "<TITLE></TITLE><AppPoolName></AppPoolName>"));
            _ret.Add(new MenuType("通用接口管理", string.Format("{0}.GDSManager", this.Name), "<TITLE></TITLE>"));
           
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
                case "IISRecycle":
                    _md = new MenuCommandDefine("IISRecycle", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "IISRecycle",
                    global::SinoSZClientSysManager.Properties.Resources.e15, 80, _md);
                    break;
                case "WinServiceWatch":
                    _md = new MenuCommandDefine("WinServiceWatch", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "WinServiceWatch",
                    global::SinoSZClientSysManager.Properties.Resources.e15, 80, _md);
                    break;
                case "OrganizeExtInfo":
                    _md = new MenuCommandDefine("OrganizeExtInfo", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "OrganizeExtInfo",
                    global::SinoSZClientSysManager.Properties.Resources.e17, 80, _md);
                    break;
                case "SystemLog":  //角色管理
                    _md = new MenuCommandDefine("SystemLog", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "SystemLog",
                    global::SinoSZClientSysManager.Properties.Resources.e17, 80, _md);
                    break;
                case "UserLog": //岗位管理
                    _md = new MenuCommandDefine("UserLog", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "UserLog",
                     global::SinoSZClientSysManager.Properties.Resources.e18, 80, _md);
                    break;
                case "QueryLog": //查询日志
                    _md = new MenuCommandDefine("QueryLog", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "QueryLog",
                     global::SinoSZClientSysManager.Properties.Resources.e18, 80, _md);
                    break;
                case "Notify"://通知通告
                    _md = new MenuCommandDefine("Notify", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "Notify",
                     global::SinoSZClientSysManager.Properties.Resources.e18, 80, _md);
                    break;
                case "InterfaceManager_SJJH":
                    _md = new MenuCommandDefine("InterfaceManager_SJJH", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "InterfaceManager_SJJH",
                     global::SinoSZClientSysManager.Properties.Resources.e18, 80, _md);
                    break;
                case "FSDataLoadAlertMailSet":  //数据加载监控提示邮件设置
                    _md = new MenuCommandDefine("FSDataLoadAlertMailSet", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "FSDataLoadAlertMailSet",
                    global::SinoSZClientSysManager.Properties.Resources.e15, 80, _md);
                    break;
                case "TaskManager"://后台工作任务管理器
                    _md = new MenuCommandDefine("TaskManager", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "TaskManager",
                    global::SinoSZClientSysManager.Properties.Resources.e15, 80, _md);
                    break;
                case "WorkCalendar"://工作日历
                    _md = new MenuCommandDefine("WorkCalendar", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "WorkCalendar",
                   global::SinoSZClientSysManager.Properties.Resources.t7, 80, _md);
                    break;
                case "GDSManager":
                    _md = new MenuCommandDefine("GDSManager", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "GDSManager",
                   global::SinoSZClientSysManager.Properties.Resources.t7, 80, _md);
                    break;
            }
            return _menuItem;
        }


        public object LoadPortalItem(string _portalItemName, string _param)
        {
            switch (_portalItemName)
            {
                case "Notify":
                    UC_Notify _uc = new UC_Notify(_param, application);
                    return _uc;
                    break;

            }
            return null;
        }

        #endregion
    }
}
