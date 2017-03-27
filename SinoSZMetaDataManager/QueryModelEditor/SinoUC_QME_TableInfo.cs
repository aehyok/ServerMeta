using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZPluginFramework;
using SinoSZJS.Base;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager.QueryModelEditor
{
    public partial class SinoUC_QME_TableInfo : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private MD_ViewTable ViewTableDefine = null;
        private bool _haveChange = false;
        private bool _initFinished = false;
        private List<MD_ViewTableColumn> TableColumnDefine = null;
        private TreeListNode CurrentNode = null;
        public SinoUC_QME_TableInfo()
        {
            InitializeComponent();
        }

        public SinoUC_QME_TableInfo(TreeListNode _currentNode)
        {
            InitializeComponent();
            CurrentNode = _currentNode;
        }

        public void RaiseDataChanged()
        {
            if (_haveChange && DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }
        public event EventHandler<EventArgs> DataSaved;
        public void RaiseDataSaved()
        {
            if (DataSaved != null)
            {
                DataSaved(this, new EventArgs());
            }

        }
        public void RaiseMenuChanged()
        {
            if (_initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }

        public void InitData(MD_ViewTable _viewTable)
        {
            ViewTableDefine = _viewTable;
            Object _tcDefine = CloneSerializeObject.Clone(ViewTableDefine.Columns);
            TableColumnDefine = _tcDefine as List<MD_ViewTableColumn>;
            ShowData();

            _initFinished = true;
            RaiseDataChanged();
        }

        private void ShowData()
        {
            if (ViewTableDefine == null) return;
            this.TE_DISPLAY.EditValue = ViewTableDefine.DisplayTitle;
            this.gridControl1.DataSource = TableColumnDefine;
            if (ViewTableDefine.ViewTableType == MDType_ViewTable.ChildTable)
            {
                this.TE_DISPLAYTYPE.SelectedIndex = (ViewTableDefine.DisplayType == MDType_DisplayType.GridType) ? 0 : 1;
            }
            else
            {
                this.TE_DISPLAYTYPE.SelectedIndex = 1;
                this.TE_DISPLAYTYPE.Properties.ReadOnly = true;

            }
            this._haveChange = false;
        }

        #region IControlMenu Members

        public List<SinoSZPluginFramework.FrmMenuGroup> GetControlMenu()
        {

            FrmMenuGroup _thisGroup;
            FrmMenuItem _item;
            List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            if (ViewTableDefine != null && ViewTableDefine.ViewTableType == MDType_ViewTable.ChildTable)
            {
                _thisGroup = new FrmMenuGroup("调整显示顺序");
                _thisGroup.MenuItems = new List<FrmMenuItem>();
                _item = new FrmMenuItem("上移", "上移", global::SinoSZMetaDataManager.Properties.Resources.up, true);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("下移", "下移", global::SinoSZMetaDataManager.Properties.Resources.down, true);
                _thisGroup.MenuItems.Add(_item);
                _ret.Add(_thisGroup);
            }


            _thisGroup = new FrmMenuGroup("修改保存");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
            _thisGroup.MenuItems.Add(_item);

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



        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "上移":
                    MoveUp();
                    break;
                case "下移":
                    MoveDown();
                    break;
                case "保存":
                    SaveData();
                    break;
                case "取消":
                    RefreshData();
                    break;
            }
            return true;
        }

        private void MoveDown()
        {
            if (this.CurrentNode == null) return;
            if (this.ViewTableDefine.ViewTableType != MDType_ViewTable.ChildTable) return;
            TreeList _treeList = this.CurrentNode.TreeList;
            int _index = _treeList.GetNodeIndex(CurrentNode);
            _treeList.SetNodeIndex(CurrentNode, _index + 1);
            SaveNewOrder();

        }

        private void MoveUp()
        {
            if (this.CurrentNode == null) return;
            if (this.ViewTableDefine.ViewTableType != MDType_ViewTable.ChildTable) return;
            TreeList _treeList = this.CurrentNode.TreeList;
            int _index = _treeList.GetNodeIndex(CurrentNode);
            _treeList.SetNodeIndex(CurrentNode, _index - 1);
            SaveNewOrder();
        }

        private void SaveNewOrder()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                TreeList treeListNode = this.CurrentNode.TreeList;
                Dictionary<string, int> ChildTableOrder = new Dictionary<string, int>();
                TreeListNode _fnode = this.CurrentNode.ParentNode;
                int i = 1;
                foreach (TreeListNode _tn in _fnode.Nodes)
                {
                    object _selectedItem = _tn.GetValue(treeListNode.Columns[0]);
                    if (_selectedItem is MD_ViewTable)
                    {
                        MD_ViewTable _vt = _selectedItem as MD_ViewTable;
                        ChildTableOrder.Add(_vt.ViewTableID, i * 10);
                        i++;
                    }
                }
                _mdc.SaveViewTableOrder_UserDefine(ChildTableOrder);
            }
        }



        #endregion

        private void RefreshData()
        {
            Object _tcDefine = CloneSerializeObject.Clone(ViewTableDefine.Columns);
            TableColumnDefine = _tcDefine as List<MD_ViewTableColumn>;
            ShowData();
        }

        private void SaveData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                this.gridView1.PostEditor();
                string _displayString = this.TE_DISPLAY.EditValue.ToString();
                MDType_DisplayType _displayType = (this.TE_DISPLAYTYPE.SelectedIndex == 0) ? MDType_DisplayType.GridType : MDType_DisplayType.FormType;
                bool _ret = _mdc.SaveViewTable_UserDefine(this.ViewTableDefine.ViewTableID, _displayString, _displayType, TableColumnDefine.ToArray());
                if (_ret)
                {
                    this.ViewTableDefine.DisplayTitle = _displayString;
                    this.ViewTableDefine.DisplayType = _displayType;
                    this.ViewTableDefine.Columns = TableColumnDefine;
                    Object _tcDefine = CloneSerializeObject.Clone(ViewTableDefine.Columns);
                    TableColumnDefine = _tcDefine as List<MD_ViewTableColumn>;

                    this._haveChange = false;
                    XtraMessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RaiseDataSaved();
                }
                else
                {
                    XtraMessageBox.Show("保存失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void UserChangData()
        {
            if (_initFinished)
            {
                this._haveChange = true;
                RaiseDataChanged();
            }
        }

        private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
        {
            UserChangData();
        }

        private void TE_DISPLAYTYPE_EditValueChanged(object sender, EventArgs e)
        {
            UserChangData();
        }



        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            UserChangData();
        }


    }
}
