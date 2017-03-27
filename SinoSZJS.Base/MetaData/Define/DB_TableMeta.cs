using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class DB_TableMeta
    {
        [DataMember]
        public string TableName { get; set; }
        [DataMember]
        public string TableComment { get; set; }
        [DataMember]
        public string TableType { get; set; }
    }
}
