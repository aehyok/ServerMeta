using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report.ReportGuideLine
{
    [DataContract]
    public class MD_ReportGuideLineDefine
    {

        public MD_ReportGuideLineDefine(string _id, string _fid, string _displayName, string _method, string _detialMethod, string _zbMeta)
        {
            this.ID = _id;
            this.FID = _fid;
            DisplayName = _displayName;
            Method = _method;
            DetialMethod = _detialMethod;
            ZBMeta = _zbMeta;
        }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string Method { get; set; }
        [DataMember]
        public string DetialMethod { get; set; }
        [DataMember]

        public string ZBMeta { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string FID { get; set; }




    }
}
