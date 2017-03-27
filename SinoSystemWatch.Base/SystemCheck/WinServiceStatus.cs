using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.SystemCheck
{
    public class WinServiceStatus
    {
        public string ServiceName { get; set; }
        public string Status { get; set; }
        public int Flag { get; set; }
        public string Description { get; set; }
    }
}
