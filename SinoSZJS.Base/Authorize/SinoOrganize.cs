using System;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoOrganize ��ժҪ˵����
    /// ��λ��֯����
    /// 2006-11-4
    /// </summary>        
    [DataContract]
    public class SinoOrganize
    {
        //�Ƿ��ѡ
        [DataMember]
        public bool CanSeleceted { get; set; }


        /// <summary>
        /// ��ʾ˳��
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��λID��
        /// </summary>
        [DataMember]
        public decimal Code { get; set; }
        /// <summary>
        /// ����λID��
        /// </summary>
        [DataMember]
        public decimal FatherCode { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// ��λȫ��
        /// </summary>
        [DataMember]
        public string FullName { get; set; }
        /// <summary>
        /// ��λ���ʡ�(ְ�ܴ���\�����ش�)
        /// </summary>
        [DataMember]
        public string Function { get; set; }

        /// <summary>
        /// ��λ����
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }

        public SinoOrganize()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        public SinoOrganize(decimal _code, decimal _fatherCode, string _dwdm, string _name, string _fullName, string _function, int _order)
        {
            this.Code = _code;
            this.DWDM = _dwdm;
            this.FatherCode = _fatherCode;
            this.Name = _name;
            this.FullName = _fullName;
            this.Function = _function;
            this.DisplayOrder = _order;
        }

        public SinoOrganize(decimal _code, decimal _fatherCode, string _dwdm, string _name, string _fullName, string _function, int _order, bool _canSelected)
        {
            this.Code = _code;
            this.DWDM = _dwdm;
            this.FatherCode = _fatherCode;
            this.Name = _name;
            this.FullName = _fullName;
            this.Function = _function;
            this.DisplayOrder = _order;
            this.CanSeleceted = _canSelected;
        }
    }
}
