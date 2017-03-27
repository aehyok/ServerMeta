using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSystemWatch.Base.Define
{
    [DataContract(IsReference = false)]
    public class SystemStateItem
    {
        public SystemStateItem(string SysName, string Url, string SysDescription)
        {
            SystemName = SysName;
            SystemDescription = SysDescription;
            SystemURL = Url;

            Connected = false;
            this.NodeState = new WatchNodeState();

        }
        /// <summary>
        /// 系统名称
        /// </summary>
        /// 
        [DataMember]
        public string SystemName { get; set; }
        /// <summary>
        /// 系统描述
        /// </summary>
        /// 
        [DataMember]
        public string SystemDescription { get; set; }
        /// <summary>
        /// WCF访问地址
        /// </summary>
        /// 
        [DataMember]
        public string SystemURL { get; set; }

        /// <summary>
        /// 是否连接成功
        /// </summary>
        /// 
        [DataMember]
        public bool Connected { get; set; }

        [DataMember]
        public string ConnectErrorMsg { get; set; }

        /** 各领域监控状态  0：未知  1：正常  2：警告 3：错误 
       */

        public int SystemFlag { get { return NodeState.SystemState; } }
        public int DataBaseFlag { get { return NodeState.DatabaseState; } }
        public int InterfaceFlag { get { return NodeState.InterfaceState; } }
        public int TaskFlag { get { return NodeState.TaskState; } }
        public int ApplicationFlag { get { return NodeState.ApplicationState; } }

        [DataMember]
        public WatchNodeState NodeState { get; set; }

        /// <summary>
        /// 数据库内容状态
        /// </summary>
        /// 
        [DataMember]
        public WatchNodeDBState DBState { get; set; }

        /// <summary>
        /// 节点有错误
        /// </summary>
        public bool NodeHaveError
        {
            get
            {
                return (NodeState.SystemState == 1) && (NodeState.InterfaceState == 1) && (NodeState.TaskState == 1)
                    && (NodeState.ApplicationState == 1) && (NodeState.DatabaseState == 1);
            }
        }
    }
}
