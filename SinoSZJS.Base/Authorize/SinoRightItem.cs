using System;
using System.Collections;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoRightItem 指一个权限定义项的ID,名称及相关定义
    /// </summary>
    /// 
    [DataContract]
    public class SinoRightItem
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [DataMember]
        public string RightID { get; set; }
        /// <summary>
        /// 父权限ID
        /// </summary>
        [DataMember]
        public string FatherRightID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [DataMember]
        public string RightName { get; set; }
        /// <summary>
        /// 权限描述
        /// </summary>
        [DataMember]
        public string RightDescript { get; set; }
        /// <summary>
        /// 权限类型　　　固定类型或动态类型
        /// </summary>
        [DataMember]
        public string RightType { get; set; }
        /// <summary>
        /// 权限的META
        /// </summary>
        [DataMember]
        public string RightMeta { get; set; }
        /// <summary>
        /// 对应的菜单ID
        /// </summary>
        [DataMember]
        public string MenuID { get; set; }
        /// <summary>
        /// 权限可能的级别定义
        /// </summary>
        [DataMember]
        public ArrayList RightLevels { get; set; }




    }

    /// <summary>
    /// 权限级别的定义
    /// </summary>
    [DataContract]
    public class RightLevelName
    {
        /// <summary>
        /// 级别
        /// </summary>
        [DataMember]
        public decimal Index { get; set; }
        /// <summary>
        /// 级别显示
        /// </summary>
        [DataMember]
        public string DisplayText { get; set; }

    }
}