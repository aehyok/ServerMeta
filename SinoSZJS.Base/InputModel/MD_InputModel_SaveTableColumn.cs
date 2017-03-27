using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.InputModel
{
    [DataContract]
    public class MD_InputModel_SaveTableColumn
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string SrcColumn { get; set; }
        [DataMember]
        public string DesColumn { get; set; }
        [DataMember]
        public string Method { get; set; }
        [DataMember]
        public string Descript { get; set; }

        public MD_InputModel_SaveTableColumn() { }
        public MD_InputModel_SaveTableColumn(string _id, string _srcCol, string _desCol, string _method, string _descript)
        {
            ID = _id;
            SrcColumn = _srcCol;
            DesColumn = _desCol;
            Method = _method;
            Descript = _descript;
        }
    }
}
