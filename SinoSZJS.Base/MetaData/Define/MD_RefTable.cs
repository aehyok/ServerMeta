using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.MetaData.EnumDefine;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract(IsReference=true)]
    public class MD_RefTable
    {

        public MD_RefTable(string _id, string _ns, string _refName, string _format, string _des, string _dw, int _downMode, int _paramMode, bool _hide)
        {
            RefTableID = _id;
            NamespaceName = _ns;
            RefTableName = _refName;
            LevelFormat = _format;
            Description = _des;
            DWDM = _dw;
            HideCode = _hide;
            RefDownloadMode = (_downMode > 1) ? MDType_RefDownloadMode.LevelDownload : MDType_RefDownloadMode.FullDownload;
            RefParamMode = (_paramMode > 1) ? MDType_RefParamMode.UserParam : MDType_RefParamMode.Normal;
        }
        [DataMember]
        public bool HideCode { get; set; }

        [DataMember]
        public string NamespaceName { get; set; }

        [DataMember]
        public MD_Namespace Namespace { get; set; }

        [DataMember]
        public string RefTableID { get; set; }
        [DataMember]
        public string RefTableName { get; set; }

        /// <summary>
        /// 分级格式
        /// </summary>
        [DataMember]
        public string LevelFormat { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 节点编号
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }

        [DataMember]
        public MDType_RefDownloadMode RefDownloadMode { get; set; }

        [DataMember]
        public MDType_RefParamMode RefParamMode { get; set; }

        public override string ToString()
        {
            return (Description == "") ? RefTableName : Description;
        }
    }
}
