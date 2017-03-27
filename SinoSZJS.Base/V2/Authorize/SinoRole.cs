﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Authorize
{
    /// <summary>
    /// added by lqm 2014.03.17 角色实体
    /// </summary>
    [DataContract]
    public class SinoRole
    {
        /// <summary>
        /// 角色具有权限集合
        /// </summary>
        [DataMember]
        public List<SinoRightItem> UserRights { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [DataMember]
        public string RoleID { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [DataMember]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [DataMember]
        public string Descript { get; set; }

        /// <summary>
        /// 角色类型　　　如果为空表示全系统通用角色，如果为DWID则表示此单位自定角色
        /// </summary>
        [DataMember]
        public string RoleDwid { get; set; }

        [DataMember]
        public bool IsOwn { get; set;}
    }
}
