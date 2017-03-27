using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SinoSZPluginFramework;
using SinoSZJS.Base.Authorize;
using SinoSZClientBase.Post;
using DevExpress.XtraBars.Ribbon;
using System.ComponentModel.Design;
using DevExpress.XtraBars.Docking;
using SinoSZJS.Base;
using SinoSZJS.Base.Misc;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using SinoSZJS.Base.MenuType;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZClientBase.PendingAlert;

namespace SinoSZClientBase
{
    /// <summary>
    /// 主界面框架
    /// </summary>
    public partial class frmMainForm : DevExpress.XtraBars.Ribbon.RibbonForm, IApplication
    {
        //最后一次点击位置
        protected Point LastClickPoint = new Point(-1, -1);
        protected int LastClickTime = 0;
        protected int MouseDoubleClickTime = Win32API.GetDoubleClickTime();
        protected Dialog_PendingAlert alertForm;
        protected List<IPendingAlert> PendingAlertLib = new List<IPendingAlert>();
        //用.Net框架提供的ServiceContainer类来实现IServiceContainer接口
        /// <summary>
        /// 服务容器
        /// </summary>
        protected ServiceContainer serviceContainer = new ServiceContainer();
        /// <summary>
        /// 插件服务
        /// </summary>
        protected PluginService pluginService;
        /// <summary>
        /// 工具栏服务
        /// </summary>
        protected ToolStripService toolStripService;
        /// <summary>
        /// 菜单服务
        /// </summary>
        protected SinoMenuService menuService;
        /// <summary>
        /// 子窗口字典
        /// </summary>
        protected Dictionary<String, Form> frmContainer = new Dictionary<string, Form>();

        /// <summary>
        /// 是否可修改用户口令
        /// </summary>
        public bool CanChangePassword = true;

        /// <summary>
        /// 注销登录界面
        /// </summary>
        public LoginForm ReLoginForm = null;

        public event EventHandler<EventArgs> ChangePassword;


        /// <summary>
        /// 主界面
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
            InitForm();
        }

        public frmMainForm(string _sysCaption)
        {
            InitializeComponent();
            InitForm();
            this.Text = _sysCaption;
        }


        public void ShowStartPage()
        {
            menuService.LoadStartupPage();
            if (this.MdiManager.Pages.Count > 0)
            {
                this.MdiManager.SelectedPage = this.MdiManager.Pages[0];
            }

        }

        /// <summary>
        /// 初始化Form
        /// </summary>
        /// <returns></returns>
        virtual protected bool InitForm()
        {
            pluginService = new PluginService(this);
            toolStripService = new ToolStripService(this);
            menuService = new SinoMenuService(this);
            menuService.LoadError += new EventHandler<SinoSZJS.Base.CommonEventArgs>(menuService_LoadError);
            serviceContainer.AddService(typeof(IPluginService), pluginService);
            serviceContainer.AddService(typeof(IToolStripService), toolStripService);
            serviceContainer.AddService(typeof(IMenuService), menuService);


            return true;
        }





        private void InitUser()
        {
            alertForm = new Dialog_PendingAlert(this);
            if (SessionClass.CurrentSinoUser != null)
            {
                this.PendingAlertLib.Clear();
                this.repositoryItemComboBox1.Items.Clear();
                this.barCurrentUser.EditValue = SessionClass.CurrentSinoUser.UserName;
                int _selectpost = 0;
                foreach (SinoPost _sp in SessionClass.CurrentSinoUser.Posts)
                {
                    PostListItem _pItem = new PostListItem(_sp);
                    int _index = this.repositoryItemComboBox1.Items.Add(_pItem);
                    if (_sp.PostID == SessionClass.CurrentSinoUser.CurrentPost.PostID)
                    {
                        _selectpost = _index;
                    }
                }
                this.barCurrentPost.EditValue = new PostListItem(SessionClass.CurrentSinoUser.CurrentPost);
                RemotingUserCTX.SetCurUser(SessionClass.CurrentSinoUser);
                if (SessionClass.CurrentSinoUser.CurrentPost != null) this.barCurrentOrg.EditValue = SessionClass.CurrentSinoUser.CurrentPost.PostDWMC;

                this.timer_PandingAlert.Enabled = true;//是否启动待办提示小图标

            }

        }

        #region IApplication Members

        public DockPanel LeftToolPanel
        {
            get { return null; }
        }

        public DockPanel RightToolPanel
        {
            get { return null; }
        }


        public DockPanel BottomToolPanel
        {
            get { return null; }
        }

        //状态栏
        public RibbonStatusBar MainStatusBar
        {
            get { return this.ribbonStatusBar; }
        }


        public RibbonControl MainRibbon
        {
            get { return this.Ribbon; }
        }

        public Form MainForm
        {
            get { return this as Form; }
        }

        /// <summary>
        /// 写系统消息
        /// </summary>
        /// <param name="_msg"></param>
        public void WriteMessage(string _msg)
        {
            WriteSysMsgBox(_msg);
        }

        /// <summary>
        /// 是否存在指定Form
        /// </summary>
        /// <param name="_frmName"></param>
        /// <returns></returns>
        virtual public bool IsExistForm(string _frmName)
        {
            if (_frmName == null) return false;
            return frmContainer.ContainsKey(_frmName);
        }

        /// <summary>
        /// 添加Form
        /// </summary>
        /// <param name="_frmName"></param>
        /// <param name="_frm"></param>
        /// <returns></returns>
        virtual public bool AddForm(string _frmName, Form _frm)
        {
            if (IsExistForm(_frmName))
            {
                SetFormActive(_frmName);
                return false;
            }

            _frm.MdiParent = this;
            _frm.Tag = _frmName;
            frmContainer[_frmName] = _frm;
            if (_frm is IChildForm)
            {
                IChildForm _c = _frm as IChildForm;
                _c.Application = this;
                _c.MenuChanged += new EventHandler<EventArgs>(_MenuChanged);

            }
            _frm.Show();
            ShowHideFormatCategory(CurrentForm);
            return true;

        }



        /// <summary>
        /// 当前Form
        /// </summary>
        IChildForm CurrentForm
        {
            get
            {
                if (this.ActiveMdiChild == null) return null;
                return this.ActiveMdiChild as IChildForm;
            }
        }

        /// <summary>
        /// 修正菜单
        /// </summary>
        /// <param name="ribbonPageCategoryCollection"></param>
        /// <param name="_c"></param>
        virtual public void ChangeMenu(RibbonPageCategoryCollection ribbonPageCategoryCollection, IChildForm _c)
        {

            RibbonPageCategory selectionCategory = ribbonPageCategoryCollection[0] as RibbonPageCategory;
            if (selectionCategory == null) return;
            selectionCategory.Pages.Clear();
            if (_c == null)
            {
                selectionCategory.Visible = false;
            }
            else
            {
                selectionCategory.Visible = true;
                IList<FrmMenuPage> _menuPages = _c.GetMenuPages();
                foreach (FrmMenuPage _page in _menuPages)
                {
                    int _index = selectionCategory.Pages.Add(new RibbonPage(_page.PageTitle));
                    IList<FrmMenuGroup> _menugroups = _page.MenuGroups;

                    foreach (FrmMenuGroup _mg in _menugroups)
                    {
                        int _groupIndex = selectionCategory.Pages[_index].Groups.Add(new RibbonPageGroup(_mg.DisplayTitle));
                        RibbonPageGroup _mgroup = selectionCategory.Pages[_index].Groups[_groupIndex];
                        IList<FrmMenuItem> _items = _mg.MenuItems;
                        foreach (FrmMenuItem _item in _items)
                        {

                            BarButtonItem _menuitem = new BarButtonItem();
                            _menuitem.Caption = _item.MenuTitle;
                            _menuitem.Tag = _item.CommandName;
                            _menuitem.LargeGlyph = _item.MenuIcon;
                            _menuitem.Glyph = _item.MenuIcon;
                            _menuitem.LargeWidth = _item.MenuPicWidth;
                            _menuitem.Enabled = _item.ButtonEnable;

                            if (_item.ChildMenus.Count < 1)
                            {
                                _menuitem.ItemClick += new ItemClickEventHandler(_menuitem_ItemClick);
                            }
                            else
                            {
                                _menuitem.ButtonStyle = BarButtonStyle.DropDown;
                                PopupMenu _cMenu = new PopupMenu();
                                _menuitem.DropDownControl = _cMenu;
                                _cMenu.Ribbon = this.Ribbon;

                                foreach (FrmMenuItem _citem in _item.ChildMenus)
                                {
                                    BarButtonItem _cmItem = new BarButtonItem();
                                    _cmItem.Caption = _citem.MenuTitle;
                                    _cmItem.Tag = _citem.CommandName;
                                    _cmItem.LargeGlyph = _citem.MenuIcon;
                                    _cmItem.Glyph = _citem.MenuIcon;
                                    _cmItem.LargeWidth = _citem.MenuPicWidth;
                                    _cmItem.Enabled = _citem.ButtonEnable;
                                    _cmItem.ItemClick += new ItemClickEventHandler(_menuitem_ItemClick);
                                    this.Ribbon.Items.Add(_cmItem);
                                    _cMenu.ItemLinks.Add(_cmItem);
                                }

                            }


                            _mgroup.ItemLinks.Add(_menuitem);

                        }

                    }

                }
            }

            if (selectionCategory.Visible && selectionCategory.Pages.Count > 0)
                ribbonPageCategoryCollection.Ribbon.SelectedPage = selectionCategory.Pages[0];
        }

        protected virtual void _menuitem_ItemClick(object sender, ItemClickEventArgs e)
        {
            string _cmdName = e.Item.Tag as string;
            CurrentForm.DoCommand(_cmdName);
        }

        protected virtual void ShowCategory()
        {
            ShowHideFormatCategory(CurrentForm);
        }

        protected virtual void _MenuChanged(object sender, EventArgs e)
        {
            ShowHideFormatCategory(CurrentForm); ;
        }



        /// <summary>
        /// 修正菜单
        /// </summary>
        /// <param name="_c"></param>
        virtual protected void ShowHideFormatCategory(IChildForm _c)
        {
            ChangeMenu(Ribbon.PageCategories, _c);
        }

        /// <summary>
        /// 移除Form
        /// </summary>
        /// <param name="_frmName"></param>
        /// <returns></returns>
        virtual public bool RemoveForm(string _frmName)
        {
            if (IsExistForm(_frmName))
            {
                Form _frm = frmContainer[_frmName];
                _frm.MdiParent = null;
                _frm.Dispose();
                frmContainer.Remove(_frmName);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 激活Form
        /// </summary>
        /// <param name="_frmName"></param>
        /// <returns></returns>
        virtual public bool SetFormActive(string _frmName)
        {
            if (IsExistForm(_frmName))
            {
                Form _frm = frmContainer[_frmName];
                _frm.Activate();
                ShowHideFormatCategory(CurrentForm); ;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 当前激活的Form
        /// </summary>
        virtual public IChildForm ActiveChildForm
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }


        public bool RegisterIPendingAlert(IPendingAlert iPendingAlert)
        {
            if (!PendingAlertLib.Contains(iPendingAlert))
            {
                PendingAlertLib.Add(iPendingAlert);
            }
            return true;
        }


        #endregion

        #region IServiceContainer Members

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
        {
            serviceContainer.AddService(serviceType, callback, promote);
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback)
        {
            serviceContainer.AddService(serviceType, callback);
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            serviceContainer.AddService(serviceType, serviceInstance, promote);
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            serviceContainer.AddService(serviceType, serviceInstance);
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            serviceContainer.RemoveService(serviceType, promote);
        }

        public void RemoveService(Type serviceType)
        {
            serviceContainer.RemoveService(serviceType);
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            return serviceContainer.GetService(serviceType);
        }

        #endregion


        private void frmMainForm_Load(object sender, EventArgs e)
        {
            pluginService.LoadAllPlugin();
            InitUser();
            this.ShowStartPage();

        }



        private void InitMenu()
        {
            foreach (Form _f in this.MdiChildren)
            {
                _f.Close();
            }

            this.MainRibbon.Pages.Clear();
            menuService.LoadMenus();
            if (SessionClass.CurrentSinoUser.CurrentPost.PostID == "0")
            {
                pluginService.SuperLoadMenus();
            }
            CheckUserPendingAlert();
        }

        private void barCurrentPost_EditValueChanged(object sender, EventArgs e)
        {
            PostListItem _pItem = this.barCurrentPost.EditValue as PostListItem;
            SinoPost _selectPost = _pItem.Post;
            RemotingUserCTX.SetCurUser(SessionClass.CurrentSinoUser);
            SessionClass.CurrentSinoUser.CurrentPost = _selectPost;
            this.barCurrentOrg.EditValue = _selectPost.PostDWMC;
            InitMenu();
        }

        private void MdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            ShowCategory();
        }

        private void MdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            string _frmName = e.Page.MdiChild.Tag as string;
            if (IsExistForm(_frmName))
            {
                frmContainer.Remove(_frmName);
            }
            ShowHideFormatCategory(CurrentForm);
            GC.Collect();
        }

        private void barLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ReLoginForm == null) return;
            //注销系统
            this.Hide();
            this.alertForm.ClearForm();
            this.timer_Iconflash.Enabled = false;
            this.notifyIcon1.Visible = false;
            if (ReLoginForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                InitUser();
                this.ShowStartPage();
            }
            else
            {
                this.Close();
                Application.Exit();
            }
        }

        private void barChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            //修改口令
            if (!CanChangePassword)
            {
                XtraMessageBox.Show("您不可以在本系统中修改用户名和口令！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ChangePassword != null)
            {
                ChangePassword(this, new EventArgs());
            }
            else
            {
                frmChangePass _f = new frmChangePass();
                _f.ShowDialog();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMessagePopup();
        }


        /// <summary>
        /// 显示信息窗
        /// </summary>
        private void ShowMessagePopup()
        {
            int x = this.Width > 290 ? this.Width - 290 : 5;
            int y = this.Height > 205 ? this.Height - 205 : 5;
            Point realPoint = this.PointToScreen(new Point(x, y));
            this.popupControlContainer1.ShowPopup(realPoint);
        }

        /// <summary>
        /// 菜单服务加载错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuService_LoadError(object sender, CommonEventArgs e)
        {
            WriteSysMsgBox(e.Message);
        }

        /// <summary>
        /// 向系统消息框添加内容
        /// </summary>
        /// <param name="_msg"></param>
        public void WriteSysMsgBox(string _msg)
        {
            SysMsgBox.AppendText(_msg);
            SysMsgBox.AppendText("\r\n");
            if (!this.timer1.Enabled) this.timer1.Enabled = true;
        }

        /// <summary>
        /// 触发显示消息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowMessagePopup();
            this.timer1.Enabled = false;
        }

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            ClearTempFile();


        }

        private void ClearTempFile()
        {
            string _path = Utils.ExeDir + "Temp";
            if (Directory.Exists(_path))
            {
                foreach (string _f in Directory.GetFiles(_path))
                {
                    try
                    {
                        File.SetAttributes(_f, FileAttributes.Normal);
                        File.Delete(_f);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("关闭时清理临时文件失败：" + ex.Message, "系统提示");
                    }
                }
            }
        }

        private void MdiManager_MouseDown(object sender, MouseEventArgs e)
        {
            if (LastClickPoint.X == e.X && LastClickPoint.Y == e.Y)
            {
                int _usedTime = Environment.TickCount - LastClickTime;
                if (_usedTime < MouseDoubleClickTime)
                {
                    int i = 0;
                    BaseTabHitInfo _info = this.MdiManager.CalcHitInfo(new Point(e.X, e.Y));
                    if (_info.Page != null)
                    {
                        XtraMdiTabPage _page = _info.Page as XtraMdiTabPage;
                        _page.MdiChild.Close();
                    }
                    _usedTime = 0;
                }
                else
                {
                    _usedTime = Environment.TickCount;
                }
            }
            else
            {
                LastClickPoint = new Point(e.X, e.Y);
                LastClickTime = Environment.TickCount;
            }

        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("您确定现在要退出系统？", "系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void timer_PandingAlert_Tick(object sender, EventArgs e)
        {
            if (SessionClass.ServerConfigData.Client_ShowPendingAlert)
            {
                CheckUserPendingAlert();
            }
        }

        private void CheckUserPendingAlert()
        {
            this.timer_PandingAlert.Enabled = false;
            //取待办事项内容

            List<PendingAlertIndex> paIndex = GetAlerts();
            if (paIndex != null && paIndex.Count > 0)
            {
                //显示ICO
                this.notifyIcon1.Visible = true;
                this.timer_Iconflash.Enabled = true;
                alertForm.SetData(paIndex);
                alertForm.ShowForm();
                this.timer_PandingAlert.Enabled = true;
            }
            else
            {
                this.notifyIcon1.Visible = false;
                this.timer_Iconflash.Enabled = false;
                this.timer_PandingAlert.Enabled = true;
            }
        }

        private List<PendingAlertIndex> GetAlerts()
        {
            List<PendingAlertIndex> _ret = new List<PendingAlertIndex>();
            foreach (IPendingAlert _ics in this.PendingAlertLib)
            {
                List<PendingAlertIndex> _l = _ics.GetAlertIndex();
                foreach (PendingAlertIndex _index in _l)
                {
                    _ret.Add(_index);
                }
            }
            return _ret;
        }

        private void timer_Iconflash_Tick(object sender, EventArgs e)
        {
            if (this.notifyIcon1.Tag == null || this.notifyIcon1.Tag.ToString() == "0")
            {
                this.notifyIcon1.Icon = global::SinoSZClientBase.Properties.Resources.keyboard2;
                this.notifyIcon1.Tag = "1";
            }
            else
            {
                this.notifyIcon1.Icon = global::SinoSZClientBase.Properties.Resources.keyboard2_cordless;
                this.notifyIcon1.Tag = "0";
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            alertForm.ShowForm();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            alertForm.ShowForm();
        }

        private void barVersion_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVersionShow _f = new frmVersionShow();
            _f.ShowDialog();
        }

    }
}