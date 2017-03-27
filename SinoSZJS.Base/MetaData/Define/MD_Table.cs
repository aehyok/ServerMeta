using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_Table
    {
        public MD_Table(string _id, string _ns, string _tname, string _ttype, string _des, string _title, string _mkey,
        string _dw, string _sfun, string _extfun)
        {
            TID = _id;
            NamespaceName = _ns;
            TableName = _tname;
            TableType = _ttype;
            Description = _des;
            DisplayTitle = _title;
            MainKey = _mkey;
            DWDM = _dw;
            SecretFun = _sfun;
            ExtSecret = _extfun;
        }

        public MD_Table(string _id, string _ns, string _tname, string _ttype, string _des, string _title, string _mkey,
        string _dw, string _sfun, string _extfun, string _resType)
        {
            TID = _id;
            NamespaceName = _ns;
            TableName = _tname;
            TableType = _ttype;
            Description = _des;
            DisplayTitle = _title;
            MainKey = _mkey;
            DWDM = _dw;
            SecretFun = _sfun;
            ExtSecret = _extfun;
            if (_resType != null)
            {
                ResourceType = _resType.Split(',').ToList<string>();
            }
            else
            {
                ResourceType = new List<string>();
            }
        }

        [DataMember]
        public List<string> ResourceType { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        [DataMember]
        public string NamespaceName { get; set; }

        /// <summary>
        /// 表的ID
        /// </summary>
        [DataMember]
        public string TID { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        [DataMember]
        public virtual string TableName { get; set; }

        /// <summary>
        /// 表类型
        /// </summary>
        [DataMember]
        public string TableType { get; set; }

        /// <summary>
        /// 表的描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 表的显示名称
        /// </summary>
        [DataMember]
        public string DisplayTitle { get; set; }

        /// <summary>
        /// 表的主键字段名称
        /// </summary>
        [DataMember]
        public string MainKey { get; set; }

        /// <summary>
        /// 节点编号
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }

        /// <summary>
        /// 安全函数
        /// </summary>
        [DataMember]
        public string SecretFun { get; set; }

        /// <summary>
        /// 扩展安全函数
        /// </summary>
        [DataMember]
        public string ExtSecret { get; set; }

        /// <summary>
        /// 本表的字段列表
        /// </summary>
        [DataMember]
        public IList<MD_TableColumn> Columns { get; set; }

        /// <summary>
        /// 本表的主键字段
        /// </summary>
        [DataMember]
        public MD_TableColumn MainKeyColumn { get; set; }

        public override string ToString()
        {
            return DisplayTitle;
        }
    }
}
