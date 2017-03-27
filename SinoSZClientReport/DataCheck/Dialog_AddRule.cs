using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.Controller;

namespace SinoSZClientReport.DataCheck
{
        public partial class Dialog_AddRule : DevExpress.XtraEditors.XtraForm
        {
                protected MDModel_QueryModel _queryModel = null;
                public string RuleName
                {
                        get
                        {
                                if (this.textEdit1.EditValue == null) return "";
                                return this.textEdit1.EditValue.ToString();
                        }
                }

                public Dialog_AddRule()
                {
                        InitializeComponent();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {

                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        if (this.RuleName == "")
                        {
                                XtraMessageBox.Show("请输入规则名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        string _errMsg = "";
                        if (!this.sinoSZUC_ConditionPanel1.CheckInput(ref _errMsg))
                        {
                                XtraMessageBox.Show(string.Format("输入条件不正确!\n {0}", _errMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        if (SaveRule())
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                }

                virtual protected bool SaveRule()
                {
                        MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
                        _rf.QueryModelName = _queryModel.FullQueryModelName;
                        this.sinoSZUC_ConditionPanel1.InsertConditions2QueryRequest(_rf);
                        string _gzsf = MC_CheckRule.QueryRequestToRule(_rf.GetQueryRequest(),this._queryModel);
                        using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
                        {
                            if (!_rsc.SaveNewDataCheckRule(this.RuleName, _queryModel.FullQueryModelName, _gzsf))
                            {
                                XtraMessageBox.Show("保存失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            return true;
                        }

                }

                public void InitData(MDModel_QueryModel _model, string _ruleName)
                {
                        _queryModel = _model;
                        this.sinoSZUC_MD_Model_FieldList1.QueryModel = _queryModel;
                        this.sinoSZUC_MD_Model_FieldList1.QueryViewName = _queryModel.FullQueryModelName;
                        this.sinoSZUC_MD_Model_FieldList1.ShowSingleLineDefaultList();
                        this.textEdit1.EditValue = _ruleName;
                }

                private void sinoSZUC_ConditionPanel1_MenuChanged(object sender, EventArgs e)
                {
                        //this.bt_Del.Enabled = this.sinoSZUC_ConditionPanel1.CurrentFocused;
                }

                private void bt_Del_Click(object sender, EventArgs e)
                {
                        this.sinoSZUC_ConditionPanel1.DoCommand("移除条件");
                }

                private void sinoSZUC_MD_Model_FieldList1_FieldSelected(object sender, SinoSZMetaDataQuery.Common.FieldSelectEventArgs e)
                {
                        this.sinoSZUC_ConditionPanel1.AddCondition(e.FieldItem);
                }

                private void simpleButton3_Click(object sender, EventArgs e)
                {
                    this.sinoSZUC_MD_Model_FieldList1.DoCommand("计算项字段");
                }

        }
}