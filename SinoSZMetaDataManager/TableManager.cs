using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using SinoSZPluginFramework;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class TableManager : UserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;
        private MD_Table _tableDefine = null;

        public MD_Table TableDefine
        {
            get { return _tableDefine; }
            set
            {
                _tableDefine = value;
                RefreshData();
            }
        }

        public TableManager()
        {
            InitializeComponent();
        }

        public TableManager(MD_Table _tb)
        {
            InitializeComponent();
            TableDefine = _tb;
            _initFinished = true;
        }

        #region IControlMenu Members





        public List<FrmMenuGroup> GetControlMenu()
        {
            FrmMenuGroup _thisGroup = new FrmMenuGroup("数据表修改保存");
            _thisGroup.MenuItems = new List<FrmMenuItem>();



            FrmMenuItem _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
            _thisGroup.MenuItems.Add(_item);
            List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            _ret.Add(_thisGroup);
            return _ret;
        }

        public bool HaveDataChanged()
        {
            return _haveChange && _initFinished;
        }

        public event EventHandler<EventArgs> DataChanged;

        public event EventHandler<EventArgs> MenuChanged;

        public bool CloseControl()
        {
            if (HaveDataChanged())
            {
                DialogResult _res = XtraMessageBox.Show("是否保存数据修改?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    SaveData();
                }
                else
                {
                    RefreshData();
                }
            }
            return true;
        }

        public void RaiseDataChanged()
        {

            if (HaveDataChanged() && DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }

        private void RaiseMenuChanged()
        {
            if (MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        private void RefreshData()
        {

            if (_tableDefine == null) return;
            this.TE_DES.EditValue = this._tableDefine.Description;
            this.TE_DISPLAY.EditValue = this._tableDefine.DisplayTitle;
            this.TE_EXTFUN.EditValue = this._tableDefine.ExtSecret;
            this.TE_ID.EditValue = this._tableDefine.TID;
            this.TE_MAINKEY.EditValue = this._tableDefine.MainKey;
            this.TE_NAMESPACE.EditValue = this._tableDefine.NamespaceName;
            this.TE_SECRETFUN.EditValue = this._tableDefine.SecretFun;
            this.TE_TABLENAME.EditValue = this._tableDefine.TableName;
            this.TE_TYPE.EditValue = this._tableDefine.TableType;
            this.te_Res.EditValue = this._tableDefine.ResourceType==null? "":string.Join(",",this._tableDefine.ResourceType);
            if (this._tableDefine.Columns == null)
            {
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {
                    this._tableDefine.Columns = _mdc.GetColumnsOfTable(this._tableDefine.TID);
                }
            }
            this.gridView1.BeginUpdate();
            this.gridControl1.DataSource = this._tableDefine.Columns;
            this.gridView1.EndUpdate();
            this._haveChange = false;
        }

        private void SaveData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                //保存数据
                this.gridView1.PostEditor();
                this._tableDefine.Description = this.TE_DES.EditValue.ToString();
                this._tableDefine.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
                this._tableDefine.ExtSecret = this.TE_EXTFUN.EditValue.ToString();
                this._tableDefine.MainKey = this.TE_MAINKEY.EditValue.ToString();
                this._tableDefine.NamespaceName = this.TE_NAMESPACE.EditValue.ToString();
                this._tableDefine.SecretFun = this.TE_SECRETFUN.EditValue.ToString();
                this._tableDefine.TableName = this.TE_TABLENAME.EditValue.ToString();
                this._tableDefine.TableType = this.TE_TYPE.EditValue.ToString();
                this._tableDefine.ResourceType = this.te_Res.EditValue.ToString().Split(',').ToList<string>();
                _mdc.SaveTableDefine(this._tableDefine);
            }
            this._haveChange = false;
            RaiseDataChanged();
        }

        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "保存":
                    SaveData();
                    break;
                case "取消":
                    RefreshData();
                    break;
                case "字段同步":
                    SyncColumn();
                    break;
            }
            return true;
        }

        private void SyncColumn()
        {
            //字段同步
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<DB_ColumnMeta> _dbColumnList = _mdc.GetDBColumnsOfTable(this._tableDefine.TableName);
                SyncTableColumn(_dbColumnList);
            }
        }

        private void SyncTableColumn(IList<DB_ColumnMeta> _dbColumnList)
        {
            if (this._tableDefine.Columns == null)
            {
                this._tableDefine.Columns = CreateNewColumns(_dbColumnList);
                this.gridControl1.DataSource = this._tableDefine.Columns;
                this._haveChange = true;
                RaiseDataChanged();
                return;
            }

            if (this._tableDefine.Columns.Count == 0)
            {
                this._tableDefine.Columns = CreateNewColumns(_dbColumnList);
                this.gridControl1.DataSource = this._tableDefine.Columns;
                this._haveChange = true;
                RaiseDataChanged();
                return;
            }

            this._tableDefine.Columns = CurrentDBColumns(_dbColumnList, this._tableDefine.Columns);
            this.gridControl1.DataSource = this._tableDefine.Columns;
            this._haveChange = true;
            RaiseDataChanged();

        }

        private IList<MD_TableColumn> CurrentDBColumns(IList<DB_ColumnMeta> _dbColumnList, IList<MD_TableColumn> _oldList)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<MD_TableColumn> _retList = new List<MD_TableColumn>();

                foreach (DB_ColumnMeta _dbc in _dbColumnList)
                {
                    MD_TableColumn _mtc = FindInOldList(_dbc.ColumnName, _oldList);
                    if (_mtc == null)
                    {
                        //添加新字段
                        string _displayName = MatchStringFromComment2(_dbc.Comments, MD_ConstDefine.RegExStrFN);
                        _displayName = (_displayName == "") ? _dbc.ColumnName : _displayName;
                        MD_TableColumn _newtc = new MD_TableColumn(_mdc.GetNewID(), this._tableDefine.TID, _dbc.ColumnName, _dbc.Nullable,
                                _dbc.DataType, _dbc.DataPrecision, 0, _dbc.DataLength, "", "", 0, _displayName, "", 1, 1, 0, true, 1, "", "", "");
                        _retList.Add(_newtc);
                    }
                    else
                    {
                        //添加旧字段
                        _retList.Add(_mtc);
                    }
                }

                return _retList;
            }

        }


        private MD_TableColumn FindInOldList(string _cname, IList<MD_TableColumn> _oldList)
        {
            foreach (MD_TableColumn _mt in _oldList)
            {
                if (_mt.ColumnName == _cname)
                {
                    return _mt;
                }
            }
            return null;
        }

        private IList<MD_TableColumn> CreateNewColumns(IList<DB_ColumnMeta> _dbColumnList)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<MD_TableColumn> _cols = new List<MD_TableColumn>();

                foreach (DB_ColumnMeta _dbc in _dbColumnList)
                {
                    string _displayName = MatchStringFromComment2(_dbc.Comments, MD_ConstDefine.RegExStrFN);
                    _displayName = (_displayName == "") ? _dbc.ColumnName : _displayName;
                    MD_TableColumn _newtc = new MD_TableColumn(_mdc.GetNewID(), this._tableDefine.TID, _dbc.ColumnName, _dbc.Nullable,
                                   _dbc.DataType, _dbc.DataPrecision, 0, _dbc.DataLength, "", "", 0, _displayName, "", 1, 1, 0, true, 1, "", "", "");
                    _cols.Add(_newtc);
                }
                return _cols;
            }
        }


        private string MatchStringFromComment2(string _sourcestring, string RegExStr)
        {
            string _result = "";
            System.Text.RegularExpressions.Match m;
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(RegExStr);

            m = r.Match(_sourcestring);
            if (m.Success)
            {
                string RawString = m.Groups[0].Value;
                _result = RawString.Substring(4, RawString.Length - 9);
                return _result;
            }
            else
                return _sourcestring;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sinoSZTextEdit5_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void sinoSZTextEdit8_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_ID_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_NAMESPACE_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_TABLENAME_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_MAINKEY_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_SECRETFUN_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_DES_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void te_Res_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }


    }
}
