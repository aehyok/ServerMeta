using System;
using System.Collections;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoRightItem ָһ��Ȩ�޶������ID,���Ƽ���ض���
    /// </summary>
    /// 
    [DataContract]
    public class SinoRightItem
    {
        /// <summary>
        /// Ȩ��ID
        /// </summary>
        [DataMember]
        public string RightID { get; set; }
        /// <summary>
        /// ��Ȩ��ID
        /// </summary>
        [DataMember]
        public string FatherRightID { get; set; }
        /// <summary>
        /// Ȩ������
        /// </summary>
        [DataMember]
        public string RightName { get; set; }
        /// <summary>
        /// Ȩ������
        /// </summary>
        [DataMember]
        public string RightDescript { get; set; }
        /// <summary>
        /// Ȩ�����͡������̶����ͻ�̬����
        /// </summary>
        [DataMember]
        public string RightType { get; set; }
        /// <summary>
        /// Ȩ�޵�META
        /// </summary>
        [DataMember]
        public string RightMeta { get; set; }
        /// <summary>
        /// ��Ӧ�Ĳ˵�ID
        /// </summary>
        [DataMember]
        public string MenuID { get; set; }
        /// <summary>
        /// Ȩ�޿��ܵļ�����
        /// </summary>
        [DataMember]
        public ArrayList RightLevels { get; set; }




    }

    /// <summary>
    /// Ȩ�޼���Ķ���
    /// </summary>
    [DataContract]
    public class RightLevelName
    {
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public decimal Index { get; set; }
        /// <summary>
        /// ������ʾ
        /// </summary>
        [DataMember]
        public string DisplayText { get; set; }

    }
}