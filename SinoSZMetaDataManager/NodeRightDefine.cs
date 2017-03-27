using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZPluginFramework;
using SinoSZJS.Base.Authorize;

using DevExpress.XtraTreeList.Nodes;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZJS.Base.Misc;
using System.Linq;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataManager
{
    public partial class NodeRightDefine : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;
        private IApplication _application = null;
        private MD_Nodes _nodesData;
        public event EventHandler<EventArgs> DataChanged;
        public event EventHandler<EventArgs> MenuChanged;
        private List<MD_RightDefine> RightData = null;
        public string ErrorMsg = "";
        public MD_Nodes NodesData
        {
            get
            {
                return _nodesData;
            }

            set
            {
                _nodesData = value;
                if (_nodesData != null)
                {
                    RefreshData();
                }
            }

        }

        /// <summary>
        /// 是否有数据变更
        /// </summary>
        public bool HaveDataChanged()
        {
            return _haveChange && _initFinished;
        }

        public void RaiseDataChanged()
        {
            if (HaveDataChanged() && DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }

        private void RaiseMenuChanged()
        {
            if (MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        public NodeRightDefine()
        {
            InitializeComponent();
        }

        public NodeRightDefine(IApplication _app)
        {
            InitializeComponent();
            _application = _app;
        }

        private void RefreshData()
        {
            this.pWait.Visible = true;
            this.timer1.Enabled = true;
            this.pBarLoad.Position = 0;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pBarLoad.Increment(5);
            if (this.pBarLoad.Position > 95) this.pBarLoad.Position = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            GetAllRightsData(_nodesData.DWDM);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowRightData();
            this.pWait.Visible = false;
            this.timer1.Enabled = false;
        }

        /// <summary>
        /// 显示授权树
        /// </summary>
        private void ShowRightData()
        {
            this.treeList1.BeginUpdate();
            this.treeList1.Nodes.Clear();
            MC_FindRightByStr _finder = new MC_FindRightByStr("");
            List<MD_RightDefine> _topRightItems = RightData.FindAll(new Predicate<MD_RightDefine>(_finder.FindByFatherID));
            _topRightItems.Sort(new MC_RightComparer());
            foreach (MD_RightDefine _rd in _topRightItems)
            {
                TreeListNode _dwnode = this.treeList1.AppendNode(null, null);
                _dwnode.SetValue(this.treeListColumn1, _rd.RightName);
                _dwnode.ImageIndex = 1;
                _dwnode.SelectImageIndex = 2;
                _dwnode.Tag = _rd;
                ShowChildren(_dwnode, _rd);
            }
            this.treeList1.ExpandAll();
            this.treeList1.EndUpdate();
        }

        private void ShowChildren(TreeListNode _fnode, MD_RightDefine _fRight)
        {
            MC_FindRightByStr _finder = new MC_FindRightByStr(_fRight.RightID);
            List<MD_RightDefine> _childRightItems = RightData.FindAll(new Predicate<MD_RightDefine>(_finder.FindByFatherID));
            _childRightItems.Sort(new MC_RightComparer());
            foreach (MD_RightDefine _rd in _childRightItems)
            {
                TreeListNode _dwnode = this.treeList1.AppendNode(null, _fnode);
                _dwnode.SetValue(this.treeListColumn1, _rd.RightName);
                _dwnode.ImageIndex = 0;
                _dwnode.SelectImageIndex = 2;
                _dwnode.Tag = _rd;
                ShowChildren(_dwnode, _rd);
            }
        }

        /// <summary>
        /// 取权限数据
        /// </summary>
        private void GetAllRightsData(string _systemid)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                RightData = _mdc.GetRightData(_systemid).ToList<MD_RightDefine>();
            }
        }


        #region IControlMenu Members
        public List<FrmMenuGroup> GetControlMenu()
        {
            FrmMenuGroup _thisGroup = new FrmMenuGroup("授权管理");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("刷新权限树", "刷新权限树", global::SinoSZMetaDataManager.Properties.Resources.g19, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("导出权限表", "导出权限表", global::SinoSZMetaDataManager.Properties.Resources.g20, true);
            _thisGroup.MenuItems.Add(_item);

            List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            _ret.Add(_thisGroup);
            return _ret;
        }

        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "刷新权限树":
                    this.pWait.Visible = true;
                    this.timer1.Enabled = true;
                    this.label1.Text = " 正在处理数据 ....";
                    this.pBarLoad.Position = 0;
                    this.backgroundWorker2.RunWorkerAsync();
                    break;
            }
            return true;
        }



        public bool CloseControl()
        {
            return true;
        }
        #endregion

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateNewRightTree();
        }

        /// <summary>
        /// 创建新的权限树
        /// </summary>
        private void CreateNewRightTree()
        {
            IList<MD_Menu> _menuList;
            List<MD_RightDefine> _ret = new List<MD_RightDefine>();
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                #region 通过菜单定义建立权限项
                try
                {
                    this.backgroundWorker2.ReportProgress(10, "正在取菜单定义数据...");
                    _menuList = _mdc.GetMenuDefineOfNode(this.NodesData.DWDM);
                    this.backgroundWorker2.ReportProgress(10, "取菜单定义成功！");
                }
                catch (Exception ex)
                {
                    this.backgroundWorker2.ReportProgress(10, string.Format("取菜单定义数据失败！！！{0}", ex.Message));
                    return;
                }

                try
                {
                    foreach (MD_Menu _menu in _menuList)
                    {
                        MD_RightDefine _item = new MD_RightDefine();
                        decimal _rightid = decimal.Parse(_menu.MenuID) * 1000;
                        _item.RightID = _rightid.ToString();
                        _item.MenuID = _menu.MenuID;
                        _item.FatherRightID = "";
                        _item.DisplayOrder = _menu.DisplayOrder;
                        _item.RightDescript = _menu.MenuToolTip;
                        _item.RightName = _menu.MenuName;
                        _item.RightType = "动态菜单";
                        _item.RightMeta = "";
                        _ret.Add(_item);


                        if (_menu.MenuType != null || _menu.MenuType != "")
                        {
                            //添加此类型菜单中的功能权限
                            AddPluginRight(_menu.MenuType, _item, _ret);
                        }

                        AddChildMenuRight(_menu, _item.RightID, _ret, _mdc);
                    }
                }
                catch (Exception ex)
                {
                    this.backgroundWorker2.ReportProgress(10, string.Format("处理权限定义数据失败！！！{0}", ex.Message));
                    return;
                }
                #endregion


                this.backgroundWorker2.ReportProgress(10, "处理权限数据完成！正在写入...");
                try
                {
                    if (_mdc.SaveRightDefine(_ret.ToArray())) this.RightData = _ret;
                    this.backgroundWorker2.ReportProgress(10, "写入权限数据完成...");
                }
                catch (Exception ex)
                {
                    this.backgroundWorker2.ReportProgress(10, string.Format("写入权限定义数据失败！！！{0}", ex.Message));
                }
            }
        }

        private void AddChildMenuRight(MD_Menu _fmenu, string _fRightID, List<MD_RightDefine> _ret, MetaDataServiceClient _mdc)
        {
            IList<MD_Menu> _menuList = _mdc.GetSubMenuDefine(_fmenu.MenuID);
            foreach (MD_Menu _menu in _menuList)
            {
                MD_RightDefine _item = new MD_RightDefine();
                decimal _rightid = decimal.Parse(_menu.MenuID) * 1000;
                _item.RightID = _rightid.ToString();
                _item.MenuID = _menu.MenuID;
                _item.FatherRightID = _fRightID;
                _item.DisplayOrder = _menu.DisplayOrder;
                _item.RightDescript = _menu.MenuToolTip;
                _item.RightName = _menu.MenuName;
                _item.RightType = "动态菜单";
                _item.RightMeta = "";
                _ret.Add(_item);

                if (_menu.MenuType != null || _menu.MenuType != "")
                {
                    if (_menu.MenuType == "WEB.MENU")
                    {
                        AddWebMenuRight(_menu, _item, _ret);
                    }
                    else
                    {
                        AddPluginRight(_menu.MenuType, _item, _ret);
                    }
                }

                AddChildMenuRight(_menu, _item.RightID, _ret, _mdc);
            }

        }

        private void AddWebMenuRight(MD_Menu _menu, MD_RightDefine _fitem, List<MD_RightDefine> _ret)
        {

            string _rparam = StrUtils.GetMetaByName2("权限定义", _menu.MenuParameter);
            if (_rparam == "") return;
            string[] _rightList = _rparam.Split(',');
            foreach (string _rightString in _rightList)
            {
                string[] _rItems = _rightString.Split(':');
                if (_rItems.Length > 2)
                {
                    MD_RightDefine _item = new MD_RightDefine();
                    decimal _rightid = decimal.Parse(_fitem.RightID) + decimal.Parse(_rItems[0]);
                    _item.RightID = _rightid.ToString();
                    _item.MenuID = _fitem.MenuID;
                    decimal _frightid = 0;
                    try
                    {
                        _frightid = decimal.Parse(_rItems[2]);
                    }
                    catch (Exception ex)
                    {
                        _frightid = 0;
                        this.ErrorMsg = ex.Message;
                    }

                    decimal _fid = decimal.Parse(_fitem.RightID) + _frightid;
                    _item.FatherRightID = _fid.ToString();
                    _item.DisplayOrder = int.Parse(_rItems[0]);
                    _item.RightDescript = _rItems[1];
                    _item.RightName = _rItems[1];
                    _item.RightType = "动态菜单";
                    _item.RightMeta = "";
                    _ret.Add(_item);
                }
            }
        }

        private void AddPluginRight(string _menuType, MD_RightDefine _fitem, List<MD_RightDefine> _ret)
        {

            string[] _mString = _menuType.Split('.');
            //添加此类型菜单中的功能权限
            IPluginService _ps = (IPluginService)_application.GetService(typeof(IPluginService));

            IPlugin _plugin = _ps.GetPluginInstance(_mString[0]);
            if (_plugin != null)
            {
                List<MenuType> _mts = _plugin.GetMenuDefines();
                if (_mts != null)
                {
                    foreach (MenuType _mt in _mts)
                    {
                        if (_mt.TypeCommandName == _menuType)
                        {
                            foreach (MenuRightItem _crDefine in _mt.ChildRightItem)
                            {
                                MD_RightDefine _item = new MD_RightDefine();
                                decimal _rightid = decimal.Parse(_fitem.RightID) + _crDefine.Index;
                                _item.RightID = _rightid.ToString();
                                _item.MenuID = _fitem.MenuID;
                                _item.FatherRightID = _fitem.RightID;
                                _item.DisplayOrder = _crDefine.Index;
                                _item.RightDescript = _crDefine.Title;
                                _item.RightName = _crDefine.Title;
                                _item.RightType = "动态菜单";
                                _item.RightMeta = "";
                                _ret.Add(_item);
                            }
                        }
                    }
                }
            }
        }


        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowRightData();
            this.pWait.Visible = false;
            this.timer1.Enabled = false;
            this.label1.Text = "刷新权限树完成！";


        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label1.Text = e.UserState.ToString();
        }



    }
}
