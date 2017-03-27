using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AppRegEnity
{

    [DataContract]
    public class ResourceInfo
    {
        [DataMember]
        public string ID { set; get; }
        [DataMember]
        public string ResourceName { set; get; }
        [DataMember]
        public string DispalyTitle { set; get; }
        [DataMember]
        public string Meta { set; get; }
        /// <summary>
        /// 资源数据获取接口
        /// </summary>
        [DataMember]
        public string ResICS { set; get; }
        /// <summary>
        /// 在该资源上注册的应用
        /// </summary>
        [DataMember]
        public List<RegisterInfo> RegApps { set; get; }
    }
}
