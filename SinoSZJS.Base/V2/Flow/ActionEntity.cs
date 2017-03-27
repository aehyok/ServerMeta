using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
	[DataContract]
	public class ActionEntity
	{
		[DataMember]
		public Flow_StateActionDefine Action { get; set; }

		public ActionEntity(Flow_StateActionDefine action)
		{
			Action = action;
		}


	}
}
