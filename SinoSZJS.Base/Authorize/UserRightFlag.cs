using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    [DataContract]
    public class UserRightFlag
    {
        [DataMember]
        public string RightID { get; set; }
        [DataMember]
        public string FatherRightID { get; set; }
        [DataMember]
        public string RightName { get; set; }
        [DataMember]
        public bool IsOwn { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        /// <summary>
        /// added by lqm 2012-12-17
        /// </summary>
        [DataMember]
        public string QxMeta { set; get; }

    }
}
