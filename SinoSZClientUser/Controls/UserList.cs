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
        public partial class UserList : XtraUserControl
        {
                private bool _initFinished = false;
                public UserList()
                {
                        InitializeComponent();
                }
                #region 自定义属性
                public bool IsUserSelected
                {
                        get
                        {
                                if (this.gridView1.FocusedRowHandle >= 0)
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

                public UserBaseInfo FocusedUser
                {
                        get
                        {
                                if (this.gridView1.FocusedRowHandle >= 0)
                                {
                                        return this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserBaseInfo;
                                }
                                else
                                {
                                        return null;
                                }
                        }
                }
                #endregion

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

                private void UserList_Load(object sender, EventArgs e)
                {
                        this._initFinished = true;
                }

                private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
                {
                        this.RaiseUserFocusChanged();
                }
        }
}
