using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.User;
using System.Linq;

namespace SinoSZClientUser.UserManager
{
    public partial class Dialog_RegisterUser : DevExpress.XtraEditors.XtraForm
    {
        private decimal CurrentOrgID = -1;
        private bool ShowChildren = false;
        private int registerCount = 0;
        private List<PersonBaseInfo> PersonList = new List<PersonBaseInfo>();
        public Dialog_RegisterUser()
        {
            InitializeComponent();
        }

        public Dialog_RegisterUser(decimal _currentOrgID, bool _showChildren)
        {
            InitializeComponent();
            CurrentOrgID = _currentOrgID;
            ShowChildren = _showChildren;
        }

        /// <summary>
        /// 添加用户处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                StringBuilder sb = new StringBuilder();
                int addCount = 0;
                int SelectedCount = 0;
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    SelectPersonBaseInfoItem _item = this.gridView1.GetRow(i) as SelectPersonBaseInfoItem;
                    if (_item.Selected)
                    {
                        SelectedCount++;
                        PersonBaseInfo _personInfo = _item.PersonInfo;
                        if (_umsc.RegisterUser(_personInfo))
                        {
                            addCount++;
                        }
                        else
                        {
                            sb.AppendLine(string.Format("用户{0}已经注册或因其它错误注册失败!", _personInfo.Name));
                        }
                    }
                }
                if (SelectedCount > 0)
                {
                    sb.AppendLine(string.Format("成功注册了{0}个用户!", addCount));
                    XtraMessageBox.Show(sb.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    registerCount += addCount;
                }
            }
        }

        /// <summary>
        /// 返回处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (registerCount > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBarControl2.Increment(5);
            if (this.progressBarControl2.Position > 90) this.progressBarControl2.Position = 0;
        }

        private void Dialog_RegisterUser_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (ShowChildren)
                {
                    PersonList = _umsc.GetPersionListInOrg(CurrentOrgID, 10000).ToList<PersonBaseInfo>();
                }
                else
                {
                    PersonList = _umsc.GetPersionListInOrg(CurrentOrgID, 1).ToList<PersonBaseInfo>();
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer1.Enabled = false;

            this.sinoCommonGrid1.DataSource = GetSelectedList(PersonList);
            this.label1.Text = string.Format(" 共查询到{0}条人员信息!", PersonList.Count);
            this.progressBarControl2.Visible = false;
            this.simpleButton1.Enabled = true;
            this.simpleButton2.Enabled = true;
        }

        private List<SelectPersonBaseInfoItem> GetSelectedList(List<PersonBaseInfo> PersonList)
        {
            List<SelectPersonBaseInfoItem> _ret = new List<SelectPersonBaseInfoItem>();
            foreach (PersonBaseInfo _info in PersonList)
            {
                _ret.Add(new SelectPersonBaseInfoItem(_info));
            }
            return _ret;
        }
    }
}