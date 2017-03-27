using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZServerBase
{
        public class Task_Test_Plugin : ITaskPlugin
        {
                #region ITaskPlugin Members

                public string Name
                {
                        get { return "TEST"; }
                }

                public string Description
                {
                    get { return "测试任务"; }
                }
                public object GetTaskObject(string _rwid, string _param)
                {
                        return new Task_Test(_rwid,_param);
                }

                #endregion


              
        }
}
