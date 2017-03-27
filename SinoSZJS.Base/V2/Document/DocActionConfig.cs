using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
	/// <summary>
	/// 文书动作配置表
	/// </summary>
	[DataContract]
	public class DocActionConfig
	{
		/// <summary>
		/// 文书动作ID
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// 案件流程动作Id
		/// </summary>
		[DataMember]
		public string ActionId { get; set; }

		/// <summary>
		/// 文书类型Id
		/// </summary>
		[DataMember]
		public string DocTypeId { get; set; }

		/// <summary>
		/// 文书名称
		/// </summary>
		[DataMember]
		public string DocTitle { get; set; }

		/// <summary>
		/// 是否作为附加条件
		/// </summary>
		[DataMember]
		public bool IsCondition { get; set; }

		/// <summary>
		/// 是否作为附加动作
		/// </summary>
		[DataMember]
		public bool IsAction { get; set; }

		public DocActionConfig() { }

		public DocActionConfig(string id, string actionId, string docTypeId)
		{
			this.Id = id;
			this.ActionId = ActionId;
			this.DocTypeId = docTypeId;
		}
	}
}
