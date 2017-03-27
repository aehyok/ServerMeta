using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract(IsReference = true)]
	public class MD_QueryModel
	{
		public MD_QueryModel() { }
		public MD_QueryModel(string qid, string ns, string qName, string des, string title, string dw, bool isFix, bool isRelation,
				bool isda, int order, string inface)
		{
			QueryModelID = qid;
			NamespaceName = ns;
			QueryModelName = qName;
			Description = des;
			DisplayTitle = title;
			DWDM = dw;
			IsFixQuery = isFix;
			IsRelationQuery = isRelation;
			IsDataAuditing = isda;
			DisplayOrder = order;
			QueryInterface = inface;
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
