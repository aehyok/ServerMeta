using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_RefParamMode
	{
		/// <summary>
		/// ����ģʽ
		/// </summary>
		[EnumMember]
		Normal = 1,
		/// <summary>
		/// ʹ�ò���ģʽ
		/// </summary>
		[EnumMember]
		UserParam = 2,
	}
}
