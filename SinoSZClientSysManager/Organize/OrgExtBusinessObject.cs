using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraTreeList;
using System.Data;
using SinoSZJS.Base.OrganizeExt;

namespace SinoSZClientSysManager.Organize
{
    public class OrgExtBusinessObject
    {
        protected bool isChanged = false;
        protected OrgExtList childOrgList = new OrgExtList();
        protected OrgExtList owner = null;
        protected OrgExtInfo infoData = null;
        protected Dictionary<string, OrgExtFieldDefine> columns = new Dictionary<string, OrgExtFieldDefine>();

        public OrgExtInfo GetInfoData()
        {
            return infoData;
        }

        public bool IsBlank
        {
            get
            {
                if (infoData == null && columns == null) return true;
                else
                    return false;
            }
        }

        public OrgExtBusinessObject(OrgExtInfo _info, List<OrgExtFieldDefine> _cols)
        {
            infoData = _info;

            columns.Clear();
            if (_cols != null)
            {
                foreach (OrgExtFieldDefine _item in _cols)
                {
                    columns.Add(_item.FieldName, _item);
                }
            }
            else
            {
                columns = null;
            }
        }

        public Dictionary<string, OrgExtFieldDefine> Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        public bool IsChanged
        {
            get { return isChanged; }
        }
        public OrgExtList Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public OrgExtList ChildOrgList
        {
            get { return childOrgList; }
            set
            {
                childOrgList = value;
                OnChanged();
            }
        }

        public object GetData(string _fieldName)
        {
            if (infoData == null) return null;
            try
            {
                if (columns.ContainsKey(_fieldName))
                {
                    if (infoData.GetValue(_fieldName) == null) return null;
                    OrgExtFieldDefine _fDefine = columns[_fieldName];
                    switch (_fDefine.FieldType)
                    {
                        case "VARCHAR2":
                        case "NVARCHAR2":
                        case "VARCHAR":
                            return Convert.ToString(infoData.GetValue(_fieldName));

                        case "NUMBER":
                            return Convert.ToDecimal(infoData.GetValue(_fieldName));

                        case "DATE":
                            return Convert.ToDateTime(infoData.GetValue(_fieldName));

                        case "BOOL":
                            return (decimal.Parse(infoData.GetValue(_fieldName)) > 0) ? true : false;

                    }
                    return infoData.GetValue(_fieldName);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void SetData(string _fieldName, object _value)
        {
            if (infoData == null) return;
            if (!columns.ContainsKey(_fieldName)) return;
            if (_value == null) infoData.SetValue(_fieldName, null);

            try
            {
                OrgExtFieldDefine _fDefine = columns[_fieldName];
                switch (_fDefine.FieldType)
                {
                    case "VARCHAR2":
                    case "NVARCHAR2":
                    case "VARCHAR":
                        infoData.SetValue(_fieldName, Convert.ToString(_value));
                        break;
                    case "NUMBER":
                        infoData.SetValue(_fieldName, Convert.ToDecimal(_value));
                        break;
                    case "DATE":
                        infoData.SetValue(_fieldName, Convert.ToDateTime(_value));
                        break;
                    case "BOOL":
                        infoData.SetValue(_fieldName, ((bool)_value) ? (decimal)1 : (decimal)0);
                        break;
                }
                isChanged = true;
                OnChanged();
            }
            catch (Exception e)
            {
                isChanged = false;
                return;
            }
        }
        void OnChanged()
        {
            if (owner == null) return;
            int index = owner.IndexOf(this);
            owner.ResetItem(index);
        }

        public void AcceptChanged()
        {
            isChanged = false;
        }
    }

    public class OrgExtList : BindingList<OrgExtBusinessObject>, TreeList.IVirtualTreeListData
    {

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            OrgExtBusinessObject obj = info.Node as OrgExtBusinessObject;
            info.Children = obj.ChildOrgList;
        }
        protected override void InsertItem(int index, OrgExtBusinessObject item)
        {
            item.Owner = this;
            base.InsertItem(index, item);
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            OrgExtBusinessObject obj = info.Node as OrgExtBusinessObject;
            info.CellData = obj.GetData(info.Column.FieldName);

        }
        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            OrgExtBusinessObject obj = info.Node as OrgExtBusinessObject;
            obj.SetData(info.Column.FieldName, info.NewCellData);
        }
    }
}
