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
        /// 一次性下载
        /// </summary>
        [EnumMember]
        FullDownload = 1,
        /// <summary>
        /// 分级下载
        /// </summary>
        [EnumMember]
        LevelDownload = 2,
    }
}
