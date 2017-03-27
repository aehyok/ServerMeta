using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataQuery.Common
{
        public partial class SinoSZUC_FixConditionPanel : UserControl
        {
                private int focusedItem = 0;
                private Control focusedControl = null;
                private bool CurrentFocused = false;
                private MDModel_QueryModel QueryModel = null;
                public SinoSZUC_FixConditionPanel()
                {
                        InitializeComponent();
                }

                private void Clear()
                {
                        focusedItem = 0;
                        focusedControl = null;
                        CurrentFocused = false;
                        QueryModel = null;
                        this.xtraScrollableControl1.Controls.Clear();
                }

                public event EventHandler<EventArgs> MenuChanged;
                virtual public void RaiseMenuChanged()
                {
                        if (MenuChanged != null)
                        {
                                MenuChanged(this, new EventArgs());
                        }
                }

                public void ShowConditionItems(MDModel_QueryModel _queryModel)
                {
                        Clear();
                        QueryModel = _queryModel;
                        MDModel_Table _mainTable = _queryModel.MainTable;
                        ShowFixCondition(_mainTable);
                        foreach (MDModel_Table _cTable in _queryModel.ChildTableDict.Values)
                        {
                                ShowFixCondition(_cTable);
                        }
                }

                /// <summary>
                /// 显示表的固定查询项
                /// </summary>
                /// <param name="_mainTable"></param>
                private void ShowFixCondition(MDModel_Table _table)
                {
                        foreach (MDModel_Table_Column _tc in _table.Columns)
                        {
                                if (_tc.ColumnDefine.IsFixQueryItem && _tc.ColumnDefine.CanShowAsCondition)
                                {
                                        AddConditionItem(_tc);
                                }
                        }
                }

                private void AddConditionItem(MDModel_Table_Column _tc)
                {
                        SinoSZUC_ConditionItem _item = null;
                        switch (_tc.ColumnDataType.ToUpper())
                        {
                                case "DATE":
                                        _item = new SinoSZUC_ConditionItem_Date(_tc);
                                        break;
                                case "NUMBER":
                                        _item = new SinoSZUC_ConditionItem_Number(_tc);
                                        break;

                                default:
                                        if (_tc.ColumnDefine.TableColumn.RefDMB != "")
                                        {
                                                _item = new SinoSZUC_ConditionItem_RefCode(_tc);
                                        }
                                        else
                                        {
                                                _item = new SinoSZUC_ConditionItem(_tc);
                                        }
                                        break;
                        }

                        if (_item != null)
                        {

                                _item.Dock = DockStyle.Top;
                                this.xtraScrollableControl1.Controls.Add(_item);
                                _item.GetFocused += new EventHandler<EventArgs>(_item_GetFocused);
                                _item.LoseFocused += new EventHandler<EventArgs>(_item_LoseFocused);
                                _item.BringToFront();
                                ResetOrderNumber();
                                this.xtraScrollableControl1.Refresh();

                        }


                }

                void _item_LoseFocused(object sender, EventArgs e)
                {
                        CurrentFocused = false;
                        RaiseMenuChanged();
                }

                void _item_GetFocused(object sender, EventArgs e)
                {
                        CurrentFocused = true;
                        SinoSZUC_ConditionItem _uc = sender as SinoSZUC_ConditionItem;
                        this.focusedItem = _uc.Index;
                        this.focusedControl = _uc;
                        RaiseMenuChanged();
                }

                private void ResetOrderNumber()
                {
                        int i = 0;
                        int all = this.xtraScrollableControl1.Controls.Count;
                        foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
                        {
                                _c.SetOrderNumber(all - i++);
                        }

                }

                /// <summary>
                /// 判断条件是否录入正确
                /// </summary>
                /// <param name="_errMsg"></param>
                /// <returns></returns>
                public bool IsValid(ref string _errMsg)
                {
                        _errMsg = "";
                        bool _haveInput = false;
                        foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
                        {
                                string _emsg = "";
                                if (_c.HaveInputData())
                                {
                                        _haveInput = true;
                                        if (!_c.CheckInput(ref _emsg))
                                        {
                                                _errMsg = _emsg;
                                                return false;
                                        }
                                }
                        }
                        if (!_haveInput) _errMsg = "请输入筛选条件项!";
                        return _haveInput;
                }


                public void InsertConditions2QueryRequest(MC_QueryRequsetFactory _queryRequestFactory)
                {
                        string _expression = "";
                        string _fg = "";
                        foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
                        {
                                string _msg = "";
                                if (_c.CheckInput(ref _msg))
                                {
                                        MDQuery_ConditionItem _cItem = _c.GetConditionItem();
                                        _queryRequestFactory.AddConditonItem(_cItem);
                                        _expression += string.Format("{0}{1}", _fg, _cItem.ColumnIndex);
                                        _fg = "*";
                                }
                        }
                        _queryRequestFactory.AddExpression(_expression);
                }

           
        }
}
