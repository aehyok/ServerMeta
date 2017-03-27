using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
    public interface ITaskPlugin
    {
        /// <summary>
        /// 任务插件名称
        /// </summary>
        String Name { get; }

        String Description { get; }
        /// <summary>
        /// 取任务对象
        /// </summary>
        /// <param name="_rwid">任务ID</param>
        /// <param name="_param">任务参数</param>
        /// <returns></returns>
        Object GetTaskObject(string _rwid, string _param);
    }
}
