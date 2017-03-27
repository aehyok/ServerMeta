using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    /// <summary>
    /// 子表记录数
    /// </summary>
    [DataContract]
    public class MDQuery_ChildTableRowCount
    {

        /// <summary>
        /// 子表名
        /// </summary>
        [DataMember]
        public string TableName { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        [DataMember]
        public int RowCount { get; set; }

        public MDQuery_ChildTableRowCount() { }

        public MDQuery_ChildTableRowCount(string _tName, int _count)
        {
            TableName = _tName;
            RowCount = _count;
        }

    }
}
