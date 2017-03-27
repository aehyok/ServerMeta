using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
	/// <summary>
	/// 流程缓存定义
	/// </summary>
	[DataContract]
	public class SystemFlow
	{
		/// <summary>
		/// FLOW索引，键值为 flowID
		/// </summary>
		protected static Dictionary<string, Flow_BaseDefine> FlowDict = new Dictionary<string, Flow_BaseDefine>();
		/// <summary>
		/// 状态索引，键值为stateID
		/// </summary>
		protected static Dictionary<string, Flow_StateDefine> StateDict = new Dictionary<string, Flow_StateDefine>();
		/// <summary>
		/// 动作索引，键值为actionID
		/// </summary>
		protected static Dictionary<string, Flow_StateActionDefine> ActionDict = new Dictionary<string, Flow_StateActionDefine>();

		/// <summary>
		/// 添加一个流程
		/// </summary>
		/// <param name="flow"></param>
		public static void AddFlow(FlowEntity flow)
		{
			if (!FlowDict.ContainsKey(flow.Flow.Id))
			{
				FlowDict.Add(flow.Flow.Id, flow.Flow);
				foreach (var state in flow.StateList)
				{
					StateDict.Add(state.State.ID, state.State);
					foreach (var action in state.ActionList)
					{
						ActionDict.Add(action.Action.ActionID, action.Action);
					}
				}
			}
		}

		/// <summary>
		/// 通过flowID取流程定义
		/// </summary>
		/// <param name="flowID"></param>
		/// <returns></returns>
		public static Flow_BaseDefine GetFlowDefine(string flowID)
		{
			if (FlowDict.ContainsKey(flowID))
				return FlowDict[flowID];
			else
				return null;
		}

		/// <summary>
		/// 根据actionID取动作定义
		/// </summary>
		/// <param name="actionID"></param>
		/// <returns></returns>
		public static Flow_StateActionDefine GetActionByID(string actionID)
		{
			return ActionDict[actionID];
		}

		/// <summary>
		/// 根据stateID取状态定义
		/// </summary>
		/// <param name="stateID"></param>
		/// <returns></returns>
		public static Flow_StateDefine GetStateByID(string stateID)
		{
			return StateDict[stateID];
		}

		/// <summary>
		/// 清空所有定义
		/// </summary>
		public static void Clear()
		{
			FlowDict.Clear();
			StateDict.Clear();
			ActionDict.Clear();
		}
	}
}
