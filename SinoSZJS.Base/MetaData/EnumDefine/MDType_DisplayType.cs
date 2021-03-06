using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.EnumDefine
{
    [DataContract]
    public enum MDType_DisplayType
    {
        /// <summary>
        /// 表格方式显示
        /// </summary>
        [EnumMember]
        GridType = 0,
        /// <summary>
        /// 表单方式显示
        /// </summary>
        [EnumMember]
        FormType = 1
    }
}
