using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
	/// <summary>
	/// 查询结果字段对应的元数据定义来源
	/// </summary>
	[DataContract]
	public class MDQuery_ColumnSource
	{
		/// <summary>
		/// 查询模型名称
		/// </summary>
		[DataMember]
		public string QueryModelName { get; set; }
		/// <summary>
		/// 表名称
		/// </summary>
		[DataMember]
		public string TableName { get; set; }
		/// <summary>
		/// 字段名称
		/// </summary>
		[DataMember]
		public string ColumnName { get; set; }

		/// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="_qvName">查询模型名称</param>
		/// <param name="_tname">表名称</param>
		/// <param name="_cname">字段名称</param>
		public MDQuery_ColumnSource(string qvName, string tname, string cname)
		{
			QueryModelName = qvName;
			TableName = tname;
			ColumnName = cname;
		}
	}
}
