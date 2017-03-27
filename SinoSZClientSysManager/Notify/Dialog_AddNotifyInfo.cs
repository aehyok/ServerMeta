using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Notify;

namespace SinoSZClientSysManager.Notify
{
        public partial class Dialog_AddNotifyInfo : DevExpress.XtraEditors.XtraForm
        {
                private bool SaveNew = true;
                private NotifyInfo _oldNotify = null;
                public Dialog_AddNotifyInfo()
                {
                        InitializeComponent();
                }
                public void InitOldData(NotifyInfo _info)
                {
                        SaveNew = false;
                        this.Text = "修改通知通告";
                        _oldNotify = _info;
                        this.te_fbdwmc.EditValue = SessionClass.CurrentSinoUser.CurrentPost.PostDWMC;
                        this.te_fbdwmc.Properties.ReadOnly = true;

                        this.te_fbsj.EditValue = DateTime.Now;
                        this.te_fbsj.Properties.ReadOnly = true;

                        this.te_fbr.EditValue = SessionClass.CurrentSinoUser.UserName;
                        this.te_fbr.Properties.ReadOnly = true;

                        this.te_xxbt.EditValue = _info.Title;
                        this.te_xxnr.EditValue = _info.Context;
                        this.te_tel.EditValue = _info.TelNum;
                        this.te_email.EditValue = _info.Email;
                }

                public void InitNewData()
                {
                        SaveNew = true;
                        this.Text = "新建通知通告";
                        this.te_fbdwmc.EditValue = SessionClass.CurrentSinoUser.CurrentPost.PostDWMC;
                        this.te_fbdwmc.Properties.ReadOnly = true;

                        this.te_fbsj.EditValue = DateTime.Now;
                        this.te_fbsj.Properties.ReadOnly = true;

                        this.te_fbr.EditValue = SessionClass.CurrentSinoUser.UserName;
                        this.te_fbr.Properties.ReadOnly = true;

                }

                private void simpleButton3_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        string _msg = "";
                        bool _ret = false;
                        if (CheckInput(ref _msg))
                        {
                                if (SaveNew)
                                {
                                        _ret = SaveNewData();
                                }
                                else
                                {
                                        _ret = UpdateData();
                                }
                                if (_ret)
                                {
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                }
                                else
                                {
                                        XtraMessageBox.Show("保存失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                }
                        }
                        else
                        {
                                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                }

                private bool UpdateData()
                {
                        if (_oldNotify == null) return false;

                        _oldNotify.Context = this.te_xxnr.EditValue.ToString().Trim();
                        _oldNotify.Title = this.te_xxbt.EditValue.ToString().Trim();
                        _oldNotify.TelNum = this.te_tel.EditValue.ToString().Trim();
                        _oldNotify.Email = this.te_email.EditValue.ToString().Trim();
                        using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                        {
                            return _csc.SaveNotifyInfo(_oldNotify);
                        }
                }

                /// <summary>
                /// 保存新数据
                /// </summary>
                private bool SaveNewData()
                {
                        NotifyInfo _newNotifyInfo = new NotifyInfo(
                                        "", this.te_xxbt.EditValue.ToString().Trim(),
                                        this.te_xxnr.EditValue.ToString().Trim(),
                                        "",
                                        "",
                                        "",
                                        "",
                                        (this.te_tel.EditValue == null) ? "" : this.te_tel.EditValue.ToString().Trim(),
                                        (this.te_email.EditValue == null) ? "" : this.te_email.EditValue.ToString().Trim(),
                                        DateTime.Now);
                        using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                        {
                            return _csc.SaveNotifyInfo(_newNotifyInfo);
                        }
                }

                private bool CheckInput(ref string _msg)
                {
                        _msg = "";
                        if (this.te_xxbt.EditValue == null || this.te_xxbt.EditValue.ToString().Trim() == "")
                        {
                                _msg = "请输入主题!";
                                return false;
                        }

                        if (this.te_xxnr.EditValue == null || this.te_xxnr.EditValue.ToString().Trim() == "")
                        {
                                _msg = "请输入内容!";
                                return false;
                        }

                        return true;
                }
        }
}