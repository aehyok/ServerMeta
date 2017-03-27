using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;


using SinoSZJS.Base.Misc;
using System.Collections;
using DevExpress.XtraNavBar;
using SinoSZClientBase;
using DevExpress.XtraTab;
using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class frmGuideLineGroupShow2 : DevExpress.XtraEditors.XtraForm, IChildForm
        {
                private IApplication _application = null;
                private bool _initFinished = false;
                private string Params = "";
                private MD_GuideLine GuideLineDefine = null;
                private List<MDQuery_GuideLineParameter> QueryParameter = null;

                public frmGuideLineGroupShow2()
                {
                        InitializeComponent();
                }


                public frmGuideLineGroupShow2(string _param)
                {
                        InitializeComponent();
                        string _title = StrUtils.GetMetaByName2("标题", _param);
                        this.Text = _title;
                        Params = _param;
                        InitForm();
                }

                private void InitForm()
                {
                        this.navBarControl1.BeginUpdate();
                        string _groups = StrUtils.GetMetaByName2("分组", Params);
                        ShowGroups(_groups);
                        ArrayList _gList = StrUtils.GetMetasByName2("指标", Params);
                        ShowLinks(_gList);
                        this.navBarControl1.EndUpdate();
                }

                private void ShowLinks(ArrayList _gList)
                {
                        foreach (string _gItem in _gList)
                        {
                                GuideLineLinkItem _glink = new GuideLineLinkItem(_gItem);
                                AddLink(_glink);
                        }
                }

                private void AddLink(GuideLineLinkItem _glink)
                {
                        NavBarItem _nb = new DevExpress.XtraNavBar.NavBarItem();
                        _nb.Caption = _glink.Title;
                        _nb.LargeImage = (SinoSZResources.Images.ContainsKey(_glink.IconName) ?
                                SinoSZResources.Images[_glink.IconName] : global::SinoSZMetaDataQuery.Properties.Resources.b23
                                );
                        _nb.Name = _glink.GuideLineID;
                        _nb.Tag = _glink;
                        NavBarGroup _group = this.navBarControl1.Groups[_glink.GroupName];
                        if (_group != null)
                        {
                                _group.ItemLinks.Add(_nb);
                        }

                }

                private void ShowGroups(string _groups)
                {
                        this.navBarControl1.Groups.Clear();
                        foreach (string _groupDefine in _groups.Split(','))
                        {
                                string[] _gstrs = _groupDefine.Split(':');
                                string _gname = _gstrs[0];
                                string _gTitle = (_gstrs.Length > 1) ? _gstrs[1] : _gname;
                                AddNavBarGroup(_gname, _gTitle);
                        }
                }

                private void AddNavBarGroup(string _gname, string _gTitle)
                {
                        NavBarGroup _newGroup = this.navBarControl1.Groups.Add();
                        _newGroup.Caption = _gTitle;
                        _newGroup.Name = _gname;
                        _newGroup.Expanded = true;
                        _newGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
                }




                #region 实现IChildFrom接口

                public IApplication Application
                {
                        get { return _application; }
                        set { _application = value; }
                }

                public event EventHandler<EventArgs> MenuChanged;
                virtual public void RaiseMenuChanged()
                {
                        if (this._initFinished && MenuChanged != null)
                        {
                                MenuChanged(this, new EventArgs());
                        }
                }

                /// <summary>
                /// 取辅助菜单页
                /// </summary>
                /// <returns></returns>
                public IList<FrmMenuPage> GetMenuPages()
                {
                        IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
                        FrmMenuPage _page = new FrmMenuPage("指标查询");
                        _page.MenuGroups = GetMenuGroups(_page.PageTitle);
                        _ret.Add(_page);
                        return _ret;
                }

                /// <summary>
                /// 取菜单组
                /// </summary>
                /// <param name="_pagename"></param>
                /// <returns></returns>
                private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
                {
                        IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
                        FrmMenuGroup _thisGroup = new FrmMenuGroup("查询处理");

                        _thisGroup.MenuItems = new List<FrmMenuItem>();



                        FrmMenuItem _item = new FrmMenuItem("查询", "查询", global::SinoSZMetaDataQuery.Properties.Resources.b28, true);
                        _thisGroup.MenuItems.Add(_item);

                        _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataQuery.Properties.Resources.x1, true);
                        _thisGroup.MenuItems.Add(_item);


                        _ret.Add(_thisGroup);

                        _thisGroup = new FrmMenuGroup("指标查询结果处理");
                        _thisGroup.MenuItems = new List<FrmMenuItem>();


                        _item = new FrmMenuItem("图表展示", "图表展示", global::SinoSZMetaDataQuery.Properties.Resources.b18, true);
                        _thisGroup.MenuItems.Add(_item);


                        _item = new FrmMenuItem("导出", "导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, true);

                        _thisGroup.MenuItems.Add(_item);
                        _ret.Add(_thisGroup);
                        return _ret;
                }


                /// <summary>
                /// 执行菜单命令
                /// </summary>
                /// <param name="_cmdName"></param>
                /// <returns></returns>
                public bool DoCommand(string _cmdName)
                {
                        switch (_cmdName)
                        {
                                case "查询":
                                        ReQuery();
                                        break;
                                case "图表展示":
                                        ShowChart();
                                        break;
                                case "导出":
                                        XtraTabPage _tp = this.xtraTabControl1.SelectedTabPage;
                                        SinoSZUC_GuideLineQueryResult _glRes = _tp.Controls[0] as SinoSZUC_GuideLineQueryResult;
                                        SinoSZExport_GridViewData.Export(_glRes.CurrentView);
                                        break;
                        }
                        this.RaiseMenuChanged();
                        return true;
                }

                private void ShowChart()
                {
                        XtraTabPage _tp = this.xtraTabControl1.SelectedTabPage;
                        SinoSZUC_GuideLineQueryResult _glRes = _tp.Controls[0] as SinoSZUC_GuideLineQueryResult;
                        _glRes.ShowAsChart(_application);
                }

                private void ReQuery()
                {
                        if (this.sinoSZUC_GuideLineDynamicInput21.InputFinised)
                        {
                                this.xtraTabControl1.SelectedTabPageIndex = 0;
                                QueryParameter = this.sinoSZUC_GuideLineDynamicInput21.GetParamters();
                                foreach (XtraTabPage _tp in this.xtraTabControl1.TabPages)
                                {
                                        MD_GuideLine _glDefine = _tp.Tag as MD_GuideLine;
                                        SinoSZUC_GuideLineQueryResult _rest = _tp.Controls[0] as SinoSZUC_GuideLineQueryResult;
                                        _rest.ShowGuideLineResult(_glDefine, QueryParameter);
                                }
                        }
                }


                #endregion

                private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
                {
                        if (this.sinoSZUC_GuideLineQueryResult1.IsQuerying) return;
                        GuideLineLinkItem _gLine = e.Link.Item.Tag as GuideLineLinkItem;
                        ShowTabPages(_gLine);
                        if (this.sinoSZUC_GuideLineDynamicInput21.InputFinised)
                        {
                                ReQuery();
                        }
                        //this.Cursor = Cursors.WaitCursor;
                }

                private void ShowTabPages(GuideLineLinkItem _gLine)
                {
                        string[] _guideLineIDs = _gLine.GuideLineID.Split(',');
                        string[] _guideLineTitles = _gLine.ExtendParams.Split(',');
                        this.xtraTabControl1.TabPages.Clear();
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            for (int i = 0; i < _guideLineIDs.Length; i++)
                            {
                                string _title = (_guideLineTitles.Length > i) ? _guideLineTitles[i] : _gLine.Title;
                                XtraTabPage _tp = this.xtraTabControl1.TabPages.Add();
                                _tp.Text = _title;
                                string _glid = _guideLineIDs[i];
                                MD_GuideLine _glDefine = _msc.GetGuideLineByID(_glid);
                                _tp.Tag = _glDefine;
                                SinoSZUC_GuideLineQueryResult _qr = new SinoSZUC_GuideLineQueryResult();
                                _qr.Dock = DockStyle.Fill;
                                _tp.Controls.Add(_qr);
                                if (i == 0)
                                {
                                    this.sinoSZUC_GuideLineDynamicInput21.InitForm(_glDefine);
                                    this.sinoSZUC_GuideLineDynamicInput21.WriteParamValue(_gLine.Params);

                                }
                                _qr.QueryFinished += new EventHandler(_qr_QueryFinished);
                                _qr.ShowDetailData += new EventHandler(_qr_ShowDetailData);
                            }
                            if (this.xtraTabControl1.TabPages.Count > 0) this.xtraTabControl1.SelectedTabPageIndex = 0;
                        }

                }

                private void _qr_ShowDetailData(object sender, EventArgs e)
                {
                        ShowDetailDataArgs _showArgs = e as ShowDetailDataArgs;
                        GuideLineDetailControler.ShowDetail(_showArgs, _application);
                }

                private void _qr_QueryFinished(object sender, EventArgs e)
                {
                        this.Cursor = Cursors.Default;
                        RaiseMenuChanged();
                }


        }
}