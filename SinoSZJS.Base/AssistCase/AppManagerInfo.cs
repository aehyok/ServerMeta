using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    /// <summary>
    /// 辅助办案中的鉴定基本信息
    /// </summary>
    [DataContract]
    public class AppManagerInfo
    {
        /// <summary>
        /// 鉴定项目
        /// </summary>
        [DataMember]
        public string AppProject { get; set; }

        /// <summary>
        /// 鉴定说明
        /// </summary>
        [DataMember]
        public string AppDescription { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        [DataMember]
        public string AppManager { get; set; }

        /// <summary>
        /// 鉴定日期
        /// </summary>
        [DataMember]
        public string AppDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 鉴定证书号
        /// </summary>
        [DataMember]
        public string AppCNo { get; set; }

        /// <summary>
        /// 鉴定后报告日期
        /// </summary>
        [DataMember]
        public string AppReportDate { get; set; }

        /// <summary>
        /// 鉴定岗位
        /// </summary>
        [DataMember]
        public string AppPostDM { get; set; }
        /// <summary>
        /// 鉴定样品
        /// </summary>
        [DataMember]
        public string AppSample { get; set; }

        /// <summary>
        /// 物品ID
        /// </summary>
        [DataMember]
        public string WPID { get; set; }

        /// <summary>
        /// 鉴定信息ID
        /// </summary>
        [DataMember]
        public string JDID { get; set; }

        /// <summary>
        /// 鉴定状态
        /// </summary>
        [DataMember]
        public decimal AppState { get; set; }
        public AppManagerInfo(string appproject,string appdescript,string appmanager,string appdate,string remark,string goodsid)
        {
            this.AppProject = appproject;
            this.AppDescription = appdescript;
            this.AppManager = appmanager;
            this.AppDate = appdate;
            this.Remark = remark;
            this.WPID = goodsid;
        }

        public AppManagerInfo(string appid, string appCNo, string appReportDate, string appPostDM)
        {
            this.JDID = appid;
            this.AppCNo = appCNo;
            this.AppReportDate = appReportDate;
            this.AppPostDM = appPostDM;
        }

        public AppManagerInfo() { }
    }
}
