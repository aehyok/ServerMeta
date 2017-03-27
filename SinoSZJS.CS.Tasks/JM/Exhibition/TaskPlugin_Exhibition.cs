using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZJS.CS.Tasks.JM.Exhibition
{
    class TaskPlugin_Exhibition : ITaskPlugin
    {
        #region ITaskPlugin Members
        public string Name
        {
            get { return "JM_EXHIBITION"; }
        }

            public object GetTaskObject(string rwid, string param)
        {
            return new Task_Exhibition(rwid, param);
        }

        public string Description
        {
            get { return "向江门缉私局传输展示数据的任务"; }
        }
        #endregion
    }
}
