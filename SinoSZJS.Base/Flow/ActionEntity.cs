using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
    [DataContract]
    public class ActionEntity
    {
        [DataMember]
        public Flow_StateActionDefine Action { get; set; }
        /// <summary>
        /// 执行动作的前提条件
        /// </summary>
        [DataMember]
        public string DoActionCondition { get; set; }
        /// <summary>
        /// 动作执行完的附加动作
        /// </summary>
        [DataMember]
        public string AddinAction { get; set; }

        public ActionEntity(Flow_StateActionDefine _action)
        {
            Action = _action;
        }


    }
}
