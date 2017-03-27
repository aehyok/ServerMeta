using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    /// <summary>
    /// 目标单位实体类
    /// </summary>
    [DataContract]
    public class Flow_DirectionUnit
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 状态单位对应表的GUID（Flow_LOCATIONSTATEMAP）
        /// </summary>
        [DataMember]
        public string FLSMAPID { get; set; }

        /// <summary>
        /// 流程操作ID
        /// </summary>
        [DataMember]
        public string ActionId { get; set; }

        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// 目标单ID
        /// </summary>
        [DataMember]
        public string TargetUnitId { get; set; }

        /// <summary>
        /// 目标单位名
        /// </summary>
        [DataMember]
        public string TargetUnitName { get; set; }

        /// <summary>
        /// 可用规则ID
        /// </summary>
        [DataMember]
        public string RuleId { get; set; }

        /// <summary>
        /// 参数定义
        /// </summary>
        [DataMember]
        public string DataShowMeta { get; set; }

        public Flow_DirectionUnit() { }

        public Flow_DirectionUnit(string id, string targetUnitName, string unitId)
        {
            this.Id = id;
            this.TargetUnitName = targetUnitName;
            this.TargetUnitId = unitId;
        }

        public Flow_DirectionUnit(string id, string targetUnitName, string actionName, string dataShowMeta)
        {
            this.Id = id;
            this.ActionName = actionName;
            this.TargetUnitName = targetUnitName;
            this.DataShowMeta = dataShowMeta;
        }
    }
}
