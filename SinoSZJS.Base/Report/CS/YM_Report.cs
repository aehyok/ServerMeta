
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace SinoSZJS.Base.Report.CS
{
	/// <summary>
	/// 页面报表定义
	/// </summary>
	[DataContract]
	public class YM_Report
	{
		/// <summary>
		/// 报表id
		/// </summary>
		[DataMember]
		public string BBID { set; get; }

		/// <summary>
		/// 报表名称
		/// </summary>
		[DataMember]
		public string BBMC { set; get; }

		/// <summary>
		/// 是否行定义
		/// </summary>
		[DataMember]
		public string ISHDY { set; get; }

		/// <summary>
		/// 报表的宽度（百分比）
		/// </summary>
		[DataMember]
		public int BBKD { set; get; }

		/// <summary>
		/// 报表显示顺序
		/// </summary>
		[DataMember]
		public int DispalyOrder { set; get; }

		/// <summary>
		/// 报表元数据描述
		/// </summary>
		[DataMember]
		public string BBMeta { set; get; }

		/// <summary>
		/// 报表的列
		/// </summary>
		[DataMember]
		public List<YM_ReportHeaderFooterColumn> HeaderFooterColumns { set; get; }

		/// <summary>
		/// 报表的列
		/// </summary>
		[DataMember]
		public List<YM_ReportColumn> Columns { set; get; }

		/// <summary>
		/// 报表的行 
		/// </summary>
		[DataMember]
		public List<YM_ReportRow> Rows { set; get; }

        /// <summary>
        /// 报表所在的命名空间的节点的单位代码
        /// </summary>
        [DataMember]
        public string DWDM { set; get; }

        /// <summary>
        /// 报表所在的命名空间
        /// </summary>
        [DataMember]
        public string Namespace { set; get; }
	}
}
