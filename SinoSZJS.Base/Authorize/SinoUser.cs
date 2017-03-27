using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoUser �û����塣
    /// �û�������
    /// </summary>
    [DataContract]
    public class SinoUser
    {
        /// <summary>
        /// �û����н�ɫ��
        /// </summary>
        /// 
        [DataMember]
        public List<SinoRole> Roles { get; set; }

        /// <summary>
        /// �û���ǰ���е�Ȩ�޼�
        /// </summary>
        //[DataMember]
        //public Dictionary<string, UserRightItem> CurrentRights { get; set; }

        /// <summary>
        /// �û����и�λ��
        /// </summary>
        [DataMember]
        public List<SinoPost> Posts { get; set; }
        /// <summary>
        /// �û�Ĭ�ϸ�λ
        /// </summary>
        /// 
        [DataMember]
        public SinoPost DefaultPost { get; set; }

        /// <summary>
        /// �û���ǰʹ�õĸ�λ
        /// </summary>
        [DataMember]
        public SinoPost CurrentPost { get; set; }

        /// <summary>
        /// �û�����    ֵΪ��1:�������û�������	2:����˽���û���
        /// </summary>
        [DataMember]
        public int UserType { get; set; }
        /// <summary>
        /// �û���¼��
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>		
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        //�û���GUID
        [DataMember]
        public string UserGUID { get; set; }
        /// <summary>
        /// �û��ĺ��عغ�
        /// </summary>
        [DataMember]
        public string UserHGGH { get; set; }
        /// <summary>
        /// ��λID
        /// </summary>
        [DataMember]
        public string DwID { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        [DataMember]
        public string DwName { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        [DataMember]
        public string Dwdm { get; set; }
        /// <summary>
        /// ��λ��GUID
        /// </summary>
        [DataMember]
        public string DwGUID { get; set; }

        /// <summary>
        /// Ȩ�޲㼶,ֵΪ:�������𼶡�ֱ�����ؼ����������ؼ�
        /// </summary>
        [DataMember]
        public string QxszJB { get; set; }

        /// <summary>
        /// Ȩ�����ڵ�λ����
        /// </summary>		
        public string QxszDWDM
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDWDM;
                }
            }
        }
        /// <summary>
        /// Ȩ�����ڵ�λ����
        /// </summary>
        public string QxszDWID
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDwID;
                }
            }
        }
        /// <summary>
        /// Ȩ�����ڵ�λ����
        /// </summary>
        public string QxszDWMC
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDWMC;
                }
            }
        }
        /// <summary>
        /// Ȩ�����ڵ�λ��GUID
        /// </summary>
        public string QxszDWGUID
        {
            get
            {
                if (this.CurrentPost == null)
                {
                    return "";
                }
                else
                {
                    return this.CurrentPost.PostDWGUID;
                }
            }
        }
        /// <summary>
        /// �û��־ֵ�λID
        /// </summary>
        [DataMember]
        public string User_FJID { get; set; }
        /// <summary>
        /// �û�ֱ����ID
        /// </summary>
        [DataMember]
        public string User_ZSJID { get; set; }
        /// <summary>
        /// �û��Ƿ�㶫����
        /// </summary>
        [DataMember]
        public bool IsGDFSUser { get; set; }
        /// <summary>
        /// ��ȫ����
        /// </summary>
        [DataMember]
        public int SecretLevel { get; set; }
        /// <summary>
        /// �û�����Ʊ��
        /// </summary>
        [DataMember]
        public string EncryptedTicket { get; set; }
        /// <summary>
        /// �û�ʹ�õ�IP��ַ
        /// </summary>
        [DataMember]
        public string IPAddress { get; set; }
        /// <summary>
        /// �û�ʹ�õ�������
        /// </summary>
        [DataMember]
        public string HostName { get; set; }
        /// <summary>
        /// �û��Ƿ���֤ͨ��
        /// </summary>
        [DataMember]
        public bool IsSignOn { get; set; }

        /// <summary>
        /// �û���ϵͳID
        /// </summary>
        [DataMember]
        public string SystemID { get; set; }

        //�����
        [DataMember]
        public SinoUserBaseInfo BaseInfo = null;
        
    }
}