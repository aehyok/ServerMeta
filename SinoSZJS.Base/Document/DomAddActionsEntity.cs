using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    //文书附加动作
    [DataContract]
    public class DomAddActionsEntity
    {
        //动作ID
        [DataMember]
        public string ID { get; set; }
        //附加动作ID
        [DataMember]
        public string ActionID { get; set; }
        //案件状态ID
        [DataMember]
        public string StateID { get; set; }
        //附加条件
        [DataMember]
        public string AddActionFJTJ { get; set; }
        //附加动作
        [DataMember]
        public string AddActionFJDZ { get; set; }
        //单位ID
        [DataMember]
        public string AddActionDwid { get; set; }

        public DomAddActionsEntity(string _ID, string _ActionID, string _stateID, string _addActionFJTJ, string _addActionFJDZ, string _addActionDwid)
        {
            this.ID = _ID;
            this.ActionID = _ActionID;
            this.StateID = _stateID;
            this.AddActionFJTJ = _addActionFJTJ;
            this.AddActionFJDZ = _addActionFJDZ;
            this.AddActionDwid = _addActionDwid;
        }

        public DomAddActionsEntity() { }
    }
}
