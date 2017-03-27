using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    /// <summary>
    /// 预统计值表
    /// </summary>
    [DataContract]
    public class ReportYTJZB
    {
        /// <summary>
        /// 统计单位ID
        /// </summary>
        [DataMember]
        public string TJDWID { set; get; }
        /// <summary>
        /// 统计项目名称
        /// </summary>
        [DataMember]
        public string TJXMFL { set; get; }
        /// <summary>
        /// 统计项目值
        /// </summary>
        [DataMember]
        public string TJXMZ { set; get; }
        /// <summary>
        /// 统计分析分类
        /// </summary>
        [DataMember]
        public string TJFXFL { set; get; }
        /// <summary>
        /// 统计分项
        /// </summary>
        [DataMember]
        public string TJFXZ { set; get; }
        /// <summary>
        /// 计算日期
        /// </summary>
        [DataMember]
        public DateTime JSSJ { set; get; }
        /// <summary>
        /// 数据有效日期
        /// </summary>
        [DataMember]
        public DateTime SJYXQ { set; get; }
        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public DateTime KSRQ { set; get; }
        /// <summary>
        /// 截止日期
        /// </summary>
        [DataMember]
        public DateTime JZRQ { set; get; }
        /// <summary>
        /// 指标ID
        /// </summary>
        [DataMember]
        public string ZBID { set; get; }
        public ReportYTJZB(string tjdwid, string tjxmfl, string tjxmz, string tjfxfl, string tjfxz, DateTime jssj, DateTime sjyxq, DateTime ksrq, DateTime jzrq, string zbid)
        {
            this.TJDWID = tjdwid;
            this.TJXMFL = tjxmfl;
            this.TJXMZ = tjxmz;
            this.TJFXFL = tjfxfl;
            this.TJFXZ = tjfxz;
            this.JSSJ = jssj;
            this.SJYXQ = sjyxq;
            this.KSRQ = ksrq;
            this.JZRQ = jzrq;
            this.ZBID = zbid;
        }
    }
}
