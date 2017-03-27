using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoPost �û��ĸ�λ���� 
    /// </summary>
    [DataContract]
    public class SinoPost
    {
        /// <summary>
        /// �˸�λ�Ľ�ɫ�б�
        /// </summary>
        [DataMember]
        public List<SinoRole> Roles { get; set; }
        /// <summary>
        /// �˸�λ��Ȩ���б�
        /// </summary>               
        [DataMember]
        public Dictionary<string, UserRightItem> Rights { get; set; }
        /// <summary>
        /// �Ƿ�Ĭ�ϸ�λ
        /// </summary>
        [DataMember]
        public bool IsDefaultPost { get; set; }
        /// <summary>
        /// ��λID
        /// </summary>
        [DataMember]
        public string PostID { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        [DataMember]
        public string PostName { get; set; }
        /// <summary>
        /// ��λ���ڵĵ�λID
        /// </summary>
        [DataMember]
        public string PostDwID { get; set; }
        /// <summary>
        /// ��λȨ�����ڵ�λ����
        /// </summary>
        [DataMember]
        public string PostDWDM { get; set; }
        /// <summary>
        /// ��λ���ڵĵ�λ����
        /// </summary>
        [DataMember]
        public string PostDWMC { get; set; }
        /// <summary>
        /// Ȩ�����ڵ�λ��GUID
        /// </summary>
        [DataMember]
        public string PostDWGUID { get; set; }
        /// <summary>
        /// ��ȫ����
        /// </summary>
        [DataMember]
        public int SecretLevel { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        [DataMember]
        public string PostDescript { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        public SinoPost()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
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
        //�����
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
