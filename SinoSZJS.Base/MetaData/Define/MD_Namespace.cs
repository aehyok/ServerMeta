using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    /// <summary>
    /// �����ռ�Ԫ���ݶ���
    /// </summary>
    /// 
    [DataContract]
    public class MD_Namespace
    {

        /// <summary>
        /// �����ռ���
        /// </summary>
        [DataMember]
        public string NameSpace { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        [DataMember]
        public string DisplayTitle { get; set; }

        /// <summary>
        /// ���������ݿ��е�����(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// �˵����ڵ�λ��(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
        /// </summary>
        [DataMember]
        public string MenuPosition { get; set; }

        /// <summary>
        /// �ڵ����,ָϵͳ����װ�ķ��������ڵĵ�λ����,���������ֽڵ�
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }

        /// <summary>
        /// ���ռ������ĸ�����(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
        /// </summary>
        [DataMember]
        public string Concepts { get; set; }

        /// <summary>
        /// ��ʾ˳��
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// �����ռ��еı�
        /// </summary>
        [DataMember]
        public IList<MD_Table> TableList { get; set; }

        /// <summary>
        /// �����ռ�Ĳ�ѯģ��
        /// </summary>
        [DataMember]
        public IList<MD_QueryModel> QueryModelList { get; set; }


        [DataMember]
        public IList<MD_RefTable> RefTableList { get; set; }

        /// <summary>
        /// �����ռ����ڽڵ�
        /// </summary>
        [DataMember]
        public MD_Nodes Nodes { get; set; }


        public override string ToString()
        {
            return string.Format("�����ռ�[{0}]", this.DisplayTitle);
        }



    }
}
