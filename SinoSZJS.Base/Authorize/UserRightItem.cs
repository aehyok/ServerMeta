using System;
using System.Data;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// RightItem 的摘要说明。
    /// 用户（或角色）所具备的单个权限项及级别范围　　　　　　　
    /// </summary>
    [DataContract(IsReference = true)]
    public class UserRightItem
    {
        [DataMember]
        public SinoRightItem Right { get; set; } //权限项
        [DataMember]
        public decimal Level { get; set; }  //级别范围

        public UserRightItem()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }



    }

}
