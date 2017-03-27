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
		/// ����ֶζ���
		/// </summary>
		[DataMember]
		public MD_TableColumn TableColumn { get; set; }


		/// <summary>
		/// ȡ��Ӧ�ı�ID
		/// </summary>
		[DataMember]
		public string TID { get; set; }

		[DataMember]
		public string TableName { get; set; }

		/// <summary>
		/// ���ֶ����ڵ���ͼ��
		/// </summary>
		[DataMember]
		public string ViewTableID { get; set; }

		/// <summary>
		/// ���ֶε�ID
		/// </summary>
		[DataMember]
		public string ViewTableColumnID { get; set; }

		/// <summary>
		/// �Ƿ����Ϊ��ѯ������ʾ
		/// </summary>
		[DataMember]
		public bool CanShowAsCondition { get; set; }

		/// <summary>
		/// �Ƿ����Ϊ��ѯ�����ʾ
		/// </summary>
		[DataMember]
		public bool CanShowAsResult { get; set; }

		/// <summary>
		/// �Ƿ�ΪĬ�Ͻ����
		/// </summary>
		[DataMember]
		public bool DefaultResult { get; set; }

		/// <summary>
		/// �Ƿ�Ϊ�̶���ѯ�ֶ�
		/// </summary>
		[DataMember]
		public bool IsFixQueryItem { get; set; }

		/// <summary>
		/// �Ƿ�����޸ģ�ֻ����������͵�VIEW��
		/// </summary>
		[DataMember]
		public bool CanModify { get; set; }

		/// <summary>
		/// �ڵ���
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }
		/// <summary>
		/// ��ʾ˳��
		/// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// ��ѯ����Ȩ(��ֵԽС��Խ��)
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
