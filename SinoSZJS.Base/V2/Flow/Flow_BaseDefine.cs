using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{

	[DataContract]
	public class Flow_BaseDefine
	{
		[DataMember]
		public string RootDWID { get; set; }

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string FlowName { get; set; }

		[DataMember]
		public string Description { get; set; }

		public Flow_BaseDefine() { }

		public Flow_BaseDefine(string id, string name, string description, string rootdwid)
		{
			this.Id = id;
			this.FlowName = name;
			this.Description = description;
			this.RootDWID = rootdwid;
		}
	}
}
