using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SinoSZPluginFramework;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
        public partial class NodeManager : UserControl, IControlMenu
        {
                private bool _haveChange = false;
                private bool _initFinished = false;
                private MD_Nodes _nodesData;
                public event EventHandler<EventArgs> DataChanged;
                public event EventHandler<EventArgs> MenuChanged;

                /// <summary>
                /// 是否有数据变更
                /// </summary>
                public bool HaveDataChanged()
                {
                        return _haveChange && _initFinished;
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

                public MD_Nodes NodesData
                {
                        get
                        {
                                return _nodesData;
                        }

                        set
                        {
                                _nodesData = value;
                                if (_nodesData != null)
                                {
                                        RefreshData();
                                }
                        }

                }

                private void RefreshData()
                {
                        this.TE_DESCRIPT.EditValue = _nodesData.Descript;
                        this.TE_DISPLAY.EditValue = _nodesData.DisplayTitle;
                        this.TE_DWDM.EditValue = _nodesData.DWDM;
                        this.TE_NAME.EditValue = _nodesData.NodeName;
                        this.TE_XH.EditValue = _nodesData.ID;
                        this._haveChange = false;
                }

                public NodeManager()
                {
                        InitializeComponent();
                }

                public NodeManager(MD_Nodes _nodes)
                {
                        InitializeComponent();
                        NodesData = _nodes;
                }

                #region IControlMenu Members
                public List<FrmMenuGroup> GetControlMenu()
                {
                        FrmMenuGroup _thisGroup = new FrmMenuGroup("修改保存");
                        _thisGroup.MenuItems = new List<FrmMenuItem>();
                        FrmMenuItem _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
                        _thisGroup.MenuItems.Add(_item);

                        _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
                        _thisGroup.MenuItems.Add(_item);

                        List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
                        _ret.Add(_thisGroup);
                        return _ret;
                }

                #endregion

                private void TE_NAME_EditValueChanged(object sender, EventArgs e)
                {
                        //修改数据
                        InputDataChanged();
                }

                private void InputDataChanged()
                {
                        _haveChange = true;
                        RaiseDataChanged();
                }

                private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

                private void TE_DWDM_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

                private void TE_DESCRIPT_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

                private void NodeManager_Load(object sender, EventArgs e)
                {
                        _initFinished = true;
                        _haveChange = false;
                }




                #region IControlMenu Members


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

                #endregion



                #region IControlMenu Members


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
                        }
                        return true;
                }

                private void SaveData()
                {
                        this.NodesData.NodeName = this.TE_NAME.EditValue.ToString();
                        this.NodesData.DWDM = this.TE_DWDM.EditValue.ToString();
                        this.NodesData.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
                        this.NodesData.Descript = this.TE_DESCRIPT.EditValue.ToString();
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            if (_mdc.SaveNodes(this.NodesData))
                            {
                                XtraMessageBox.Show("保存成功！");
                                _haveChange = false;
                                this.RaiseMenuChanged();
                            }
                        }
                }

                #endregion


                public MD_Nodes SaveNew()
                {
                        _nodesData = new MD_Nodes();
                        _nodesData.ID = Guid.NewGuid().ToString();
                        this.NodesData.NodeName = this.TE_NAME.EditValue.ToString();
                        this.NodesData.DWDM = this.TE_DWDM.EditValue.ToString();
                        this.NodesData.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
                        this.NodesData.Descript = this.TE_DESCRIPT.EditValue.ToString();
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            if (_mdc.SaveNewNodes(this.NodesData))
                            {
                                XtraMessageBox.Show("添加成功！");
                            }
                            return _nodesData;
                        }
                }
        }
}
