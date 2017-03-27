using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.BackLog
{
    public class BackLogGroup
    {
        public string GroupName { set; get; }
        public string GroupTitle { set; get; }
        public List<BackLogRegInfo> BackLogs { set; get; }
    }
}
