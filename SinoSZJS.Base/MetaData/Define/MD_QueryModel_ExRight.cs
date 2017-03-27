using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_QueryModel_ExRight
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string RightName { get; set; }
        [DataMember]
        public string RightTitle { get; set; }
        [DataMember]
        public string ModelID { get; set; }
        [DataMember]
        public string FatherRightID { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }

        public override string ToString()
        {
            return RightTitle;
        }

    }
}
