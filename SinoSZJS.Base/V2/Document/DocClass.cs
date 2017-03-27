using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
	/// <summary>
	/// 文书分类
	/// </summary>
	[DataContract]
	public class DocClass
	{
		/// <summary>
		/// 文书分类id
		/// </summary>
		[DataMember]
		public string Id { get; set; }


		/// <summary>
		/// 分类名称
		/// </summary>
		[DataMember]
		public string ClassName { get; set; }


		/// <summary>
		/// 排序
		/// </summary>
		[DataMember]
		public decimal DisplayOrder { get; set; }
	}
}
