using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.User;

namespace SinoSZClientUser.Controls
{
    public partial class UserMappingList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _initFinished = false;
        public UserMappingList()
        {
            InitializeComponent();
        }

        #region 自定义属性
        public bool IsUserSelected
        {
            get
            {
                if (this.bandedGridView1.FocusedRowHandle >= 0)
                {
                    return true;
                }
                return false;
            }
        }

        public object DataSource
        {
            get { return this.sinoCommonGrid1.DataSource; }
            set
            {
                this._initFinished = false;
                this.sinoCommonGrid1.DataSource = value;
                this._initFinished = true;
            }
        }

        public void BeginUpdate()
        {
             this.bandedGridView1.BeginUpdate();
        }

        public void EndUpdate()
        {
            this.bandedGridView1.EndUpdate();
        }

        public UserMappingInfo FocusedUser
        {
            get
            {
                if (this.bandedGridView1.FocusedRowHandle >= 0)
                {
                    return this.bandedGridView1.GetRow(this.bandedGridView1.FocusedRowHandle) as UserMappingInfo;
                }
                else
                {
                    return null;
                }
            }
        }

        #region 自定义事件
        public event EventHandler<EventArgs> UserFocusChanged;
        virtual public void RaiseUserFocusChanged()
        {
            if (this._initFinished && UserFocusChanged != null)
            {
                UserFocusChanged(this, new EventArgs());
            }
        }
        #endregion

        private void UserMappingList_Load(object sender, EventArgs e)
        {
            this._initFinished = true;
        }

        
        #endregion

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.RaiseUserFocusChanged();
        }
    }
}
