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
        public Dictionary<string, string> ExtProperties { get; set; }       //������չ����

        public OrgExtInfo()
        {

        }
        public OrgExtInfo(string _zzjgid, string _zzjgqc, string _zzjgxsmc, decimal _isDisplay, decimal _order, string _sjdwid)
        {
            ExtProperties = new Dictionary<string, string>();
            ExtProperties.Add("ZZJGID", _zzjgid);//��֯����ID
            ExtProperties.Add("ZZJGQC", _zzjgqc);//��֯����ȫ��
            ExtProperties.Add("JGXSMC", _zzjgxsmc);//��֯������ʾ����
            ExtProperties.Add("ISDISPLAY", _isDisplay.ToString());//�Ƿ���ʾ
            ExtProperties.Add("DISPLAYORDER", _order.ToString());//��ʾ˳��
            ExtProperties.Add("SJDWID", _sjdwid);      //�ϼ���λID
        }



    }
}
