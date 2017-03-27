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
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
    public partial class frmSinoSZ_RelationQuery_Task : SinoSZMetaDataQuery.DataQuery.frmSinoSZ_RelationQuery
    {
        public frmSinoSZ_RelationQuery_Task()
        {
            InitializeComponent();
        }

        public frmSinoSZ_RelationQuery_Task(string _qv, string _param)
            : base(_qv, _param)
        {
        }


        protected override void QueryData(SinoSZPluginFramework.IApplication _application)
        {
            if (_application == null) return;

            string _errorMsg = "";
            if (!this.sinoSZUC_MD_Model_FieldList1.CheckItems(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("选择查询结果不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.sinoSZUC_ConditionPanel1.CheckInput(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("查询条件不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = this.QueryModelName;
            this.sinoSZUC_ConditionPanel1.InsertConditions2QueryRequest(_rf);
            this.sinoSZUC_MD_Model_FieldList1.InsertResultFields2QueryRequest(_rf);

            MDQuery_Request _queryRequest = _rf.GetQueryRequest();
            if (_queryRequest.MainResultTable.Columns.Count < 1)
            {
                XtraMessageBox.Show("主表必须至少选择一个结果字段！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dialog_TaskInfo _f = new Dialog_TaskInfo();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    string _taskid = _msc.AddNewQueryTask(_f.Task_Name, _queryRequest);
                    if (_taskid != "")
                    {
                        XtraMessageBox.Show("此查询请求已经添加到查询任务中!请稍后在查询任务列表中查看查询结果!");
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("添加到查询任务失败!");
                    }
                }
            }

        }
    }
}

