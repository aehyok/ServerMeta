using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.SystemInterface;

namespace SinoSZClientSysManager.InterfaceManager
{
	public partial class IMUC_SJJH_AccessLog : DevExpress.XtraEditors.XtraUserControl
	{
		private string _yhm = "";
		private SystemICS_SJJH_Node _toBeQuery = null;
		private List<SystemICS_SJJH_DownloadLog> LogList = null;
		private Dictionary<string, SystemICS_SJJH_DownloadLog> MainInfo = null;
		private SystemICS_SJJH_Node LastNode = null;
		public IMUC_SJJH_AccessLog()
		{
			InitializeComponent();
		}

		public void ShowInfo(SystemICS_SJJH_Node _selectedItem)
		{
			_toBeQuery = _selectedItem;
			DateTime _now = DateTime.Now.Date;
			this.te_end.EditValue = _now;
			this.te_start.EditValue = _now.AddDays(-1);
			this.bt_Refresh.Enabled = false;
			if (!this.backgroundWorker1.IsBusy)
			{
				QueryData();
			}
		}

		private void QueryData()
		{
			if (_toBeQuery != null)
			{
				lock (_toBeQuery)
				{
					_yhm = _toBeQuery.UserName;
					LastNode = _toBeQuery;
					_toBeQuery = null;
				}
				if (!this.backgroundWorker1.IsBusy)
				{
					this.bt_Refresh.Enabled = false;
					this.panelWait.Visible = true;
					this.backgroundWorker1.RunWorkerAsync();
				}
			}
		}


		public void Clear()
		{
			this.gridView1.BeginUpdate();
			this.sinoCommonGrid1.DataSource = null;
			this.gridView1.EndUpdate();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
            //DateTime _st = (this.te_start.EditValue == null) ? DateTime.Now : (DateTime)this.te_start.EditValue;
            //DateTime _et = (this.te_end.EditValue == null) ? DateTime.Now : (DateTime)this.te_end.EditValue;
            //LogList = SinoSZSysManagerDC.SysManagerFactroy.GetSJJHProcessList(_yhm, _st, _et);
            //MainInfo = SinoSZSysManagerDC.SysManagerFactroy.GetSJJHState(_yhm);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (_toBeQuery != null)
			{
				QueryData();
			}
			else
			{
				this.gridView1.BeginUpdate();
				this.sinoCommonGrid1.DataSource = LogList;
				this.gridView1.EndUpdate();
				if (MainInfo.ContainsKey("新增修改进度"))
				{
					SystemICS_SJJH_DownloadLog _log = MainInfo["新增修改进度"];
					lb_xz_time.Text = _log.DownloadTime.ToString("yyyy年MM月dd日 HH:mm:ss");
					lb_xz_bs.Text = _log.ODS_ID.ToString();
				}
				else
				{
					lb_xz_time.Text = "";
					lb_xz_bs.Text = "";
				}

				if (MainInfo.ContainsKey("代码表更新进度"))
				{
					SystemICS_SJJH_DownloadLog _log = MainInfo["代码表更新进度"];
					this.lb_dmbgx_time.Text = _log.DownloadTime.ToString("yyyy年MM月dd日 HH:mm:ss");
					this.lb_dmbgx_bs.Text = _log.ODS_ID.ToString();
				}
				else
				{
					this.lb_dmbgx_time.Text = "";
					this.lb_dmbgx_bs.Text = "";
				}
				if (MainInfo.ContainsKey("删除数据更新进度"))
				{
					SystemICS_SJJH_DownloadLog _log = MainInfo["删除数据更新进度"];
					this.lb_scsj_time.Text = _log.DownloadTime.ToString("yyyy年MM月dd日 HH:mm:ss");
					this.lb_scsj_bs.Text = _log.ODS_ID.ToString();
				}
				else
				{
					this.lb_scsj_time.Text = "";
					this.lb_scsj_bs.Text = "";
				}


				this.bt_Refresh.Enabled = true;
				this.panelWait.Visible = false;
			}
		}

		private void bt_Refresh_Click(object sender, EventArgs e)
		{
			_toBeQuery = LastNode;
			QueryData();
		}
	}
}
