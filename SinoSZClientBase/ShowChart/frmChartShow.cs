using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Collections;
using SinoSZPluginFramework;


namespace SinoSZClientBase.ShowChart
{
	public partial class frmChartShow : DevExpress.XtraEditors.XtraForm, IChildForm
	{
		private IApplication _application = null;
		public Dictionary<string, string> FieldsDict = null;
		public DataTable FullDataSource = null;
		public DataTable DataSource = null;
		public bool _initFinishted = false;
		private int _ChartType = 0;
		private bool _showLegend = true;
		private bool _showLabel = true;
		private bool _showAsLog = false;

		public frmChartShow()
		{
			InitializeComponent();
		}

		public frmChartShow(DataTable _data, Dictionary<string, string> _fieldsDict)
		{
			InitializeComponent();
			FieldsDict = _fieldsDict;
			FullDataSource = ConvertDecimalToDouble(_data);
			DataSource = FullDataSource;
			CreateColumnList();
			this.CB_CHARTTYPE.SelectedIndex = 0;
			this.CB_ITEMCOUNT.SelectedIndex = 3;
			_initFinishted = true;
			CreatChart();
			RaiseMenuChanged();
		}


		public int DataPrecision
		{
			get
			{
				return Convert.ToInt32(this.spinEdit1.EditValue);
			}
		}

		/// <summary>
		/// 建立字段列表
		/// </summary>
		private void CreateColumnList()
		{
			string[] _meta;
			if (DataSource == null) return;
			if (FieldsDict == null) return;
			DataTable _dt = DataSource;
			//排序列表中添加一个空字段
			ChartFieldItem _blankItem = new ChartFieldItem("[ 无排序字段 ]", "[ 无排序字段 ]");
			this.CB_SORTLIST.Properties.Items.Add(_blankItem);
			this.CB_SORTLIST.SelectedIndex = 0;

			foreach (string _fname in FieldsDict.Keys)
			{
				string _displayName = FieldsDict[_fname];
				DataColumn _dc = _dt.Columns[_fname];
				if (_dc != null)
				{
					ChartFieldItem _fitem = new ChartFieldItem(_fname, _displayName);

					if (_dc.DataType == typeof(string) || _dc.DataType == typeof(DateTime))
					{
						//如果是字符型或日期型,则将字段名加入到横坐标中                                                                              
						this.CB_XLIST.Properties.Items.Add(_fitem);
					}
					else
					{
						//如果是数值型,则将字段名加入到纵坐标中
						this.CB_YLIST.Items.Add(_fitem, false);
					}

					//将字段加入到排序列表中
					this.CB_SORTLIST.Properties.Items.Add(_fitem);
				}
			}
			if (this.CB_XLIST.Properties.Items.Count > 0) this.CB_XLIST.SelectedIndex = 0;
			if (this.CB_YLIST.Items.Count == 1) this.CB_YLIST.Items[0].CheckState = CheckState.Checked;
		}

		/// <summary>
		/// 将表中Decimal类型数据转换为Double
		/// </summary>
		/// <param name="_data"></param>
		/// <returns></returns>
		private DataTable ConvertDecimalToDouble(DataTable _dt)
		{
			DataColumn _thedc;
			if (_dt == null) return null;
			DataTable _newdt = new DataTable();
			foreach (DataColumn _dc in _dt.Columns)
			{
				if (_dc.DataType == typeof(decimal))
				{
					_thedc = _newdt.Columns.Add(_dc.ColumnName, typeof(Double));
				}
				else
				{
					_thedc = _newdt.Columns.Add(_dc.ColumnName, _dc.DataType);
				}
				if (FieldsDict.ContainsKey(_dc.ColumnName))
				{
					_thedc.Caption = FieldsDict[_dc.ColumnName];
				}
				else
				{
					_thedc.Caption = _dc.Caption;
				}
			}
			foreach (DataRow _dr in _dt.Rows)
			{
				DataRow _newrow = _newdt.NewRow();
				foreach (DataColumn _dc in _newdt.Columns)
				{
					if (_dc.DataType == typeof(Double))
					{
						_newrow[_dc.ColumnName] = _dr.IsNull(_dc.ColumnName) ? 0 : Convert.ToDouble(_dr[_dc.ColumnName]);
					}
					else
					{
						_newrow[_dc.ColumnName] = _dr[_dc.ColumnName];
					}
				}
				_newdt.Rows.Add(_newrow);
			}
			_newdt.AcceptChanges();
			return _newdt;
		}


		/// <summary>
		/// 显示图表
		/// </summary>
		public void CreatChart()
		{
			//如果未初始化
			if (!_initFinishted) return;
			panelShow.Controls.Clear();
			//如果没有数据源
			if (DataSource == null) return;
			//如果没有选择图表类型
			if (this.CB_CHARTTYPE.SelectedItem == null) return;
			//如果没有X坐标,则退出
			string _Xfields = GetXFields();
			if (_Xfields == "") return;



			//取纵坐标数据
			List<string> _Yfields = new List<string>();
			Dictionary<string, string> _YTitles = new Dictionary<string, string>();
			foreach (CheckedListBoxItem _obj in this.CB_YLIST.CheckedItems)
			{
				ChartFieldItem _item = _obj.Value as ChartFieldItem;
				_Yfields.Add(_item.FieldName);
				_YTitles.Add(_item.FieldName, _item.DisplayName);
			}
			//如果没有Y坐标,则退出
			if (_Yfields.Count < 1) return;

			string _charTypeStr = CB_CHARTTYPE.SelectedItem.ToString();

			DataTable _dt = ReCountData(_charTypeStr);

			//开始画图表
			Control chartControl1;


			if (CB_CHARTTYPE.SelectedItem != null)
			{

				switch (_charTypeStr)
				{
					case "柱状图":
						_ChartType = 0;
						chartControl1 = DevChartClass.CreateBarChart(_dt, _Xfields, _Yfields, _YTitles, this.checkEdit1.Checked, this.DataPrecision);
						panelShow.Controls.Add(chartControl1);
						break;
					case "饼状图":
						_ChartType = 1;
						chartControl1 = DevChartClass.CreatePieChart(_dt, _Xfields, _Yfields, _YTitles, this.checkEdit1.Checked, this.DataPrecision);
						panelShow.Controls.Add(chartControl1);
						break;
					case "线型图":
						_ChartType = 2;
						chartControl1 = DevChartClass.CreateLineChart(_dt, _Xfields, _Yfields, _YTitles, this.checkEdit1.Checked, this.DataPrecision);
						panelShow.Controls.Add(chartControl1);
						break;
				}
			}
			_showLegend = true;
			_showLabel = true;
			_showAsLog = false;
		}

		/// <summary>
		/// 筛选记录个数
		/// </summary>
		/// <param name="DataSource"></param>
		/// <returns></returns>
		private DataTable ReCountData(string _charType)
		{
			DataView _dv;
			DataTable _dt;
			string _countStr = this.CB_ITEMCOUNT.EditValue.ToString().Trim();
			string _XfieldName = GetXFields();
			if (this.CB_SORTLIST.SelectedItem == null) return DataSource;
			ChartFieldItem _sortFiled = this.CB_SORTLIST.SelectedItem as ChartFieldItem;


			int _countNum = int.MaxValue;
			if (this.CB_ITEMCOUNT.EditValue != null)
			{

				if (_countStr != "全部")
				{
					_countNum = int.Parse(_countStr);
				}
			}



			string _sortType = "DESC";
			switch (this.CB_SORTTYPE.SelectedIndex)
			{
				case 0:
					_sortType = "DESC";
					break;
				case 1:
					_sortType = "ASC";
					break;
			}
			string _sortString = "";
			//如果是无排序字段,则用
			if (_sortFiled.FieldName == "[ 无排序字段 ]")
			{
				_sortString = string.Format("{0} {1}", _XfieldName, _sortType);
			}
			else
			{
				_sortString = string.Format("{0} {1}", _sortFiled.FieldName, _sortType);
			}

			switch (_charType)
			{
				case "饼状图":
					_dv = new DataView(DataSource, "", _sortString, DataViewRowState.CurrentRows);
					_dt = DataSource.Clone();
					DataRow _otherDataRow = null;
					if (_countStr != "全部")
					{
						_otherDataRow = _dt.NewRow();
						if (_dt.Columns[_XfieldName].DataType == typeof(DateTime))
						{
							_otherDataRow[_XfieldName] = DateTime.MinValue;
						}
						else
						{
							_otherDataRow[_XfieldName] = "其它";
						}
					}

					for (int i = 0; i < _dv.Count; i++)
					{
						if (i < _countNum)
						{
							DataRow _dr = _dv[i].Row;
							_dt.ImportRow(_dr);
						}
						else
						{
							DataRow _dr = _dv[i].Row;
							foreach (DataColumn _dc in _dt.Columns)
							{
								if (_dc.DataType == typeof(double) && _dc.ColumnName != _XfieldName)
								{
									if (_otherDataRow.IsNull(_dc)) _otherDataRow[_dc.ColumnName] = 0;
									_otherDataRow[_dc.ColumnName] = ((double)_otherDataRow[_dc.ColumnName]) + (_dr.IsNull(_dc.ColumnName) ? 0 : (double)_dr[_dc.ColumnName]);
								}
							}
						}
					}
					if (_otherDataRow != null) _dt.Rows.Add(_otherDataRow);
					return _dt;


				default:
					_dv = new DataView(DataSource, "", _sortString, DataViewRowState.CurrentRows);
					_dt = DataSource.Clone();

					for (int i = 0; i < _dv.Count; i++)
					{
						if (i < _countNum)
						{
							DataRow _dr = _dv[i].Row;
							_dt.ImportRow(_dr);
						}
						else
						{
							break;
						}
					}
					return _dt;

			}

		}

		/// <summary>
		/// 筛选横坐标记录
		/// </summary>
		private void FilterData()
		{
			List<string> xfields = new List<string>();
			foreach (ChartFieldItem _item in this.CB_XLIST.Properties.Items)
			{
				xfields.Add(_item.FieldName);
			}
			frmFilterRecord _f = new frmFilterRecord(FullDataSource, xfields);
			if (_f.ShowDialog() == DialogResult.OK)
			{
				DataSource = _f.SelectedData;
				CreatChart();
				RaiseMenuChanged();
			}
		}


		/// <summary>
		/// 取X坐标字段
		/// </summary>
		/// <returns></returns>
		private string GetXFields()
		{
			if (this.CB_XLIST.SelectedItem == null) return "";
			ChartFieldItem _item = this.CB_XLIST.SelectedItem as ChartFieldItem;

			return (_item == null) ? "" : _item.FieldName;
		}

		/// <summary>
		/// 重绘LABEL
		/// </summary>
		private void ReDrawLable()
		{
			if (panelShow.Controls.Count < 1) return;
			ChartUC_ICS _cc = (ChartUC_ICS)panelShow.Controls[0];
			_cc.ShowLabel = this._showLabel;
			_cc.Refresh();
		}

		/// <summary>
		/// 重绘注解
		/// </summary>
		private void ReDrawLegend()
		{
			if (panelShow.Controls.Count < 1) return;
			ChartUC_ICS _cc = (ChartUC_ICS)panelShow.Controls[0];
			_cc.ShowLegend = this._showLegend;
			_cc.Refresh();
		}

		/// <summary>
		/// 导出图表
		/// </summary>
		private void ExportChart()
		{
			if (panelShow.Controls.Count < 1) return;
			ChartUC_ICS _cc = (ChartUC_ICS)panelShow.Controls[0];
			_cc.ExportChart();


		}

		/// <summary>
		/// 重绘坐标值类型
		/// </summary>
		private void ReDrawValueType()
		{

		}

		private void CB_SORTTYPE_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatChart();
			RaiseMenuChanged();
		}

		private void CB_CHARTTYPE_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatChart();
			RaiseMenuChanged();
		}

		private void CB_XLIST_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatChart();
			RaiseMenuChanged();
		}

		private void CB_SORTLIST_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatChart();
			RaiseMenuChanged();
		}

		private void CB_ITEMCOUNT_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatChart();
			RaiseMenuChanged();
		}

		private void CB_YLIST_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
		{
			CreatChart();
			RaiseMenuChanged();
		}

		#region 实现IChildForm接口

		public IApplication Application
		{
			get { return _application; }
			set { _application = value; }
		}
		public event EventHandler<EventArgs> MenuChanged;
		virtual public void RaiseMenuChanged()
		{
			if (this._initFinishted && MenuChanged != null)
			{
				MenuChanged(this, new EventArgs());
			}
		}


		public IList<FrmMenuPage> GetMenuPages()
		{
			IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
			FrmMenuPage _page = new FrmMenuPage("图表展示");
			_page.MenuGroups = GetMenuGroups(_page.PageTitle);
			_ret.Add(_page);
			return _ret;
		}

		private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
		{
			FrmMenuItem _item;
			IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();


			FrmMenuGroup _thisGroup = new FrmMenuGroup("图表显示功能");

			_thisGroup.MenuItems = new List<FrmMenuItem>();
			if (this._showLabel)
			{
				_item = new FrmMenuItem("取消标签", "取消标签", global::SinoSZClientBase.Properties.Resources.b19, true);
				_thisGroup.MenuItems.Add(_item);
			}
			else
			{
				_item = new FrmMenuItem("显示标签", "显示标签", global::SinoSZClientBase.Properties.Resources.b20, true);
				_thisGroup.MenuItems.Add(_item);
			}

			if (this._showLegend)
			{
				_item = new FrmMenuItem("取消注解", "取消注解", global::SinoSZClientBase.Properties.Resources.b21, true);
				_thisGroup.MenuItems.Add(_item);
			}
			else
			{
				_item = new FrmMenuItem("显示注解", "显示注解", global::SinoSZClientBase.Properties.Resources.b22, true);
				_thisGroup.MenuItems.Add(_item);
			}
			//if (this._showAsLog)
			//{
			//        _item = new FrmMenuItem("标准坐标", "标准坐标值", global::SinoSZClientBase.Properties.Resources.b24, true);
			//        _thisGroup.MenuItems.Add(_item);
			//}
			//else
			//{
			//        _item = new FrmMenuItem("指数坐标", "指数坐标值", global::SinoSZClientBase.Properties.Resources.b23, true);
			//        _thisGroup.MenuItems.Add(_item);
			//}
			_ret.Add(_thisGroup);
			_thisGroup = new FrmMenuGroup("图表处理功能");

			_thisGroup.MenuItems = new List<FrmMenuItem>();

			_item = new FrmMenuItem("筛选记录", "筛选记录", global::SinoSZClientBase.Properties.Resources.b25, true);
			_thisGroup.MenuItems.Add(_item);

			_item = new FrmMenuItem("刷新图表", "刷新图表", global::SinoSZClientBase.Properties.Resources.b25, true);
			_thisGroup.MenuItems.Add(_item);

			_item = new FrmMenuItem("导出图表", "导出图表", global::SinoSZClientBase.Properties.Resources.x3, true);
			_thisGroup.MenuItems.Add(_item);

			_ret.Add(_thisGroup);
			return _ret;
		}


		public bool DoCommand(string _cmdName)
		{
			switch (_cmdName)
			{
				case "刷新图表":
					CreatChart();
					break;
				case "取消标签":
				case "显示标签":
					_showLabel = !_showLabel;
					ReDrawLable();
					break;
				case "取消注解":
				case "显示注解":
					_showLegend = !_showLegend;
					ReDrawLegend();
					break;
				case "标准坐标值":
				case "指数坐标值":
					_showAsLog = !_showAsLog;
					ReDrawValueType();
					break;
				case "筛选记录":
					FilterData();
					break;
				case "导出图表":
					ExportChart();
					break;
			}
			RaiseMenuChanged();
			return true;
		}










		#endregion

		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
		{
			if (panelShow.Controls.Count < 1) return;
			ChartUC_ICS _cc = (ChartUC_ICS)panelShow.Controls[0];
			_cc.CanSelect = this.checkEdit1.Checked;
			_cc.Refresh();
		}

		private void spinEdit1_EditValueChanged(object sender, EventArgs e)
		{
			if (panelShow.Controls.Count < 1) return;
			ChartUC_ICS _cc = (ChartUC_ICS)panelShow.Controls[0];
			_cc.DataPrecision = this.DataPrecision;

		}



	}
}