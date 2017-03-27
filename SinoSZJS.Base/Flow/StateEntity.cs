using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.Document;

namespace SinoSZJS.Base.Flow
{
   
    [DataContract]
    public class StateEntity
    {
        public StateEntity(Flow_StateDefine _state)
        {
            State = _state;
        }

        /// <summary>
        /// 状态定义
        /// </summary>
        [DataMember]
        public Flow_StateDefine State { get; set; }

        /// <summary>
        ///文书定义 
        /// </summary>
        [DataMember]
        public List<DocDW> DocumentList { get; set; }

        /// <summary>
        /// 动作列表
        /// </summary>        
        [DataMember]
        public List<ActionEntity> ActionList { get; set; }


    }
}
