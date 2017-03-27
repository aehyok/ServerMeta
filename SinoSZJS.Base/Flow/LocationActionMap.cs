using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
    /// <summary>
    /// added by lqm 2013.5.11  环节动作配置表
    /// </summary>
    [DataContract]
    public class LocationActionMap
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsHave { get; set; }
    }
}
