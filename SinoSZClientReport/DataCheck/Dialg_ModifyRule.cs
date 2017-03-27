using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZJS.Base.Controller;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZClientReport.DataCheck
{
        public partial class Dialg_ModifyRule : Dialog_AddRule 
        {
                private MD_CheckRule CurrentRule = null;
                public Dialg_ModifyRule()
                {
                        InitializeComponent();
                }            
                protected override bool SaveRule()
                {
                        MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
                        _rf.QueryModelName = _queryModel.FullQueryModelName;
                        this.sinoSZUC_ConditionPanel1.InsertConditions2QueryRequest(_rf);
                        string _gzsf = MC_CheckRule.QueryRequestToRule(_rf.GetQueryRequest(),this._queryModel);
                        using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
                        {
                            if (!_rsc.ChangeDataCheckRule(CurrentRule.ID, _gzsf))
                            {
                                XtraMessageBox.Show("修改算法失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            return true;
                        }
                }

               public void LoadRule(MDModel_QueryModel _model, MD_CheckRule _selectRule)
                {
                        CurrentRule = _selectRule;
                        _queryModel = _model;
                        this.textEdit1.EditValue = CurrentRule.RuleName;
                        this.textEdit1.Properties.ReadOnly = true;
                        this.sinoSZUC_MD_Model_FieldList1.QueryModel = _queryModel;
                        this.sinoSZUC_MD_Model_FieldList1.QueryViewName = _queryModel.FullQueryModelName;
                        this.sinoSZUC_MD_Model_FieldList1.ShowSingleLineDefaultList();

                        MDQuery_Request _request = MC_CheckRule.RuleToQueryRequest(CurrentRule, _queryModel,null);
                        this.sinoSZUC_ConditionPanel1.RefreshBySaveRequest(this._queryModel, _request);
                }


        }
}