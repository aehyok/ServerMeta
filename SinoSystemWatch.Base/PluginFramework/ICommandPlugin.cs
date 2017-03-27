using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.PluginFramework
{
    public interface ICommandPlugin
    {
        /// <summary>
        /// 命令处理插件
        /// </summary>
        String Name { get; }

        String Description { get; }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="Parameters">执行参数</param>
        /// <returns>返回值</returns>
        byte[] DoCommand(byte[] Parameters);
    }
}
