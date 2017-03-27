using System.Collections.Generic;
using System.Runtime.Serialization;
using SinoSZJS.Base.V2.MetaData.Define;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
	[DataContract(IsReference = true)]
	public class MD_GuideLineGroup
	{


		public MD_GuideLineGroup()
		{
		}


		public MD_GuideLineGroup(string ztmc, string ztsm, string nsName, string ssdw, int lx, int qxlx)
		{
			this.SSDW = ssdw;
			this.ZBZTMC = ztmc;
			this.ZBZTSM = ztsm;
			this.NamespaceName = nsName;
			this.LX = lx;
			this.QXLX = qxlx;
		}

		[DataMember]
		public List<MD_GuideLine> ChildGuideLines { get; set; }
		[DataMember]
		public MD_Nodes MD_Nodes { get; set; }
		[DataMember]
		public string SSDW { get; set; }
		[DataMember]
		public string ZBZTMC { get; set; }
		[DataMember]
		public string ZBZTSM { get; set; }
		[DataMember]
		public int LX { get; set; }
		[DataMember]
		public int QXLX { get; set; }
		[DataMember]
		public string NamespaceName { get; set; }

		public override string ToString()
		{
			return this.ZBZTMC;
		}

	}
}
