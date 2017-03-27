using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
	[DataContract]
	/// <summary>
	/// 文书事项实体
	/// </summary>
	public class DocItem
	{
		[DataMember]
		public string ID { set; get; }
		[DataMember]
		/// <summary>
		/// 事项说明
		/// </summary>
		public string SXSM { set; get; }
		[DataMember]
		/// <summary>
		/// 实体id
		/// </summary>
		public string BZID { set; get; }
		[DataMember]
		/// <summary>
		/// 生成时间
		/// </summary>
		public DateTime SCSJ { set; get; }
		[DataMember]
		/// <summary>
		/// 事项状态
		/// </summary>
		public string SXZT { set; get; }
		[DataMember]
		/// <summary>
		/// 定义事项
		/// </summary>
        public List<DocItemDetail> DYSX { set; get; }
	}
}
