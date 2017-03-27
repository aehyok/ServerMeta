using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    [DataContract(IsReference = true)]
    public class MD_InputModel_ColumnGroup
    {
        /// <summary>
        /// 录入模型Id
        /// </summary>
        [DataMember]
        public string ModelId { get; set; }
        
        /// <summary>
        /// 录入模型分组Id
        /// </summary>
        [DataMember]
        public string GroupId { get; set; }

        /// <summary>
        /// 分组显示名称
        /// </summary>
        [DataMember]
        public string DisplayTitle { get; set; }

        /// <summary>
        /// 分组显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 分组中字段列表
        /// </summary>
        [DataMember]
        public List<MD_InputModel_Column> Columns { get; set; }

        /// <summary>
        /// 分组类型
        /// </summary>
        [DataMember]
        public string GroupType { get; set; }

        /// <summary>
        /// 应用注册Url
        /// </summary>
        [DataMember]
        public string AppRegUrl { get; set; }

        /// <summary>
        /// 分组中的参数
        /// </summary>
        [DataMember]
        public string GroupParam { get; set; }

        /// <summary>
        /// 模型名称
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DisplayTitle;
        }

        public MD_InputModel_ColumnGroup() { }

        public MD_InputModel_ColumnGroup(string groupId, string modelId, string displayTitle, int displayOrder)
        {
            ModelId = modelId;
            GroupId = groupId;
            DisplayTitle = displayTitle;
            DisplayOrder = displayOrder;
        }
    }
}
