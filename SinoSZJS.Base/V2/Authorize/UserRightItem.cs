using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Authorize
{
    /// <summary>
    /// added by lqm 2014.03.17 用户（或角色）所具备的单个权限项及级别范围　　　
    /// </summary>
    [DataContract]
    public class UserRightItem
    {
        /// <summary>
        /// 权限项
        /// </summary>
        [DataMember]
        public SinoRightItem Right { get; set; } 

        /// <summary>
        /// 级别范围
        /// </summary>
        [DataMember]
        public decimal Level { get; set; }  

        public UserRightItem()
        {
        }
    }
}
