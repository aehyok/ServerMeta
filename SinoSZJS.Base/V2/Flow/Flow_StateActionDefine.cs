using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
	[DataContract]
	public class Flow_StateActionDefine
	{
		[DataMember]
		public string ParamDefine { get; set; }

		[DataMember]
		public decimal DisplayOrder { get; set; }
		/// <summary>
		///  状态变迁动作ID
		/// </summary>
		[DataMember]
		public string ActionID { get; set; }
		/// <summary>
		/// 状态变迁动作名
		/// </summary>
		[DataMember]
		public string ActionName { get; set; }
		/// <summary>
		/// 状态变迁动作显示名
		/// </summary>
		[DataMember]
		public string ActionTitle { get; set; }
		/// <summary>
		/// 初始状态
		/// </summary>
		[DataMember]
		public string BeginState { get; set; }
		/// <summary>
		/// 结束状态
		/// </summary>
		[DataMember]
		public string EndState { get; set; }
		/// <summary>
		/// 动作类型　　(业务流处理:指移交流转等,常规动作:保存.打印,生成文书等)
		/// </summary>
		[DataMember]
		public string ActionType { get; set; }

		[DataMember]
		public string EndStateName { get; set; }

		/// <summary>
		/// 动作使用者类型(0 所有人 1,有查看权的人　2,历史处理人　3.当前处理人)
		/// </summary>
		[DataMember]
		public int UserType { get; set; }

		[DataMember]
		public string UnitID { get; set; }
		public Flow_StateActionDefine() { }
		public Flow_StateActionDefine(string actionID, string actionName, string actionTitle, string beginState, string endState, string endName,
								string actionType, int userType, decimal order, string param, string unitid)
		{
			this.ActionID = actionID;
			this.ActionName = actionName;
			this.ActionTitle = actionTitle;
			this.BeginState = beginState;
			this.EndState = endState;
			this.EndStateName = endName;
			this.ActionType = actionType;
			this.UserType = userType;
			this.DisplayOrder = order;
			this.ParamDefine = param;
			this.UnitID = unitid;
		}

		public Flow_StateActionDefine(string actionID, string actionName, string actionTitle, string beginState, string endState,
						string actionType, int userType, decimal order, string param)
		{
			this.ActionID = actionID;
			this.ActionName = actionName;
			this.ActionTitle = actionTitle;
			this.BeginState = beginState;
			this.EndState = endState;
			this.ActionType = actionType;
			this.UserType = userType;
			this.DisplayOrder = order;
			this.ParamDefine = param;
		}




	}
}
