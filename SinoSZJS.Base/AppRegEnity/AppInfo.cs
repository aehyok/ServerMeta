using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AppRegEnity
{
    [DataContract]
    public class AppInfo
    {
        [DataMember]
        public string ID { set; get; }
        [DataMember]
        public string AppName { set; get; }
        [DataMember]
        public string DisplayTitle { set; get; }
        [DataMember]
        public string Meta { set; get; }
        /// <summary>
        /// 是否集成授权
        /// </summary>
        [DataMember]
        public bool IsMixRight { set; get; }
        /// <summary>
        /// 集成授权调用接口
        /// </summary>
        [DataMember]
        public string MixRightUrl { set; get; }
        /// <summary>
        /// 在该应用上注册的资源
        /// </summary>
        [DataMember]
        public List<RegisterInfo> RegResouces { set; get; }
    }
}
