using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MenuType
{
    [DataContract]
    public class firstPageItem
    {
        public firstPageItem(string _id, string _type, string _param, string _caption)
        {
            ID = _id;
            ItemType = _type;
            ItemParam = _param;
            Caption = _caption;
        }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string ItemType { get; set; }
        [DataMember]
        public string ItemParam { get; set; }
        [DataMember]
        public string Caption { get; set; }


    }
}
