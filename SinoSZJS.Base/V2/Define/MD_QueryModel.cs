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
		/// ��ģ��ʹ�õĲ�ѯ�ӿ�
		/// </summary>
		[DataMember]
		public string QueryInterface { get; set; }


		/// <summary>
		/// �����ռ�
		/// </summary>
		[DataMember]
		public MD_Namespace Namespace { get; set; }

		[DataMember]
		public string NamespaceName { get; set; }

		[DataMember]
		public string FullName { get; set; }

		/// <summary>
		/// ����
		/// </summary>
		[DataMember]
		public MD_ViewTable MainTable { get; set; }


		/// <summary>
		/// �ӱ��б�
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
		/// ��ѯģ������
		/// </summary>
		[DataMember]
		public string QueryModelName { get; set; }

		/// <summary>
		/// ����
		/// </summary>
		[DataMember]
		public string Description { get; set; }

		/// <summary>
		/// ��ʾ����
		/// </summary>
		[DataMember]
		public string DisplayTitle { get; set; }

		/// <summary>
		/// �ڵ���
		/// </summary>
		[DataMember]
		public String DWDM { get; set; }

		/// <summary>
		/// �Ƿ�̶���ѯ
		/// </summary>
		[DataMember]
		public bool IsFixQuery { get; set; }

		/// <summary>
		/// �Ƿ������ѯ
		/// </summary>
		[DataMember]
		public bool IsRelationQuery { get; set; }

		/// <summary>
		/// �Ƿ��������
		/// </summary>
		[DataMember]
		public bool IsDataAuditing { get; set; }
		/// <summary>
		/// ��ʾ˳��
		/// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// ��ѯģ��ID
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
