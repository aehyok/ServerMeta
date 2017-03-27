using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.31 录入模型子模型
    /// </summary>
    [DataContract]
    public class MD_InputChild
    {
        /// <summary>
        /// 录入模型实体定义
        /// </summary>
        [DataMember]
        public MD_InputModel MD_ChildDefine { get; set; }

        /// <summary>
        /// 录入模型实体数据
        /// </summary>
        [DataMember]
        public MD_InputEntity MD_ChildData { get; set; }

        /// <summary>
        /// 录入模型实体主键
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }

        /// <summary>
        /// 子模型列表选择模式（单选框，还是多选框）
        /// </summary>
        [DataMember]
        public int SelectMode { get; set; }
    }
}
