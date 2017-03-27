using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    /// <summary>
    /// 文书实体
    /// </summary>
    [DataContract]
    public class DocEntity
    {
        /// <summary>
        /// 文书ID
        /// </summary>
        [DataMember]
        public string WSID { get; set; }
        /// <summary>
        /// 案件ID
        /// </summary>
        [DataMember]
        public string AJID { get; set; }
        /// <summary>
        /// 文书编号(配置ID)
        /// </summary>
        [DataMember]
        public string WSBH { get; set; }
        /// <summary>
        /// 文书中文名称
        /// </summary>
        [DataMember]
        public string WSBHMC { get; set; }
        /// <summary>
        /// 文书字号
        /// </summary>
        [DataMember]
        public string WSZH { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        [DataMember]
        public string DQZT { get; set; }
        /// <summary>
        /// 文书内容BLOB
        /// </summary>
        [DataMember]
        public byte[] WSNR { get; set; }
        /// <summary>
        /// 文书数据 存CLOB
        /// </summary>
        [DataMember]
        public string WSSJ { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        [DataMember]
        public DateTime SCSJ { get; set; }
        /// <summary>
        /// 处理ID
        /// </summary>
        [DataMember]
        public string CLID { get; set; }
        /// <summary>
        /// 打开方式
        /// </summary>
        [DataMember]
        public string DKFS { get; set; }
        /// <summary>
        /// 经办人员
        /// </summary>
        [DataMember]
        public string WSJBR { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        [DataMember]
        public string DWID { get; set; }


        public DocEntity() { }

        public DocEntity(string _wsid, string _ajid, string _wsbh, string _wsbhmc, string _wszh, string _dqzt,
                          byte[] _wsnr, string _wssj, DateTime _scsj, string _clid, string _dkfs, string _wsjbr, string _dwid)
        {
            this.WSID = _wsid;
            this.AJID = _ajid;
            this.WSBH = _wsbh;
            this.WSBHMC = _wsbhmc;
            this.WSZH = _wszh;
            this.DQZT = _dqzt;
            this.WSNR = _wsnr;
            this.WSSJ = _wssj;
            this.SCSJ = _scsj;
            this.CLID = _clid;
            this.DKFS = _dkfs;
            this.WSJBR = _wsjbr;
            this.DWID = _dwid;
        }

    }
}
