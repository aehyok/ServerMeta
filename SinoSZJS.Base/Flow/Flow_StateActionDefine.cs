using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
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
        public Flow_StateActionDefine(string _actionID, string _actionName, string _actionTitle, string _beginState, string _endState,string _endName,
                                string _actionType, int _userType, decimal _order, string _param,string unitid)
        {
            this.ActionID = _actionID;
            this.ActionName = _actionName;
            this.ActionTitle = _actionTitle;
            this.BeginState = _beginState;
            this.EndState = _endState;
            this.EndStateName = _endName;
            this.ActionType = _actionType;
            this.UserType = _userType;
            this.DisplayOrder = _order;
            this.ParamDefine = _param;
            this.UnitID = unitid;
        }

        public Flow_StateActionDefine(string _actionID, string _actionName, string _actionTitle, string _beginState, string _endState,
                        string _actionType, int _userType, decimal _order, string _param)
        {
            this.ActionID = _actionID;
            this.ActionName = _actionName;
            this.ActionTitle = _actionTitle;
            this.BeginState = _beginState;
            this.EndState = _endState;
            this.ActionType = _actionType;
            this.UserType = _userType;
            this.DisplayOrder = _order;
            this.ParamDefine = _param;
        }




    }
}
