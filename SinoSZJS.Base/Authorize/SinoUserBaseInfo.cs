using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// 用户基本信息实体
    /// </summary>
    [DataContract]
    public class SinoUserBaseInfo
    {
        /// <summary>
        /// 用户类型    值为：1:“海关用户”　或	2:“缉私局用户”
        /// </summary>
        public int UserType = 2;
        /// <summary>
        /// 用户登录名
        /// </summary>
        /// 
        [DataMember]
        public string LoginName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        /// 
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        /// 
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 用户的GUID
        /// </summary>
        /// 
        [DataMember]
        public string UserGUID { get; set; }
        /// <summary>
        /// 用户的海关关号
        /// </summary>
        /// 
        [DataMember]
        public string UserHGGH { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        /// 
        [DataMember]
        public string DwID { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        /// 
        [DataMember]
        public string DwName { get; set; }
        /// <summary>
        /// 单位代码
        /// </summary>
        /// 
        [DataMember]
        public string Dwdm { get; set; }
        /// <summary>
        /// 单位的GUID
        /// </summary>
        /// 
        [DataMember]
        public string DwGUID { get; set; }
        /// <summary>
        /// 安全级别
        /// </summary>
        /// 
        [DataMember]
        public int SecretLevel = 0;
        /// <summary>
        /// 默认岗位ID
        /// </summary>
        /// 
        [DataMember]
        public string DefaultPostID = null;

        [DataMember]
        public string Sex { get; set; }

        /// <summary>
        /// 用户具有岗位集
        /// </summary>
        [DataMember]
        public List<SinoPost> Posts { get; set; }
        /// <summary>
        /// 用户默认岗位
        /// </summary>
        /// 
        [DataMember]
        public SinoPost DefaultPost { get; set; }

        /// <summary>
        /// 用户当前使用的岗位
        /// </summary>
        [DataMember]
        public SinoPost CurrentPost { get; set; }

    }
}
