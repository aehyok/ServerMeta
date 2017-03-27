using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{

	[DataContract]
	public class Flow_StateDefine
	{
		[DataMember]
		public string FlowID { get; set; }

		[DataMember]
		public decimal Order { get; set; }

		[DataMember]
		public string ID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string DisplayName { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string Type { get; set; }

		public Flow_StateDefine() { }
		public Flow_StateDefine(string id, string name, string displayName, string description, string type, string flowid, decimal order)
		{
			this.FlowID = flowid;
			this.ID = id;
			this.Name = name;
			this.DisplayName = displayName;
			this.Description = description;
			this.Type = type;
			this.Order = order;
		}





	}
}
