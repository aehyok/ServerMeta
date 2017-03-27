using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class DB_ColumnMeta
    {
        [DataMember]
        public string ColumnName { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public string DataType { get; set; }
        [DataMember]
        public bool Nullable { get; set; }
        [DataMember]
        public int DataLength { get; set; }
        [DataMember]
        public int DataPrecision { get; set; }
    }
}
