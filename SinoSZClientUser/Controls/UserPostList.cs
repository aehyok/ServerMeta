using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZClientUser.PostManager;
using SinoSZJS.Base.User;
using System.Linq;

namespace SinoSZClientUser.Controls
{
    public partial class UserPostList : DevExpress.XtraEditors.XtraUserControl
    {
        private UserBaseInfo CurrentUser = null;
        private bool _initFinished = false;

        public UserPostList()
        {
            InitializeComponent();
        }
        public UserPostInfo SelectedPost
        {
            get
            {
                if (this.gridView1.FocusedRowHandle >= 0)
                {
                    return this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserPostInfo;
                }
                else
                {
                    return null;
                }
            }
        }
        public UserBaseInfo UserInfo
        {
            set
            {
                CurrentUser = value;
                InitForm();
            }
        }

        private void InitForm()
        {
            _initFinished = false;
            this.sinoCommonGrid1.DataSource = null;
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                List<UserPostInfo> _postList = _umsc.GetPostListByUserID(CurrentUser.UserID).ToList<UserPostInfo>();
                this.sinoCommonGrid1.DataSource = _postList;
            }
            _initFinished = true;
        }

        public List<UserPostInfo> GetSelectedPosts()
        {
            List<UserPostInfo> _ret = new List<UserPostInfo>();
            if (this.gridView1.SelectedRowsCount > 0)
            {
                int[] _selectedIndexs = this.gridView1.GetSelectedRows();
                foreach (int _index in _selectedIndexs)
                {
                    UserPostInfo _item = this.gridView1.GetRow(_index) as UserPostInfo;
                    _ret.Add(_item);
                }
            }
            return _ret;
        }

        public bool ExistName(List<UserPostInfo> ClipPad, ref string _msg)
        {
            bool _ret = false;
            _msg = "";
            string _fg = "";
            if (this.gridView1.RowCount > 0)
            {
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    UserPostInfo _pItem = this.gridView1.GetRow(i) as UserPostInfo;
                    foreach (UserPostInfo _p in ClipPad)
                    {
                        if (_p.PostID == _pItem.PostID)
                        {
                            _ret = true;
                            _msg += _fg;
                            _msg += _p.PostName;
                            _fg = ",";
                        }
                    }
                }

            }

            return _ret;
        }
    }
}
