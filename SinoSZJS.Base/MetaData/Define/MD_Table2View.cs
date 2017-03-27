using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_Table2View
    {


        public MD_Table2View(string _id, string _tid, string _model, string _condi, string _confine)
        {
            ID = _id;
            TID = _tid;
            ModelName = _model;
            ConditionStr = _condi;
            Confine = _confine;
        }
        [DataMember]
        public string Confine { get; set; }

        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string TID { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public string ConditionStr { get; set; }

        public override string ToString()
        {
            return ModelName;
        }



    }
}
