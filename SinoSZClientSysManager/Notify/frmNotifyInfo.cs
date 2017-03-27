using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZPluginFramework;
using SinoSZJS.Base.Notify;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientSysManager.Notify
{
    public partial class frmNotifyInfo : frmBase
    {
        private DataTable NotifyList = null;
        private NotifyInfo CurrentInfo = null;
        public frmNotifyInfo()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            this._initFinished = true;
            this.labelStatus.Text = "正在读取数据....";
            this.panelControl1.Visible = true;
            this.marqueeProgressBarControl1.Properties.Stopped = false;
            this.RaiseMenuChanged();
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                NotifyList = _csc.GetNotifyList(1000000);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.panelControl1.Visible = false;
            this.marqueeProgressBarControl1.Properties.Stopped = true;
            this.gridView1.BeginUpdate();
            this.gridControl1.DataSource = NotifyList;
            this.gridView1.EndUpdate();
            this.RaiseMenuChanged();
        }


        #region 重载基类的方法

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("通知通告");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("新增", "新增", global::SinoSZClientSysManager.Properties.Resources.u1, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("修改", "修改", global::SinoSZClientSysManager.Properties.Resources.u3, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("删除", "删除", global::SinoSZClientSysManager.Properties.Resources.u2, true);
            _thisGroup.MenuItems.Add(_item);
            //_item = new FrmMenuItem("查询", "查询", global::SinoSZClientSysManager.Properties.Resources.b28, true);
            //_thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "新增":
                    Dialog_AddNotifyInfo _frmadd = new Dialog_AddNotifyInfo();
                    _frmadd.InitNewData();
                    if (_frmadd.ShowDialog() == DialogResult.OK)
                    {
                        this.backgroundWorker1.RunWorkerAsync();
                    }
                    break;
                case "修改":
                    if (CurrentInfo != null)
                    {
                        if (CurrentInfo.FBdwid == SessionClass.CurrentSinoUser.CurrentPost.PostDWDM && CurrentInfo.FByhmc == SessionClass.CurrentSinoUser.UserName
                              )
                        {
                            Dialog_AddNotifyInfo _frmModify = new Dialog_AddNotifyInfo();
                            _frmModify.InitOldData(CurrentInfo);
                            if (_frmModify.ShowDialog() == DialogResult.OK)
                            {
                                ClearMsg();
                                this.backgroundWorker1.RunWorkerAsync();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("您无权修改此记录!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "删除":
                    if (CurrentInfo != null)
                    {
                        if (CurrentInfo.FBdwid == SessionClass.CurrentSinoUser.CurrentPost.PostDWDM && CurrentInfo.FByhmc == SessionClass.CurrentSinoUser.UserName
                                )
                        {
                            if (XtraMessageBox.Show("您确认要删除此通知通告记录吗？", "系统提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                                {
                                    if (_csc.DeleteNotifyInfo(CurrentInfo))
                                    {
                                        XtraMessageBox.Show("删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ClearMsg();
                                        this.backgroundWorker1.RunWorkerAsync();

                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("删除失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("您无权删除此记录!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "查询":
                    break;
            }
            return true;
        }




        #endregion

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int _index = this.gridView1.FocusedRowHandle;
            if (_index >= 0)
            {
                DataRow _dr = this.gridView1.GetDataRow(_index);
                string _msgid = _dr["ID"].ToString();
                ShowMsg(_msgid);
            }
        }

        private void ShowMsg(string _msgid)
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                CurrentInfo = _csc.GetNotifyInfo(_msgid);
            }
            if (CurrentInfo != null)
            {
                this.te_xxbt.EditValue = CurrentInfo.Title;
                this.te_xxnr.EditValue = CurrentInfo.Context;
                this.te_fbdwmc.EditValue = CurrentInfo.FBdwmc;
                this.te_fbr.EditValue = CurrentInfo.FByhmc;
                this.te_fbsj.EditValue = CurrentInfo.SendTime;
                this.te_tel.EditValue = CurrentInfo.TelNum;
                this.te_email.EditValue = CurrentInfo.Email;
            }
            else
            {
                ClearMsg();
            }
        }

        private void ClearMsg()
        {
            this.te_xxbt.EditValue = null;
            this.te_xxnr.EditValue = null;
            this.te_fbdwmc.EditValue = null;
            this.te_fbr.EditValue = null;
            this.te_fbsj.EditValue = null;
            this.te_tel.EditValue = null;
            this.te_email.EditValue = null;
        }

    }
}