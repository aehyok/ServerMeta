using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZJS.Base.Authorize;
using SinoSZClientBase.MetaDataQueryService;


namespace SinoSZClientReport.DataCheck.Board
{
    public partial class Dialog_SHMsgInfo : DevExpress.XtraEditors.XtraForm
    {
        private string InfoID = "";
        private string ShjlID = "";
        private MD_DataCheckMsg _infoData = null;
        public Dialog_SHMsgInfo()
        {
            InitializeComponent();
        }

        public Dialog_SHMsgInfo(string _msgID)
        {
            InitializeComponent();
            InfoID = _msgID;
            ShowInfo();
        }

        public void InitNew(string _shjlid, string _title, string _msg)
        {
            string _shdwid;
            ShjlID = _shjlid;
            this.te_BH.Properties.ReadOnly = true;
            this.te_Hide.ForeColor = Color.Blue;
            this.te_FBDW.EditValue = SessionClass.CurrentSinoUser.CurrentPost.PostDWMC;
            this.te_FBDW.Properties.ReadOnly = true;
            this.te_FBR.EditValue = SessionClass.CurrentSinoUser.UserName;
            this.te_FBR.Properties.ReadOnly = true;
            this.te_FBSJ.EditValue = DateTime.Now;
            this.te_FBSJ.Properties.ReadOnly = true;
            this.te_FKJG.Properties.ReadOnly = true;
            this.te_FKSJ.Properties.ReadOnly = true;
            this.te_CDDW.ForeColor = Color.Blue;

            this.te_Context.EditValue = _msg;
            this.te_Context.ForeColor = Color.Blue;

            this.te_Title.EditValue = _title;
            this.te_Title.ForeColor = Color.Blue;
            this.te_Tel.ForeColor = Color.Blue;
            this.te_Email.ForeColor = Color.Blue;
            this.te_CDDW.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
            this.simpleButton2.Text = "发布";

            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                _shdwid = _rsc.GetSjshInfo_DWID(this.ShjlID);
            }
            if (_shdwid != "")
            {
                this.te_CDDW.SelectedCode(decimal.Parse(_shdwid));
            }
        }

        public void InitData(string _ggjlid)
        {
            InfoID = _ggjlid;
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {

                _infoData = _rsc.GetDataCheckMsg(_ggjlid);
            }
            if (_infoData == null)
            {
                SetReadOnly();
                return;
            }
            ShjlID = _infoData.SHJLID;
            this.te_CDDW.InitRootDWID(SessionClass.RootOrgID);

            this.te_BH.EditValue = _infoData.BH;
            this.te_Hide.EditValue = _infoData.SFYC;
            this.te_FBSJ.EditValue = _infoData.FBSJ;
            this.te_FBR.EditValue = _infoData.FBR;
            this.te_FBDW.EditValue = _infoData.FBDWMC;
            this.te_CDDW.SelectedDWDM(this._infoData.CDDWDM);
            this.te_Tel.EditValue = _infoData.LXDH;
            this.te_Email.EditValue = _infoData.YJDZ;
            this.te_Title.EditValue = _infoData.XXBT;
            this.te_Context.EditValue = _infoData.XXNR;
            this.te_FKJG.EditValue = _infoData.FKJG;
            this.te_FKSJ.EditValue = _infoData.FKSJ;

            if (SessionClass.CurrentSinoUser.CurrentPost.PostDWDM == _infoData.FBDWDM && _infoData.FKJG == "")
            {
                ModifyFBXX();
            }
            else if (SessionClass.CurrentSinoUser.CurrentPost.PostDWDM == _infoData.CDDWDM)
            {
                FKXX();
            }
            else
            {
                SetReadOnly();
            }

        }

        private void FKXX()
        {
            this.te_BH.Properties.ReadOnly = true;
            this.te_Hide.Properties.ReadOnly = true;
            this.te_FBSJ.Properties.ReadOnly = true;
            this.te_FBR.Properties.ReadOnly = true;
            this.te_FBDW.Properties.ReadOnly = true;
            this.te_CDDW.Properties.ReadOnly = true;
            this.te_Tel.Properties.ReadOnly = true;
            this.te_Email.Properties.ReadOnly = true;
            this.te_Title.Properties.ReadOnly = true;
            this.te_Context.Properties.ReadOnly = true;
            this.te_FKJG.ForeColor = Color.Blue;
            this.te_FKSJ.Properties.ReadOnly = true;
            this.simpleButton2.Text = "反馈";
        }

        private void SetReadOnly()
        {
            this.te_BH.Properties.ReadOnly = true;
            this.te_Hide.Properties.ReadOnly = true;
            this.te_FBSJ.Properties.ReadOnly = true;
            this.te_FBR.Properties.ReadOnly = true;
            this.te_FBDW.Properties.ReadOnly = true;
            this.te_CDDW.Properties.ReadOnly = true;
            this.te_Tel.Properties.ReadOnly = true;
            this.te_Email.Properties.ReadOnly = true;
            this.te_Title.Properties.ReadOnly = true;
            this.te_Context.Properties.ReadOnly = true;
            this.te_FKJG.Properties.ReadOnly = true;
            this.te_FKSJ.Properties.ReadOnly = true;
            this.simpleButton2.Visible = false;
            this.simpleButton1.Text = "确定";
        }

        private void ModifyFBXX()
        {
            this.te_BH.Properties.ReadOnly = true;
            this.te_Hide.ForeColor = Color.Blue;
            this.te_FBDW.Properties.ReadOnly = true;
            this.te_FBR.Properties.ReadOnly = true;
            this.te_FBSJ.Properties.ReadOnly = true;
            this.te_FKJG.Properties.ReadOnly = true;
            this.te_FKSJ.Properties.ReadOnly = true;
            this.te_CDDW.ForeColor = Color.Blue;
            this.te_Context.ForeColor = Color.Blue;
            this.te_Title.ForeColor = Color.Blue;
            this.te_Tel.ForeColor = Color.Blue;
            this.te_Email.ForeColor = Color.Blue;
            this.simpleButton2.Text = "保存";
            this.simpleButton3.Visible = true;
        }
        /// <summary>
        /// 显示信息
        /// </summary>
        private void ShowInfo()
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            switch (this.simpleButton2.Text)
            {
                case "发布":
                    SendNewMsg();
                    break;
                case "反馈":
                    SendFKInfo();
                    break;
                case "保存":
                    SaveChanged();
                    break;
            }
        }

        private void SaveChanged()
        {
            if (_infoData == null) return;
            if (this.te_CDDW.Code == -1)
            {
                XtraMessageBox.Show("请选择传达单位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.te_Title.EditValue == "" || this.te_Title.EditValue.ToString().Trim() == "")
            {
                XtraMessageBox.Show("请输入公告主题！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.te_Context.EditValue == "" || this.te_Context.EditValue.ToString().Trim() == "")
            {
                XtraMessageBox.Show("请输入公告内容！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _cddw = this.te_CDDW.DWDM.ToString();
            decimal _sfkj = (this.te_Hide.SelectedIndex == 0) ? (decimal)0 : (decimal)1;
            string _tel = (this.te_Tel.EditValue == null) ? "" : this.te_Tel.EditValue.ToString();
            string _email = (this.te_Email.EditValue == null) ? "" : this.te_Email.EditValue.ToString();
            string _title = this.te_Title.EditValue.ToString();
            string _context = this.te_Context.EditValue.ToString();
            using (MetaDataQueryServiceClient _rsc = new MetaDataQueryServiceClient())
            {
                if (_rsc.UpdateDataCheckMsg(this._infoData.ID, _title, _context, _cddw, _tel, _email, _sfkj))
                {
                    XtraMessageBox.Show("保存修改内容成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("保存修改内容失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void SendFKInfo()
        {
            if (_infoData == null) return;
            if (this.te_FKJG.EditValue != null && this.te_FKJG.EditValue.ToString().Trim() != "")
            {
                string _fkjg = this.te_FKJG.EditValue.ToString();
                using (MetaDataQueryServiceClient _rsc = new MetaDataQueryServiceClient())
                {
                    if (_rsc.SendDataCheckMsgFK(_infoData.ID, _fkjg))
                    {
                        XtraMessageBox.Show("反馈成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("反馈失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("请选择反馈结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void SendNewMsg()
        {
            if (InfoID == "")
            {
                if (this.te_CDDW.Code == -1)
                {
                    XtraMessageBox.Show("请选择传达单位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.te_Title.EditValue == "" || this.te_Title.EditValue.ToString().Trim() == "")
                {
                    XtraMessageBox.Show("请输入公告主题！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.te_Context.EditValue == "" || this.te_Context.EditValue.ToString().Trim() == "")
                {
                    XtraMessageBox.Show("请输入公告内容！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string _cddw = this.te_CDDW.DWDM.ToString();
                decimal _sfkj = (this.te_Hide.SelectedIndex == 0) ? (decimal)0 : (decimal)1;
                string _tel = (this.te_Tel.EditValue == null) ? "" : this.te_Tel.EditValue.ToString();
                string _email = (this.te_Email.EditValue == null) ? "" : this.te_Email.EditValue.ToString();
                string _title = this.te_Title.EditValue.ToString();
                string _context = this.te_Context.EditValue.ToString();
                using (MetaDataQueryServiceClient _rsc = new MetaDataQueryServiceClient())
                {
                    if (_rsc.InsertNewDataCheckMsg(this.ShjlID, _title, _context, _cddw, _tel, _email, _sfkj))
                    {
                        XtraMessageBox.Show("发布成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("发布失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


            }
            else
            {
                XtraMessageBox.Show("发布失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //删除
            if (_infoData == null) return;
            if (XtraMessageBox.Show("请确认是否要删除此公告记录？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
                {
                    if (_rsc.DeleteDataCheckMsg(this._infoData.ID))
                    {
                        XtraMessageBox.Show("删除审核公告成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("删除审核公告失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }


    }
}