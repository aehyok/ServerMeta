using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    /// <summary>
    /// 文书显示列表
    /// </summary>
    [DataContract]
    public class WSListEntity
    {
        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string WSMC { get; set; }

        /// <summary>
        /// 动作名称
        /// </summary>
        [DataMember]
        public string ActionName { get; set; }

        /// <summary>
        /// ajyyws表中的文书ID
        /// </summary>
        [DataMember]
        public string WSID { get; set; }

        public WSListEntity() { }

        public WSListEntity(string _wsmc, string _actionname, string _wsid)
        {
            this.WSMC = _wsmc;
            this.ActionName = _actionname;
            this.WSID = _wsid;
        }
    }
}
