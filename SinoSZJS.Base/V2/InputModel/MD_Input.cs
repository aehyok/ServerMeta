using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.26录入模型
    /// </summary>
    [DataContract]
    public class MD_Input
    {
        /// <summary>
        /// 录入模型实体定义
        /// </summary>
        [DataMember]
        public MD_InputModel MD_Define { get; set; }

        /// <summary>
        /// 录入模型实体数据
        /// </summary>
        [DataMember]
        public MD_InputEntity MD_Data { get; set; }

        /// <summary>
        /// 录入模型实体主键
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }

        public MD_Input()
        {
            MD_Define = new MD_InputModel();
            MD_Data = new MD_InputEntity();
        }
    }
}
