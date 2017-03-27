using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MD_RelativeMainTable
    {
        /// <summary>
        /// 查询模型主表定义
        /// </summary>
        [DataMember]
        public MDQuery_ResultTable MainTable { set; get; }

        /// <summary>
        /// 查询模型主表数据
        /// </summary>
        [DataMember]
        public DataTable TableResult { set; get; }
    }
}
