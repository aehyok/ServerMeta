using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 已制作文书列表
    /// </summary>
    [DataContract]
    public class DocList
    {
        /// <summary>
        /// 案件已有文书列表的文书Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书类型明细Id
        /// </summary>
        [DataMember]
        public string DocTypeDetailsId { get; set; }

        /// <summary>
        /// 文书类型名称
        /// </summary>
        [DataMember]
        public string DocTypeName { get; set; }


        public DocList(string id,string detailsId, string name)
        {
            this.Id = id;
            this.DocTypeDetailsId = detailsId;
            this.DocTypeName = name;
        }
    }
}
