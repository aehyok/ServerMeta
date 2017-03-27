using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 文书附加条件和附加动作表
    /// </summary>
    [DataContract]
    public class DocAppend
    {
        /// <summary>
        /// 附加条件
        /// </summary>
        [DataMember]
        public string AppendCondition { get; set; }

        /// <summary>
        /// 附加动作
        /// </summary>
        [DataMember]
        public string AppendAction { get; set; }
    }
}
