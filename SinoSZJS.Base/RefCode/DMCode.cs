using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.RefCode
{
    [DataContract]
    public class DMCode
    {
        /// <summary>
        /// 代码
        /// </summary>
        [DataMember]
        public string DM { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string MC { get; set; }


        public DMCode(string _dm, string _mc)
        {
            this.DM = _dm;
            this.MC = _mc;
        }

    }
}
