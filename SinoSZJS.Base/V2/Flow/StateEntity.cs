using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{

	[DataContract]
	public class StateEntity
	{
		public StateEntity(Flow_StateDefine state)
		{
			State = state;
		}

		/// <summary>
		/// 状态定义
		/// </summary>
		[DataMember]
		public Flow_StateDefine State { get; set; }

		/// <summary>
		/// 动作列表
		/// </summary>        
		[DataMember]
		public List<ActionEntity> ActionList { get; set; }


	}
}
