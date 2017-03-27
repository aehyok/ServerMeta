using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZPluginFramework;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZClientBase.Cache;

namespace SinoSZClientReport.DataCheck
{
	public partial class frmDataCheck : frmBase
	{
		private MDModel_QueryModel _queryModel;
		private DC_DataCheckParam CheckParam = null;
		private DataTable _resultTable = null;
		public frmDataCheck()
		{
			InitializeComponent();
		}


		public override void Init(string _title, string _menuName, object _param)
		{
			this.Text = _title;
			this._menuPageName = _menuName;
			this._initFinished = true;
			this.panelWait.Visible = true;
			CheckParam = _param as DC_DataCheckParam;
			this.labelStatus.Text = "正在查询符合条件的记录 ...";
			CreateGridColumn();
			this.RaiseMenuChanged();
			this.backgroundWorker1.RunWorkerAsync();

		}

		private void CreateGridColumn()
		{
			this.bandedGridView1.BeginUpdate();
			foreach (MDQuery_TableColumn _column in CheckParam.Request.MainResultTable.Columns)
			{
				AddColumn(_column);
			}
			foreach (MDQuery_ResultTable _table in CheckParam.Request.ChildResultTables)
			{
				foreach (MDQuery_TableColumn _column in _table.Columns)
				{
					AddColumn(_column);
				}
			}
			this.bandedGridView1.EndUpdate();

		}

		private void AddColumn(MDQuery_TableColumn _qdf)
		{
			BandedGridColumn _col = new BandedGridColumn();
			this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { _col });
			this.gridBand1.Columns.Add(_col);
			_col.Caption = _qdf.ColumnTitle;
			_col.FieldName = _qdf.ColumnAlias;
			//_col.Options = ((DevExpress.XtraGrid.Columns.ColumnOptions)(((((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered | DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.CanResized)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.FixedWidth)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused)
			//        | DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)));
			_col.Visible = true;
			_col.VisibleIndex = 0;
			_col.Width = 120;
		}

		#region 重载基类的方法

		protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
		{
			IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

			FrmMenuGroup _thisGroup = new FrmMenuGroup("审核功能");
			_thisGroup.MenuItems = new List<FrmMenuItem>();
			FrmMenuItem _item = new FrmMenuItem("审核信息", "审核信息", global::SinoSZClientReport.Properties.Resources.x2, true);
			_thisGroup.MenuItems.Add(_item);
			_item = new FrmMenuItem("批量审核", "批量审核", global::SinoSZClientReport.Properties.Resources.s1, true);
			_thisGroup.MenuItems.Add(_item);
			_item = new FrmMenuItem("导出", "导出", global::SinoSZClientReport.Properties.Resources.x3, true);
			_thisGroup.MenuItems.Add(_item);
			_ret.Add(_thisGroup);

			return _ret;
		}

		protected override bool ExcuteCommand(string _cmdName)
		{
			switch (_cmdName)
			{
				case "审核信息":
					this.DataSh();
					break;
				case "批量审核":
					this.PLSH();
					break;
				case "导出":
					ExportData();
					break;
			}
			return true;
		}

		private void PLSH()
		{
			int[] _selectedIndies = this.bandedGridView1.GetSelectedRows();
			if (_selectedIndies.Length < 1)
			{
				XtraMessageBox.Show("请选择需审核的记录！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			List<DataRow> _selectedRow = new List<DataRow>();
			foreach (int _index in _selectedIndies)
			{
				DataRow _dr = this.bandedGridView1.GetDataRow(_index);
				_selectedRow.Add(_dr);
			}

			Dialog_InputSHInfo _f = new Dialog_InputSHInfo();
			_f.InitForm(_selectedRow, this._queryModel.FullQueryModelName, this._queryModel.MainTable.TableName, this._queryModel.MainTable.TableDefine.Table.MainKey);
			if (_f.ShowDialog() == DialogResult.OK)
			{

			}
		}

		private void ExportData()
		{
			SinoSZExport_GridViewData.Export(this.bandedGridView1);
		}




		#endregion

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			//查询记录                      
			this.backgroundWorker1.ReportProgress(0, "正在按条件查询记录");
			try
			{

				_queryModel = MetaDataCache.GetQueryModelDefine(CheckParam.Request.QueryModelName);


				DataTable _dt = QueryRecord();

				if (_dt == null || _dt.Rows.Count < 1)
				{
					_resultTable = null;
					return;
				}
				else
				{
					_resultTable = CreateResultTable(_dt);
				}
				//按规则检验】
				if (CheckParam.Rules.Count > 0)
				{
					int i = 0;
					int _step = 40 / CheckParam.Rules.Count;
					foreach (MD_CheckRule _rule in CheckParam.Rules)
					{
						this.backgroundWorker1.ReportProgress(25 + i * _step, string.Format("正在检验第{0}条规则", i + 1));
						CheckRule(_rule, _queryModel);
					}
				}
				//检查更新记录
				this.backgroundWorker1.ReportProgress(70, "正在检查更新记录");
				CheckUpdateRecord();

				//筛选记录
				this.backgroundWorker1.ReportProgress(85, "正在筛选记录");
				FilterRecord();
				e.Result = "";
			}
			catch (Exception ex)
			{
				this.backgroundWorker1.ReportProgress(0, string.Format("检记录发生错误！{0}", ex.Message));
				e.Result = "ERROR!" + ex.Message;
			}
		}

		private DataTable CreateResultTable(DataTable _lsdt)
		{

			DataTable _dt = _lsdt.Copy();
			_dt.Columns.Add("JC_STATE", typeof(decimal));
			_dt.Columns.Add("JC_MSG", typeof(string));
			_dt.Columns.Add("MESS", typeof(string));
			_dt.Columns.Add("GX_STATE", typeof(decimal));

			foreach (DataRow _dr in _dt.Rows)
			{
				_dr["JC_STATE"] = 0;
				_dr["JC_MSG"] = "";
				_dr["MESS"] = "";
				_dr["GX_STATE"] = 0;
				if (_dr.IsNull("SH_ZONGSJ")) _dr["SH_ZONGSJ"] = "0";
				if (_dr.IsNull("SH_ZHISJ")) _dr["SH_ZHISJ"] = "0";
				if (_dr.IsNull("SH_FJ")) _dr["SH_FJ"] = "0";
			}
			return _dt;
		}


		/// <summary>
		/// 筛选符合条件的记录
		/// </summary>
		private void FilterRecord()
		{

			if (_resultTable.Rows.Count < 1) return;
			string _filterStr = "";

			if (CheckParam.FilterDefine.SH_ZJ != -1)
			{
				_filterStr += string.Format("or  SH_ZONGSJ <> '{0}'", CheckParam.FilterDefine.SH_ZJ);
			}
			if (CheckParam.FilterDefine.SH_ZSJ != -1)
			{
				_filterStr += string.Format("or  SH_ZHISJ <> '{0}'", CheckParam.FilterDefine.SH_ZSJ);
			}
			if (CheckParam.FilterDefine.SH_FJ != -1)
			{
				_filterStr += string.Format("or  SH_FJ <> '{0}'", CheckParam.FilterDefine.SH_FJ);

			}
			if (CheckParam.FilterDefine.SH_BG != -1)
			{
				_filterStr += string.Format("or  GX_STATE <> {0}", CheckParam.FilterDefine.SH_BG);
			}
			if (CheckParam.FilterDefine.SH_JG != -1)
			{
				_filterStr += string.Format("or  JC_STATE <> {0}", CheckParam.FilterDefine.SH_JG);
			}
			if (CheckParam.FilterDefine.SH_RK != -1)
			{
				_filterStr += string.Format("or  RKQK<>{0}", CheckParam.FilterDefine.SH_RK);
			}

			if (_filterStr == "")
				return;
			else
			{
				_filterStr = _filterStr.Substring(4);
			}
			DataRow[] _drs = _resultTable.Select(_filterStr);
			if (_drs.Length == 0) return;

			foreach (DataRow _dr in _drs)
			{

				_dr.Delete();
			}
			_resultTable.AcceptChanges();
			return;
		}

		/// <summary>
		/// 检查更新情况
		/// </summary>
		private void CheckUpdateRecord()
		{
			foreach (DataRow _dr in _resultTable.Rows)
			{

				decimal _currentNum = (_dr.IsNull("CURRENT_WHXH")) ? 0 : (decimal)_dr["CURRENT_WHXH"];
				decimal _oldNum = (_dr.IsNull("OLD_WHXH")) ? 0 : (decimal)_dr["OLD_WHXH"];
				if (_currentNum > _oldNum)
				{
					_dr["GX_STATE"] = 1;

				}
				else
				{
					_dr["GX_STATE"] = 0;
				}
			}

		}

		/// <summary>
		/// 检查规则
		/// </summary>
		/// <param name="_rule"></param>
		private void CheckRule(MD_CheckRule _rule, MDModel_QueryModel _queryModel)
		{
			DataSet _lsdt;
			MDQuery_Request _request = MC_CheckRule.RuleToQueryRequest(_rule, _queryModel, this.CheckParam.Request);
			if (_request == null) return;
			using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
			{
				_lsdt = _rsc.QueryData(_request);
			}
			if (_lsdt != null && _lsdt.Tables.Count > 0)
			{
				DataTable _dt = _lsdt.Tables[0];
				if (_dt.Rows.Count > 0)
				{
					writeRuleCheckRusult(_dt, _rule.RuleName);
				}
			}
		}

		private void writeRuleCheckRusult(DataTable _dt, string _ruleName)
		{
			foreach (DataRow _dr in _dt.Rows)
			{
				string _id = _dr["MAINID"].ToString();
				foreach (DataRow _dr2 in _resultTable.Rows)
				{
					string _id2 = _dr2["MAINID"].ToString();
					if (_id == _id2)
					{
						_dr2["JC_STATE"] = 1;
						_dr2["JC_MSG"] = _dr2["JC_MSG"].ToString() + _ruleName + ";\r\n";
						string[] _gzname = _ruleName.Split('-');
						_dr2["MESS"] = _dr2["MESS"].ToString() + _gzname[0] + ";";
						break;
					}
				}
			}
		}



		/// <summary>
		/// 查询记录
		/// </summary>
		private DataTable QueryRecord()
		{
			SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient();
			return _rsc.QueryDataWithWHXH(this.CheckParam.Request, this.CheckParam.DWDM);

		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// string _s = e.Result.ToString();
			if (e.Result != null && e.Result != "")
			{
				XtraMessageBox.Show("发生错误！" + e.Result, "系统提示");
			}
			else
			{
				this.sinoCommonGrid1.DataSource = _resultTable;

				this.labelStatus.Text = string.Format("共查到{0}条记录!", ((_resultTable == null) ? 0 : _resultTable.Rows.Count));
			}
			this.marqueeProgressBarControl1.Visible = false;
		}

		private void frmDataCheck_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.backgroundWorker1.IsBusy) this.backgroundWorker1.CancelAsync();
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.labelStatus.Text = string.Format("{0}.... {1}%", e.UserState, e.ProgressPercentage);
		}

		private void bandedGridView1_DoubleClick(object sender, EventArgs e)
		{

		}

		private void sinoCommonGrid1_DoubleClick(object sender, EventArgs e)
		{
			DataRow row;
			GridColumn _gc = bandedGridView1.FocusedColumn;
			string _cString = _gc.FieldName.ToString();

			if (this.bandedGridView1.FocusedRowHandle >= 0)
			{

				row = this.bandedGridView1.GetDataRow(this.bandedGridView1.FocusedRowHandle);
				if (_cString == "JC_STATE" && (decimal)row["JC_STATE"] == 1)
				{
					XtraMessageBox.Show(row["JC_MSG"].ToString(), "异常数据检查情况", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					DataSh();
				}


			}
		}

		private void DataSh()
		{
			int _index = bandedGridView1.FocusedRowHandle;
			if (_index < 0) return;

			DataRow _dr = bandedGridView1.GetDataRow(_index);
			string _mainid = _dr["MAINID"].ToString();
			string _title = string.Format("数据审核[{0}]", _mainid);
			frm_DataCheckInfo _frm = MenuFunctions.AddPage<frm_DataCheckInfo>(_title, _application);
			if (_frm != null)
			{
				_frm.Init(_title, "数据审核", _mainid, CheckParam.Request, _queryModel, _dr);
			}
		}

		private void sinoCommonGrid1_Click(object sender, EventArgs e)
		{

		}


	}
}