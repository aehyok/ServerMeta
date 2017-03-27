using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace SinoSZJS.Base.InputModel
{
    [DataContract]
    public class MD_ChildEntity
    {
        [DataMember]
        public MD_InputModel MD_Child { get; set; }

        [DataMember]
        public MD_InputEntity ChildData { get; set; }


        [DataMember]
        public bool ChildSaveVisible { get; set; }

        /// <summary>
        /// 主模型名称
        /// </summary>
        [DataMember]
        public  string MainModelName{ get;set;}

        /// <summary>
        /// 主模型主键
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }

        /// <summary>
        /// 是否为线索
        /// </summary>
        [DataMember]
        public bool IsClue { get; set; }

        /// <summary>
        /// added by lqm 20130708 子模型列表选择模式
        /// </summary>
        [DataMember]
        public int SelectMode { get; set; }
    }
}
