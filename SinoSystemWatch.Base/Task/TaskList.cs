using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;

namespace SinoSystemWatch.Base.Task
{
    public class TaskList
    {
        public static Dictionary<string, TaskListItem> Tasks = new Dictionary<string, TaskListItem>();

        public static void Add(TaskListItem _item)
        {
            if (Tasks.ContainsKey(_item.TaskName))
            {
                return;
            }
            else
            {
                Tasks.Add(_item.TaskName, _item);
            }
        }

        public static void AddByTaskplugin(ITaskPlugin _taskplugin)
        {
            TaskListItem _item = new TaskListItem();
            _item.TaskName = _taskplugin.Name;
            _item.TaskCheckType = _taskplugin.CheckType;
            _item.State = 0;
            _item.LastResult = 9;
            _item.LastErrorMsg = "";
            _item.LastFinishedTime = DateTime.MinValue;
            _item.NextStartTime = DateTime.Now;
            _item.TaskPlugin = _taskplugin;
            Add(_item);
        }

        public static bool RemoveTask(string _taskName)
        {
            if (Tasks.ContainsKey(_taskName))
            {
                Tasks.Remove(_taskName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Remove(TaskListItem _item)
        {
            if (Tasks.ContainsKey(_item.TaskName))
            {
                Tasks.Remove(_item.TaskName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ComputeState()
        {
            WatchNodeCache.Init();
            foreach (TaskListItem _item in Tasks.Values)
            {
                if (_item.TaskRunResult != null)
                {
                    switch (_item.TaskCheckType)
                    {
                        case "SYSTEM":
                            WatchNodeCache.CurrentState.SystemState = Math.Max(WatchNodeCache.CurrentState.SystemState, _item.TaskRunResult.StateFlag);
                            break;
                        case "DATABASE":
                            WatchNodeCache.CurrentState.DatabaseState = Math.Max(WatchNodeCache.CurrentState.DatabaseState, _item.TaskRunResult.StateFlag);
                            break;
                        case "APPLICATION":
                            WatchNodeCache.CurrentState.ApplicationState = Math.Max(WatchNodeCache.CurrentState.ApplicationState, _item.TaskRunResult.StateFlag);
                            break;
                        case "INTERFACE接口":
                            WatchNodeCache.CurrentState.InterfaceState = Math.Max(WatchNodeCache.CurrentState.InterfaceState, _item.TaskRunResult.StateFlag);
                            break;
                        case "TASK":
                            WatchNodeCache.CurrentState.TaskState = Math.Max(WatchNodeCache.CurrentState.TaskState, _item.TaskRunResult.StateFlag);
                            break;
                    }
                }
            }
        }



        public static string GetCheckMsg()
        {
            List<TaskResultInfo> _ret = new List<TaskResultInfo>();
            foreach (TaskListItem _item in Tasks.Values)
            {
                TaskResultInfo _t = new TaskResultInfo();
                _t.TaskName = _item.TaskName;
                _t.TaskRunResult = _item.TaskRunResult;
                _t.TaskCheckType = _item.TaskCheckType;
                _t.State = _item.State;
                _t.NextStartTime = _item.NextStartTime;
                _t.LastResult = _item.LastResult;
                _t.LastFinishedTime = _item.LastFinishedTime;
                _t.LastErrorMsg = _item.LastErrorMsg;
                _ret.Add(_t);
            }
            var jser = new JavaScriptSerializer();
            //序列化
            string _retstr = jser.Serialize(_ret);
            return _retstr;
        }

        public static bool RunTaskImmediately(string TaskName)
        {
            if (Tasks.ContainsKey(TaskName))
            {
                TaskListItem _item = Tasks[TaskName];
                _item.NextStartTime = DateTime.Now.AddHours(-1);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
