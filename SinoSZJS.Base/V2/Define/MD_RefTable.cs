using System.Runtime.Serialization;
using SinoSZJS.Base.V2.MetaData.EnumDefine;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract(IsReference = true)]
	public class MD_RefTable
	{

		public MD_RefTable(string id, string ns, string refName, string format, string des, string dw, int downMode, int paramMode, bool hide)
		{
			RefTableID = id;
			NamespaceName = ns;
			RefTableName = refName;
			LevelFormat = format;
			Description = des;
			DWDM = dw;
			HideCode = hide;
			RefDownloadMode = (downMode > 1) ? MDType_RefDownloadMode.LevelDownload : MDType_RefDownloadMode.FullDownload;
			RefParamMode = (paramMode > 1) ? MDType_RefParamMode.UserParam : MDType_RefParamMode.Normal;
		}
		[DataMember]
		public bool HideCode { get; set; }

		[DataMember]
		public string NamespaceName { get; set; }

		[DataMember]
		public MD_Namespace Namespace { get; set; }

		[DataMember]
		public string RefTableID { get; set; }
		[DataMember]
		public string RefTableName { get; set; }

		/// <summary>
		/// 分级格式
		/// </summary>
		[DataMember]
		public string LevelFormat { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[DataMember]
		public string Description { get; set; }

		/// <summary>
		/// 节点编号
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }

		[DataMember]
		public MDType_RefDownloadMode RefDownloadMode { get; set; }

		[DataMember]
		public MDType_RefParamMode RefParamMode { get; set; }

		public override string ToString()
		{
			return (Description == "") ? RefTableName : Description;
		}
	}
}
