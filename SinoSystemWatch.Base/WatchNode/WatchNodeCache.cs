using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.Define;

namespace SinoSystemWatch.Base.WatchNode
{
    public class WatchNodeCache
    {
        public static WatchNodeState CurrentState { get; set; }
        public static string Output()
        {
            return String.Format("{0}{1}{2}{3}{4}", CurrentState.SystemState, CurrentState.DatabaseState, CurrentState.ApplicationState, CurrentState.TaskState, CurrentState.InterfaceState);
        }


        public static void Init()
        {
            CurrentState = new WatchNodeState();        
        }
    }
}
