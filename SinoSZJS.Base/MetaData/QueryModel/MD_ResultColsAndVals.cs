using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MD_ResultColsAndVals
    {
        [DataMember]
        public DataSet MD_QResult{ set; get; }
        [DataMember]
        public MDModel_QueryModel MD_MQuery { set; get; }
        [DataMember]
        public List<MDQuery_ConditionItem> MD_QConditionList { set; get; }

    }
}
