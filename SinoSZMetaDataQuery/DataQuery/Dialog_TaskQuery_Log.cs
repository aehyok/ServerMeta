using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;


namespace SinoSZMetaDataQuery.DataQuery
{
	public partial class Dialog_TaskQuery_Log : DevExpress.XtraEditors.XtraForm
	{
		private MDQuery_Task CurrentTask;
		public Dialog_TaskQuery_Log(MDQuery_Task task)
		{
			InitializeComponent();
			CurrentTask = task;
		}

		private void Dialog_TaskQuery_Log_Load(object sender, EventArgs e)
		{
			this.lb_CurrentState.Text = GetCurrentStateText();
			InitInfo();
		}

		private void InitInfo()
		{
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                DataTable _dt = _msc.GetTaskQueryLog(CurrentTask.TaskID);
                this.sinoCommonGrid1.DataSource = _dt;
            }
			
		}

		private string GetCurrentStateText()
		{
			switch (CurrentTask.TaskState)
			{
				case 0:
					return "请求中";
				case 1:
					return "调度中";
				case 2:
					return "执行中";
				case 3:
					return "执行完成";
				case 4:
					return "任务取消";
				case 9:
					return "超时";
				case 10:
					return "查询出错";
				case 11:
					return "结果被清除";
				default:
					return "未知";
			}
		}
	}
}