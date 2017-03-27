using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract]
	public class MD_Nodes
	{
		/// <summary>
		/// 包含的命名空间
		/// </summary>
		[DataMember]
		public List<MD_Namespace> NameSpaces { get; set; }
		/// <summary>
		/// 节点名称
		/// </summary>
		[DataMember]
		public string NodeName { get; set; }

		/// <summary>
		/// 节点编码
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }

		/// <summary>
		/// 显示名称
		/// </summary>
		[DataMember]
		public string DisplayTitle { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[DataMember]
		public string Descript { get; set; }

		/// <summary>
		/// 节点ID
		/// </summary>
		[DataMember]
		public string ID { get; set; }

		public MD_Nodes()
		{
		}

		public MD_Nodes(string nodename, string displayTitle, string dwdm)
		{
			this.NodeName = nodename;
			this.DisplayTitle = displayTitle;
			this.DWDM = dwdm;
		}

		public MD_Nodes(string id, string nodename, string displayTitle, string descript, string dwdm)
		{
			this.ID = id;
			this.NodeName = nodename;
			this.DisplayTitle = displayTitle;
			this.DWDM = dwdm;
			this.Descript = descript;
		}

		public override string ToString()
		{
			return DisplayTitle;
		}
	}
}
