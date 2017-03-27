
using System.Runtime.Serialization;
namespace SinoSZJS.Base.Instruments
{
    /// <summary>
    /// added by mhq 2014.01.09
    /// 文书配置表（JSYW_WSDY_WSPZB）
    /// </summary>
    [DataContract]
    public class Entity_DocConfig
    {
        /// <summary>
        /// 文书配置表ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        
        /// <summary>
        /// 文书类型ID（关联JSYW_WSDY_WSLX）
        /// </summary>
        [DataMember]
        public int DocTypeId { get; set; }
        
        /// <summary>
        /// 文书所属单位ID
        /// </summary>
        [DataMember]
        public int DocOwnedUnitId { get; set; }

        /// <summary>
        /// 签章路径
        /// </summary>
        [DataMember]
        public string SignPath { get; set; }
        
        /// <summary>
        /// 流程ID
        /// </summary>
        [DataMember]
        public string FlowId { get; set; }
        
        /// <summary>
        /// 文书字号
        /// </summary>
        [DataMember]
        public string IdentifyNo { get; set; }
        
    }
}
