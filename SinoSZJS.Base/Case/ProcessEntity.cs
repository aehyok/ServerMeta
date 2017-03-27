using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Runtime.Serialization;
using SinoSZJS.Base.Flow;

namespace SinoSZJS.Base.Case
{
    /// <summary>
    /// 处理实体
    /// </summary>
    [DataContract]
    public class ProcessEntity
    {
        [DataMember]
        /// <summary>
        /// 目标单位ID
        /// </summary>
        public string TargetDWID { get; set; }
        [DataMember]
        /// <summary>
        /// 实体ID
        /// </summary>
        public string ID { get; set; }
        [DataMember]
        /// <summary>
        /// 动作命令
        /// </summary>
        public string CommandName { get; set; }
        [DataMember]
        /// <summary>
        /// 连接详细信息ID
        /// </summary>
        public string InfoID { get; set; }
        /// <summary>
        /// 动作实体
        /// </summary>
        [DataMember]
        public ActionEntity Action { set; get; }

        public ProcessEntity() { }

        public ProcessEntity(string _targetDWID, string _id, string _commandName, string _infoID)
        {
            this.TargetDWID = _targetDWID;
            this.ID = _id;
            this.CommandName = _commandName;
            this.InfoID = _infoID;
        }
        public ProcessEntity(string _targetDWID, string _id, ActionEntity action, string _infoID)
        {
            this.TargetDWID = _targetDWID;
            this.ID = _id;
            this.InfoID = _infoID;
            this.Action = action;
        }


    }
}
