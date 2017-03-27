using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract(IsReference = true)]
    public class MD_QueryModel
    {
        public MD_QueryModel() { }
        public MD_QueryModel(string _qid, string _ns, string _qName, string _des, string _title, string _dw, bool _isFix, bool _isRelation,
                bool _isda, int _order, string _interface)
        {
            QueryModelID = _qid;
            NamespaceName = _ns;
            QueryModelName = _qName;
            Description = _des;
            DisplayTitle = _title;
            DWDM = _dw;
            IsFixQuery = _isFix;
            IsRelationQuery = _isRelation;
            IsDataAuditing = _isda;
            DisplayOrder = _order;
            QueryInterface = _interface;
            FullName = string.Format("{0}.{1}", NamespaceName, QueryModelName);
        }

        /// <summary>
        /// ��ģ��ʹ�õĲ�ѯ�ӿ�
        /// </summary>
        [DataMember]
        public string QueryInterface { get; set; }


        /// <summary>
        /// �����ռ�
        /// </summary>
        [DataMember]
        public MD_Namespace Namespace { get; set; }

        [DataMember]
        public string NamespaceName { get; set; }

        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public MD_ViewTable MainTable { get; set; }


        /// <summary>
        /// �ӱ��б�
        /// </summary>
        [DataMember]
        public IList<MD_ViewTable> ChildTables { get; set; }

        [DataMember]
        public IList<MD_View2ViewGroup> View2ViewGroup { get; set; }

        [DataMember]
        public IList<MD_View_GuideLine> View2GuideLines { get; set; }

        [DataMember]
        public IList<MD_View2App> View2Application { get; set; }

        /// <summary>
        /// ��ѯģ������
        /// </summary>
        [DataMember]
        public string QueryModelName { get; set; }

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
        /// �ڵ���
        /// </summary>
        [DataMember]
        public String DWDM { get; set; }

        /// <summary>
        /// �Ƿ�̶���ѯ
        /// </summary>
        [DataMember]
        public bool IsFixQuery { get; set; }

        /// <summary>
        /// �Ƿ������ѯ
        /// </summary>
        [DataMember]
        public bool IsRelationQuery { get; set; }

        /// <summary>
        /// �Ƿ��������
        /// </summary>
        [DataMember]
        public bool IsDataAuditing { get; set; }
        /// <summary>
        /// ��ʾ˳��
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ѯģ��ID
        /// </summary>
        [DataMember]
        public string QueryModelID { get; set; }

        [DataMember]
        public string EXTMeta { get; set; }

        public override string ToString()
        {
            return DisplayTitle;
        }
    }
}
