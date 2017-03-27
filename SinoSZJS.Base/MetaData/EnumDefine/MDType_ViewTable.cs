using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.EnumDefine
{
    [DataContract]
    public enum MDType_ViewTable
    {
        [EnumMember]
        MainTable = 0,
        [EnumMember]
        ChildTable = 1,
    }
}
