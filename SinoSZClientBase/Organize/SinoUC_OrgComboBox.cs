using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using SinoSZJS.Base.Authorize;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace SinoSZClientBase.Organize
{
    public class SinoUC_OrgComboBox : PopupContainerEdit
    {
        //列表窗口相关变量 (全部用pw前缀)  -------------------------------------------------
        protected PopupContainerControl _pwContainer;
        protected TreeList _pwListTree;
        protected TreeListColumn _pwListTreeColumn;
        private Timer _pwTimer;
        private IAuthorize ics_Auth = null;


        //相关私有变量
        private SinoOrganize _selectedCode = null;

        public SinoUC_OrgComboBox()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 是否只读
        /// </summary>
        [Category("WinFormEx")]
        public bool ReadOnly
        {
            get { return Properties.ReadOnly; }
            set
            {
                Properties.ReadOnly = value;
                foreach (EditorButton btn in Properties.Buttons)
                    btn.Enabled = !value;
            }
        }

        /// <summary>
        /// 当前所选/录入的单位
        /// </summary>
        [Category("WinFormEx"), Bindable(true)]
        public SinoOrganize OrgItem
        {
            get
            {
                return _selectedCode;
            }

            set
            {

            }
        }

        /// <summary>
        /// 当前所选/录入的单位ID
        /// </summary>
        [Category("WinFormEx")]
        public decimal Code
        {
            get
            {
                if (_selectedCode == null) return -1;
                else
                    return _selectedCode.Code;
            }

        }

        /// <summary>
        /// 当前所选/录入的单位名称
        /// </summary>
        [Category("WinFormEx"), Bindable(true)]
        public string Name
        {
            get
            {
                if (_selectedCode == null) return "";
                else
                    return _selectedCode.Name;
            }

            set
            {

            }
        }

        /// <summary>
        /// 当前所选/录入的单位全称
        /// </summary>
        [Category("WinFormEx"), Bindable(true)]
        public string FullName
        {
            get
            {
                if (_selectedCode == null) return "";
                else
                    return _selectedCode.FullName;
            }

            set
            {

            }
        }

        /// <summary>
        /// 当前所选/录入的单位编码
        /// </summary>
        [Category("WinFormEx"), Bindable(true)]
        public string DWDM
        {
            get
            {
                if (_selectedCode == null) return "";
                else
                    return _selectedCode.DWDM;
            }

            set
            {

            }
        }

        #endregion

        #region 公共方法
        public void InitRootDWID(string rootDWID)
        {
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                this._pwListTree.Nodes.Clear();
                string _rdwid = rootDWID;
                switch (rootDWID)
                {
                    case "CURRENTPOST":
                        _rdwid = SinoUserCtx.CurUser.CurrentPost.PostDwID;
                        break;
                }

                IList<SinoOrganize> _childOrg = _csc.GetRootDwList(_rdwid, 1); ;
                if (_childOrg == null || _childOrg.Count < 1)
                {
                    return;
                }

                foreach (SinoOrganize _so in _childOrg)
                {
                    TreeListNode _tn = _pwListTree.AppendNode("", null);
                    _tn.SetValue(_pwListTreeColumn, _so.Name);
                    _tn.Tag = _so;
                    _tn.HasChildren = true;
                    _TryShowNextLevel(_tn);
                    _tn.Expanded = true;
                }
            }

        }

        public void SelectedCode(decimal _code)
        {
            string _sid = _code.ToString();
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                List<SinoOrganize> _childOrg = _csc.GetRootDwList(_sid, 1).ToList<SinoOrganize>();
                FindOrgByStr _finder = new FindOrgByStr(_sid);
                List<SinoOrganize> olist = _childOrg.FindAll(new Predicate<SinoOrganize>(_finder.FindByID));
                olist.Sort(new SinoOrganizeComparer());
                foreach (SinoOrganize _so in olist)
                {
                    _ChangeText(_so, true, true);
                }
            }
        }

        public void SelectedDWDM(string _dwdm)
        {
            //string _sid = _code.ToString();
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                string _sid = _csc.GetDWIDByDWDM(_dwdm).ToString();
                List<SinoOrganize> _childOrg = _csc.GetRootDwList(_sid, 1).ToList<SinoOrganize>();
                FindOrgByStr _finder = new FindOrgByStr(_sid);
                List<SinoOrganize> olist = _childOrg.FindAll(new Predicate<SinoOrganize>(_finder.FindByID));
                olist.Sort(new SinoOrganizeComparer());
                foreach (SinoOrganize _so in olist)
                {
                    _ChangeText(_so, true, true);
                }
            }
        }
        #endregion

        //	DevExpress的控件似乎有些bug, 自动生成的InitializeComponent代码有些问题，因此手工写一个
        private void InitializeComponent()
        {
            this._pwContainer = new PopupContainerControl();
            this._pwListTree = new TreeList();
            this._pwContainer.SuspendLayout();

            // 
            // _pwContainer
            // 
            this._pwContainer.BorderStyle = BorderStyles.Default;
            this._pwContainer.Controls.Add(this._pwListTree);
            this._pwContainer.Location = new System.Drawing.Point(0, 23);
            this._pwContainer.Name = "_pwContainer";
            this._pwContainer.Size = new System.Drawing.Size(256, 280);
            this._pwContainer.TabIndex = 1;
            // 
            // _pwListTree
            // 
            this._pwListTree.BackColor = Color.Honeydew;
            this._pwListTree.BorderStyle = BorderStyles.NoBorder;
            this._pwListTree.Dock = System.Windows.Forms.DockStyle.Fill;

            this._pwListTree.Location = new System.Drawing.Point(0, 0);
            this._pwListTree.Name = "_pwListTree";
            this._pwListTree.KeyFieldName = "Code";
            this._pwListTree.OptionsView.ShowColumns = false;
            this._pwListTree.OptionsView.ShowIndicator = false;
            this._pwListTree.Appearance.FocusedCell.BackColor = Color.FromArgb(255, 252, 205);
            this._pwListTree.Appearance.FocusedCell.BackColor2 = Color.FromArgb(249, 191, 18);
            this._pwListTree.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this._pwListTree.Size = new System.Drawing.Size(254, 257);
            this._pwListTree.TabIndex = 3;
            this._pwListTree.OptionsBehavior.AllowExpandOnDblClick = false;
            this._pwListTree.DoubleClick += new System.EventHandler(this.listTree_DoubleClick);
            this._pwListTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listTree_KeyDown);
            this._pwListTree.BeforeExpand += new BeforeExpandEventHandler(_pwListTree_BeforeExpand);


            //
            // _pwListTreeColumn
            //
            _pwListTreeColumn = this._pwListTree.Columns.Add();
            _pwListTreeColumn.Visible = true;
            _pwListTreeColumn.VisibleIndex = 0;
            _pwListTreeColumn.OptionsColumn.AllowEdit = false;
            _pwListTreeColumn.OptionsColumn.ReadOnly = true;
            _pwListTreeColumn.FieldName = "DISPLAYTITLE2";


            //
            //	_pwTimer
            //
            this._pwTimer = new System.Windows.Forms.Timer();
            this._pwTimer.Enabled = false;
            this._pwTimer.Interval = 1;
            this._pwTimer.Tick += new EventHandler(this.Timer_Tick);

            this._pwContainer.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.Properties)).BeginInit();
            // 
            // TreeComboBox
            // 
            this.Size = new System.Drawing.Size(200, 22);

            this.ButtonClick += new ButtonPressedEventHandler(OrgComboBox_ButtonClick);
            this.Resize += new System.EventHandler(this.popupContainer_Resize);
            this.KeyDown += new KeyEventHandler(OrgComboBox_KeyDown);
            this.Leave += new System.EventHandler(this.OrgComboBox_Leave);
            this.KeyUp += new KeyEventHandler(OrgComboBox_KeyUp);
            this.Closed += new ClosedEventHandler(OrgComboBox_Closed);
            // 
            // _properties
            // 
            this.Properties.Name = "_properties";
            this.Properties.AllowFocused = false;
            this.Properties.PopupControl = _pwContainer;
            this.Properties.CloseOnLostFocus = true;
            this.Properties.CloseOnOuterMouseClick = true;
            //this.Properties.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Bottom, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText);
            this.Properties.ButtonsStyle = BorderStyles.Default;


            ((System.ComponentModel.ISupportInitialize)(this.Properties)).EndInit();

        }
        #region 私有方法
        /// <summary>
        /// 用户选取某个节点(还需要判断是否可以选择)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool _TrySelectNode(TreeListNode node)
        {
            if (!_CanSelectNode(node))
            {
                _BeepError();
                return false;
            }
            SinoOrganize _CValue = (SinoOrganize)_pwListTree.FocusedNode.Tag;
            _ChangeText(_CValue, true, true);
            RaiseSelectionChangeCommitted();
            ClosePopup();
            return true;
        }

        /// <summary>
        /// 显示下级单位
        /// </summary>
        /// <param name="_node"></param>
        private void _TryShowNextLevel(TreeListNode _node)
        {
            TreeListNode _tn;
            List<SinoOrganize> _childOrg;
            SinoOrganize _rci = (SinoOrganize)_node.Tag;
            if (_node.HasChildren && _node.Nodes.Count < 1)
            {
                using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
                {
                    _childOrg = _csc.GetRootDwList(_rci.Code.ToString(), 2).ToList<SinoOrganize>();
                }
                FindOrgByStr _finder = new FindOrgByStr(_rci.Code.ToString());
                List<SinoOrganize> olist = _childOrg.FindAll(new Predicate<SinoOrganize>(_finder.FindByFatherID));
                olist.Sort(new SinoOrganizeComparer());
                foreach (SinoOrganize _so in olist)
                {
                    _tn = _pwListTree.AppendNode("", _node);
                    _tn.SetValue(_pwListTreeColumn, _so.Name);
                    _tn.Tag = _so;
                    _tn.HasChildren = true;
                    _tn.Expanded = false;

                }
            }
        }

        /// <summary>
        /// 收起此点
        /// </summary>
        /// <param name="treeListNode"></param>
        private void _TryCollapseNode(TreeListNode node)
        {
            node.Expanded = false;
        }


        /// <summary>
        /// 修改代码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="text"></param>
        /// <param name="raiseCodeChanged"></param>
        /// <param name="raiseCodeChangedByUser"></param>
        protected void _ChangeText(SinoOrganize codeData, bool raiseCodeChanged, bool raiseCodeChangedByUser)
        {
            this._selectedCode = codeData;

            this.Text = this._selectedCode.Name;

            if (raiseCodeChanged) RaiseCodeChanged();			//	必须，否则数据绑定无法回填到数据提供者中

            if (raiseCodeChangedByUser)
            {
                RaiseCodeChangedByUser();
            }
        }

        /// <summary>
        /// 节点是否可以被选取
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected virtual bool _CanSelectNode(TreeListNode node)
        {
            return node != null;
        }

        /// <summary>
        /// 提示音
        /// </summary>
        protected void _BeepNotify()
        {
            //Win32API.Beep(70, 100);
        }
        /// <summary>
        /// 警告音
        /// </summary>
        protected void _BeepError()
        {
            //Win32API.Beep(4000, 100);
        }
        #endregion

        #region 所有事件处理
        /// <summary>
        /// 处理双击树节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTree_DoubleClick(object sender, System.EventArgs e)
        {
            _pwTimer.Enabled = false;
            _TrySelectNode(_pwListTree.FocusedNode);
        }

        /// <summary>
        /// 处理下拉选择树的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void listTree_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!this.IsPopupOpen || _pwListTree.FocusedNode == null)
                        return;
                    _TrySelectNode(_pwListTree.FocusedNode);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    this._pwListTree.FocusedNode.Expanded = true;
                    e.Handled = true;
                    break;
                case Keys.Left:
                    _TryCollapseNode(this._pwListTree.FocusedNode);
                    e.Handled = true;
                    break;
            }
        }

        /// <summary>
        /// 展开下级树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pwListTree_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            _TryShowNextLevel(e.Node);
            return;
        }

        /// <summary>
        /// 点击按钮后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrgComboBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!this.ReadOnly)
            {
                ShowPopup();
            }
        }

        /// <summary>
        /// 改变弹出窗口大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popupContainer_Resize(object sender, System.EventArgs e)
        {
            if (this.Width > 250) this._pwContainer.Width = this.Width - 4;
        }

        /// <summary>
        /// 在录入窗中按键时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrgComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    this._selectedCode = null;
                    this.Text = "";
                    e.Handled = true;
                    break;

                case Keys.Back:
                    this._selectedCode = null;
                    e.Handled = true;
                    this.Text = "";
                    break;

                case Keys.Escape:
                    e.Handled = true;
                    ClosePopup();
                    break;

                case Keys.Enter:
                    if (this._pwContainer.Visible)
                    {
                        _TrySelectNode(this._pwListTree.FocusedNode);
                        e.Handled = true;
                    }
                    else
                    {
                        if (!this.ReadOnly) ShowPopup();
                        _pwListTree.Focus();
                        e.Handled = true;
                    }
                    e.Handled = true;
                    break;

                case Keys.Up:
                case Keys.Down:
                    if (!this.ReadOnly) ShowPopup();
                    _pwListTree.Focus();
                    e.Handled = true;
                    break;

                case Keys.Left:
                case Keys.Right:
                    break;
                default:
                    ShowPopup();
                    break;
            }
        }

        /// <summary>
        /// 抬起按键时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OrgComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                case Keys.Enter:
                case Keys.Down:
                case Keys.Back:
                case Keys.Left:
                case Keys.Right:
                case Keys.Delete:
                    break;
                default:
                    //this.InputCache = this.Text;
                    // _TryFindCodeItem();
                    break;
            }
        }

        /// <summary>
        /// 焦点离开　
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrgComboBox_Leave(object sender, System.EventArgs e)
        {
            ClosePopup();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OrgComboBox_Closed(object sender, ClosedEventArgs e)
        {
            this.Text = (this._selectedCode == null) ? "" : this._selectedCode.Name;
        }

        /// <summary>
        /// 延时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_pwTimer.Enabled)		//	多加一个判断，杜绝多个WM_TIMER消息导致多次进入
                return;
            _pwTimer.Enabled = false;
            if (!this.IsPopupOpen)
                return;
            _TrySelectNode(_pwListTree.FocusedNode);
        }

        #endregion

        #region 自定义事件处理
        /// <summary>
        /// 当前选择改变
        /// </summary>
        [Category("WinFormEx")]
        public event EventHandler CodeChanged;
        public void RaiseCodeChanged()
        {
            EventArgs e = new EventArgs();
            if (CodeChanged != null)
                CodeChanged(this, e);
        }
        /// <summary>
        /// 用户改变当前选择
        /// </summary>
        [Category("WinFormEx")]
        public event EventHandler CodeChangedByUser;
        public void RaiseCodeChangedByUser()
        {
            EventArgs e = new EventArgs();
            if (CodeChangedByUser != null)
                CodeChangedByUser(this, e);
        }

        /// <summary>
        /// 提交选择改变
        /// </summary>
        [Category("WinFormEx")]
        public event EventHandler SelectionChangeCommitted;
        public void RaiseSelectionChangeCommitted()
        {
            EventArgs e = new EventArgs();
            if (SelectionChangeCommitted != null)
                SelectionChangeCommitted(this, e);
        }

        #endregion




    }
}
