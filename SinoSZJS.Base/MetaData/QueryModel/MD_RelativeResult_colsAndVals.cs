using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MD_RelativeResult_colsAndVals
    {
        [DataMember]
        public DataSet ResultTables { get; set; }
        [DataMember]
        public MDQuery_ResultTable MainTable { set; get; }
        [DataMember]
        public MDQuery_ResultTable SingleTable { set; get; }
        [DataMember]
        public List<MDQuery_ResultTable> ChildTable { set; get; }
        [DataMember]
        public List<MDQuery_ConditionItem> ConditionItemList { set; get; }
        [DataMember]
        public string MList { set; get; }
        [DataMember]
        public string CList { set; get; }
        [DataMember]
        public string ExpressValue { set; get; }
        [DataMember]
        public string QModelName { set; get; }
    }
}
