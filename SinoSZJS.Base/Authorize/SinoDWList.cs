using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    [DataContract]
    public class SinoDWList
    {

        /// <summary>
        /// 单位代码
        /// </summary>
        /// 
        [DataMember]
        public string DWDM { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string DWMC { get; set; }


        public SinoDWList(string _dwdm, string _dwmc)
        {
            this.DWDM = _dwdm;
            this.DWMC = _dwmc;

        }

    }
}
