using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ClientPlugin
{
        /// <summary>
        /// 菜单类型定义
        /// </summary>
        [Serializable]
        public class MenuType
        {
                /// <summary>
                /// 显示的汉字名称
                /// </summary>
                public string DisplayName = "";
                /// <summary>
                /// 命令名称　　　格式: 插件名.命令名
                /// </summary>
                public string TypeCommandName = "";
                /// <summary>
                /// 命令参数格式定义
                /// </summary>
                public string TypeParameterDefine = "";
                /// <summary>
                /// 构建函数
                /// </summary>
                /// <param name="_displayName"></param>
                /// <param name="_commandName"></param>
                /// <param name="_parameter"></param>
                public MenuType(string _displayName, string _commandName, string _parameter)
                {
                        DisplayName = _displayName;
                        TypeCommandName = _commandName;
                        TypeParameterDefine = _parameter;
                }

                public List<MenuRightItem> ChildRightItem = new List<MenuRightItem>();

                public override string ToString()
                {
                        return string.Format("{0}[{1}]",DisplayName,TypeCommandName);
                }
        }
}
