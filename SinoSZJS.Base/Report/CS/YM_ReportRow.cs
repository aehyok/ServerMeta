using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report.CS
{
	/// <summary>
	/// 报表行定义
	/// </summary>
	[DataContract]
	public class YM_ReportRow
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
		/// 行名称
		/// </summary>
		[DataMember]
		public string HMC { set; get; }

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
		/// 行序
		/// </summary>
		[DataMember]
        public int HX { set; get; }

		/// <summary>
		/// 行宽
		/// </summary>
		[DataMember]
		public int Width { set; get; }

		/// <summary>
		/// 对其方式
		/// </summary>
		[DataMember]
		public string Alignment { set; get; }

		/// <summary>
		/// 行的背景色
		/// </summary>
		[DataMember]
		public string BackColor { set; get; }

		/// <summary>
		/// 行元数据
		/// </summary>
		[DataMember]
		public string HMeta { set; get; }
	}
}
