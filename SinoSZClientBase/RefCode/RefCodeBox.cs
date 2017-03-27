using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using SinoSZJS.Base.RefCode;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraGrid;
using SinoSZClientBase.CommonService;

namespace SinoSZClientBase.RefCode
{
        public class RefCodeBox : PopupContainerEdit
        {

                #region Members

                private bool _firstVisible = true;			//	是否是第一次设置Visible属性(用于模拟窗口的Load事件)
                private string _refCodeName = "";                       //      代码表名
                private RefCodeData _selectedCode = null;
                private RefCodeTable _rct;                              //      代码表
                private bool _canMultiSelect = false;                   //      是否可多选
                private Dictionary<string, RefCodeData> _selectCollection = new Dictionary<string, RefCodeData>();  //      多选的集合
                private List<TreeListNode> _matchCollection = new List<TreeListNode>();
                //列表窗口相关变量 (全部用pw前缀)  -------------------------------------------------
                protected PopupContainerControl _pwContainer;
                protected TreeList _pwListTree;
                protected TreeListColumn _pwListTreeColumn;
                private Timer _pwTimer;

                private string _inputCache = "";

                #endregion

                public RefCodeBox()
                {
                        InitializeComponent();
                }

                #region Properties

                private string InputCache
                {
                        get { return _inputCache; }
                        set
                        {
                                _inputCache = value;

                                if (_inputCache == "" && _rct != null)
                                {
                                        if (_rct.Properties.LevelDownloadMode == 1) ShowAllTreeItem();
                                }
                        }
                }

                private string SelectedAllCode = "";


                /// <summary>
                /// 分级格式            //最版本中的用法,现已经无意义
                /// </summary>
                [Category("WinFormEx")]
                public string LevelFormat
                {
                        get
                        {
                                if (_rct == null) return "";
                                return _rct.Properties.LevelFormat;
                        }
                }



                /// <summary>
                /// 是否可多选
                /// </summary>
                [Category("WinFormEx")]
                public bool CanMultiSelect
                {
                        get { return this._canMultiSelect; }
                        set
                        {
                                this._canMultiSelect = value;
                                if (_canMultiSelect)
                                {
                                        if (_selectCollection.Count == 0 && this._selectedCode != null)
                                        {
                                                _selectCollection.Clear();

                                                _selectCollection.Add(this._selectedCode.Code, this._selectedCode);
                                        }

                                }
                                else
                                {
                                        if (this._selectedCode == null && _selectCollection.Count > 0)
                                        {
                                                foreach (RefCodeData _dt in _selectCollection.Values)
                                                {
                                                        this._selectedCode = _dt;
                                                        break;
                                                }
                                        }


                                }
                                this.Text = this.DisplayText;

                        }
                }

                public string DisplayText
                {
                        get
                        {
                                StringBuilder _ret = new StringBuilder();
                                StringBuilder _tooltip = new StringBuilder();
                                if (this._canMultiSelect)
                                {
                                        if (this._selectCollection.Count > 0)
                                        {
                                                int _scount = this._selectCollection.Count;
                                                foreach (RefCodeData _rfd in this._selectCollection.Values)
                                                {
                                                        if (this._rct.Properties.HideCode)
                                                        {
                                                                _ret.Append(string.Format("{0},", _rfd.DisplayTitle));
                                                                _tooltip.Append(string.Format("[{0}]{1},", _rfd.Code, _rfd.DisplayTitle));
                                                        }
                                                        else
                                                        {

                                                                if (_scount > 5)
                                                                {
                                                                        _ret.Append(string.Format("[{0}],", _rfd.Code));
                                                                        _tooltip.Append(string.Format("[{0}]{1},", _rfd.Code, _rfd.DisplayTitle));
                                                                }
                                                                else
                                                                {
                                                                        _ret.Append(string.Format("[{0}]{1},", _rfd.Code, _rfd.DisplayTitle));
                                                                        _tooltip.Append(string.Format("[{0}]{1},", _rfd.Code, _rfd.DisplayTitle));
                                                                }
                                                        }

                                                }
                                        }
                                }
                                else
                                {
                                        if (this._selectedCode != null)
                                        {
                                                if (this._rct.Properties.HideCode)
                                                {
                                                        _ret.Append(string.Format("{0}", _selectedCode.DisplayTitle));
                                                }
                                                else
                                                {
                                                        _ret.Append(string.Format("[{0}] {1}", _selectedCode.Code, _selectedCode.DisplayTitle));
                                                }
                                        }
                                }
                                this.ToolTip = _tooltip.ToString();
                                this.InputCache = "";
                                return _ret.ToString();
                        }
                }
                /// <summary>
                /// 当前所选/录入的代码
                /// </summary>
                [Category("WinFormEx"), Bindable(true)]
                public string Code
                {
                        get
                        {
                                if (_selectedCode == null) return "";
                                else
                                        return _selectedCode.Code;
                        }


                        set
                        {
                                if (value != null && value != "")
                                {
                                        RefCodeData _CValue = FindByCode(value);
                                        if (_CValue != null) _ChangeText(_CValue, false, false);
                                }
                                //string theCode = value;
                                //string theValue = value;
                                //if (theCode == null || theCode == string.Empty)
                                //{
                                //        theCode = string.Empty;
                                //        theValue = string.Empty;
                                //}
                                ////对于数据绑定的部分暂不处理
                                ////else if (!RefCodeTable.Code2Value(theCode, out theValue))
                                ////	theValue	=  theCode;	//	如果编码错误且设置了ShowErrCode，则Text里面放这个错误的编码，便于用户看到
                                //_ChangeText(theCode, theValue, false, false);
                        }
                }



                /// <summary>
                /// 是否可以编辑. 不可编辑则像DropDownList风格的ComboBox, 只可选择不能输入
                /// </summary>
                [Category("WinFormEx")]
                public bool CanEdit
                {
                        get { return Properties.TextEditStyle == TextEditStyles.Standard; }
                        set { Properties.TextEditStyle = value ? TextEditStyles.Standard : TextEditStyles.DisableTextEditor; }
                }

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
                /// 代码表
                /// </summary>
                [Category("WinFormEx")]
                public string RefTableName
                {
                        get { return _refCodeName; }
                        set
                        {


                                _refCodeName = value;
                                //加载代码表
                                if (!IsDesignMode && _refCodeName != "")
                                {
                                        _rct = RefCodeManager.GetRefTable(_refCodeName);
                                        InitPopupControl();

                                }
                        }
                }

                #endregion

                #region InitializeComponent
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

                        this.ButtonClick += new ButtonPressedEventHandler(RefCodeBox_ButtonClick);
                        this.Resize += new System.EventHandler(this.popupContainer_Resize);
                        this.KeyDown += new KeyEventHandler(RefCodeBox_KeyDown);
                        this.Leave += new System.EventHandler(this.RefCodeBox_Leave);
                        this.KeyUp += new KeyEventHandler(RefCodeBox_KeyUp);
                        this.Closed += new ClosedEventHandler(RefCodeBox_Closed);
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










                #endregion

                #region Events

                [Category("WinFormEx")]
                public event EventHandler FirstVisible;

                [Category("WinFormEx")]
                public event EventHandler SelectionChangeCommitted;

                [Category("WinFormEx")]
                public new event ButtonPressedEventHandler ButtonClick;

                [Category("WinFormEx")]
                public event EventHandler CodeChanged;

                [Category("WinFormEx")]
                public event EventHandler CodeChangedByUser;

                #endregion


                #region Virtual Methods

                protected virtual bool _IsDesignMode()
                {
                        return this.IsDesignMode;
                }

                //	节点是否可以被选取
                protected virtual bool _CanSelectNode(TreeListNode node)
                {
                        return node != null;
                }

                #endregion

                #region Private/Protected Methods

                private bool _TryFindCodeItem()
                {
                        if (_rct == null) return false;
                        if (_rct.Properties.LevelDownloadMode == 2)
                        {
                                this.Text = "";
                                this.InputCache = "";
                                return false;
                        }

                        string _findStr = this.InputCache;
                        int _strLength = _findStr.Length;
                        bool _isfind = false;
                        _matchCollection.Clear();
                        this._pwListTree.BeginUpdate();
                        if (_rct.Properties.LevelDownloadMode == 1)
                        {
                                foreach (TreeListNode _node in this._pwListTree.Nodes)
                                {
                                        RefCodeData _rd = _node.Tag as RefCodeData;

                                        string _s = (_rd.Code.Length < _strLength) ? "" : _rd.Code.Substring(0, _strLength);
                                        string _pyzt = (_rd.PYZT.Length < _strLength) ? "" : _rd.PYZT.Substring(0, _strLength).ToUpper();
                                        if (_s == _findStr || _pyzt == _findStr.ToUpper())
                                        {
                                                _matchCollection.Add(_node);
                                                _isfind = true;
                                                _node.Visible = true;
                                                if (_node.HasChildren) FindItemInChild(_node, _strLength, _findStr);
                                        }
                                        else
                                        {
                                                bool _childFind = false;
                                                if (_node.HasChildren)
                                                {
                                                        _childFind = FindItemInChild(_node, _strLength, _findStr);
                                                        if (_childFind) _isfind = true;
                                                }
                                                _node.Visible = _childFind;
                                        }
                                }
                        }
                        this._pwListTree.MoveLastVisible();
                        this._pwListTree.EndUpdate();
                        if (!_isfind)
                        {
                                this.Text = "";
                                this.InputCache = "";
                        }
                        else
                        {
                                if (_matchCollection.Count == 1)
                                {
                                        _TrySelectNode(_matchCollection[0]);
                                }

                        }
                        return true;
                }

                private RefCodeData FindByCode(string _value)
                {
                        foreach (TreeListNode _node in this._pwListTree.Nodes)
                        {
                                RefCodeData _rd = _node.Tag as RefCodeData;
                                if (_rd.Code == _value) return _rd;
                        }
                        using (CommonServiceClient _csc = new CommonServiceClient())
                        {
                            return _csc.GetRefCodeByCode(this._refCodeName, _value);
                        }
                }

                private bool FindItemInChild(TreeListNode _fnode, int _strLength, string _findStr)
                {
                        bool _ret = false;
                        foreach (TreeListNode _node in _fnode.Nodes)
                        {
                                RefCodeData _rd = _node.Tag as RefCodeData;
                                string _s = (_rd.Code.Length < _strLength) ? "" : _rd.Code.Substring(0, _strLength);
                                string _pyzt = (_rd.PYZT.Length < _strLength) ? "" : _rd.PYZT.Substring(0, _strLength).ToUpper();
                                if (_findStr == "011")
                                {
                                        int i = 0;
                                }
                                if (_s == _findStr || _pyzt.ToUpper() == _findStr.ToUpper())
                                {
                                        _matchCollection.Add(_node);
                                        _node.Visible = true;
                                        if (_node.HasChildren) FindItemInChild(_node, _strLength, _findStr);
                                        _ret = true;
                                }
                                else
                                {
                                        bool _childFind = false;
                                        if (_node.HasChildren)
                                        {
                                                _childFind = FindItemInChild(_node, _strLength, _findStr);
                                                if (_childFind) _ret = true;
                                        }
                                        _node.Visible = _childFind;
                                }
                        }
                        return _ret;
                }


                private void ShowAllTreeItem()
                {
                        if (_rct == null) return;
                        if (_rct.Properties.LevelDownloadMode == 2) return;

                        foreach (TreeListNode _node in this._pwListTree.Nodes)
                        {
                                _node.Visible = true;
                                if (_node.HasChildren == true)
                                {
                                        ShowAllChild(_node);
                                }
                        }
                }

                private void ShowAllChild(TreeListNode _fnode)
                {
                        foreach (TreeListNode _node in _fnode.Nodes)
                        {
                                _node.Visible = true;
                                if (_node.HasChildren == true)
                                {
                                        ShowAllChild(_node);
                                }
                        }
                }

                /// <summary>
                /// 多选时显示
                /// </summary>
                private void _ShowMultiText()
                {
                        RefCodeData _t;
                        if (!this._canMultiSelect) return;
                        string _showstr = "", _tooltipstr = "";
                        foreach (string key in _selectCollection.Keys)
                        {
                                _t = (RefCodeData)_selectCollection[key];
                                _showstr = _showstr + _t.Code + ",";
                                _tooltipstr = _tooltipstr + string.Format(" [{0}] {1} \n", _t.Code, _t.DisplayTitle);
                                this.ToolTip = _tooltipstr;
                        }
                        this.Text = _showstr;
                        this.Select(this.Text.Length, 0);
                }

                /// <summary>
                /// 显示匹配项
                /// </summary>
                private void _ShowMatchItems()
                {
                        ShowPopup();
                }

                /// <summary>
                /// 初始化弹出窗
                /// </summary>
                private void InitPopupControl()
                {
                        TreeListNode _tn;

                        if (_rct == null)
                                return;
                        this._pwListTree.BeginUnboundLoad();
                        if (_rct.Properties.LevelDownloadMode == 2)
                        {
                                //	分级下载
                                _pwListTree.Nodes.Clear();
                                if (this.SelectedAllCode != "")
                                {
                                        RefCodeData _allrefCodeData = new RefCodeData(this.SelectedAllCode, "全部", "", 0, true, "全部", "", true, true, true);
                                        _tn = _pwListTree.AppendNode(_allrefCodeData.Code, null);
                                        _tn.SetValue(_pwListTreeColumn, (this._rct.Properties.HideCode) ? _allrefCodeData.DisplayTitle : RefCodeManager.GetFullDisplay(_allrefCodeData));
                                        _tn.Tag = _allrefCodeData;
                                        _tn.Expanded = true;
                                        _tn.HasChildren = false;
                                }
                                IList<RefCodeData> _crows = RefCodeManager.GetLevelDownChildRecords(_rct, string.Empty);

                                if (_crows == null) return;
                                foreach (RefCodeData _codeItem in _crows)
                                {
                                        _tn = _pwListTree.AppendNode(_codeItem.Code, null);
                                        _tn.SetValue(_pwListTreeColumn, (this._rct.Properties.HideCode) ? _codeItem.DisplayTitle : RefCodeManager.GetFullDisplay(_codeItem));
                                        _tn.Tag = _codeItem;
                                        _tn.Expanded = false;
                                        if (_codeItem.IsLeaves)
                                        {
                                                _tn.HasChildren = false;
                                        }
                                        else
                                        {
                                                _tn.HasChildren = true;
                                        }

                                }
                                //_pwListTree.CollapseAll();
                                //if (_pwListTree.Nodes.Count > 0) _pwListTree.Nodes[0].Selected = true;
                        }
                        else
                        {
                                //	全部下载
                                RefCodeManager.GetAllRecords(_rct);
                                _pwListTree.Nodes.Clear();
                                if (this.SelectedAllCode != "")
                                {
                                        RefCodeData _allrefCodeData = new RefCodeData(this.SelectedAllCode, "全部", "", 0, true, "全部", "", true, true, true);
                                        _tn = _pwListTree.AppendNode(_allrefCodeData.Code, null);
                                        _tn.SetValue(_pwListTreeColumn, (this._rct.Properties.HideCode) ? _allrefCodeData.DisplayTitle : RefCodeManager.GetFullDisplay(_allrefCodeData));
                                        _tn.Tag = _allrefCodeData;
                                        _tn.Expanded = true;
                                        _tn.HasChildren = false;
                                }

                                //	分级代码                                        
                                IList<RefCodeData> _crows = RefCodeManager.GetChildLevelRecords(_rct, string.Empty);
                                if (_crows == null) return;
                                foreach (RefCodeData _codeItem in _crows)
                                {
                                        _tn = _pwListTree.AppendNode(_codeItem.Code, null);
                                        _tn.SetValue(_pwListTreeColumn, (this._rct.Properties.HideCode) ? _codeItem.DisplayTitle : RefCodeManager.GetFullDisplay(_codeItem));
                                        _tn.Tag = _codeItem;
                                        _addChildItem(_codeItem.Code, _tn);

                                }
                                _pwListTree.ExpandAll();
                                if (_pwListTree.Nodes.Count > 0) _pwListTree.FindNodeByID(0);

                        }
                        this._pwListTree.EndUnboundLoad();
                }


                private void _TryShowNextLevel(TreeListNode _node)
                {
                        TreeListNode _tn;
                        RefCodeData _rci = (RefCodeData)_node.Tag;
                        if (_rci.IsLeaves || !_node.HasChildren) return;
                        if (_node.HasChildren && _node.Nodes.Count == 0)
                        {
                                IList<RefCodeData> _crows = RefCodeManager.GetLevelDownChildRecords(_rct, _rci.Code);
                                if (_crows == null) return;
                                _node.Nodes.Clear();
                                foreach (RefCodeData _codeItem in _crows)
                                {
                                        _tn = _pwListTree.AppendNode(_codeItem.Code, _node);
                                        _tn.SetValue(_pwListTreeColumn, (this._rct.Properties.HideCode) ? _codeItem.DisplayTitle : RefCodeManager.GetFullDisplay(_codeItem));
                                        _tn.Tag = _codeItem;
                                        if (_codeItem.IsLeaves)
                                        {
                                                _tn.HasChildren = false;
                                        }
                                        else
                                        {
                                                _tn.HasChildren = true;
                                        }
                                }
                        }
                }

                private void _addChildItem(string code, TreeListNode _fatherNode)
                {
                        TreeListNode _tn;
                        IList<RefCodeData> _crows = RefCodeManager.GetChildLevelRecords(_rct, code);
                        if (_crows == null) return;

                        foreach (RefCodeData _codeItem in _crows)
                        {
                                _tn = _pwListTree.AppendNode(_codeItem.Code, _fatherNode);
                                _tn.SetValue(_pwListTreeColumn, (this._rct.Properties.HideCode) ? _codeItem.DisplayTitle : RefCodeManager.GetFullDisplay(_codeItem));
                                _tn.Tag = _codeItem;
                                _addChildItem(_codeItem.Code, _tn);

                        }
                }

                /// <summary>
                /// 修改代码
                /// </summary>
                /// <param name="code"></param>
                /// <param name="text"></param>
                /// <param name="raiseCodeChanged"></param>
                /// <param name="raiseCodeChangedByUser"></param>
                protected void _ChangeText(RefCodeData codeData, bool raiseCodeChanged, bool raiseCodeChangedByUser)
                {
                        this._selectedCode = codeData;
                        if (this._canMultiSelect)
                        {
                                if (this._selectCollection.ContainsKey(codeData.Code))
                                {
                                }
                                else
                                {
                                        this._selectCollection.Add(codeData.Code, codeData);
                                }
                        }

                        this.Text = this.DisplayText;

                        if (raiseCodeChanged)
                                RaiseCodeChanged();			//	必须，否则数据绑定无法回填到数据提供者中
                        if (raiseCodeChangedByUser)
                        {
                                //Debug.Assert(raiseCodeChanged);
                                RaiseCodeChangedByUser();
                        }
                }


                #region 控制当前选择行移动


                #endregion

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
                        RefCodeData _CValue = (RefCodeData)_pwListTree.FocusedNode.Tag;
                        _ChangeText(_CValue, true, true);
                        RaiseSelectionChangeCommitted();
                        ClosePopup();
                        return true;
                }

                /// <summary>
                /// 收起此点
                /// </summary>
                /// <param name="treeListNode"></param>
                private void _TryCollapseNode(TreeListNode node)
                {
                        node.Expanded = false;
                }





                protected void _BeepNotify()
                {
                        //Win32API.Beep(70, 100);
                }

                protected void _BeepError()
                {
                        //Win32API.Beep(4000, 100);
                }

                #endregion


                #region Public Methods

                /// <summary>
                /// 清除所有值
                /// </summary>
                public void ClearValue()
                {
                        this._selectedCode = null;
                        this._selectCollection.Clear();
                        this.Text = this.DisplayText;
                }

                /// <summary>
                /// 取所有值
                /// </summary>
                /// <returns></returns>
                public List<string> GetValues()
                {
                        List<string> _ret = new List<string>();
                        if (this._canMultiSelect)
                        {
                                foreach (RefCodeData _rfd in this._selectCollection.Values)
                                {
                                        _ret.Add(_rfd.Code);
                                }
                        }
                        else
                        {
                                _ret.Add(this.Code);
                        }
                        return _ret;
                }


                public void RaiseCodeChanged()
                {
                        EventArgs e = new EventArgs();
                        if (CodeChanged != null)
                                CodeChanged(this, e);
                }

                public void RaiseCodeChangedByUser()
                {
                        EventArgs e = new EventArgs();
                        if (CodeChangedByUser != null)
                                CodeChangedByUser(this, e);
                }

                public void RaiseFirstVisible()
                {
                        EventArgs e = new EventArgs();
                        if (FirstVisible != null)
                                FirstVisible(this, e);
                }

                public void RaiseSelectionChangeCommitted()
                {
                        EventArgs e = new EventArgs();
                        if (SelectionChangeCommitted != null)
                                SelectionChangeCommitted(this, e);
                }

                public new void ShowPopup()
                {

                        base.ShowPopup();
                        if (this.CanEdit)
                                this.Focus();

                }


                #endregion

                #region Event Hander

                #region 处理下拉选择树的事件
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



                private void listTree_DoubleClick(object sender, System.EventArgs e)
                {
                        _pwTimer.Enabled = false;
                        _TrySelectNode(_pwListTree.FocusedNode);
                }



                void _pwListTree_BeforeExpand(object sender, BeforeExpandEventArgs e)
                {
                        if (_rct.Properties.LevelDownloadMode == 2)
                        {
                                _TryShowNextLevel(e.Node);
                        }
                        return;
                }


                #endregion


                #region 处理弹出窗的事件
                private void popupContainer_Resize(object sender, System.EventArgs e)
                {
                        if (this.Width > 250) this._pwContainer.Width = this.Width - 4;
                }

                #endregion


                private void Timer_Tick(object sender, EventArgs e)
                {
                        if (!_pwTimer.Enabled)		//	多加一个判断，杜绝多个WM_TIMER消息导致多次进入
                                return;
                        _pwTimer.Enabled = false;
                        if (!this.IsPopupOpen)
                                return;
                        _TrySelectNode(_pwListTree.FocusedNode);
                }

                #region 处理本控件的事件

                private void RefCodeBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
                {
                        if (!this.ReadOnly)
                        {
                                if (ButtonClick != null)
                                        ButtonClick(sender, e);
                                ShowPopup();
                        }
                }

                private void RefCodeBox_KeyDown(object sender, KeyEventArgs e)
                {
                        switch (e.KeyCode)
                        {
                                case Keys.Delete:
                                        if (this.SelectionStart < this.Text.Length)
                                        {
                                                if (this.CanMultiSelect)
                                                {
                                                        if (this._selectCollection.Count > 0)
                                                        {
                                                                int _startIndex = this.SelectionStart;
                                                                string[] _strs = this.Text.Trim().Split(',');
                                                                int _countLen = 0;
                                                                for (int i = 0; i < _strs.Length; i++)
                                                                {
                                                                        _countLen += (_strs[i].Length + 1);
                                                                        if (_startIndex < _countLen)
                                                                        {
                                                                                string _delcode = "";
                                                                                if (this._rct.Properties.HideCode)
                                                                                {
                                                                                        string _codeText = _strs[i];
                                                                                        foreach (string _code in this._selectCollection.Keys)
                                                                                        {
                                                                                                RefCodeData _rc = this._selectCollection[_code];
                                                                                                if (_rc.DisplayTitle == _codeText)
                                                                                                {
                                                                                                        _delcode = _code;
                                                                                                        break;
                                                                                                }
                                                                                        }
                                                                                }
                                                                                else
                                                                                {
                                                                                        string[] _strtemp = _strs[i].Split(']');
                                                                                        _delcode = _strtemp[0].Split('[')[1];
                                                                                }
                                                                                if (_delcode != "")
                                                                                {
                                                                                        this._selectCollection.Remove(_delcode);
                                                                                }
                                                                                break;
                                                                        }
                                                                }
                                                        }
                                                }
                                                else
                                                {
                                                        this._selectedCode = null;
                                                }

                                                this.Text = DisplayText;
                                        }
                                        e.Handled = true;
                                        break;
                                case Keys.Back:
                                        if (this.CanMultiSelect)
                                        {
                                                if (this._selectCollection.Count > 0 && InputCache == "" && this.Text != "")
                                                {
                                                        int _startIndex = this.SelectionStart;
                                                        string[] _strs = this.Text.Trim().Split(',');
                                                        int _countLen = 0;
                                                        for (int i = 0; i < _strs.Length; i++)
                                                        {
                                                                _countLen += (_strs[i].Length + 1);
                                                                if (_startIndex < _countLen + 1)
                                                                {
                                                                        string _delcode = "";
                                                                        if (this._rct.Properties.HideCode)
                                                                        {
                                                                                string _codeText = _strs[i];
                                                                                foreach (string _code in this._selectCollection.Keys)
                                                                                {
                                                                                        RefCodeData _rc = this._selectCollection[_code];
                                                                                        if (_rc.DisplayTitle == _codeText)
                                                                                        {
                                                                                                _delcode = _code;
                                                                                                break;
                                                                                        }
                                                                                }
                                                                        }
                                                                        else
                                                                        {
                                                                                string[] _strtemp = _strs[i].Split(']');
                                                                                _delcode = _strtemp[0].Split('[')[1];
                                                                        }
                                                                        if (_delcode != "")
                                                                        {
                                                                                this._selectCollection.Remove(_delcode);
                                                                        }
                                                                        break;
                                                                }
                                                        }
                                                        e.Handled = true;
                                                        this.Text = DisplayText;
                                                }
                                                else
                                                {
                                                        InputCache = "";
                                                        this.Text = "";
                                                }

                                        }
                                        else
                                        {
                                                this._selectedCode = null;
                                                e.Handled = true;
                                                this.Text = DisplayText;
                                        }

                                        break;
                                case Keys.Escape:
                                        //this.Text = this.DisplayText;
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
                                        if (this.InputCache == "")
                                        {
                                                this.Text = "";
                                        }
                                        ShowPopup();
                                        break;
                        }
                }

                void RefCodeBox_KeyUp(object sender, KeyEventArgs e)
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
                                        this.InputCache = this.Text;
                                        _TryFindCodeItem();
                                        break;
                        }
                }

                private void RefCodeBox_Leave(object sender, System.EventArgs e)
                {
                        ClosePopup();
                }

                void RefCodeBox_Closed(object sender, ClosedEventArgs e)
                {
                        this.Text = this.DisplayText;
                }
                #endregion

                #endregion


                //增加一个全部的选项
                public void AddAllCode(string _allCode)
                {
                        SelectedAllCode = _allCode;
                }

                public void SetValues(List<string> list)
                {
                        foreach (string _value in list)
                        {
                                RefCodeData _CValue = FindByCode(_value);
                                if (_CValue != null)
                                {
                                        _ChangeText(_CValue, false, false);
                                }
                        }
                }
        }
}
