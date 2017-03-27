using System.Runtime.Serialization;
using SinoSZJS.Base.V2.Authorize;

namespace SinoSZJS.Base.V2.Flow
{
	[DataContract]
	public class BizEntityAction
	{
		[DataMember]
		public string BizID { get; set; }
		[DataMember]
		public string DesDWID { get; set; }
		[DataMember]
		public string DesUserID { get; set; }
		[DataMember]
		public string ActionInfoID { get; set; }
		[DataMember]
		public Flow_StateActionDefine Action { get; set; }
		[DataMember]
		public SinoRequestUser ActionUser { get; set; }
		public BizEntityAction() { }

		public BizEntityAction(string bizID, Flow_StateActionDefine action, SinoRequestUser su, string desdwid, string desuserid, string infoID)
		{
			BizID = bizID;
			Action = action;
			ActionUser = su;
			DesDWID = desdwid;
			DesUserID = desuserid;
			ActionInfoID = infoID;
		}
	}
}
