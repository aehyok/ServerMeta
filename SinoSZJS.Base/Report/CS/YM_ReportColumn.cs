using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report.CS
{
	/// <summary>
	/// 页面报表列定义
	/// </summary>
	[DataContract]
	public class YM_ReportColumn
	{
		/// <summary>
		/// 主键id
		/// </summary>
		[DataMember]
		public string ID { set; get; }

		/// <summary>
		/// 报表id
		/// </summary>
		[DataMember]
		public string BBID { set; get; }

		/// <summary>
		/// 列名称
		/// </summary>
		[DataMember]
		public string LMC { set; get; }

		/// <summary>
		/// 上级id
		/// </summary>
		[DataMember]
		public string SJID { set; get; }

		/// <summary>
		/// 跨行数
		/// </summary>
		[DataMember]
		public int RowSpan { set; get; }

		/// <summary>
		/// 跨列数
		/// </summary>
		[DataMember]
		public int ColSpan { set; get; }

		/// <summary>
		/// 列序
		/// </summary>
		[DataMember]
		public int LX { set; get; }

		/// <summary>
		/// 列宽
		/// </summary>
		[DataMember]
		public int Width { set; get; }

		/// <summary>
		/// 列域
		/// </summary>
		[DataMember]
		public string LField { set; get; }


		/// <summary>
		/// 域对其方式
		/// </summary>
		[DataMember]
		public string Alignment { set; get; }

		/// <summary>
		/// 域显示格式
		/// </summary>
		[DataMember]
		public string FormatStr { set; get; }

		/// <summary>
		/// 列元数据
		/// </summary>
		[DataMember]
		public string LMeta { set; get; }
	}
}
