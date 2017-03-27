using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_Menu
    {
        [DataMember]
        public MD_Nodes MD_Nodes { get; set; }

        [DataMember]
        public string MenuID { get; set; }

        [DataMember]
        public string MenuName { get; set; }

        [DataMember]
        public string MenuType { get; set; }

        [DataMember]
        public string MenuParameter { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string FatherMenuID { get; set; }

        [DataMember]
        public string MenuToolTip { get; set; }

        [DataMember]
        public string MenuIcon { get; set; }

        [DataMember]
        public bool ShowInToolBar { get; set; }

        [DataMember]
        public string NodeID { get; set; }
        [DataMember]
        public string SystemID { get; set; }
        [DataMember]
        public string IconName { get; set; }


        public override string ToString()
        {
            return MenuName;
        }
    }
}
