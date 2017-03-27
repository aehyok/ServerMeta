using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
    [DataContract]
    public class FlowEntityConfigItem
    {
        public string DWID { get; set; }
        public List<FlowEntity> Flows { get; set; }

        public FlowEntity GetFlowByName(string FlowName)
        {
            var _fs = from _c in Flows
                      where _c.Flow.FlowName == FlowName
                      select _c;
            if (_fs.Count() > 0) return _fs.First();
            else return null;
        }
    }
}
