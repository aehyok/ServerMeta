using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Data;

namespace SinoSZJS.Base.GuideLine
{
    /// <summary>
    /// 指标实体定义
    /// </summary>
    public class GuideLineEntity
    {
        /// <summary>
        /// 指标id
        /// </summary>
        public string ZBID { set; get; }
        /// <summary>
        /// 指标参数键值对
        /// </summary>
        public Dictionary<string, object> Paras { set; get; }
        /// <summary>
        /// 指标定义
        /// </summary>
        public MD_GuideLine GuideLineDefine { set; get; }
        /// <summary>
        /// 指标结果集
        /// </summary>
        public DataTable ResultTable { set; get; }
    }
}
