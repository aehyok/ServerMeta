using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZJS.CS.Tasks.Customs.TJS
{
    public class TaskPlugin_TJS : ITaskPlugin
    {
        #region ITaskPlugin Members

        public string Name
        {
            get { return "TJS"; }
        }

        public object GetTaskObject(string _rwid, string _param)
        {
            return new Task_TJS(_rwid, _param);
        }

        public string Description
        {
            get { return "缉私数据上报统计司任务"; }
        }

        #endregion



       
    }
}
