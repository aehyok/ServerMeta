using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
        /// <summary>
        /// 人员基本信息
        /// </summary>
        [DataContract]
        public class PersonBaseInfo
        {
              

                public PersonBaseInfo() { }
                public PersonBaseInfo(string _pid, string _uid,string _name, string _loginName, string _orgID, string _orgFullName, string _orgShortName, string _headShip)
                {
                        this.ID = _pid;
                        this.UserID = _uid;
                        this.Name = _name;
                        this.LoginName = _loginName;
                        this.OrgID = _orgID;
                        this.OrgFullName = _orgFullName;
                        this.OrgShortName = _orgShortName;
                        this.HeadShip = _headShip;
                }

                /// <summary>
                /// 人员ID
                /// </summary>
                [DataMember]
                public string ID { get; set; }

                /// <summary>
                /// 用户ID
                /// </summary>
                [DataMember]
                public string UserID { get; set; }
                /// <summary>
                /// 用户姓名
                /// </summary>
                [DataMember]
                public string Name { get; set; }
                /// <summary>
                /// 登录名称
                /// </summary>
                [DataMember]
                public string LoginName { get; set; }
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
                /// <summary>
                /// 职务
                /// </summary>
                [DataMember]
                public string HeadShip { get; set; }




        }
}
