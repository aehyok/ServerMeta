using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;

using SinoSZJS.Base.Excel;



using SinoSZPluginFramework;
using DevExpress.XtraGrid.Views.Base;
using SinoSZMetaDataQuery.Common;
using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;
using SinoSZJS.Base.MetaData.Common;
using SinoSZClientBase.Cache;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataCompare
{
	public partial class frmDataCompareResult : frmBase
	{
		protected MDCompare_Request compareRequest = null;
		protected Dictionary<string, ExcelColumnAlias> ExcelColumns = null;
		protected DataTable srcData = null;
		protected DataSet CompareResult = null;
		protected MDModel_QueryModel QueryModel = null;

		#region 属性
		private BaseView _currentGrid = null;
		/// <summary>
		/// 当前显示的Grid对象
		/// </summary>
		public BaseView CurrentGrid
		{
			get { return _currentGrid; }
		}
		#endregion



		public frmDataCompareResult()
		{
			InitializeComponent();
		}

		public override void Init(string _title, string _menuName, object _param)
		{
			compareRequest = _param as MDCompare_Request;
			this.Text = _title;
			_initFinished = true;
			RaiseMenuChanged();
		}

		public void Init(string _title, string _menuName, object _param, List<ExcelColumnAlias> excelColumns)
		{
			ExcelColumns = new Dictionary<string, ExcelColumnAlias>();
			foreach (ExcelColumnAlias _alias in excelColumns)
			{
				ExcelColumns.Add(_alias.ColumnName, _alias);
			}

			Init(_title, _menuName, _param);
			this.backgroundWorker1.RunWorkerAsync();
		}

		private void frmDataCompareResult_Load(object sender, EventArgs e)
		{
			this.tableLayoutPanel1.RowStyles[3].Height = 30;
			this.marqueeProgressBarControl1.Properties.Stopped = false;
			this.panelControl1.Visible = true;
			this.radioGroup1.Enabled = false;

		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			string _fname = "";
            QueryModel = MetaDataCache.GetQueryModelDefine(compareRequest.QueryModelName);
			//处理比对数据表

			srcData = new DataTable();
			foreach (DataColumn _dc in compareRequest.ExcelData.Columns)
			{
				if (_dc.ColumnName == "XH")
				{
					_fname = "XH";
				}
				else
				{
					ExcelColumnAlias _alias = ExcelColumns[_dc.ColumnName];
					_fname = _alias.Alias;
				}
				srcData.Columns.Add(_fname, _dc.DataType);

			}

			foreach (DataRow _dr in compareRequest.ExcelData.Rows)
			{
				DataRow _newrow = srcData.NewRow();
				foreach (DataColumn _dc in compareRequest.ExcelData.Columns)
				{
					if (_dc.ColumnName == "XH")
					{
						_fname = "XH";
					}
					else
					{
						ExcelColumnAlias _alias = ExcelColumns[_dc.ColumnName];
						_fname = _alias.Alias;
					}
					_newrow[_fname] = _dr[_dc.ColumnName];

				}
				srcData.Rows.Add(_newrow);
			}

			//调用比对服务
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                CompareResult = _msc.CompareData(compareRequest, srcData);
            }

			//建立关系
			MC_QueryModel.CreateDataRelation(this.QueryModel, CompareResult);
			DataTable _mtable = CompareResult.Tables[QueryModel.MainTable.TableName];
			DataTable _ctable = CompareResult.Tables["EXCELRESULTDATA"];
			CompareResult.Relations.Add("比对的EXCEL文件", _mtable.Columns["MAINID"], _ctable.Columns["MAINID"]);

		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			if (CompareResult != null)
			{
				ShowData();

			}
			this.marqueeProgressBarControl1.Properties.Stopped = true;
			this.tableLayoutPanel1.RowStyles[3].Height = 0;
			this.panelControl1.Visible = false;
			this.radioGroup1.Enabled = true;
			RaiseMenuChanged();
		}

		private void ShowData()
		{
			if (CompareResult != null)
			{
				if (this.radioGroup1.SelectedIndex == 0)
				{
					this.sinoSZUC_GridControlEx1.ClearColumns();
					this.sinoSZUC_GridControlEx1.ShowQueryResult(compareRequest as MDQuery_Request, QueryModel);
					this.sinoSZUC_GridControlEx1.DataSource = CompareResult.Tables[this.QueryModel.MainTable.TableName];
				}
				else
				{
					this.sinoSZUC_GridControlEx1.ClearColumns();
					this.sinoSZUC_GridControlEx1.DataSource = CompareResult.Tables["RESIDUAL"];
				}
			}
			else
			{
				this.sinoSZUC_GridControlEx1.ClearColumns();
			}
			this.tableLayoutPanel1.RowStyles[1].Height = 100;
			this.tableLayoutPanel1.RowStyles[2].Height = 0;
			_currentGrid = this.sinoSZUC_GridControlEx1.CurrentView;
		}


		private void ExportData()
		{
			SinoSZExport_GridViewData.Export(this.CurrentGrid);
		}


		private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowData();
			RaiseMenuChanged();
		}


		#region 重载基类的方法



		protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
		{
			FrmMenuItem _item;
			IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
			FrmMenuGroup _thisGroup = new FrmMenuGroup("数据比对结果");
			_thisGroup.MenuItems = new List<FrmMenuItem>();
			bool _canUse = !this.backgroundWorker1.IsBusy;
			if (compareRequest != null && this.QueryModel != null && this.radioGroup1.SelectedIndex == 0 && this.CompareResult != null)
			{

				_item = new FrmMenuItem("展示方式", "展示方式", global::SinoSZMetaDataQuery.Properties.Resources.b11, _canUse);
				_thisGroup.MenuItems.Add(_item);

				FrmMenuItem _citem = new FrmMenuItem("常规展示", "常规展示", global::SinoSZMetaDataQuery.Properties.Resources.b12, _canUse);
				_item.ChildMenus.Add(_citem);
				foreach (DataTable _dt in this.CompareResult.Tables)
				{
					if (_dt.TableName != this.QueryModel.MainTable.TableName)
					{
						MDModel_Table _mt = MC_QueryModel.GetTableDefine(this.QueryModel, _dt.TableName);
						if (_mt != null)
						{
							_citem = new FrmMenuItem(string.Format("关联展示[{0}]", _mt.TableDefine.DisplayTitle),
								string.Format("关联展示,{0}", _dt.TableName),
								global::SinoSZMetaDataQuery.Properties.Resources.b13, _canUse);
							_item.ChildMenus.Add(_citem);
						}

					}
				}

				_citem = new FrmMenuItem(string.Format("关联展示[{0}]", "EXCEL文件"),
								string.Format("关联展示,{0}", "EXCELRESULTDATA"),
								global::SinoSZMetaDataQuery.Properties.Resources.b13, _canUse);
				_item.ChildMenus.Add(_citem);

				_citem = new FrmMenuItem("关联展示[全部]", "全部平铺展示", global::SinoSZMetaDataQuery.Properties.Resources.b14, true);
				_item.ChildMenus.Add(_citem);
			}


			_item = new FrmMenuItem("导出", "导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, _canUse);
			_thisGroup.MenuItems.Add(_item);

			_ret.Add(_thisGroup);

			return _ret;
		}

		protected override bool ExcuteCommand(string _cmdName)
		{
			string[] _cmdstrs = _cmdName.Split(',');
			string _cmdType = _cmdstrs[0];
			switch (_cmdType)
			{
				case "常规展示":
					ShowAsNormal();
					break;
				case "关联展示":
					if (_cmdstrs.Length > 1) ShowAsRelation(_cmdstrs[1]);
					break;
				case "全部平铺展示":
					ShowFull();
					break;

				case "导出":
					ExportData();
					break;


			}

			return true;
		}

		private void ShowFull()
		{
			if (this.sinoSZUC_GridControlEx_FullRelation1.DataSource == null)
			{
				DataTable _fullComboData = MC_QueryModel.CreateFullComboData(this.compareRequest, this.QueryModel, this.CompareResult);
				this.sinoSZUC_GridControlEx_FullRelation1.ShowQueryResult(this.compareRequest, this.QueryModel, this.CompareResult.Tables["EXCELRESULTDATA"]);
				this.sinoSZUC_GridControlEx_FullRelation1.DataSource = _fullComboData;
			}
			this.tableLayoutPanel1.RowStyles[1].Height = 0;
			this.tableLayoutPanel1.RowStyles[2].Height = 100;
			_currentGrid = this.sinoSZUC_GridControlEx_FullRelation1.CurrentView;
			RaiseMenuChanged();
		}

		private void ShowAsRelation(string _relationTableName)
		{
			SinoSZ_TableRelationCompose _trc = SinoSZ_TableRelationCompose.Compse(this.compareRequest as MDQuery_Request, this.QueryModel,
				       CompareResult.Tables[_relationTableName]);

			this.sinoSZUC_GridControlEx1.ClearColumns();
			this.sinoSZUC_GridControlEx1.ShowQueryResult(_trc.QueryRequest, _trc.QueryModel);
			this.sinoSZUC_GridControlEx1.DataSource = _trc.ResultData;
			this.tableLayoutPanel1.RowStyles[1].Height = 100;
			this.tableLayoutPanel1.RowStyles[2].Height = 0;
			_currentGrid = this.sinoSZUC_GridControlEx1.CurrentView;
		}


		private void ShowAsNormal()
		{
			ShowData();
		}




		#endregion

	}
}