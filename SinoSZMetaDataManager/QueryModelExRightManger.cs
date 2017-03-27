using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZPluginFramework;
using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZMetaDataManager
{
        public partial class QueryModelExRightManger : DevExpress.XtraEditors.XtraUserControl, IControlMenu
        {
                private bool _haveChange = false;
                private bool _initFinished = false;


                private MD_QueryModel_ExRight CurrentRight = null;
                public QueryModelExRightManger()
                {
                        InitializeComponent();
                }

                public QueryModelExRightManger(MD_QueryModel_ExRight _right)
                {
                        InitializeComponent();
                        CurrentRight = _right;
                        RefreshData();
                }

                #region IControlMenu Members

                /// <summary>
                /// 是否有数据变更
                /// </summary>
                public bool HaveDataChanged()
                {
                        return _haveChange && _initFinished;
                }

                public event EventHandler<EventArgs> DataChanged;

                public event EventHandler<EventArgs> MenuChanged;


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
                                case "保存":
                                        SaveData();
                                        break;
                                case "取消":
                                        RefreshData();
                                        break;
                        }
                        return true;
                }



                #endregion


                private void InputDataChanged()
                {
                        _haveChange = true;
                        RaiseDataChanged();
                }

                private void RefreshData()
                {
                        this.te_value.EditValue = this.CurrentRight.RightName;
                        this.te_title.EditValue = this.CurrentRight.RightTitle;
                        this.te_order.EditValue = this.CurrentRight.DisplayOrder.ToString();
                        this._haveChange = false;
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

                private void SaveData()
                {
                        this.CurrentRight.RightName = this.te_value.EditValue.ToString();
                        this.CurrentRight.RightTitle = this.te_title.EditValue.ToString();
                        this.CurrentRight.DisplayOrder = int.Parse(this.te_order.EditValue.ToString());
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            if (_mdc.SaveQueryModelExRight(this.CurrentRight))
                            {
                                XtraMessageBox.Show("保存成功！");
                                _haveChange = false;
                                this.RaiseMenuChanged();
                            }
                        }
                }

                private void QueryModelExRightManger_Load(object sender, EventArgs e)
                {
                        _initFinished = true;
                        RaiseDataChanged();
                }

                private void te_value_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

        }
}
