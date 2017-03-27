using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract]
	public class MD_ViewTableColumn
	{
		public MD_ViewTableColumn(string vtcid, string vtid, string tcid, bool cancondi, bool canres, bool defaultshow,
				bool isfixitem, bool canmodify, string dw, int prio, int displayOrder)
		{

			ViewTableColumnID = vtcid;
			ViewTableID = vtid;
			ColumnID = tcid;
			CanShowAsCondition = cancondi;
			CanShowAsResult = canres;
			DefaultResult = defaultshow;
			IsFixQueryItem = isfixitem;
			CanModify = canmodify;
			DWDM = dw;
			Priority = prio;
			DisplayOrder = displayOrder;

		}

		[DataMember]
		public string ColumnID { get; set; }

		/// <summary>
		/// 表的字段定义
		/// </summary>
		[DataMember]
		public MD_TableColumn TableColumn { get; set; }


		/// <summary>
		/// 取对应的表ID
		/// </summary>
		[DataMember]
		public string TID { get; set; }

		[DataMember]
		public string TableName { get; set; }

		/// <summary>
		/// 本字段所在的视图表
		/// </summary>
		[DataMember]
		public string ViewTableID { get; set; }

		/// <summary>
		/// 本字段的ID
		/// </summary>
		[DataMember]
		public string ViewTableColumnID { get; set; }

		/// <summary>
		/// 是否可做为查询条件显示
		/// </summary>
		[DataMember]
		public bool CanShowAsCondition { get; set; }

		/// <summary>
		/// 是否可做为查询结果显示
		/// </summary>
		[DataMember]
		public bool CanShowAsResult { get; set; }

		/// <summary>
		/// 是否为默认结果项
		/// </summary>
		[DataMember]
		public bool DefaultResult { get; set; }

		/// <summary>
		/// 是否为固定查询字段
		/// </summary>
		[DataMember]
		public bool IsFixQueryItem { get; set; }

		/// <summary>
		/// 是否可以修改（只用于审核类型的VIEW）
		/// </summary>
		[DataMember]
		public bool CanModify { get; set; }

		/// <summary>
		/// 节点编号
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }
		/// <summary>
		/// 显示顺序
		/// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// 查询优先权(数值越小则越高)
		/// </summary>
		[DataMember]
		public int Priority { get; set; }

		public string DisplayTitle
		{
			get
			{
				if (TableColumn == null) return "";
				return TableColumn.DisplayTitle;
			}
			set
			{
				TableColumn.DisplayTitle = value;
			}
		}
	}
}
