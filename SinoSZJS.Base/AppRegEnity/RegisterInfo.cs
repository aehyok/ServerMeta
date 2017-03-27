using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AppRegEnity
{
    [DataContract]
    public class RegisterInfo
    {
        [DataMember]
        public string ID { set; get; }
        [DataMember]
        public string ResName { set; get; }
        [DataMember]
        public string AppName { set; get; }
        /// <summary>
        /// 应用控制操作地址
        /// </summary>
        [DataMember]
        public string RegUrl { set; get; }
        [DataMember]
        public string Meta { set; get; }
        /// <summary>
        /// 应用操作名称
        /// </summary>
        [DataMember]
        public string ActionName { set; get; }
        /// <summary>
        /// 操作显示名称
        /// </summary>
        [DataMember]
        public string ActionTitle { set; get; }
        /// <summary>
        /// 应用数据显示
        /// </summary>
        [DataMember]
        public string DisplayUrl { set; get; }
    }
}
