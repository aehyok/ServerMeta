using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.Flow
{
    [DataContract]
    public class BizEntityAction
    {
        [DataMember]
        public object ActionInfo { get; set; }
        [DataMember]
        public string BizID { get; set; }
        [DataMember]
        public ActionEntity Action { get; set; }
        [DataMember]
        public SinoRequestUser ActionUser { get; set; }
        [DataMember]
        public string DesDWID { get; set; }
        [DataMember]
        public string DesUserID { get; set; }
        [DataMember]
        public string ActionInfoID { get; set; }
        [DataMember]
        public string CZDWMC { get; set; }
        [DataMember]
        public string CZYHMC { get; set; }
        [DataMember]
        public DateTime CZSJ { get; set; }


        public BizEntityAction() { }

        public BizEntityAction(string _bizID, ActionEntity _action, SinoRequestUser _su, string _desdwid, string _desuserid, string _infoID)
        {
            BizID = _bizID;
            Action = _action;
            ActionUser = _su;
            DesDWID = _desdwid;
            DesUserID = _desuserid;
            ActionInfoID = _infoID;
        }


        /// <summary>
        /// 保存新的动作信息
        /// </summary>
        /// <returns></returns>
        virtual public bool SaveNewActionInfoData()
        {
            if (this.ActionInfoID == "") this.ActionInfoID = Guid.NewGuid().ToString();
            return true;
        }

        /// <summary>
        /// 保存动作信息
        /// </summary>
        /// <returns></returns>
        virtual public bool SaveActionInfoData()
        {
            return true;
        }

        /// <summary>
        /// 取动作的详细信息
        /// </summary>
        /// <param name="_infoDataID"></param>
        /// <returns></returns>
        virtual public bool GetActionInfoData(string _infoDataID)
        {
            return true;
        }

        /// <summary>
        /// 删除动作 信息
        /// </summary>
        /// <returns></returns>
        virtual public bool DeleteActionInfoData()
        {
            return true;
        }


    }
}
