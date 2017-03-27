using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.RefCode
{
    [DataContract]
    public class SinoBizParameter
    {

        [DataMember]
        public string CSID { get; set; }

        [DataMember]
        public string TJDWID { get; set; }

        [DataMember]
        public string CSM { get; set; }

        [DataMember]
        public string CSZ { get; set; }

        [DataMember]
        public string CSZBS { get; set; }

        [DataMember]
        public int XH { get; set; }

        [DataMember]
        public string SM { get; set; }

    }
}
