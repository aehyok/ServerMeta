using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Define
{
    public class SystemSimpleInfoItem
    {
        /// <summary>
        /// 总体状态，由各领域监控状态决定，全1则正常，有3则为3，有2则为2，全零则为零
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 系统所在IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 系统监控服务端口
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /** 各领域监控状态  0：未知  1：正常  2：警告 3：错误 
         */

        /// <summary>
        /// 操作系统状态
        /// </summary>
        public string SystemState { get; set; }
        /// <summary>
        /// 数据库状态
        /// </summary>
        public string DatabaseState { get; set; }
        /// <summary>
        /// 应用系统状态
        /// </summary>
        public string ApplicationState { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public string TaskState { get; set; }
        /// <summary>
        /// 接口状态
        /// </summary>
        public string InterfaceState { get; set; }
    }
}
