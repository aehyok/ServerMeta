using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    [DataContract]
    public class WPBMXHInfo
    {
        /// <summary>
        ///销毁物品ID
        /// </summary>
        [DataMember]
        public decimal XHWPID { get; set; }
        /// <summary>
        /// 执行ID
        /// </summary>
        [DataMember]
        public decimal ZXID { get; set; }
        /// <summary>
        /// 案件ID
        /// </summary>
        [DataMember]
        public decimal AJID { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [DataMember]
        public string WPMC { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        public string GG { get; set; }
        /// <summary>
        /// 销毁数量
        /// </summary>
        [DataMember]
        public decimal XHSL { get; set; }
        /// <summary>
        /// 价值
        /// </summary>
        [DataMember]
        public decimal JZ { get; set; }
        /// <summary>
        /// 偷逃税额
        /// </summary>
        [DataMember]
        public decimal TTSE { get; set; }
        /// <summary>
        /// 计量单位代码
        /// </summary>
        [DataMember]
        public string JLDWDM { get; set; }
        /// <summary>
        /// 原产地
        /// </summary>
        [DataMember]
        public string YCDDM { get; set; }
        /// <summary>
        /// 新旧程度
        /// </summary>
        [DataMember]
        public string XJCDDM { get; set; }
        /// <summary>
        /// 武平仓单号
        /// </summary>
        [DataMember]
        public string WPCDH { get; set; }
        /// <summary>
        /// 处理类型
        /// </summary>
        [DataMember]
        public string CLLX { get; set; }

        /// <summary>
        /// 物品ID
        /// </summary>
        [DataMember]
        public decimal WPID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public WPBMXHInfo()
        { 
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xhwpid">物品销毁ID</param>
        /// <param name="zxid">执行ID</param>
        /// <param name="ajid">案件ID</param>
        /// <param name="wpmc">物品名称</param>
        /// <param name="gg">规格</param>
        /// <param name="xhsl">销毁数量</param>
        /// <param name="jz">价值</param>
        /// <param name="ttse">偷逃税额</param>
        /// <param name="jldwdm">计量单位代码</param>
        /// <param name="ycddm">原产地代码</param>
        /// <param name="xjcddm">新旧程度代码</param>
        /// <param name="wpcdh">物品仓单号</param>
        /// <param name="cllx">处理类型</param>
        /// <param name="wpid">物品ID</param>
        public WPBMXHInfo(decimal xhwpid, decimal zxid, decimal ajid, string wpmc, string gg, decimal xhsl, decimal jz, decimal ttse, string jldwdm, string ycddm, string xjcddm, string wpcdh, string cllx,decimal wpid)
        {
            this.XHWPID = xhwpid;
            this.ZXID = zxid;
            this.AJID = ajid;
            this.WPMC = wpmc;
            this.GG = gg;
            this.XHSL = xhsl;
            this.JZ = jz;
            this.TTSE = ttse;
            this.JLDWDM = jldwdm;
            this.YCDDM = ycddm;
            this.WPCDH = wpcdh;
            this.XJCDDM = xjcddm;
            this.CLLX = cllx;
            this.WPID = wpid;
        }
    }
}
