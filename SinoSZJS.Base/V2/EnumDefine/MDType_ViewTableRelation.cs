using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_ViewTableRelation
	{
		/// <summary>
		/// �����һ����¼��Ӧ����һ��(��û��)��¼
		/// </summary>
		[EnumMember]
		SingleChildRecord = 1,
		/// <summary>
		/// �����һ����¼��Ӧ�������(��û��)��¼
		/// </summary>
		[EnumMember]
		MultiChildRecord = 0,
	}
}
