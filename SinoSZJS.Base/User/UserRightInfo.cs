using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    [DataContract]
    public class UserRightInfo
    {
        public UserRightInfo() { }
        public UserRightInfo(string _rid, string _name, string _fid, int _order, bool _have)
        {
            RightID = _rid;
            RightName = _name;
            FatherRightID = _fid;
            DisplayOrder = _order;
            HaveRight = _have;
        }
        /// <summary>
        /// 权限ID
        /// </summary>
        [DataMember]
        public string RightID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [DataMember]
        public string RightName { get; set; }
        /// <summary>
        /// 父权限ID
        /// </summary>
        [DataMember]
        public string FatherRightID { get; set; }
        /// <summary>
        /// 是否具有权
        /// </summary>
        [DataMember]
        public bool HaveRight { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }
    }
}
