using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_ViewTable
	{
		[EnumMember]
		MainTable = 0,
		[EnumMember]
		ChildTable = 1,
	}
}
