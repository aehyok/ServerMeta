using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.InputModel
{

    [DataContract(IsReference = true)]
    public class MD_InputModel_ColumnGroup
    {
        [DataMember]
        public string ModelID { get; set; }
        [DataMember]
        public string GroupID { get; set; }
        [DataMember]
        public string DisplayTitle { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        [DataMember]
        public List<MD_InputModel_Column> Columns { get; set; }
        [DataMember]
        public string GroupType { get; set; }
        [DataMember]
        public string AppRegUrl { get; set; }
        [DataMember]
        public string GroupParam { get; set; }
        #region lqm合并添加 2012/9/20
        public override string ToString()
        {
            return DisplayTitle;
        }

        public MD_InputModel_ColumnGroup() { }

        public MD_InputModel_ColumnGroup(string _groupID, string _modelID, string _title, int _order)
        {
            ModelID = _modelID;
            GroupID = _groupID;
            DisplayTitle = _title;
            DisplayOrder = _order;
        }
        #endregion
    }
}
