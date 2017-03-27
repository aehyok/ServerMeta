using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.Application
{
    public class SystemLogStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ErrorNum { get; set; }
        public int InfoNum { get; set; }
    }
}
