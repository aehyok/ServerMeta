using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report
{
    [DataContract]
    public class MD_ReportVerifyInfo
    {

        /// <summary>
        /// 审核单位名称
        /// </summary>
        [DataMember]
        public string OrgName { get; set; }


        /// <summary>
        /// 审核人姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        [DataMember]
        public DateTime VerifyDate { get; set; }

        public MD_ReportVerifyInfo() { }
        public MD_ReportVerifyInfo(string _org, string _user, DateTime _dt)
        {
            this.OrgName = _org;
            this.UserName = _user;
            this.VerifyDate = _dt;
        }
    }
}
