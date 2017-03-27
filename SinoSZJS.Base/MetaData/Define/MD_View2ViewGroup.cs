using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract(IsReference = true)]
    public class MD_View2ViewGroup
    {
        [DataMember]
        public IList<MD_View2View> View2Views { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        [DataMember]
        public string DisplayTitle { get; set; }
        [DataMember]
        public string QueryModelID { get; set; }

        public override string ToString()
        {
            return this.DisplayTitle;
        }


    }
}
