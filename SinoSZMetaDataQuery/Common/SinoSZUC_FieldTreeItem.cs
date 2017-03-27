using System;
using System.Collections.Generic;
using System.Text;


using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.EnumDefine;

namespace SinoSZMetaDataQuery.Common
{
        public class SinoSZUC_FieldTreeItem
        {
                protected string id = "";
                protected string parentID = "";
                protected int state = 0;
                protected object data = null;
                protected string itemType = "NONE";
                protected string displayTitle = "";
                protected bool isDefault = false;
                protected bool canShowAsResult = true;
                protected bool canShowAsCondition = true;
                protected string alias = "";
                protected string dataType = "";


                public bool CanShowAsCondition
                {
                        get { return canShowAsCondition; }
                        set { canShowAsCondition = value; }
                }

                public bool CanShowAsResult
                {
                        get { return canShowAsResult; }
                        set { canShowAsResult = value; }
                }

                public bool IsDefault
                {
                        get { return isDefault; }
                        set { isDefault = value; }
                }

                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string ParentID
                {
                        get { return parentID; }
                        set { parentID = value; }
                }

                public object Data
                {
                        get { return data; }
                        set { data = value; }
                }

                public string ItemType
                {
                        get { return itemType; }
                        set { itemType = value; }
                }

                /// <summary>
                /// 状态，　0:全不选　1:选择部分　2:全选  3:不可作为结果字段
                /// </summary>
                public int State
                {
                        get { return state; }
                        set { state = value; }
                }

                public string Alias
                {
                        get { return alias; }
                        set { alias = value; }
                }

                public string DataType
                {
                        get { return dataType; }
                        set { dataType = value; }
                }

                public SinoSZUC_FieldTreeItem() { }

                public SinoSZUC_FieldTreeItem(MDModel_Table _mt)
                {
                        id = _mt.TableDefine.TableID;
                        parentID = "";
                        state = 0;
                        data = _mt;
                        itemType = "TABLE";
                        displayTitle = _mt.TableDefine.DisplayTitle;
                        isDefault = true;
                }

                public SinoSZUC_FieldTreeItem(MDModel_Table_Column _tc)
                {
                        if (_tc.ColumnType == QueryColumnType.TableColumn)
                        {
                                id = _tc.ColumnDefine.ColumnID;
                                parentID = _tc.TID;
                                data = _tc;
                                itemType = "COLUMN";
                                displayTitle = _tc.ColumnTitle;
                                isDefault = _tc.ColumnDefine.DefaultResult;
                                canShowAsResult = _tc.ColumnDefine.CanShowAsResult;
                                canShowAsCondition = _tc.ColumnDefine.CanShowAsCondition;
                                alias = _tc.ColumnAlias;
                                dataType = _tc.ColumnDataType;
                                if (canShowAsResult)
                                {
                                        state = 0;
                                }
                                else
                                {
                                        state = 3;
                                }
                        }
                        else
                        {
                                id = _tc.ColumnAlias;
                                parentID = _tc.TID;
                                data = _tc;
                                itemType = "COLUMN";
                                displayTitle = _tc.ColumnTitle;
                                isDefault = false;
                                canShowAsResult = true;
                                canShowAsCondition = true;
                                alias = _tc.ColumnAlias;
                                dataType = _tc.ColumnDataType;

                                state = 0;

                        }
                }

                public static IList<SinoSZUC_FieldTreeItem> GetListByQueryView(MDModel_QueryModel _model)
                {
                        List<SinoSZUC_FieldTreeItem> _ret = new List<SinoSZUC_FieldTreeItem>();
                        SinoSZUC_FieldTreeItem _mainTableItem = new SinoSZUC_FieldTreeItem(_model.MainTable);
                        _ret.Add(_mainTableItem);
                        foreach (MDModel_Table_Column _tc in _model.MainTable.Columns)
                        {
                                if (_tc.ColumnDefine.CanShowAsCondition || _tc.ColumnDefine.CanShowAsResult)
                                {
                                        SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_tc);
                                        _ret.Add(_tcItem);
                                }
                        }

                        foreach (MDModel_Table _ctable in _model.ChildTableDict.Values)
                        {
                                SinoSZUC_FieldTreeItem _cTableItem = new SinoSZUC_FieldTreeItem(_ctable);
                                _ret.Add(_cTableItem);
                                foreach (MDModel_Table_Column _tc in _ctable.Columns)
                                {
                                        if (_tc.ColumnDefine.CanShowAsCondition || _tc.ColumnDefine.CanShowAsResult)
                                        {
                                                SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_tc);
                                                _ret.Add(_tcItem);
                                        }
                                }
                        }
                        return _ret;
                }


                public static IList<SinoSZUC_FieldTreeItem> GetSingleLineDefaultListByQueryView(MDModel_QueryModel _model)
                {
                        List<SinoSZUC_FieldTreeItem> _ret = new List<SinoSZUC_FieldTreeItem>();
                        SinoSZUC_FieldTreeItem _mainTableItem = new SinoSZUC_FieldTreeItem(_model.MainTable);
                        _ret.Add(_mainTableItem);
                        bool _haveSelected = false;
                        foreach (MDModel_Table_Column _tc in _model.MainTable.Columns)
                        {
                                if (_tc.ColumnDefine.CanShowAsCondition || _tc.ColumnDefine.CanShowAsResult)
                                {
                                        SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_tc);
                                        if (_tc.ColumnDefine.DefaultResult)
                                        {
                                                _tcItem.State = 2;
                                                _haveSelected = true;
                                        }
                                        _ret.Add(_tcItem);
                                }
                        }
                        if (_haveSelected)
                        {
                                _mainTableItem.State = 1;
                        }


                        foreach (MDModel_Table _ctable in _model.ChildTableDict.Values)
                        {
                                if (_ctable.TableDefine.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord)
                                {
                                        _haveSelected = false;
                                        SinoSZUC_FieldTreeItem _cTableItem = new SinoSZUC_FieldTreeItem(_ctable);
                                        _ret.Add(_cTableItem);
                                        foreach (MDModel_Table_Column _tc in _ctable.Columns)
                                        {
                                                if (_tc.ColumnDefine.CanShowAsCondition || _tc.ColumnDefine.CanShowAsResult)
                                                {
                                                        SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_tc);
                                                        if (_tc.ColumnDefine.DefaultResult)
                                                        {
                                                                _tcItem.state = 2;
                                                                _haveSelected = true;
                                                        }
                                                        _ret.Add(_tcItem);
                                                }
                                        }
                                        if (_haveSelected)
                                        {
                                                _cTableItem.State = 1;
                                        }
                                }
                        }

                        return _ret;
                }
        }
}
