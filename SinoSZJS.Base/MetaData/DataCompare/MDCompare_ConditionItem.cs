using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.DataCompare
{
    [DataContract]
    public class MDCompare_ConditionItem
    {
        [DataMember]
        public string ColumnIndex { get; set; }
        [DataMember]
        public MDQuery_TableColumn Column { get; set; }
        [DataMember]
        public string Operator { get; set; }
        [DataMember]
        public string CompareTagetField { get; set; }
    }
}
