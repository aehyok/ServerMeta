using System.Runtime.Serialization;

namespace SinoSZJS.Base.Instruments
{
    /// <summary>
    /// added by mhq 2014.01.09
    /// 文书流程动作表（JSYW_WSDY_WSDZB）
    /// </summary>
    [DataContract]
    public class Entity_DocAction
    {
        /// <summary>
        /// 文书流程动作表ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书类型ID（关联JSYW_WSDY_WSLX表）
        /// </summary>
        [DataMember]
        public int DocTypeId { get; set; }

        /// <summary>
        /// 案件流程动作ID
        /// </summary>
        [DataMember]
        public string CaseActionId { get; set; }

        /// <summary>
        /// 文书所属单位ID
        /// </summary>
        [DataMember]
        public int DocOwnedUnitId { get; set; }

    }

}
