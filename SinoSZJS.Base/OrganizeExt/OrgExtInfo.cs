using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.OrganizeExt
{
    [DataContract]
    public class OrgExtInfo
    {
        [DataMember]
        public Dictionary<string, string> ExtProperties { get; set; }       //其它扩展属性

        public OrgExtInfo()
        {

        }
        public OrgExtInfo(string _zzjgid, string _zzjgqc, string _zzjgxsmc, decimal _isDisplay, decimal _order, string _sjdwid)
        {
            ExtProperties = new Dictionary<string, string>();
            ExtProperties.Add("ZZJGID", _zzjgid);//组织机构ID
            ExtProperties.Add("ZZJGQC", _zzjgqc);//组织机构全称
            ExtProperties.Add("JGXSMC", _zzjgxsmc);//组织机构显示名称
            ExtProperties.Add("ISDISPLAY", _isDisplay.ToString());//是否显示
            ExtProperties.Add("DISPLAYORDER", _order.ToString());//显示顺序
            ExtProperties.Add("SJDWID", _sjdwid);      //上级单位ID
        }



    }
}
