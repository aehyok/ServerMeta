using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MDSearchResult_DataPreview
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string DataText { get; set; }
    }
}
