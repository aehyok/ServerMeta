using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    /// <summary>
    /// 岗位用户列表
    /// </summary>
    [DataContract]
    public class PostUserList
    {
        public PostUserList() { }

        public PostUserList(string _userID, string _userName, string _personID, string _dwid, string _djsfzh, string _loginName,
                             string _sex, string _customsNO, string _policeNO, string _yjdz, string _zwmc, string _zwjb,
                             string _gwmc, string _gwms, string _ssdwid)
        {
            UserID = _userID;
            UserName = _userName;
            PersonID = _personID;
            DWID = _dwid;
            DJSFZH = _djsfzh;
            LoginName = _loginName;
            Sex = _sex;
            CustomsNO = _customsNO;
            PoliceNO = _policeNO;
            YJDZ = _yjdz;
            ZWMC = _zwmc;
            ZWJB = _zwjb;
            GWMC = _gwmc;
            GWMS = _gwms;
            SSDWID = _ssdwid;
        }


        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
        [DataMember]
        public string PersonID { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string DWID { get; set; }
        /// <summary>
        /// 登记身份证号
        /// </summary>
        [DataMember]
        public string DJSFZH { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }
        /// <summary>
        /// 海关编号
        /// </summary>
        [DataMember]
        public string CustomsNO { get; set; }
        /// <summary>
        /// 警号
        /// </summary>
        [DataMember]
        public string PoliceNO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string YJDZ { get; set; }
        /// <summary>
        /// 职务名称
        /// </summary>
        [DataMember]
        public string ZWMC { get; set; }
        /// <summary>
        /// 职务级别
        /// </summary>
        [DataMember]
        public string ZWJB { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        [DataMember]
        public string GWMC { get; set; }
        /// <summary>
        /// 岗位说明
        /// </summary>
        [DataMember]
        public string GWMS { get; set; }
        /// <summary>
        /// 所属单位ID
        /// </summary>
        [DataMember]
        public string SSDWID { get; set; }

    }
}
