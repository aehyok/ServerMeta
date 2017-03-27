using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report.ReportGuideLine
{
    [DataContract(IsReference = true)]
    public class MD_ReportGuideLineItem
    {

        public MD_ReportGuideLineItem(string _id, string _fid, string _displayName, string _ztName, Enum_ReportGuideLineItemType _type)
        {
            ID = _id;
            FID = _fid;
            DisplayName = _displayName;
            ZTName = _ztName;
            Type = _type;
        }
        [DataMember]
        public List<MD_ReportGuideLineItem> Children { get; set; }

        [DataMember]
        public string ZTName { get; set; }
        [DataMember]
        public Enum_ReportGuideLineItemType Type { get; set; }


        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string FID { get; set; }
        [DataMember]
        public string DisplayName { get; set; }



    }
}
