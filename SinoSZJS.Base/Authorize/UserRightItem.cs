using System;
using System.Data;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// RightItem ��ժҪ˵����
    /// �û������ɫ�����߱��ĵ���Ȩ�������Χ��������������
    /// </summary>
    [DataContract(IsReference = true)]
    public class UserRightItem
    {
        [DataMember]
        public SinoRightItem Right { get; set; } //Ȩ����
        [DataMember]
        public decimal Level { get; set; }  //����Χ

        public UserRightItem()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }



    }

}
