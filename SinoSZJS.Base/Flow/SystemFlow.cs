using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.Config;
using System.Configuration;

namespace SinoSZJS.Base.Flow
{
    [DataContract]
    public class SystemFlow
    {

        #region 新增
        /// <summary>
        /// FLOW索引，键值为 FLOWNAME.DWID
        /// </summary>
        protected static Dictionary<string, FlowEntity> flowDict = new Dictionary<string, FlowEntity>();

        ///// <summary>
        ///// STATE索引，键值为 STATEID.DWID
        ///// </summary>
        //protected static Dictionary<string, StateEntity> StateDict = new Dictionary<string, StateEntity>();
        ///// <summary>
        ///// ACTION索引，键值为 ACTIONID.DWID
        ///// </summary>
        //protected static Dictionary<string, ActionEntity> ActionDict = new Dictionary<string, ActionEntity>();

        /// <summary>
        /// 添加一个流程
        /// </summary>
        /// <param name="dwid"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public static bool AddFlow(string dwid, FlowEntity flow)
        {
            string _key = string.Format("{0}.{1}", flow.Flow.ID, dwid);
            if (flowDict.ContainsKey(_key)) return false;
            flowDict.Add(_key, flow);

            //foreach (StateEntity _se in _flow.StateList)
            //{
            //    string _stateKey = string.Format("{0}.{1}", _se.State.ID, DWID);
            //    StateDict.Add(_stateKey, _se);
            //    foreach (ActionEntity _ae in _se.ActionList)
            //    {
            //        string _actionKey = string.Format("{0}.{1}", _ae.Action.ActionID, DWID);
            //        ActionDict.Add(_actionKey, _ae);
            //    }
            //}
            return true;
        }


        /// <summary>
        /// 通过FLOWNAME.DWID取流程定义
        /// </summary>
        /// <param name="dwid"></param>
        /// <param name="flowID"></param>
        /// <returns></returns>
        public static FlowEntity GetFlowConfig(string dwid, string flowID)
        {
            string _key = string.Format("{0}.{1}", flowID, dwid);
            if (flowDict.ContainsKey(_key))
            {
                return flowDict[_key];
            }
            return flowDict[string.Format("{0}.{1}", flowID, ConfigFile.SytemDWRootID)];
        }
        /// <summary>
        /// 取初始状态
        /// </summary>
        /// <param name="flowID"></param>
        /// <param name="dwid"></param>
        /// <returns></returns>
        public static StateEntity GetStartState(string flowID, string dwid)
        {
            FlowEntity _fe = GetFlowConfig(dwid, flowID);
            foreach (StateEntity _se in _fe.StateList)
            {
                if (_se.State.Type == "开始")
                    return _se;
            }
            return null;
        }
        /// <summary>
        /// 通过流程ID和状态名称取状态定义
        /// </summary>
        /// <param name="flowID"></param>
        /// <param name="stateName"></param>
        /// <param name="dwid"></param>
        /// <returns></returns>
        public static StateEntity GetStateByName(string flowID, string stateName, string dwid)
        {
            FlowEntity _fe = GetFlowConfig(dwid, flowID);
            foreach (StateEntity _se in _fe.StateList)
            {
                if (_se.State.Name == stateName) return _se;
            }
            return null;
        }

        public static ActionEntity GetActionByName(string flowID, string actionName, string dwid)
        {
            FlowEntity _fe = GetFlowConfig(dwid, flowID);
            ActionEntity _ae = null;
            foreach (StateEntity se in _fe.StateList)
            {
                foreach (ActionEntity ae in se.ActionList)
                {
                    if (ae.Action.ActionName == actionName)
                        _ae = ae;
                }
            }
            return _ae;
        }
        /// <summary>
        /// 取新建动作
        /// </summary>
        /// <param name="dwid"></param>
        /// <param name="flowID"></param>
        /// <returns></returns>
        public static ActionEntity GetCreateAction(string dwid, string flowID)
        {
            FlowEntity _fe = GetFlowConfig(dwid, flowID);
            StateEntity _se = _fe.GetStartState();
            if (_se == null) return null;
            if (_se.ActionList.Count < 1) return null;
            return _se.ActionList[0];
        }

        //public static FlowEntity GetFlowNameKey(string FlowNameKey)
        //{
        //    string[] _sp = FlowNameKey.Split(',');
        //    return GetFlowConfig(_sp[0], _sp[1]);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="DWID"></param>
        ///// <param name="StateID"></param>
        ///// <returns></returns>
        //public static StateEntity GetStateConfig(string DWID, string StateID)
        //{
        //    string _key = string.Format("{0}.{1}", StateID, DWID);
        //    if (StateDict.ContainsKey(_key))
        //    {
        //        return StateDict[_key];
        //    }
        //    return StateDict[string.Format("{0}.{1}", StateID, MVCConfig.RootDWID)];
        //}

        //public static ActionEntity GetActionConfig(string DWID, string ActionID)
        //{
        //    string _key = string.Format("{0}.{1}", ActionID, DWID);
        //    if (ActionDict.ContainsKey(_key))
        //    {
        //        return ActionDict[_key];
        //    }
        //    return ActionDict[string.Format("{0}.{1}", ActionID, MVCConfig.RootDWID)];
        //}
        #endregion

        /// <summary>
        /// 清空所有定义
        /// </summary>
        /// <returns></returns>
        public static bool Clear()
        {
            flowDict.Clear();
            //StateDict.Clear();
            //ActionDict.Clear();
            //FlowList.Clear();
            //StateList.Clear();
            //ActionList.Clear();
            return true;
        }
    }
}
