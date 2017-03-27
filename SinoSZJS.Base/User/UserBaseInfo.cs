using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    /// <summary>
    /// 用户基本信息定义
    /// </summary>
    [DataContract]
    public class UserBaseInfo
    {


        public UserBaseInfo() { }

        public UserBaseInfo(string _userid, string _loginName, string _personid, string _orgid, string _orgFullName,
                string _orgShortName, string _userName, string _sex, string _customsNo, string _policeNo,
                string _email, string _headShip, string _level, string _limit, string _secret, string _userType)
        {
            UserID = _userid;
            LoginName = _loginName;
            PersonID = _personid;
            OrgID = _orgid;
            OrgFullName = _orgFullName;
            OrgShortName = _orgShortName;
            UserName = _userName;
            Sex = _sex;
            CustomsNO = _customsNo;
            PoliceNO = _policeNo;
            Email = _email;
            HeadShip = _headShip;
            Level = _level;
            Limit = _limit;
            Secret = _secret;
            UserType = _userType;
        }

        /// <summary>
        /// 用户类型
        /// </summary>
        [DataMember]
        public string UserType { get; set; }

        /// <summary>
        /// 安全级别
        /// </summary>
        [DataMember]
        public string Secret { get; set; }
        /// <summary>
        /// 限定级别
        /// </summary>
        [DataMember]
        public string Limit { get; set; }
        /// <summary>
        /// 用户级别
        /// </summary>
        [DataMember]
        public string Level { get; set; }

        /// <summary>
        /// 用户职务
        /// </summary>
        [DataMember]
        public string HeadShip { get; set; }
        /// <summary>
        /// 电子邮件地址
        /// </summary>
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// 警号
        /// </summary>
        [DataMember]
        public string PoliceNO { get; set; }
        /// <summary>
        /// 海关编号
        /// </summary>
        [DataMember]
        public string CustomsNO { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }


        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
        [DataMember]
        public string PersonID { get; set; }
        /// <summary>
        /// 组织机构ID
        /// </summary>
        [DataMember]
        public string OrgID { get; set; }
        /// <summary>
        /// 组织机构全称
        /// </summary>
        [DataMember]
        public string OrgFullName { get; set; }
        /// <summary>
        /// 组织机构简称
        /// </summary>
        [DataMember]
        public string OrgShortName { get; set; }

    }
}
