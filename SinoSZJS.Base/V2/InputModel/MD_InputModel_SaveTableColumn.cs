using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    [DataContract]
    public class MD_InputModel_SaveTableColumn
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string SrcColumn { get; set; }
        [DataMember]
        public string DesColumn { get; set; }
        [DataMember]
        public string Method { get; set; }
        [DataMember]
        public string Descript { get; set; }

        public MD_InputModel_SaveTableColumn() { }
        public MD_InputModel_SaveTableColumn(string id, string srcColumn, string desColumn, string method, string descript)
        {
            Id = id;
            SrcColumn = srcColumn;
            DesColumn = desColumn;
            Method = method;
            Descript = descript;
        }
    }
}
