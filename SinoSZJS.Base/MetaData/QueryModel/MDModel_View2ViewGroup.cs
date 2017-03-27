using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract(IsReference = true)]
    public class MDModel_View2ViewGroup
    {
        public MDModel_View2ViewGroup(string id, string title, int order)
        {
            ID = id;
            DisplayTitle = title;
            DisplayOrder = order;
        }
        public override string ToString()
        {
            return this.DisplayTitle;
        }

        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        [DataMember]
        public string DisplayTitle { get; set; }
        [DataMember]
        public List<MDModel_View2View> View2Views { get; set; }
        [DataMember]
        public string QueryModelID { get; set; }

    }
}
