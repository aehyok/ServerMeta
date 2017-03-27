using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZJS.Base.Controller;
using SinoSZJS.Base.Authorize;
using SinoSZClientBase.Cache;

namespace SinoSZClientReport.DataCheck
{
    public partial class SinoUC_CheckDataSearch : DevExpress.XtraEditors.XtraUserControl
    {
        protected string QueryModelName = "";
        protected MDModel_QueryModel _queryModel = null;
        protected List<MD_CheckRule> _ruleList = null;
        protected DC_FilterDefine FilterDefine = null;
        public bool InputReady = false;
        public SinoUC_CheckDataSearch()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> InitFinished;
        virtual public void RaiseInitFinished()
        {
            if (InitFinished != null)
            {
                InitFinished(this, new EventArgs());
            }
        }


        public void InitModel(string _caption, string _qv)
        {
            QueryModelName = _qv;
            _ruleList = null;
            _queryModel = null;
            this.InputReady = false;
            this.sinoCommonGrid1.DataSource = null;
            this.marqueeProgressBarControl1.Properties.Stopped = false;
            this.panelControl2.Visible = true;
            this.labelStatus.Text = "正在处理数据,请稍候...";
            this.backgroundWorker1.RunWorkerAsync();
        }



        private MDQuery_Request GetQueryRequest()
        {
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = this.QueryModelName;
            this.sinoSZUC_FixConditionPanel1.InsertConditions2QueryRequest(_rf);
            this.sinoSZUC_MD_Model_FieldList1.InsertResultFields2QueryRequest(_rf);
            return _rf.GetQueryRequest();
        }

        private List<MD_CheckRule> GetRuleList()
        {
            CurrencyManager cm_Meta2 = (CurrencyManager)this.BindingContext[_ruleList, ""];
            cm_Meta2.EndCurrentEdit();

            this.sinoCommonGrid1.MainView.PostEditor();
            List<MD_CheckRule> _ret = new List<MD_CheckRule>();

            foreach (MD_CheckRule _rule in _ruleList)
            {
                if (_rule.State)
                {
                    _ret.Add(_rule);
                }
            }
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                //_rsc.SaveCheckRuleState(this.QueryModelName, _ret);
            }
            return _ret;
        }

        /// <summary>
        /// 初始化所有输入条
        /// </summary>
        private void InitInputBox()
        {
            this.sinoUC_OrgComboBox1.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
            this.sinoUC_OrgComboBox1.SelectedCode(decimal.Parse(SessionClass.CurrentSinoUser.CurrentPost.PostDwID));
            FilterDefine = new DC_FilterDefine();
            this.imageComboBoxEdit1.DataBindings.Clear();
            this.imageComboBoxEdit1.DataBindings.Add("EditValue", FilterDefine, "SH_ZJ");
            this.imageComboBoxEdit2.DataBindings.Clear();
            this.imageComboBoxEdit2.DataBindings.Add("EditValue", FilterDefine, "SH_ZSJ");
            this.imageComboBoxEdit3.DataBindings.Clear();
            this.imageComboBoxEdit3.DataBindings.Add("EditValue", FilterDefine, "SH_FJ");
            this.imageComboBoxEdit4.DataBindings.Clear();
            this.imageComboBoxEdit4.DataBindings.Add("EditValue", FilterDefine, "SH_JG");
            this.imageComboBoxEdit5.DataBindings.Clear();
            this.imageComboBoxEdit5.DataBindings.Add("EditValue", FilterDefine, "SH_BG");
            this.imageComboBoxEdit6.DataBindings.Clear();
            this.imageComboBoxEdit6.DataBindings.Add("EditValue", FilterDefine, "SH_RK");
            this.checkEdit1.Checked = true;
        }

        /// <summary>
        /// 初始化规则集合
        /// </summary>
        /// <param name="_queryModel"></param>
        private void InitRules(MDModel_QueryModel _queryModel)
        {
            this.sinoCommonGrid1.DataSource = this._ruleList;
        }
        /// <summary>
        /// 初始化结果列表
        /// </summary>
        /// <param name="_queryModel"></param>
        private void InitDefaultResult(MDModel_QueryModel _queryModel)
        {
            if (_queryModel != null)
            {
                this.sinoSZUC_MD_Model_FieldList1.QueryModel = _queryModel;
                this.sinoSZUC_MD_Model_FieldList1.ShowSingleLineDefaultList();
            }
        }

        /// <summary>
        /// 初始化条件列表
        /// </summary>
        /// <param name="_queryModel"></param>
        private void InitDefaultConditionItem(MDModel_QueryModel _queryModel)
        {
            this.sinoSZUC_FixConditionPanel1.ShowConditionItems(_queryModel);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StringBuilder _sb = new StringBuilder();
            if (QueryModelName != "")
            {
                try
                {
                    _queryModel = MetaDataCache.GetQueryModelDefine(QueryModelName);
                }
                catch (Exception ex)
                {
                    _sb.Append(string.Format("取QueryModel={0}出错！{1}", QueryModelName, ex.Message));
                }

                try
                {
                    _ruleList = MetaDataCache.GetDataCheckRuleDefine(QueryModelName, true);
                }
                catch (Exception ex2)
                {
                    _sb.Append(string.Format("取规则定义{0}出错!{1}", QueryModelName, ex2.Message));
                }
                e.Result = _sb.ToString();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_queryModel != null)
            {
                InitDefaultConditionItem(_queryModel);
                InitDefaultResult(_queryModel);
                InitRules(_queryModel);
            }
            InitInputBox();
            this.xtraTabControl1.SelectedTabPageIndex = 0;
            this.panelControl2.Visible = false;
            this.marqueeProgressBarControl1.Properties.Stopped = true;
            InputReady = true;
            RaiseInitFinished();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this._ruleList == null) return;
            bool _check = this.checkEdit1.Checked;
            this.sinoCommonGrid1.BeginUpdate();

            foreach (MD_CheckRule _rule in this._ruleList)
            {
                _rule.State = _check;
            }

            this.sinoCommonGrid1.EndUpdate();
        }


        /// <summary>
        /// 数据审核
        /// </summary>
        /// <param name="_application"></param>
        public void CheckData(IApplication _application)
        {
            List<MD_CheckRule> _rules;
            if (FilterDefine == null) return;
            PropertyManager cm_Meta2 = (PropertyManager)this.BindingContext[FilterDefine, ""];
            cm_Meta2.EndCurrentEdit();


            string _msg = "";
            if (!this.sinoSZUC_FixConditionPanel1.IsValid(ref _msg))
            {
                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MDQuery_Request _request = GetQueryRequest();

            if (this._ruleList != null)
            {
                _rules = GetRuleList();
            }
            else
            {
                _rules = new List<MD_CheckRule>();
            }

            //if (_rules.Count < 1)
            //{
            //    XtraMessageBox.Show("请选择规则!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            string _SelectRootDWDM = this.sinoUC_OrgComboBox1.DWDM.ToString();
            DC_DataCheckParam _dcParam = new DC_DataCheckParam(_request, _rules, _SelectRootDWDM, FilterDefine);
            frmDataCheck _frm = MenuFunctions.AddPage<frmDataCheck>(Guid.NewGuid().ToString(), _application);

            if (_frm != null)
            {
                _frm.Init("数据审核", "审核功能", _dcParam);
            }

        }


        internal void AddRule(IApplication _application)
        {
            Dialog_AddRule _f = new Dialog_AddRule();
            _f.InitData(this._queryModel, string.Format("规则{0}", _ruleList.Count));
            if (_f.ShowDialog() == DialogResult.OK)
            {
                //刷新规则列表
                RefreshRuleList(true);
            }
        }

        public bool RuleSelected
        {
            get
            {
                if (this.gridView1.RowCount < 1 || this.gridView1.FocusedRowHandle < 0) return false;
                return true;
            }
        }

        public void DelRule(IApplication _application)
        {
            if (RuleSelected)
            {
                int _index = this.gridView1.FocusedRowHandle;
                MD_CheckRule _selectRule = this.gridView1.GetRow(_index) as MD_CheckRule;
                using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
                {
                    if (_rsc.DelDataCheckRule(_selectRule.ID))
                    {
                        //刷新规则列表
                        RefreshRuleList(true);

                    }
                    else
                    {
                        XtraMessageBox.Show("删除规则失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void RefreshRuleList(bool NeedRefresh)
        {
            _ruleList = MetaDataCache.GetDataCheckRuleDefine(QueryModelName, NeedRefresh);
            this.sinoCommonGrid1.DataSource = this._ruleList;
        }

        public void ModifyRule(IApplication _application)
        {
            if (RuleSelected)
            {
                int _index = this.gridView1.FocusedRowHandle;
                MD_CheckRule _selectRule = this.gridView1.GetRow(_index) as MD_CheckRule;
                Dialg_ModifyRule _f = new Dialg_ModifyRule();
                _f.LoadRule(this._queryModel, _selectRule);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    //刷新规则列表
                    RefreshRuleList(true);
                }
            }
        }

        public void ImportRule(IApplication _application)
        {


            Dialog_ImportRules _frm = new Dialog_ImportRules();
            _frm.InitRuleList(this._queryModel.FullQueryModelName);
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                List<DataRow> _ret = _frm.SelectedRules;
                if (_ret.Count > 0)
                {
                    using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
                    {
                        foreach (DataRow _row in _ret)
                        {
                            MD_CheckRule _findRule = null;
                            string _gzmc = _row["GZMC"].ToString();
                            if (FindRule(_gzmc, ref _findRule))
                            {
                                if (XtraMessageBox.Show(string.Format("规则{0}已经存在，是否覆盖？", _gzmc), "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    _rsc.RecoverRuleDefine(_findRule.ID, _row["ID"].ToString());
                                    //刷新规则列表
                                    RefreshRuleList(true);
                                }
                            }
                            else
                            {
                                _rsc.ImportRule(_row["ID"].ToString());
                                //刷新规则列表
                                RefreshRuleList(true);
                            }
                        }
                    }
                }
            }

        }

        private bool FindRule(string _gzmc, ref MD_CheckRule _findRule)
        {
            _findRule = null;
            foreach (MD_CheckRule _rule in this._ruleList)
            {
                if (_rule.RuleName == _gzmc)
                {
                    _findRule = _rule;
                    return true;
                }
            }

            return false;
        }
    }
}
