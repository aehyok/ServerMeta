using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract]
	public class MD_View2App
	{
		[DataMember]
		public string ID { get; set; }
		[DataMember]
		public string ViewID { get; set; }
		[DataMember]
		public string Title { get; set; }
		[DataMember]
		public string RegURL { get; set; }
		[DataMember]
		public string AppName { get; set; }
		[DataMember]
		public string Meta { get; set; }
		[DataMember]
		public int DisplayOrder { get; set; }
		[DataMember]
		public int DisplayHeight { get; set; }

		public override string ToString()
		{
			if (Title != null)
			{
				return Title;
			}
			else
			{
				return ID;
			}
		}
	}
}
