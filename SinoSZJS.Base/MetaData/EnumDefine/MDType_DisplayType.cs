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
        /// ���ʽ��ʾ
        /// </summary>
        [EnumMember]
        GridType = 0,
        /// <summary>
        /// ����ʽ��ʾ
        /// </summary>
        [EnumMember]
        FormType = 1
    }
}
