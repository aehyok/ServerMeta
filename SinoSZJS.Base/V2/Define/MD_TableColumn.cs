using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract]
	public class MD_TableColumn
	{

		public MD_TableColumn(string _tcid, string _tid, string _cname, bool _isnull, string _ctype, int _preci,
				int _sca, int _len, string _refd, string _dmblevel, int _secretlevel, string _displaytitle,
				string _displayformat, int _displaylength, int _displayheight, int _displayorder, bool _candisplay,
				int _colwidth, string _dw, string _tag, string _refword)
		{
			ColumnID = _tcid;
			TID = _tid;
			ColumnName = _cname;
			IsNullable = _isnull;
			ColumnType = _ctype;
			Precision = _preci;
			Scale = _sca;
			Length = _len;
			RefDMB = _refd.ToUpper();
			this.DMBLevelFormat = _dmblevel;
			SecretLevel = _secretlevel;
			DisplayTitle = _displaytitle.Substring(0, (_displaytitle.Length > 50) ? 50 : _displaytitle.Length);
			DisplayFormat = _displayformat;
			DisplayLength = _displaylength;
			DisplayHeight = _displayheight;
			DisplayOrder = _displayorder;
			CanDisplay = _candisplay;
			ColWidth = _colwidth;
			DWDM = _dw;
			this.CTag = _tag;
			RefWordTableName = _refword;
		}

		[DataMember]
		public string TID { get; set; }

		/// <summary>
		/// ���ֶε�ID
		/// </summary>
		[DataMember]
		public string ColumnID { get; set; }

		/// <summary>
		/// �ֶ�����
		/// </summary>
		[DataMember]
		public string ColumnName { get; set; }

		/// <summary>
		/// �ֶο��
		/// </summary>
		[DataMember]
		public int ColWidth { get; set; }

		/// <summary>
		/// �ֶΰ����ĸ���
		/// </summary>
		[DataMember]
		public string CTag { get; set; }

		/// <summary>
		/// ��ʾ��ʽ
		/// </summary>
		[DataMember]
		public string DisplayFormat { get; set; }

		/// <summary>
		/// ��ʾ�и߶�
		/// </summary>
		[DataMember]
		public int DisplayHeight { get; set; }

		/// <summary>
		/// ��ʾ����
		/// </summary>
		[DataMember]
		public int DisplayLength { get; set; }

		/// <summary>
		/// ��ʾ˳��
		/// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// ��ʾ����
		/// </summary>
		[DataMember]
		public string DisplayTitle { get; set; }
		/// <summary>
		/// �����ּ�ģʽ
		/// </summary>
		[DataMember]
		public string DMBLevelFormat { get; set; }

		/// <summary>
		/// �ڵ���
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }

		/// <summary>
		/// �����Ƿ����Ϊ��
		/// </summary>
		[DataMember]
		public bool IsNullable { get; set; }

		/// <summary>
		/// �ֶγ���
		/// </summary>
		[DataMember]
		public int Length { get; set; }

		[DataMember]
		public int Precision { get; set; }

		/// <summary>
		/// ���������
		/// </summary>
		[DataMember]
		public string RefDMB { get; set; }

		/// <summary>
		/// ��Ӧ���ñ�����
		/// </summary>
		[DataMember]
		public string RefWordTableName { get; set; }

		[DataMember]
		public int Scale { get; set; }

		/// <summary>
		/// ��ȫ����
		/// </summary>
		[DataMember]
		public int SecretLevel { get; set; }

		/// <summary>
		/// �ֶ�����
		/// </summary>
		[DataMember]
		public string ColumnType { get; set; }

		/// <summary>
		/// ��Ӧ�������
		/// </summary>
		[DataMember]
		public MD_RefTable RefTable { get; set; }

		/// <summary>
		/// �Ƿ���ʾ
		/// </summary>
		[DataMember]
		public bool CanDisplay { get; set; }
	}
}
