using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{

	[DataContract]
	public class FlowEntity
	{
		public FlowEntity(Flow_BaseDefine fe)
		{
			Flow = fe;
		}

		/// <summary>
		/// 流程信息定义
		/// </summary>       
		[DataMember]
		public Flow_BaseDefine Flow { get; set; }

		/// <summary>
		/// 状态列表
		/// </summary>
		[DataMember]
		public List<StateEntity> StateList { get; set; }

		/// <summary>
		/// 取初始状态
		/// </summary>
		/// <returns></returns>
		public StateEntity GetStartState()
		{
            return this.StateList.Find(state => state.State.Type == "开始");
			foreach (StateEntity _ae in this.StateList)
			{
				if (_ae.State.Type == "开始")
				{
					return _ae;
				}
			}
			return null;
		}

	}
}
