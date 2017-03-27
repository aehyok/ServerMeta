using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.Application
{
    public class WCFServiceStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WCFType { get; set; }
        public string URL { get; set; }
        public int WcfStauts { get; set; }
        public string WcfError { get; set; }
    }
}
