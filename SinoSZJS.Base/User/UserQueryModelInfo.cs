using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    [DataContract]
    public class UserQueryModelInfo
    {
        public UserQueryModelInfo() { }

        public UserQueryModelInfo(string _qvid, string _ns, string _qvName, string _qvTitle, bool _have)
        {
            QueryModelID = _qvid;
            QueryModelNamespace = _ns;
            QueryModelTitle = _qvTitle;
            QueryModelName = _qvName;
            HaveRight = _have;
        }
        [DataMember]
        public string QueryModelID { get; set; }
        [DataMember]
        public string QueryModelNamespace { get; set; }
        [DataMember]
        public string QueryModelName { get; set; }
        [DataMember]
        public string QueryModelTitle { get; set; }
        [DataMember]
        public bool HaveRight { get; set; }

    }
}
