using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Authorize;
using SinoSZClientUser.PostManager;
using System.Linq;
namespace SinoSZClientUser.Controls
{
    public partial class PostList : UserControl
    {
        private SinoOrganize CurrentOrg = null;
        private bool _initFinished = false;
        public PostList()
        {
            InitializeComponent();
        }

        public SinoOrganize Organize
        {
            set
            {
                CurrentOrg = value;
                InitPostList();
            }
        }



        #region 属性
        public SinoPost SelectedPost
        {
            get
            {
                if (this.gridView1.FocusedRowHandle >= 0)
                {
                    PostItem _item = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PostItem;
                    return _item.PostData;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 自定义事件
        public event EventHandler<EventArgs> FocusPostChanged;
        public void RaiseFocusPostChanged()
        {
            if (!_initFinished) return;
            if (FocusPostChanged != null)
            {
                FocusPostChanged(this, new EventArgs());
            }

        }
        #endregion

        private void PostList_Load(object sender, EventArgs e)
        {
            InitPostList();
        }

        private void InitPostList()
        {
            List<SinoPost> _postList;
            _initFinished = false;
            this.sinoCommonGrid1.DataSource = null;
            if (CurrentOrg != null)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    _postList = _umsc.GetPostListInOrg(CurrentOrg).ToList<SinoPost>();
                }
                List<PostItem> PostItemList = new List<PostItem>();
                foreach (SinoPost _sp in _postList)
                {
                    PostItemList.Add(new PostItem(_sp));
                }

                this.sinoCommonGrid1.DataSource = PostItemList;
            }
            _initFinished = true;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0) RaiseFocusPostChanged();
        }



        internal List<SinoPost> GetSelectedPosts()
        {
            List<SinoPost> _ret = new List<SinoPost>();
            if (this.gridView1.SelectedRowsCount > 0)
            {
                int[] _selectedIndexs = this.gridView1.GetSelectedRows();
                foreach (int _index in _selectedIndexs)
                {
                    PostItem _item = this.gridView1.GetRow(_index) as PostItem;
                    _ret.Add(_item.PostData);
                }
            }
            return _ret;
        }

        public bool ExistName(List<SinoPost> ClipPad, ref string _msg)
        {
            bool _ret = false;
            _msg = "";
            string _fg = "";
            if (this.gridView1.RowCount > 0)
            {
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    PostItem _pItem = this.gridView1.GetRow(i) as PostItem;
                    foreach (SinoPost _p in ClipPad)
                    {
                        if (_p.PostName == _pItem.PostName)
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
