using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.TaskCheck
{
    public class CheckTaskStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RWID { get; set; }
        public int LastRunFlag { get; set; }
        public int RWZT { get; set; }
        public int ErrorNum { get; set; }
    }
}
