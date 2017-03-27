using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.InputModel
{
    [DataContract]
    public class MD_InputEntitys
    {
        [DataMember]
        public MD_InputEntity MD_IEntity { get; set; }

        [DataMember]
        public MD_InputModel MD_InputModels { get; set; }

        [DataMember]
        public string MD_ChildContentXML { get;set;}

        [DataMember]
        public string MainKey { get; set; }

        /// <summary>
        /// 保存按钮是否显示
        /// </summary>
        [DataMember]
        public bool MD_ControlBtnSave { get; set; }

        /// <summary>
        /// 控制RoundPanel是否显示
        /// </summary>
        [DataMember]
        public bool MD_ControlRndPanel { get; set; }

        /// <summary>
        /// 标识是否为子模型,子模型 （暂时还未用到）
        /// </summary>
        [DataMember]
        public bool IsChildModel { get; set; }

        /// <summary>
        /// 是否为线索
        /// </summary>
        [DataMember]
        public bool IsClue { get; set; }

        /// <summary>
        /// 线索ID
        /// </summary>
        [DataMember]
        public string XSID { get; set; }

        /// <summary>
        /// added by lqm 20130708 子模型列表选择模式
        /// </summary>
        [DataMember]
        public int SelectMode { get; set; }

        /// <summary>
        /// added by lqm 20130712线索受理的查询模型名称
        /// </summary>
        [DataMember]
        public string QueryModelName { get; set; }

        /// <summary>
        /// 取线索数据指标ID
        /// </summary>
        [DataMember]
        public string GuideLineID { get; set; }
    }
}
