using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.AssistCase
{
    /// <summary>
    /// 辅助办案  added by  lqm 2012/11/19
    /// </summary>
    [DataContract]
    public class AssistGuideLine
    {

        [DataMember]
        public string GridViewName { get; set; }
        /// <summary>
        /// 每个Tab页的结果集
        /// </summary>
        [DataMember]
        public DataTable ResultTable { get; set; }

        /// <summary>
        /// 每个Tab页的字段列表
        /// </summary>
        [DataMember]
        public MD_GuideLineFieldGroup FieldGroup { get; set; }

        /// <summary>
        /// 指标ID
        /// </summary>
        [DataMember]
        public string GuideLineID { get; set; }

        //[DataMember]
        //public MD_GuideLine MD_GLine { get; set; }

        [DataMember]
        List<MDQuery_GuideLineParameter>  ListGuideLineParams { get; set; }

        [DataMember]
        public List<string> GuideIDList { get; set; }

        [DataMember]
        public bool EnableScroll { get; set; }
    }
}
