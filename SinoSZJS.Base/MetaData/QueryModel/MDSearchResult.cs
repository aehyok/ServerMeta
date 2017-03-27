using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
       [DataContract]
    public class MDSearchResult
    {
        /// <summary>
        /// 本检索的Session ID
        /// </summary>
        [DataMember]
        public string SessionID { get; set; }
        /// <summary>
        /// 要检索的内容
        /// </summary>
        [DataMember]
        public string SearchText { get; set; }
        /// <summary>
        /// 要检索的KEY
        /// </summary>
        [DataMember]
        public string SearchKey { get; set; }
        /// <summary>
        /// 本检索的返回记录数
        /// </summary>
        [DataMember]
        public int TotalRecordCount { get; set; }
        /// <summary>
        /// 本检索返回的每页记录数
        /// </summary>
        [DataMember]
        public int RecordPerPage { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int TotalPageNum { get; set; }
        /// <summary>
        /// 本检索当前返回的页号
        /// </summary>
        [DataMember]
        public int CurrentPageNum { get; set; }
        /// <summary>
        /// 结果记录
        /// </summary>
        [DataMember]
        public List<MDSearchResult_TableRow> ResultRows { get; set; }


    }
}
