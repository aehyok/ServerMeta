using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZMetaDataManager
{
        public interface IControlMenu
        {
                /// <summary>
                /// 取制作菜单组
                /// </summary>
                /// <returns></returns>
                List<FrmMenuGroup> GetControlMenu();

                /// <summary>
                /// 是否有数据变更
                /// </summary>
                /// <returns></returns>
                bool HaveDataChanged();

                /// <summary>
                /// 触发数据变更事件
                /// </summary>
                event EventHandler<EventArgs> DataChanged;

                /// <summary>
                /// 刷新菜单
                /// </summary>
                event EventHandler<EventArgs> MenuChanged;

                /// <summary>
                /// 关闭控件
                /// </summary>
                /// <returns></returns>
                bool CloseControl();

                /// <summary>
                /// 执行命令
                /// </summary>
                /// <returns></returns>
                bool DoCommand(string _cmdName);
        }
}
