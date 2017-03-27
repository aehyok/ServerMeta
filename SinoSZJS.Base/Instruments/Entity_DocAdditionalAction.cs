using System.Runtime.Serialization;

namespace SinoSZJS.Base.Instruments
{
    /// <summary>
    /// added by mhq 2014.01.09
    /// 文书审批附加动作表（JSYW_WSDY_WSSPFJDZB）
    /// </summary>
    [DataContract]
    public class Entity_DocAdditionalAction
    {
        /// <summary>
        /// 文书审批附加动作表ID
        /// </summary>
        [DataMember]
        public string Id {get;set; }

        /// <summary>
        /// 动作ID
        /// </summary>
        [DataMember]
        public string ActionId { get; set; }
        
        /// <summary>
        /// 附加条件
        /// </summary>
        [DataMember]
        public string AdditionalCondition { get; set; }

        /// <summary>
        /// 附加动作
        /// </summary>
        [DataMember]
        public string AdditionalAction { get; set; }
        
        /// <summary>
        /// 文书所属单位ID
        /// </summary>
        [DataMember]
        public int DocOwnedUnitId { get; set; }

    }
}
