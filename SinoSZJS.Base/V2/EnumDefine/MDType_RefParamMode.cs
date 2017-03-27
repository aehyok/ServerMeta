using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_RefParamMode
	{
		/// <summary>
		/// 正常模式
		/// </summary>
		[EnumMember]
		Normal = 1,
		/// <summary>
		/// 使用参数模式
		/// </summary>
		[EnumMember]
		UserParam = 2,
	}
}
