using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MD_GuideLineSimpleParam
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        /// 
        [DataMember]
        public string ParameterName { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        [DataMember]
        public string ParameterValue { get; set; }
    }
}
