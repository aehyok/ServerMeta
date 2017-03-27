using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_ViewTableRelation
	{
		/// <summary>
		/// 主表的一条记录对应本表一条(或没有)记录
		/// </summary>
		[EnumMember]
		SingleChildRecord = 1,
		/// <summary>
		/// 主表的一条记录对应本表多条(或没有)记录
		/// </summary>
		[EnumMember]
		MultiChildRecord = 0,
	}
}
