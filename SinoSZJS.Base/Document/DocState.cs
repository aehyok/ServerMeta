using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    public class DocState
    {
        /// <summary>
        /// 文书状态表ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        [DataMember]
        public string WSState { get; set; }
        /// <summary>
        /// 文书中文名称
        /// </summary>
        [DataMember]
        public string WSMC { get; set; }

        public DocState() { }

        public DocState(string _ID,string _WSState, string _WSMC)
        {
            this.ID = _ID;
            this.WSState = _WSState;
            this.WSMC = _WSMC;
        }
    }
}
