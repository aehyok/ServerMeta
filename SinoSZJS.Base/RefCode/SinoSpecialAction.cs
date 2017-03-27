using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace SinoSZJS.Base.RefCode
{
    [DataContract]
    public class SinoSpecialAction
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DWID { get; set; }

        [DataMember]
        public string Yearth { get; set; }

        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// added by lqm 2013.06.18 开始日期和结束日期
        /// </summary>
        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }
    }
}
