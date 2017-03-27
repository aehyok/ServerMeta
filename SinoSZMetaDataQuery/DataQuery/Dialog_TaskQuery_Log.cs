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
					return "������";
				case 1:
					return "������";
				case 2:
					return "ִ����";
				case 3:
					return "ִ�����";
				case 4:
					return "����ȡ��";
				case 9:
					return "��ʱ";
				case 10:
					return "��ѯ����";
				case 11:
					return "��������";
				default:
					return "δ֪";
			}
		}
	}
}