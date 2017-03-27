using System.Runtime.Serialization;

namespace SinoSZJS.Base.Instruments
{

    /// <summary>
    /// added by mhq 2014.01.09
    /// 文书类型（JSYW_WSDY_WSLX）
    /// </summary>
    [DataContract]
    public class Entity_DocType
    {
        /// <summary>
        /// 文书类型ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 文书分类ID（关联JSYW_WSDY_WSFL表）
        /// </summary>
        [DataMember]
        public string DocClassId { get; set; }

        /// <summary>
        /// 文书类型名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 案件系统文书编号
        /// </summary>
        [DataMember]
        public int CaseSysDocNo { get; set; }

        /// <summary>
        /// 文书所属单位ID
        /// </summary>
        [DataMember]
        public int DocOwnedUnitId { get; set; }

    }
}
