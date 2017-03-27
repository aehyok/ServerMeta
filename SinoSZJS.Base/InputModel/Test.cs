using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.InputModel
{
    [DataContract(IsReference=true)]
    public class Test
    {
        [DataMember]
        public Dictionary<string, DataSet> Dic { get; set; }
    }
}
