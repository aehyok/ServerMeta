using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;
using System.ComponentModel;

namespace SinoSZClientUser
{
    [Description("中科富星用户及授权管理插件!")]
    public class SinoSZClientUserPlugin : IPlugin, IMenuCommand
    {
        private IApplication application = null;
        private string name = "SinoSZClientUser";
        private string description = "用户及授权管理插件";

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
            _ret.Add(new MenuType("角色管理", string.Format("{0}.RoleManager", this.Name), "<标题></标题><查询模型></查询模型>"));
            _ret.Add(new MenuType("岗位管理", string.Format("{0}.PostManager", this.Name), ""));
            _ret.Add(new MenuType("用户管理", string.Format("{0}.UserManager", this.Name), "<可添加></可添加>"));
            _ret.Add(new MenuType("三统一用户映射", string.Format("{0}.UserMappingCUPAA", this.Name), "<标题></标题><查询模型></查询模型>"));
            _ret.Add(new MenuType("用户手机号码管理", string.Format("{0}.UserMobileManager", this.Name), "<标题></标题>"));
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
                case "RoleManager":  //角色管理
                    _md = new MenuCommandDefine("RoleManager", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "RelationQuery",
                    global::SinoSZClientUser.Properties.Resources.e1, 80, _md);
                    break;
                case "PostManager": //岗位管理
                    _md = new MenuCommandDefine("PostManager", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "RelationQuery",
                     global::SinoSZClientUser.Properties.Resources.e4, 80, _md);
                    break;
                case "UserManager": //用户管理
                    _md = new MenuCommandDefine("UserManager", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "RelationQuery",
                     global::SinoSZClientUser.Properties.Resources.e10, 80, _md);
                    break;
                case "UserMobileManager":
                    _md = new MenuCommandDefine("UserMobileManager", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "UserMobileManager",
                     global::SinoSZClientUser.Properties.Resources.e20, 80, _md);
                    break;
                case "UserMappingCUPAA":
                    _md = new MenuCommandDefine("UserMappingCUPAA", _displayTitle, this as IMenuCommand, _param);
                    _menuItem = new FrmMenuItem(_displayTitle, "UserMappingCUPAA",
                     global::SinoSZClientUser.Properties.Resources.e4, 80, _md);
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
