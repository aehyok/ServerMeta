using System.Collections.Generic;
using System.Runtime.Serialization;
using SinoSZJS.Base.V2.MetaData.EnumDefine;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	/// <summary>
	/// Ԫ���ݱ���
	/// </summary>
	[DataContract(IsReference = true)]
	public class MD_ViewTable
	{

		/// <summary>
		/// ��Ӧ�Ĳ�ѯģ��
		/// </summary>
		[DataMember]
		public string QueryModelID { get; set; }


		[DataMember]
		public MD_Table Table { get; set; }

		/// <summary>
		/// ��ͼ��ID
		/// </summary>
		[DataMember]
		public string ViewTableID { get; set; }


		[DataMember]
		public string TableID { get; set; }
		/// <summary>
		/// ��ͼ�������(������ӱ�)
		/// </summary>
		[DataMember]
		public MDType_ViewTable ViewTableType { get; set; }

		/// <summary>
		/// �ӱ����ʾ��ʽ
		/// </summary>
		[DataMember]
		public MDType_DisplayType DisplayType { get; set; }

		/// <summary>
		/// ��ϵ���ʽ
		/// </summary>
		[DataMember]
		public string RelationString { get; set; }

		/// <summary>
		/// �븸��Ĺ�ϵ����
		/// </summary>
		[DataMember]
		public MDType_ViewTableRelation ViewTableRelationType { get; set; }

		/// <summary>
		/// ��ʾ����
		/// </summary>
		[DataMember]
		public string DisplayTitle { get; set; }

		/// <summary>
		/// ��ʾ˳��
		/// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// �ڵ���
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }
		/// <summary>
		/// ��Ӧ�ĸ���
		/// </summary>
		[DataMember]
		public MD_ViewTable FatherTable { get; set; }

		/// <summary>
		/// �ӱ��б�
		/// </summary>
		[DataMember]
		public IList<MD_ViewTable> ChildTables { get; set; }

		/// <summary>
		/// ��ѯ����Ȩ(��ֵԽС��Խ��)
		/// </summary>
		[DataMember]
		public int Priority { get; set; }

		[DataMember]
		public string NamespaceName { get; set; }
		[DataMember]
		public string TableName { get; set; }

		[DataMember]
		public string IntegratedApp { get; set; }

		[DataMember]
		public IList<MD_ViewTableColumn> Columns { get; set; }
		[DataMember]
		public string FatherTableID { get; set; }

		public MD_ViewTable(string vtid, string viewid, string tid, string ttype, string relation, string condi,
			   string display, int order, string dw, string fid, int pri, int dtype, string integratedApp)
		{
			this.ViewTableID = vtid;
			this.QueryModelID = viewid;
			this.TableID = tid;
			this.ViewTableType = (ttype == "M") ? MDType_ViewTable.MainTable : MDType_ViewTable.ChildTable;
			this.RelationString = relation;
			this.ViewTableRelationType = (condi == "1") ? MDType_ViewTableRelation.SingleChildRecord : MDType_ViewTableRelation.MultiChildRecord;
			this.DisplayType = (dtype > 0) ? MDType_DisplayType.FormType : MDType_DisplayType.GridType;
			this.DisplayTitle = display;
			this.DisplayOrder = order;
			this.DWDM = dw;
			this.FatherTableID = fid;
			this.Priority = pri;
			this.IntegratedApp = integratedApp;
		}


		public override string ToString()
		{
			return DisplayTitle;
		}


	}
}
