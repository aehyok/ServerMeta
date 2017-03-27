using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.BackLog
{
    /// <summary>
    /// 分组待办实体
    /// </summary>
    [DataContract]
    public class BackLogRegInfo
    {
        [DataMember]
        public string ID { set; get; }
        [DataMember]
        public string AppName { set; get; }
        [DataMember]
        public string Title { set; get; }
        [DataMember]
        public string CountUrl { set;get;}
        [DataMember]
        public string ImgUrl { set; get; }
        [DataMember]
        public string Type { set; get; }
        [DataMember]
        public string LinkUrl { set; get; }
    }
}
