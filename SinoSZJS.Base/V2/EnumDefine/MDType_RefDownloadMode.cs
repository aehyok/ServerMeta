using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_RefDownloadMode
	{
		/// <summary>
		/// һ��������
		/// </summary>
		[EnumMember]
		FullDownload = 1,
		/// <summary>
		/// �ּ�����
		/// </summary>
		[EnumMember]
		LevelDownload = 2,
	}
}
