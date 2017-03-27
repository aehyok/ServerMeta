using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.EnumDefine
{
	[DataContract]
	public enum MDType_RefDownloadMode
	{
		/// <summary>
		/// 一次性下载
		/// </summary>
		[EnumMember]
		FullDownload = 1,
		/// <summary>
		/// 分级下载
		/// </summary>
		[EnumMember]
		LevelDownload = 2,
	}
}
