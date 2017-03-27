using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.EnumDefine
{
    [DataContract]
    public enum MDType_RefDownloadMode
    {
        /// <summary>
        /// һ��������
        /// </summary>
        [EnumMember]
        FullDownload = 1,
        /// <summary>
        /// �ּ�����
        /// </summary>
        [EnumMember]
        LevelDownload = 2,
    }
}
