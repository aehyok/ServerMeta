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

namespace SinoSZMetaDataManager
{
        public partial class Table2ViewManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
        {
                private bool _haveChange = false;
                private bool _initFinished = false;
                private MD_Table2View t2VDefine = null;

                public MD_Table2View T2VDefine
                {
                        get
                        {
                                return t2VDefine;
                        }
                        set
                        {
                                t2VDefine = value;
                                RefreshData();
                        }
                }

                public Table2ViewManager()
                {
                        InitializeComponent();
                }

                public Table2ViewManager(MD_Table2View _t2v)
                {
                        InitializeComponent();
                        T2VDefine = _t2v;
                        _initFinished = true;
                }



                #region IControlMenu Members

                public List<FrmMenuGroup> GetControlMenu()
                {
                        FrmMenuGroup _thisGroup;
                        FrmMenuItem _item;

                        List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

                        _thisGroup = new FrmMenuGroup("关联条件和限制");
                        _thisGroup.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加条件", "添加条件", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
                        _thisGroup.MenuItems.Add(_item);


                        _ret.Add(_thisGroup);

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
                        if (T2VDefine == null) return;
                        this.TE_MODEL.EditValue = T2VDefine.ModelName;
                        //this.TE_CONDITION.EditValue = T2VDefine.ConditionStr;
                        this.TE_CONFINE.EditValue = T2VDefine.Confine;
                        this._haveChange = false;
                }

                private void SaveData()
                {
                        //保存数据
                        //T2VDefine.ConditionStr = this.TE_CONDITION.EditValue.ToString();
                        T2VDefine.Confine = this.TE_CONFINE.EditValue.ToString();
                        //SinoSZMetaConfig.MetaDataFactroy.SaveTableDefine(this._tableDefine);
                        this._haveChange = false;
                        RaiseDataChanged();
                }


                private void TE_CONFINE_EditValueChanged(object sender, EventArgs e)
                {
                        this._haveChange = true;
                        RaiseDataChanged();
                }

        }
}
