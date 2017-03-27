using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;



using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataManager
{
	public partial class Dialog_EditGuideLineDetailParam : DevExpress.XtraEditors.XtraForm
	{
		private MD_GuideLineDetailDefine DetailDefine = null;
		private List<MD_GuideLineDetailParameter> DetailParam = null;
		public Dialog_EditGuideLineDetailParam()
		{
			InitializeComponent();
		}

		public Dialog_EditGuideLineDetailParam(MD_GuideLineDetailDefine _detailDefine)
		{
			InitializeComponent();
			if (_detailDefine.DetailMethodID == "" && _detailDefine.QueryDetailType != "其它") return;
			DetailDefine = _detailDefine;
			switch (_detailDefine.QueryDetailType)
			{
				case "查询模型":
					this.panelQueryModel.Visible = true;
					this.panelGuideLine.Visible = false;
					this.panelOther.Visible = false;
					this.panelQueryModel.BringToFront();
					InitDetailParm(_detailDefine);
					if (_detailDefine.DetailParameterMeta != null && _detailDefine.DetailParameterMeta != "")
					{
						DetailParam = MC_GuideLine.GetGuideLineDetailParam(_detailDefine.DetailParameterMeta);
						MD_GuideLineDetailParameter _p = DetailParam[0];
						int _selectedIndex = -1;
						for (int i = 0; i < this.comboBoxEdit1.Properties.Items.Count; i++)
						{
							SelectTableColumn _stc = this.comboBoxEdit1.Properties.Items[i] as SelectTableColumn;
							if (_stc.Column.TableColumn.ColumnName == _p.Name)
							{
								_selectedIndex = i;
								break;
							}
						}
						if (_selectedIndex >= 0) this.comboBoxEdit1.SelectedIndex = _selectedIndex;
						this.te_Value.EditValue = _p.DataValue;
					}
					break;
				case "指标定义":
					this.panelQueryModel.Visible = false;
					this.panelGuideLine.Visible = true;
					this.panelOther.Visible = false;
					this.panelGuideLine.BringToFront();
					if (_detailDefine.DetailParameterMeta != null && _detailDefine.DetailParameterMeta != "")
					{
						DetailParam = MC_GuideLine.GetGuideLineDetailParam(_detailDefine.DetailParameterMeta);
					}
					else
					{
						DetailParam = InitDetailParm(_detailDefine);
					}
					this.sinoCommonGrid1.DataSource = DetailParam;
					break;
				case "其它":
					this.panelGuideLine.Visible = false;
					this.panelQueryModel.Visible = false;
					this.panelOther.Visible = true;
					this.panelOther.BringToFront();
					if (_detailDefine.DetailParameterMeta != null && _detailDefine.DetailParameterMeta != "")
					{
						this.memoEdit1.EditValue = _detailDefine.DetailParameterMeta;
					}
					break;

			}


		}

		public string GetDetailParam()
		{
			string _ret = "";
			string _fg = "";
			switch (DetailDefine.QueryDetailType)
			{
				case "查询模型":
					if (this.comboBoxEdit1.SelectedItem != null)
					{
						SelectTableColumn _item = this.comboBoxEdit1.SelectedItem as SelectTableColumn;
						string _value = this.te_Value.EditValue.ToString();
						_ret += string.Format("{0}={1}={2}={3}", _item.Column.TableColumn.ColumnName,
													  _item.Column.TableColumn.DisplayTitle,
													  _item.Column.TableColumn.ColumnType,
													  _value);
					}
					break;
				case "指标定义":
					this.gridView1.PostEditor();
					foreach (MD_GuideLineDetailParameter _p in DetailParam)
					{
						_ret += _fg;
						_ret += string.Format("{0}={1}={2}={3}", _p.Name, _p.Title, _p.Type, _p.DataValue);
						_fg = ",";
					}
					break;

				case "其它":
					_ret = this.memoEdit1.EditValue.ToString();
					break;
			}

			return _ret;
		}

		private List<MD_GuideLineDetailParameter> InitDetailParm(MD_GuideLineDetailDefine _detailDefine)
		{
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                List<MD_GuideLineDetailParameter> _ret = new List<MD_GuideLineDetailParameter>();
                switch (_detailDefine.QueryDetailType)
                {
                    case "查询模型":
                        MD_QueryModel _model = _mdc.GetQueryModelByName(_detailDefine.DetailMethodID);
                        MD_ViewTable _viewTable = _mdc.GetMainTableOfQueryModel(_model.QueryModelID);
                        this.comboBoxEdit1.Properties.Items.Clear();
                        this.comboBoxEdit1.EditValue = null;
                        foreach (MD_ViewTableColumn _col in _viewTable.Columns)
                        {
                            SelectTableColumn _item = new SelectTableColumn(_col);

                            if (_col.TableColumn.ColumnName == _viewTable.Table.MainKey)
                            {
                                _item.Title += " [主键] ";
                            }
                            this.comboBoxEdit1.Properties.Items.Add(_item);
                        }
                        this.te_Type.EditValue = "";
                        this.te_Title.EditValue = "";
                        this.te_Value.EditValue = "";

                        break;
                    case "指标定义":

                        MD_GuideLine _gl = _mdc.GetGuideLineDefine(_detailDefine.DetailMethodID);
                        List<MD_GuideLineParameter> _gParam = MC_GuideLine.GetParametersFromMeta(_gl.GuideLineMeta);
                        foreach (MD_GuideLineParameter _p in _gParam)
                        {
                            _ret.Add(new MD_GuideLineDetailParameter(_p.ParameterName, _p.DisplayTitle, _p.ParameterType, ""));
                        }
                        break;
                }
                return _ret;
            }
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			DetailParam = InitDetailParm(DetailDefine);
			this.sinoCommonGrid1.DataSource = DetailParam;
		}

		private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			if (e.RowHandle >= 0)
			{
				MD_GuideLineDetailParameter _param = this.gridView1.GetRow(e.RowHandle) as MD_GuideLineDetailParameter;

				if (e.Column.FieldName == "DataValue")
				{
					switch (_param.Type)
					{
						case "日期型":
							e.RepositoryItem = this.repositoryItemComboBox1;
							break;
						case "逻辑型":
							break;
						case "代码表":
							break;
						case "单位型(全部)":
						case "单位型(权限范围)":
						case "单位ID型(缉私局权限)":
						case "单位ID型(全部)":
						case "单位ID型(权限范围)":
							break;

						default:
							break;
					}
				}
			}
		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxEdit1.SelectedItem != null)
			{
				SelectTableColumn _item = this.comboBoxEdit1.SelectedItem as SelectTableColumn;
				this.te_Title.EditValue = _item.Column.TableColumn.ColumnName;
				this.te_Type.EditValue = _item.Column.TableColumn.ColumnType;
			}
		}



	}

	public class SelectTableColumn
	{
		private string _title = "";
		private MD_ViewTableColumn _column = null;

		public SelectTableColumn(MD_ViewTableColumn _col)
		{
			_title = string.Format("[{0}] {1}", _col.TableColumn.ColumnName, _col.TableColumn.DisplayTitle);
			_column = _col;
		}


		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		public MD_ViewTableColumn Column
		{
			get { return _column; }
			set { _column = value; }
		}

		public override string ToString()
		{
			return _title;
		}

	}
}