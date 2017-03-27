using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
        public class TaskDefine
        {
                private string _taskid = "";
                private string _type = "";
                private string _param = "";

                public string TaskID 
                {
                        get { return _taskid;}
                        set { _taskid = value;}
                }

                public string TaskType
                {
                        get{ return _type;}
                        set { _type = value;}
                }

                public string TaskParameter
                {
                        get { return _param;}
                        set { _param = value;}
                }
        }

}
