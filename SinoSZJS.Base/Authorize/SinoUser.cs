using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoUser 用户定义。
    /// 用户定义项
    /// </summary>
    [DataContract]
    public class SinoUser
    {
        /// <summary>
        /// 用户具有角色集
        /// </summary>
        /// 
        [DataMember]
        public List<SinoRole> Roles { get; set; }

        /// <summary>
        /// 用户当前具有的权限集
        /// </summary>
        //[DataMember]
        //public Dictionary<string, UserRightItem> CurrentRights { get; set; }

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

        /// <summary>
        /// 用户类型    值为：1:“海关用户”　或	2:“缉私局用户”
        /// </summary>
        [DataMember]
        public int UserType { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        //用户的GUID
        [DataMember]
        public string UserGUID { get; set; }
        /// <summary>
        /// 用户的海关关号
        /// </summary>
        [DataMember]
        public string UserHGGH { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string DwID { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string DwName { get; set; }
        /// <summary>
        /// 单位代码
        /// </summary>
        [DataMember]
        public string Dwdm { get; set; }
        /// <summary>
        /// 单位的GUID
        /// </summary>
        [DataMember]
        public string DwGUID { get; set; }

        /// <summary>
        /// 权限层级,值为:海关总署级、直属海关级、隶属海关级
        /// </summary>
        [DataMember]
        public string QxszJB { get; set; }

        /// <summary>
        /// 权限所在单位代码
        /// </summary>		
        public string QxszDWDM
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDWDM;
                }
            }
        }
        /// <summary>
        /// 权限所在单位代码
        /// </summary>
        public string QxszDWID
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDwID;
                }
            }
        }
        /// <summary>
        /// 权限所在单位名称
        /// </summary>
        public string QxszDWMC
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDWMC;
                }
            }
        }
        /// <summary>
        /// 权限所在单位的GUID
        /// </summary>
        public string QxszDWGUID
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDWGUID;
                }
            }
        }
        /// <summary>
        /// 用户分局单位ID
        /// </summary>
        [DataMember]
        public string User_FJID { get; set; }
        /// <summary>
        /// 用户直属局ID
        /// </summary>
        [DataMember]
        public string User_ZSJID { get; set; }
        /// <summary>
        /// 用户是否广东分署
        /// </summary>
        [DataMember]
        public bool IsGDFSUser { get; set; }
        /// <summary>
        /// 安全级别
        /// </summary>
        [DataMember]
        public int SecretLevel { get; set; }
        /// <summary>
        /// 用户加密票据
        /// </summary>
        [DataMember]
        public string EncryptedTicket { get; set; }
        /// <summary>
        /// 用户使用的IP地址
        /// </summary>
        [DataMember]
        public string IPAddress { get; set; }
        /// <summary>
        /// 用户使用的主机名
        /// </summary>
        [DataMember]
        public string HostName { get; set; }
        /// <summary>
        /// 用户是否验证通过
        /// </summary>
        [DataMember]
        public bool IsSignOn { get; set; }

        /// <summary>
        /// 用户的系统ID
        /// </summary>
        [DataMember]
        public string SystemID { get; set; }

        //新添加
        [DataMember]
        public SinoUserBaseInfo BaseInfo = null;
        
    }
}