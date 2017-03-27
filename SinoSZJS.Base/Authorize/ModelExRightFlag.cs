using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    [DataContract]
    public class ModelExRightFlag
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string ModelID { get; set; }
        [DataMember]
        public string RightName { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public bool IsOwn { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        [DataMember]
        public string FatherID { get; set; }
        [DataMember]
        public List<ModelExRightFlag> Children { get; set; }
    }
}
