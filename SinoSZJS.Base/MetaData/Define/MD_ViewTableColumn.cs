using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_ViewTableColumn
    {
        public MD_ViewTableColumn(string _vtcid, string _vtid, string _tcid, bool _cancondi, bool _canres, bool _defaultshow,
                bool _isfixitem, bool _canmodify, string _dw, int _prio, int _displayOrder)
        {

            ViewTableColumnID = _vtcid;
            ViewTableID = _vtid;
            ColumnID = _tcid;
            CanShowAsCondition = _cancondi;
            CanShowAsResult = _canres;
            DefaultResult = _defaultshow;
            IsFixQueryItem = _isfixitem;
            CanModify = _canmodify;
            DWDM = _dw;
            Priority = _prio;
            DisplayOrder = _displayOrder;

        }

        [DataMember]
        public string ColumnID { get; set; }

        /// <summary>
        /// ����ֶζ���
        /// </summary>
        [DataMember]
        public MD_TableColumn TableColumn { get; set; }


        /// <summary>
        /// ȡ��Ӧ�ı�ID
        /// </summary>
        [DataMember]
        public string TID { get; set; }

        [DataMember]
        public string TableName { get; set; }

        /// <summary>
        /// ���ֶ����ڵ���ͼ��
        /// </summary>
        [DataMember]
        public string ViewTableID { get; set; }

        /// <summary>
        /// ���ֶε�ID
        /// </summary>
        [DataMember]
        public string ViewTableColumnID { get; set; }

        /// <summary>
        /// �Ƿ����Ϊ��ѯ������ʾ
        /// </summary>
        [DataMember]
        public bool CanShowAsCondition { get; set; }

        /// <summary>
        /// �Ƿ����Ϊ��ѯ�����ʾ
        /// </summary>
        [DataMember]
        public bool CanShowAsResult { get; set; }

        /// <summary>
        /// �Ƿ�ΪĬ�Ͻ����
        /// </summary>
        [DataMember]
        public bool DefaultResult { get; set; }

        /// <summary>
        /// �Ƿ�Ϊ�̶���ѯ�ֶ�
        /// </summary>
        [DataMember]
        public bool IsFixQueryItem { get; set; }

        /// <summary>
        /// �Ƿ�����޸ģ�ֻ����������͵�VIEW��
        /// </summary>
        [DataMember]
        public bool CanModify { get; set; }

        /// <summary>
        /// �ڵ���
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }
        /// <summary>
        /// ��ʾ˳��
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ѯ����Ȩ(��ֵԽС��Խ��)
        /// </summary>
        [DataMember]
        public int Priority { get; set; }

        public string DisplayTitle
        {
            get
            {
                if (TableColumn == null) return "";
                return TableColumn.DisplayTitle;
            }
            set
            {
                TableColumn.DisplayTitle = value;
            }
        }
    }
}
