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

namespace SinoSZMetaDataManager
{
        public partial class ConceptTag : DevExpress.XtraEditors.XtraUserControl, IControlMenu
        {
                private bool _haveChange = false;
                private bool _initFinished = false;
                private MD_ConceptItem _Data = null;
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

                public MD_ConceptItem Data
                {
                        get { return _Data; }
                        set
                        {
                                _Data = value;
                                if (_Data != null)
                                {
                                        RefreshData();
                                }
                        }
                }

                private void RefreshData()
                {
                        this.TE_TAG.EditValue = _Data.CTag;
                        this.TE_DISPLAY.EditValue = _Data.DisplayOrder;
                        this.TE_DWDM.EditValue = _Data.DWDM;
                        this.TE_GROUPNAME.EditValue = _Data.GroupName;
                        this.TE_NAME.EditValue = _Data.Description;
                        this._haveChange = false;
                }

                public ConceptTag()
                {
                        InitializeComponent();
                }
                public ConceptTag(MD_ConceptItem _item)
                {
                        InitializeComponent();
                        this.Data = _item;
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

                private void SaveData()
                {
                        this.Data.DisplayOrder = int.Parse(this.TE_DISPLAY.EditValue.ToString());
                        this.Data.Description = this.TE_NAME.EditValue.ToString();
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            if (_mdc.SaveConceptTag(this.Data))
                            {
                                XtraMessageBox.Show("保存成功！");
                                _haveChange = false;
                                this.RaiseMenuChanged();
                            }
                        }
                }

                #endregion

                private void InputDataChanged()
                {
                        _haveChange = true;
                        RaiseDataChanged();
                }

                private void TE_NAME_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

                private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
                {
                        InputDataChanged();
                }

                private void ConceptTag_Load(object sender, EventArgs e)
                {
                        this._initFinished = true;
                }
        }
}
