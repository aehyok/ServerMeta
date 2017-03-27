using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZPluginFramework;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager.QueryModelEditor
{
        public partial class View2ViewInfo : DevExpress.XtraEditors.XtraUserControl, IControlMenu
        {
                private bool _haveChange = false;
                private bool _initFinished = false;
                private MD_View2View Data = null;
                public View2ViewInfo()
                {
                        InitializeComponent();
                }


                public View2ViewInfo(MD_View2View _data)
                {
                        InitializeComponent();
                        this.Data = _data;
                        RefreshData();
                }

                private void RefreshData()
                {
                        this.TE_Order.EditValue = Data.DisplayOrder;
                        this.TE_DisplayName.EditValue = Data.DisplayTitle;
                        this.TE_MODEL.EditValue = Data.TargetViewName;
                        this.TE_RELATION.EditValue = this.Data.RelationString;
                        this._haveChange = false;
                        RaiseMenuChanged();
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
                #region IControlMenu Members

                public List<SinoSZPluginFramework.FrmMenuGroup> GetControlMenu()
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

                private void SaveData()
                {
                        this.Data.DisplayOrder = int.Parse(this.TE_Order.EditValue.ToString());
                        this.Data.DisplayTitle = this.TE_DisplayName.EditValue.ToString();
                        this.Data.RelationString = this.TE_RELATION.EditValue.ToString();
                        this.Data.TargetViewName = this.TE_MODEL.EditValue.ToString();
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            if (_mdc.SaveView2View(this.Data))
                            {
                                XtraMessageBox.Show("保存成功！");
                                _haveChange = false;
                                this.RaiseMenuChanged();
                            }
                        }
                }

                private void InputDataChanged()
                {
                        _haveChange = true;
                        RaiseDataChanged();
                }

                private void TE_DisplayName_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

                private void View2ViewInfo_Load(object sender, EventArgs e)
                {
                        _initFinished = true;
                        _haveChange = false;
                }

        }
}
