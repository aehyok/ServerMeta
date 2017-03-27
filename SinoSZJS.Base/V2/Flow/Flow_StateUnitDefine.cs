using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    [DataContract]
    public class Flow_StateUnitDefine
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string ID { set; get; }

        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string UnitID { set; get; }

        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string UnitName { set; get; }

        /// <summary>
        /// 状态ID
        /// </summary>
        [DataMember]
        public string StateID { set; get; }

        /// <summary>
        /// 数据参数
        /// </summary>
        [DataMember]
        public string DataShowMeta { set; get; }

        /// <summary>
        /// 类型（1操作，2显示）
        /// </summary>
        [DataMember]
        public string Type { set; get; }

        [DataMember]
        public string StateName { set; get; }

        public Flow_StateUnitDefine(string id, string unitid, string stateid, string datameta, string type, string unitname, string statename)
        {
            this.ID = id;
            this.UnitID = unitid;
            this.StateID = stateid;
            this.DataShowMeta = datameta;
            this.Type = type;
            this.UnitName = unitname;
            this.StateName = statename;
        }

        public Flow_StateUnitDefine()
        { }
    }
}
