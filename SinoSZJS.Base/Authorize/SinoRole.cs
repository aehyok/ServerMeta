using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// ��ɫ����
    /// </summary>
    [DataContract]
    public class SinoRole
    {
        /// <summary>
        /// ��ɫ����Ȩ�޼���
        /// </summary>
        [DataMember]
        public List<SinoRightItem> UserRights { get; set; }
        /// <summary>
        /// ��ɫID
        /// </summary>
        [DataMember]
        public string RoleID { get; set; }
        /// <summary>
        /// ��ɫ��
        /// </summary>
        [DataMember]
        public string RoleName { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        [DataMember]
        public string Descript { get; set; }
        /// <summary>
        /// ��ɫ���͡��������Ϊ�ձ�ʾȫϵͳͨ�ý�ɫ�����ΪDWID���ʾ�˵�λ�Զ���ɫ
        /// </summary>
        [DataMember]
        public string RoleDwid { get; set; }
        [DataMember]
        public bool IsOwn { get; set; }//�����
    }
}