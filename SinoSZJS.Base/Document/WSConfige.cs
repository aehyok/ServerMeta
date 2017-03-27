using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    [DataContract]
    public class WSConfige
    {
        /// <summary>
        /// 文书类型ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string WSMC { get; set; }

        /// <summary>
        /// 案件系统文书ID
        /// </summary>        
        [DataMember]
        public string AJWSBH { get; set; }
        
        /// <summary>
        /// 文书所属单位ID
        /// </summary>        
        [DataMember]
        public string DWID { get; set; }
        
        /// <summary>
        /// 文书类型
        /// </summary>
        /// [DataMember]
        public string WSFLID { get; set; }

        /// <summary>
        /// 文书录入模型名称
        /// </summary>
        [DataMember]
        public string MODELNAME { get; set; }

        /// <summary>
        /// 文书部分视图名称
        /// </summary>
        [DataMember]
        public string PATHNAME { get; set; }

        /// <summary>
        /// 文书对应视图中From名称
        /// </summary>
        [DataMember]
        public string WSFORMNAME { get; set; }

        /// <summary>
        /// 文书取物品指标
        /// </summary>
        [DataMember]
        public string WSZB { get; set; }

        /// <summary>
        /// 工厂对应文书类名称
        /// </summary>
        [DataMember]
        public string FACTORYCLASSNAME { get; set; }

        /// <summary>
        /// 动作标识为了标识该份文书所属动作
        /// </summary>
        [DataMember]
        public string ACTIONNAME { get; set; }

        /// <summary>
        /// 用于文书排序id
        /// </summary>
        [DataMember]
        public string PXID { get; set; }

        /// <summary>
        /// 要转换成的目标文书
        /// </summary>
        [DataMember]
        public string ConvertWS { get; set; }

        /// <summary>
        /// 文书字号设置
        /// </summary>
        [DataMember]
        public string WSZH { get; set; }

        public WSConfige() { }

        public WSConfige(string _id, string _wsmc, string _ajwsbh, string _dwid, string _wslx,string _modelname,string _pathname,string _wsfromname,string _wszb,string _factoryclassname,string _actionname,string _pxid,string _covws,string _wszh)
        {
            this.ID = _id;
            this.WSMC = _wsmc;
            this.AJWSBH = _ajwsbh;
            this.DWID = _dwid;
            this.WSFLID = _wslx;
            this.MODELNAME = _modelname;
            this.PATHNAME = _pathname;
            this.WSFORMNAME = _wsfromname;
            this.WSZB = _wszb;
            this.FACTORYCLASSNAME = _factoryclassname;
            this.ACTIONNAME = _actionname;
            this.PXID = _pxid;
            this.ConvertWS = _covws;
            this.WSZH = _wszh;
        }
    }
}
