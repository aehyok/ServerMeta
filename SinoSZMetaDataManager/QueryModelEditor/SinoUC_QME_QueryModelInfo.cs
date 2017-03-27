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
        public partial class SinoUC_QME_QueryModelInfo : DevExpress.XtraEditors.XtraUserControl, IControlMenu
        {
                private bool _haveChange = false;
                private bool _initFinished = false;
                private MD_QueryModel QueryModel = null;
                public SinoUC_QME_QueryModelInfo()
                {
                        InitializeComponent();
                }


                public void RaiseDataChanged()
                {
                        if (_haveChange && DataChanged != null)
                        {
                                DataChanged(this, new EventArgs());
                        }

                }
                public void RaiseMenuChanged()
                {
                        if (_initFinished && MenuChanged != null)
                        {
                                MenuChanged(this, new EventArgs());
                        }
                }


                internal void InitData(MD_QueryModel _qv)
                {
                        QueryModel = _qv;
                        if (_qv != null)
                        {

                                this.TE_DES.EditValue = _qv.Description;
                                this.TE_DISPLAY.EditValue = _qv.DisplayTitle;
                        }
                        _initFinished = true;
                        RaiseDataChanged();

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


                private void RefreshData()
                {
                        if (this.QueryModel != null)
                        {
                                this.TE_DES.EditValue = QueryModel.Description;
                                this.TE_DISPLAY.EditValue = QueryModel.DisplayTitle;
                        }
                        this._haveChange = false;
                        RaiseDataChanged();
                }

                private void SaveData()
                {
                        string _descript = (this.TE_DES.EditValue == null) ? "" : this.TE_DES.EditValue.ToString().Trim();
                        string _display = (this.TE_DISPLAY.EditValue == null) ? "" : this.TE_DISPLAY.EditValue.ToString().Trim();
                        if (_display == "")
                        {
                                XtraMessageBox.Show("显示名称不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {

                            if (_mdc.SaveQueryModel_UserDefine(QueryModel.QueryModelID, _display, _descript))
                            {
                                QueryModel.Description = _descript;
                                QueryModel.DisplayTitle = _display;
                                this._haveChange = false;
                                RaiseMenuChanged();
                            }
                        }

                }

                private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
                {
                        UserChangData();
                }

                private void TE_DES_EditValueChanged(object sender, EventArgs e)
                {
                        UserChangData();
                }

                private void UserChangData()
                {
                        if (_initFinished)
                        {
                                this._haveChange = true;
                                RaiseDataChanged();
                        }
                }


        }
}
