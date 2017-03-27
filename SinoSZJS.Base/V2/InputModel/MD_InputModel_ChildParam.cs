using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.25 子模型参数列表
    /// </summary>
    [DataContract]
    public class MD_InputModel_ChildParam
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        
        /// <summary>
        /// 参数数据类型
        /// </summary>
        [DataMember]
        public string DataType { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        public MD_InputModel_ChildParam() { }
        public MD_InputModel_ChildParam(string name, string type, string value)
        {
            Name = name;
            DataType = type;
            Value = value;
        }
    }
}
