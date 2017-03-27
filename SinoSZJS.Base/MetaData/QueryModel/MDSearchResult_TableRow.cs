using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MDSearchResult_TableRow
    {
        /// <summary>
        /// 记录的主键值
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }
        /// <summary>
        /// 记录的行号
        /// </summary>
        [DataMember]
        public int RecordNum { get; set; }
        /// <summary>
        /// 记录所在的页号
        /// </summary>
        [DataMember]
        public int PageNum { get; set; }
        /// <summary>
        /// 为被检索的原始文本
        /// </summary>
        [DataMember]
        public string Doc_Text { get; set; }
        /// <summary>
        /// 原始文本增加突出显示的结果
        /// </summary>
        [DataMember]
        public string Doc_MarkUp { get; set; }
        /// <summary>
        /// 原始文本片段化之后增加突出显示的结果
        /// </summary>
        [DataMember]
        public string Doc_Snippet_Markup { get; set; }

        /// <summary>
        /// 数据预览
        /// </summary>
        [DataMember]
        public List<MDSearchResult_DataPreview> DataPreview { get; set; }
    }
}
