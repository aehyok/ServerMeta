using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZJS.CS.Tasks.HP.Inspection
{
    public class TaskPlugin_Inspection : ITaskPlugin
    {

        #region ITaskPlugin Members

        public string Name
        {
            get { return "HP_INSPECTION"; }
        }

        public object GetTaskObject(string _rwid, string _param)
        {
            return new Task_Inspection(_rwid, _param);
        }

        public string Description
        {
            get { return "向黄埔查验异常系统反馈任务"; }
        }

        #endregion
    }

}
