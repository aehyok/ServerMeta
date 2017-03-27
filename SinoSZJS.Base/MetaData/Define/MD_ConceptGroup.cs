using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    /// <summary>
    /// 概念组
    /// </summary>
    [DataContract(IsReference=true)]
    public class MD_ConceptGroup
    {

        public MD_ConceptGroup() { }
        public MD_ConceptGroup(string _name, string _des, string _dwdm, int _order)
        {
            Name = _name;
            Description = _des;
            DWDM = _dwdm;
            DisplayOrder = _order;
        }
        /// <summary>
        /// 概念组名称
        /// </summary>
        /// 
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 组描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 此概念属于的节点代码
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 组中包含的概念
        /// </summary>
        [DataMember]
        public List<MD_ConceptItem> Items { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name, Description);
        }
    }
}
