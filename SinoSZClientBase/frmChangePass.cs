using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientBase
{
        public partial class frmChangePass : DevExpress.XtraEditors.XtraForm
        {
                private string _newPass = "";
                public frmChangePass()
                {
                        InitializeComponent();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                    if (ValidNewPass())
                    {
                        string _oldPass = this.te_oldPass.EditValue.ToString();
                        string _newPass = this.te_newPass.EditValue.ToString();
                        using (AuthorizeService.AuthorizeServiceClient _asc = new AuthorizeService.AuthorizeServiceClient())
                        {

                            if (_asc.ChangePassWord(SessionClass.CurrentSinoUser.LoginName, _oldPass, _newPass))
                            {
                                XtraMessageBox.Show("修改口令成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                XtraMessageBox.Show("修改口令失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }

                        }
                    }
                }

                private bool ValidNewPass()
                {
                        string _oldPass = this.te_oldPass.EditValue.ToString();
                        if (_oldPass == string.Empty)
                        {
                                XtraMessageBox.Show("请输入原口令!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                        }
                        _newPass = this.te_newPass.EditValue.ToString();
                        if (_newPass == string.Empty)
                        {
                                XtraMessageBox.Show("请输入新口令!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                        }

                        string _newPass2 = this.te_newPass2.EditValue.ToString();
                        if (_newPass2 == string.Empty)
                        {
                                XtraMessageBox.Show("请重复输入新口令!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                        }

                        if (_newPass != _newPass2)
                        {
                                XtraMessageBox.Show("重复输入的新口令不一致!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                        }

                        if (!ValidPasswordComplexity(_newPass))
                        {
                                XtraMessageBox.Show("新口令不符合规则！必需符合以下要求:\n1.长度必须大于8位\n2.必须有字符、数字和符号\n3.不能有汉字\n",
                                        "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                        }


                        if (!ValidOldPass(_oldPass))
                        {
                                XtraMessageBox.Show("输入的原口令不正确!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                        }
                        return true;

                }

                /// <summary>
                /// 验证新口令的复杂性
                /// </summary>
                /// <param name="_passString"></param>
                /// <returns></returns>
                private bool ValidPasswordComplexity(string _passString)
                {
                        if (_passString.Length < 8)
                        {
                                return false;
                        }
                        bool _haveDigitalOrLetter = false;
                        bool _havePun = false;

                        foreach (Char _c in _passString)
                        {
                                if (Char.IsLetterOrDigit(_c)) _haveDigitalOrLetter = true;
                                if (Char.IsPunctuation(_c)) _havePun = true;                             
                        }
                        return (_haveDigitalOrLetter && _havePun);
                }

             

                /// <summary>
                /// 验证旧口令的正确性
                /// </summary>
                /// <param name="_oldPass"></param>
                private bool ValidOldPass(string _oldPass)
                {
                    using (AuthorizeService.AuthorizeServiceClient _asc = new AuthorizeService.AuthorizeServiceClient())
                    {
                        return _asc.CheckPassword(SessionClass.CurrentSinoUser.LoginName, _oldPass,SessionClass.CurrentCheckType);
                    }
                }

       


        }
}