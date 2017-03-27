using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.JSGDS;
using SinoSZJS.Base.Misc;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class UC_GDSDefine : UserControl
    {
        private GDSCommanderDefine GDSDefine = null;
        public event EventHandler<EventArgs> DataChanged;
        private bool InitFinished = false;
        public UC_GDSDefine()
        {
            InitializeComponent();
        }

        public UC_GDSDefine(GDSCommanderDefine Define)
        {
            InitializeComponent();
            GDSDefine = Define;
        }

        private void UC_GDSDefine_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            this.te_ID.EditValue = GDSDefine.ID;
            this.te_DWDM.EditValue = GDSDefine.DWDM;
            this.te_Command.EditValue = GDSDefine.CommandName;
            this.te_DES.EditValue = GDSDefine.Descript;
            this.te_Type.EditValue = GDSDefine.IcsType;
            this.te_TokenType.EditValue = GDSDefine.TokenType;
            this.te_Call.EditValue = GDSDefine.CallParamDefine;
            this.te_Return.EditValue = GDSDefine.ReturnDefine;
            this.ce_ICSSTATE.Checked = (GDSDefine.State == "1");
            this.te_ZB.EditValue = StrUtils.GetMetaByName2("ZB", GDSDefine.IcsConfig);
            string _savecall = StrUtils.GetMetaByName2("SAVECALL", GDSDefine.IcsConfig).Trim();
            string _savereturn = StrUtils.GetMetaByName2("SAVERETURN", GDSDefine.IcsConfig).Trim();

            this.ce_SaveCall.Checked = (_savecall == "Y" || _savecall == "YES" || _savecall == "TRUE");
            this.ce_SaveReturn.Checked = (_savereturn == "Y" || _savereturn == "YES" || _savereturn == "TRUE");
            this.GDSTokenSet.CommandName = GDSDefine.CommandName;
            InitFinished = true;
        }

        public bool SaveData()
        {
            //保存数据
            GDSCommanderDefine gdf = new GDSCommanderDefine();
            gdf.ID = (this.te_ID.EditValue == null) ? "" : this.te_ID.EditValue.ToString();
            gdf.DWDM = (this.te_DWDM.EditValue == null) ? "" : this.te_DWDM.EditValue.ToString();
            gdf.CommandName = (this.te_Command.EditValue == null) ? "" : this.te_Command.EditValue.ToString();
            gdf.Descript = (this.te_DES.EditValue == null) ? "" : this.te_DES.EditValue.ToString();
            gdf.IcsType = (this.te_Type.EditValue == null) ? "" : this.te_Type.EditValue.ToString();
            gdf.TokenType = (this.te_TokenType.EditValue == null) ? "" : this.te_TokenType.EditValue.ToString();
            gdf.CallParamDefine = (this.te_Call.EditValue == null) ? "" : this.te_Call.EditValue.ToString();
            gdf.ReturnDefine = (this.te_Return.EditValue == null) ? "" : this.te_Return.EditValue.ToString();

            string _zb = (this.te_ZB.EditValue == null) ? "" : this.te_ZB.EditValue.ToString();
            string _savecall = this.ce_SaveCall.Checked ? "TRUE" : "FALSE";
            string _savereturn = this.ce_SaveReturn.Checked ? "TRUE" : "FALSE";
            gdf.IcsConfig = string.Format("<ZB>{0}</ZB><SAVECALL>{1}</SAVECALL><SAVERETURN>{2}</SAVERETURN>", _zb, _savecall, _savereturn);
            gdf.State = this.ce_ICSSTATE.Checked ? "1" : "0";

            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                bool _ret = _csc.SaveGDSDefine(gdf);
                if (_ret)
                {
                    MessageBox.Show("保存成功！", "系统消息", MessageBoxButtons.OK);
                    GDSDefine.DWDM = gdf.DWDM;
                    GDSDefine.CallParamDefine = gdf.CallParamDefine;
                    GDSDefine.CommandName = gdf.CommandName;
                    GDSDefine.Descript = gdf.Descript;
                    GDSDefine.IcsConfig = gdf.IcsConfig;
                    GDSDefine.IcsType = gdf.IcsType;
                    GDSDefine.ReturnDefine = gdf.ReturnDefine;
                    GDSDefine.State = gdf.State;
                    GDSDefine.TokenType = gdf.TokenType;

                }
                else
                {
                    MessageBox.Show("保存失败！", "系统消息", MessageBoxButtons.OK);
                }
                return _ret;
            }
        }

        public void RaiseDataChanged()
        {
            if (InitFinished && DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }

        private void te_Command_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_DWDM_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_DES_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_Type_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_TokenType_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_Call_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_Return_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void te_ZB_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }


        private void ce_SaveCall_CheckStateChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void ce_SaveReturn_CheckStateChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }


        private void ce_ICSSTATE_CheckStateChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    break;
                case 1:
                    this.GDSTokenSet.Load();
                    break;
                case 2:
                    this.uC_GDSLog1.CommandName = this.GDSDefine.CommandName;
                    break;
                case 3:
                    this.uC_GDSTest1.InitData(this.GDSDefine.CommandName);
                    break;
            }
        }
    }
}
