using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportTemplate
    {
        [DataMember]
        public string LBMC { set; get; }
        [DataMember]
        public string GBMC { set; get; }
        [DataMember]
        public int LBSX { set; get; }
        [DataMember]
        public int GBSX { set; get; }
        [DataMember]
        public string DWID { set; get; }
        public ReportTemplate() { }
        public ReportTemplate(string lbmc,string gbmc,int lbsx,int gbsx,string dwid)
        {
            LBMC = lbmc;
            GBMC = gbmc;
            LBSX = lbsx;
            GBSX = gbsx;
            DWID = dwid;
        }
    }
}
