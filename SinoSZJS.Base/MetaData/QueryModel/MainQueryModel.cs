using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MainQueryModel
    {
        [DataMember]
        public MDQueryResult_TableRow MainQueryModel_Row { get; set; }

        [DataMember]
        public List<MDModel_Table_Column> TableColumnList { get; set; }
    }
}
