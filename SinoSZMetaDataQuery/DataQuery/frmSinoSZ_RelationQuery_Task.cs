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
                XtraMessageBox.Show(string.Format("ѡ���ѯ�������ȷ:{0}", _errorMsg), "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.sinoSZUC_ConditionPanel1.CheckInput(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("��ѯ��������ȷ:{0}", _errorMsg), "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = this.QueryModelName;
            this.sinoSZUC_ConditionPanel1.InsertConditions2QueryRequest(_rf);
            this.sinoSZUC_MD_Model_FieldList1.InsertResultFields2QueryRequest(_rf);

            MDQuery_Request _queryRequest = _rf.GetQueryRequest();
            if (_queryRequest.MainResultTable.Columns.Count < 1)
            {
                XtraMessageBox.Show("�����������ѡ��һ������ֶΣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        XtraMessageBox.Show("�˲�ѯ�����Ѿ���ӵ���ѯ������!���Ժ��ڲ�ѯ�����б��в鿴��ѯ���!");
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("��ӵ���ѯ����ʧ��!");
                    }
                }
            }

        }
    }
}

