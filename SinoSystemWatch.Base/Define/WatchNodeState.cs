using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSystemWatch.Base.Define
{
    [DataContract(IsReference = false)]
    public class WatchNodeState
    {

        /** 各领域监控状态  0：未知  1：正常  2：警告 3：错误 
      */
        [DataMember]
        /// <summary>
        /// 操作系统状态
        /// </summary>
        public int SystemState { get; set; }

        [DataMember]
        /// <summary>
        /// 数据库状态
        /// </summary>
        public int DatabaseState { get; set; }
        /// <summary>
        /// 应用系统状态
        /// </summary>
        /// 
        [DataMember]
        public int ApplicationState { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        /// 
        [DataMember]
        public int TaskState { get; set; }
        /// <summary>
        /// 接口状态
        /// </summary>
        /// 
        [DataMember]
        public int InterfaceState { get; set; }

        public WatchNodeState()
        {
            this.SystemState = 0;
            this.DatabaseState = 0;
            this.ApplicationState = 0;
            this.TaskState = 0;
            this.InterfaceState = 0;
        }

        public WatchNodeState(string _msg)
        {
            // TODO: Complete member initialization
            this.SystemState = int.Parse(_msg.Substring(0, 1));
            this.DatabaseState = int.Parse(_msg.Substring(1, 1));
            this.ApplicationState = int.Parse(_msg.Substring(2, 1));
            this.TaskState = int.Parse(_msg.Substring(3, 1));
            this.InterfaceState = int.Parse(_msg.Substring(4, 1));
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}", this.SystemState, this.DatabaseState, this.ApplicationState, this.TaskState, this.InterfaceState);
        }
    }
}
