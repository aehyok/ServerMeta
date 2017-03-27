using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoPost 用户的岗位定义 
    /// </summary>
    [DataContract]
    public class SinoPost
    {
        /// <summary>
        /// 此岗位的角色列表
        /// </summary>
        [DataMember]
        public List<SinoRole> Roles { get; set; }
        /// <summary>
        /// 此岗位的权限列表
        /// </summary>               
        [DataMember]
        public Dictionary<string, UserRightItem> Rights { get; set; }
        /// <summary>
        /// 是否默认岗位
        /// </summary>
        [DataMember]
        public bool IsDefaultPost { get; set; }
        /// <summary>
        /// 岗位ID
        /// </summary>
        [DataMember]
        public string PostID { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        [DataMember]
        public string PostName { get; set; }
        /// <summary>
        /// 岗位所在的单位ID
        /// </summary>
        [DataMember]
        public string PostDwID { get; set; }
        /// <summary>
        /// 岗位权限所在单位代码
        /// </summary>
        [DataMember]
        public string PostDWDM { get; set; }
        /// <summary>
        /// 岗位所在的单位名称
        /// </summary>
        [DataMember]
        public string PostDWMC { get; set; }
        /// <summary>
        /// 权限所在单位的GUID
        /// </summary>
        [DataMember]
        public string PostDWGUID { get; set; }
        /// <summary>
        /// 安全级别
        /// </summary>
        [DataMember]
        public int SecretLevel { get; set; }
        /// <summary>
        /// 岗位描述
        /// </summary>
        [DataMember]
        public string PostDescript { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        public SinoPost()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public SinoPost(string _gwmc, string _gwid, string _gwdwid, string _dwmc, string _dwdm, string _gwms, int _secretLevel, bool _sfmr)
        {
            this.PostName = _gwmc;
            this.PostID = _gwid;
            this.PostDwID = _gwdwid;
            this.PostDWMC = _dwmc;
            this.PostDWDM = _dwdm;
            this.PostDescript = _gwms;
            this.IsDefaultPost = _sfmr;
            this.SecretLevel = _secretLevel;
            this.Rights = new Dictionary<string, UserRightItem>();
            this.Roles = new List<SinoRole>();
            this.DisplayOrder = 0;
        }
        //新添加
        public SinoPost(string _gwmc, string _gwid, string _gwdwid, string _dwmc, string _dwdm, string _gwms, int _secretLevel, bool _sfmr, int _order)
        {
            this.PostName = _gwmc;
            this.PostID = _gwid;
            this.PostDwID = _gwdwid;
            this.PostDWMC = _dwmc;
            this.PostDWDM = _dwdm;
            this.PostDescript = _gwms;
            this.IsDefaultPost = _sfmr;
            this.SecretLevel = _secretLevel;
            this.DisplayOrder = (_order == 0) ? 100 : _order;
            this.Rights = new Dictionary<string, UserRightItem>();
            this.Roles = new List<SinoRole>();
        }
    }
}
