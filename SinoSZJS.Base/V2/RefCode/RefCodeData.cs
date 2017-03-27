using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.RefCode
{
    /// <summary>
    /// added by lqm 2014.03.28 
    /// </summary>
    [DataContract(IsReference = true)]
    public class RefCodeData
    {
        public RefCodeData() { }

        public RefCodeData(string code, string title, string pyzt, int order, bool isEffective, string note,
                                string fcode, bool canShow, bool canInput, bool isLeaves)
        {
            Code = code;
            DisplayTitle = title;
            PYZT = pyzt;
            Order = order;
            IsEffective = isEffective;
            Note = note;
            FatherCode = fcode;
            CanShow = canShow;
            CanInput = canInput;
            IsLeaves = isLeaves;
        }


        [DataMember]
        public List<RefCodeData> ChildData { get; set; }
        [DataMember]
        public bool HaveChilds { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public string FatherCode { get; set; }
        [DataMember]
        public bool CanShow { get; set; }
        [DataMember]
        public bool CanInput { get; set; }
        [DataMember]
        public bool IsLeaves { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string DisplayTitle { get; set; }
        [DataMember]
        public string PYZT { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public bool IsEffective { get; set; }

    }
}
