using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZClientBase;
using SinoSZJS.Base.Authorize;
using SinoSZPluginFramework;
using DevExpress.XtraEditors;
using SinoSZJS.Base.User;
using System.Linq;

namespace SinoSZClientUser.MobileNumber
{
    public partial class frmUserMobile : frmBase
    {
        protected SinoOrganize _currentOrg = null;
        private bool ShowChildOrgUsers = false;
        private List<UserExtInfo> CurrentUserList = null;
        public frmUserMobile()
        {
            InitializeComponent();
        }
        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this.sinoUC_OrgTree1.LoadOrgList(SessionClass.CurrentSinoUser.QxszDWID);
            this._currentOrg = this.sinoUC_OrgTree1.SelectedOrganize;
            _initFinished = true;
        }



        #region ���ػ���ķ���

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuGroup _thisGroup;
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            bool CanUse = !(this.backgroundWorker1.IsBusy) && _initFinished;

            _thisGroup = new FrmMenuGroup("�ֻ�����ά������");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            if (this.ShowChildOrgUsers)
            {
                _item = new FrmMenuItem("�����¼�", "�����¼�", global::SinoSZClientUser.Properties.Resources.e14, true);
            }
            else
            {
                _item = new FrmMenuItem("�����¼�", "�����¼�", global::SinoSZClientUser.Properties.Resources.e13, true);
            }
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("�޸���Ϣ", "�޸���Ϣ", global::SinoSZClientUser.Properties.Resources.e7, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            if (_initFinished)
            {
                switch (_cmdName)
                {
                    case "�����¼�":
                        this.ShowChildOrgUsers = false;
                        RefreshUserList();
                        break;
                    case "�����¼�":
                        this.ShowChildOrgUsers = true;
                        RefreshUserList();
                        break;

                    case "�޸���Ϣ":
                        ChangeMobile();
                        break;

                }
            }
            return true;
        }

        private void ChangeMobile()
        {
            if (this.gridView1.RowCount < 1 || this.gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("��ѡ����Ҫ�޸���Ϣ���û���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                UserExtInfo _info = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserExtInfo;
                Dialog_ChangeUserExtInfo _f = new Dialog_ChangeUserExtInfo(_info);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                    {
                        if (_umsc.SaveUserExtInfo(_info.LogonName, _f.Mobile, _f.Email))
                        {
                            this.gridView1.BeginUpdate();
                            _info.EMAIL = _f.Email;
                            _info.Mobile = _f.Mobile;
                            this.gridView1.EndUpdate();
                        }
                        else
                        {
                            XtraMessageBox.Show("�޸��û����ֻ����뼰�����ʼ���Ϣʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// ˢ���û��б�
        /// </summary>
        private void RefreshUserList()
        {
            this.pWaitUserList.Visible = true;
            this.timer1.Enabled = true;
            this.sinoUC_OrgTree1.Enabled = false;
            this.pBarUserList.Position = 0;
            if (!this.backgroundWorker1.IsBusy) this.backgroundWorker1.RunWorkerAsync();
        }




        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pBarUserList.Increment(5);
            if (this.pBarUserList.Position > 90) this.pBarUserList.Position = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                CurrentUserList = _umsc.GetUserMobileList(this._currentOrg.Code, ShowChildOrgUsers ? (decimal)10000 : (decimal)1).ToList<UserExtInfo>();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer1.Enabled = false;
            this.sinoCommonGrid1.DataSource = CurrentUserList;
            this.pWaitUserList.Visible = false;
            this.sinoUC_OrgTree1.Enabled = true;
            this.RaiseMenuChanged();
        }

        private void sinoUC_OrgTree1_FocusChanged(object sender, SinoSZClientBase.Organize.OrgEventArgs e)
        {
            SinoOrganize _org = e.Organize;
            _currentOrg = _org;
            RefreshUserList();
        }

    }
}