using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZMetaDataQuery.Common;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
        public partial class Dialog_TaskRequest : DevExpress.XtraEditors.XtraForm
        {
                private MDQuery_Request _request = null;
                private MDQuery_Task _taskDefine = null;
                public Dialog_TaskRequest()
                {
                        InitializeComponent();
                }

                public Dialog_TaskRequest(MDQuery_Task _task)
                {
                        InitializeComponent();
                        _taskDefine = _task;
                        InitForm();
                }

                private void InitForm()
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        _request = _msc.GetQueryTaskRequestContext(_taskDefine.TaskID);
                        this.textEdit1.EditValue = _request.ConditionExpressions;
                        this.sinoSZUC_GridControlEx1.ShowBlankQueryResult(_request);
                        ShowCondition(_request);
                    }
                }

                private void ShowCondition(MDQuery_Request _request)
                {
                        foreach (MDQuery_ConditionItem _item in _request.ConditionItems)
                        {
                                AddCondition(_item);
                        }
                }

                public void AddCondition(MDQuery_ConditionItem _tc)
                {
                        SinoSZUC_ConditionItem _item = new SinoSZUC_ConditionItem(_tc);

                        _item.Dock = DockStyle.Top;
                        this.xtraScrollableControl1.Controls.Add(_item);
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}