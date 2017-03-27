using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract(IsReference = true)]
    public class MD_QueryModel
    {
        public MD_QueryModel() { }
        public MD_QueryModel(string _qid, string _ns, string _qName, string _des, string _title, string _dw, bool _isFix, bool _isRelation,
                bool _isda, int _order, string _interface)
        {
            QueryModelID = _qid;
            NamespaceName = _ns;
            QueryModelName = _qName;
            Description = _des;
            DisplayTitle = _title;
            DWDM = _dw;
            IsFixQuery = _isFix;
            IsRelationQuery = _isRelation;
            IsDataAuditing = _isda;
            DisplayOrder = _order;
            QueryInterface = _interface;
            FullName = string.Format("{0}.{1}", NamespaceName, QueryModelName);
        }

        /// <summary>
        /// 本模型使用的查询接口
        /// </summary>
        [DataMember]
        public string QueryInterface { get; set; }


        /// <summary>
        /// 命名空间
        /// </summary>
        [DataMember]
        public MD_Namespace Namespace { get; set; }

        [DataMember]
        public string NamespaceName { get; set; }

        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 主表
        /// </summary>
        [DataMember]
        public MD_ViewTable MainTable { get; set; }


        /// <summary>
        /// 子表列表
        /// </summary>
        [DataMember]
        public IList<MD_ViewTable> ChildTables { get; set; }

        [DataMember]
        public IList<MD_View2ViewGroup> View2ViewGroup { get; set; }

        [DataMember]
        public IList<MD_View_GuideLine> View2GuideLines { get; set; }

        [DataMember]
        public IList<MD_View2App> View2Application { get; set; }

        /// <summary>
        /// 查询模型名称
        /// </summary>
        [DataMember]
        public string QueryModelName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [DataMember]
        public string DisplayTitle { get; set; }

        /// <summary>
        /// 节点编号
        /// </summary>
        [DataMember]
        public String DWDM { get; set; }

        /// <summary>
        /// 是否固定查询
        /// </summary>
        [DataMember]
        public bool IsFixQuery { get; set; }

        /// <summary>
        /// 是否关联查询
        /// </summary>
        [DataMember]
        public bool IsRelationQuery { get; set; }

        /// <summary>
        /// 是否数据审核
        /// </summary>
        [DataMember]
        public bool IsDataAuditing { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 查询模型ID
        /// </summary>
        [DataMember]
        public string QueryModelID { get; set; }

        [DataMember]
        public string EXTMeta { get; set; }

        public override string ToString()
        {
            return DisplayTitle;
        }
    }
}
