using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.DataCompare
{
    [DataContract]
    public class MDCompare_Request : MDQuery_Request
    {
        [DataMember]
        public DataTable ExcelData { get; set; }
        [DataMember]
        public Dictionary<string, string> ColumnDictionary { get; set; }
        [DataMember]
        public string CompareConditionExpression { get; set; }
        [DataMember]
        public Dictionary<string, MDCompare_ConditionItem> CompareItems { get; set; }
    }
}
