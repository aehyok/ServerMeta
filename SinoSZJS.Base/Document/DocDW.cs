using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    /// <summary>
    /// 单位文书实体
    /// </summary>
    [DataContract]
    public class DocDW
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 文书类型ID
        /// </summary>
        [DataMember]
        public string WSLXID { get; set; }
        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string WSMC { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string DWID { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string DWMC { get; set; }
        /// <summary>
        /// 文书模版
        /// </summary>
        [DataMember]
        public string WSMB { get; set; }
        /// <summary>
        /// 对应流程ID
        /// </summary>
        [DataMember]
        public string LCID { get; set; }
        /// <summary>
        /// 案件系统文书ID
        /// </summary>
        [DataMember]
        public string AJWSBH { get; set; }

        /// <summary>
        /// 文书对应的录入模型
        /// </summary>
        [DataMember]
        public string WSModelName { get; set; }

        /// <summary>
        /// 文书对应的视图名称
        /// </summary>
        [DataMember]
        public string PathName { get; set; }

        /// <summary>
        /// 文书字号起始数值
        /// </summary>
        [DataMember]
        public string StartNo { get; set; }

        public DocDW() { }

        public DocDW(string _id, string _wslxid, string _wsmc, string _dwid, string _dwmc, string _wsmb, string _lcid,string _modelname,string _pathname)
        {
            this.ID = _id;
            this.WSLXID = _wslxid;
            this.WSMC = _wsmc;
            this.DWID = _dwid;
            this.DWMC = _dwmc;
            this.WSMB = _wsmb;
            this.LCID = _lcid;
            this.WSModelName = _modelname;
            this.PathName = _pathname;
        }
        public DocDW(string _id, string _wslxid, string _wsmc, string _dwid, string _dwmc, string _wsmb, string _lcid)
        {
            this.ID = _id;
            this.WSLXID = _wslxid;
            this.WSMC = _wsmc;
            this.DWID = _dwid;
            this.DWMC = _dwmc;
            this.WSMB = _wsmb;
            this.LCID = _lcid;
        }

        public DocDW(string _id, string _wslxid, string _wsmc, string _dwid, string _dwmc, string _wsmb, string _lcid,string _ajwsbh)
        {
            this.ID = _id;
            this.WSLXID = _wslxid;
            this.WSMC = _wsmc;
            this.DWID = _dwid;
            this.DWMC = _dwmc;
            this.WSMB = _wsmb;
            this.LCID = _lcid;
            this.AJWSBH = _ajwsbh;
        }
    }
}
