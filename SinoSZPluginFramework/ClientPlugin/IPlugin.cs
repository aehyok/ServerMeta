using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZPluginFramework
{
        /// <summary>
        /// 客户端插件
        /// </summary>
        public interface IPlugin
        {
                /// <summary>
                /// 应用程序
                /// </summary>
                IApplication Application { get;set;}
                /// <summary>
                /// 插件名称
                /// </summary>
                String Name { get;set;}
                /// <summary>
                /// 插件描述
                /// </summary>
                String Description { get;set;}
                /// <summary>
                /// 插件加载方法
                /// </summary>
                void Load();
                /// <summary>
                /// 超级管理员用户插件加载方法
                /// </summary>
                void SuperLoad();
                /// <summary>
                /// 插件卸载方法
                /// </summary>
                void UnLoad();
                /// <summary>
                /// 加载时事件
                /// </summary>
                event EventHandler<EventArgs> Loading;                
                /// <summary>
                /// 加载菜单组
                /// </summary>
                /// <param name="_menuGroup"></param>
                /// <param name="_xmlparam"></param>
                void Load(FrmMenuGroup _menuGroup,string _xmlparam);
                /// <summary>
                /// 取插件提供的菜单接口
                /// </summary>
                /// <returns></returns>
                List<MenuType> GetMenuDefines();

                /// <summary>
                /// 取Portal对象
                /// </summary>
                /// <param name="_portalItemName"></param>
                /// <param name="_param"></param>
                /// <returns></returns>
                object LoadPortalItem(string _portalItemName, string _param);

                /// <summary>
                /// 取指定命令菜单
                /// </summary>
                /// <param name="_commandName"></param>
                /// <returns></returns>
                FrmMenuItem GetMenuItem(string _commandName,string _displayTitle,string _param);
        }
}
