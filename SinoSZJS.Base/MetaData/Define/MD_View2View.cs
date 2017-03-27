using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_View2View
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string RelationString { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        [DataMember]
        public string DisplayTitle { get; set; }
        [DataMember]
        public string ViewGroupID { get; set; }
        [DataMember]
        public string TargetViewName { get; set; }
        [DataMember]
        public string QueryModelID { get; set; }

        public override string ToString()
        {
            return this.DisplayTitle;
        }
    }
}
