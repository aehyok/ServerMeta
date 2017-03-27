using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    ///自定义查询中子列表排序专用模型
    public  class MD_RelativeChildResult
    {
        /// <summary>
        /// 子列表数据
        /// </summary>
        public DataTable ChildDataTable { set; get; }

        /// <summary>
        /// 调用的查询模型的名称
        /// </summary>
        public string QModelName { set; get; }

        /// <summary>
        /// 查询条件列表字符串
        /// </summary>
        public string ConditionItemList { set; get; }

        /// <summary>
        /// 主表的查询字段列表
        /// </summary>
        public string MList { set; get; }

        /// <summary>
        /// 子表的查询字段列表
        /// </summary>
        public string CList { set; get; }

        /// <summary>
        /// 查询表达式
        /// </summary>
        public string ExpressValue { set; get; }

        /// <summary>
        /// 子表
        /// </summary>
        public MDQuery_ResultTable ChildTable { set; get; }
    }
}
