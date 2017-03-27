using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
    [DataContract]
    public class Flow_DirectionUnit
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 状态单位对应表的GUID（Flow_LOCATIONSTATEMAP）
        /// </summary>
        [DataMember]
        public string FLSMAPID { get; set; }

        /// <summary>
        /// 流程操作ID
        /// </summary>
        [DataMember]
        public string ActionID { get; set; }

        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// 目标单ID
        /// </summary>
        [DataMember]
        public string TargetUnitID { get; set; }

        /// <summary>
        /// 目标单位名
        /// </summary>
        [DataMember]
        public string TargetUnitName { get; set; }

        /// <summary>
        /// 可用规则ID
        /// </summary>
        [DataMember]
        public string RuleID { get; set; }

        /// <summary>
        /// 参数定义
        /// </summary>
        [DataMember]
        public string DataShowMeta { get; set; }

        public Flow_DirectionUnit() { }

        public Flow_DirectionUnit(string _id, string _targetunitname, string _unitID)
        {
            this.ID = _id;
            this.TargetUnitName = _targetunitname;
            this.TargetUnitID = _unitID;
        }

        public Flow_DirectionUnit(string _id, string _targetunitname, string _actionname, string _datashowmeta)
        {
            this.ID = _id;
            this.ActionName = _actionname;
            this.TargetUnitName = _targetunitname;
            this.DataShowMeta = _datashowmeta;
        }
    }
}
