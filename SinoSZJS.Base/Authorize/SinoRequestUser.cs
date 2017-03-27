using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    [DataContract]
    public class SinoRequestUser
    {
        /// <summary>
        /// 请求的用户基本信息
        /// </summary>
        /// 
        [DataMember]
        public SinoUserBaseInfo BaseInfo { get; set; }
        /// <summary>
        /// 请求的岗位
        /// </summary>
        /// 
        [DataMember]
        public SinoPost SinoPost { get; set; }

       
    }
}
