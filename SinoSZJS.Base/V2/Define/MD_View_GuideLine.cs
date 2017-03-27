using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract]
	public class MD_View_GuideLine
	{

		[DataMember]
		public string ID { get; set; }
		[DataMember]
		public int DisplayOrder { get; set; }
		[DataMember]
		public string DisplayTitle { get; set; }
		[DataMember]
		public string ViewID { get; set; }
		[DataMember]
		public string TargetGuideLineID { get; set; }
		[DataMember]
		public string RelationParam { get; set; }

		public override string ToString()
		{
			return DisplayTitle;
		}
	}
}
