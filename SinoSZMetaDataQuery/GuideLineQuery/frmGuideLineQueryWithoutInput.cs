using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class frmGuideLineQueryWithoutInput : DevExpress.XtraEditors.XtraForm, IChildForm
        {
                private IApplication _application = null;
                private bool _initFinished = false;
                private MD_GuideLine GuideLineDefine = null;
                private List<MDQuery_GuideLineParameter> QueryParameter = null;
                public frmGuideLineQueryWithoutInput()
                {
                        InitializeComponent();
                }

                public frmGuideLineQueryWithoutInput(MD_GuideLine _guideLine, List<MDQuery_GuideLineParameter> _queryParams)
                {
                        InitializeComponent();
                        GuideLineDefine = _guideLine;
                        QueryParameter = _queryParams;
                        this.Text = GuideLineDefine.GuideLineName;
                        _initFinished = true;
                }

                public frmGuideLineQueryWithoutInput(string _title, string _guideLineID, string _params, bool _canGroup)
                {
                        InitializeComponent();
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            GuideLineDefine = _msc.GetGuideLineByID(_guideLineID);
                        }
                        QueryParameter = MC_GuideLine.CreateQueryParameter(GuideLineDefine, _params);
                        this.sinoSZUC_GuideLineQueryResult1.CanGrouped = _canGroup;
                        this.Text = _title;
                        _initFinished = true;
                }



                public void QueryData()
                {
                        this.sinoSZUC_GuideLineQueryResult1.ShowGuideLineResult(this.GuideLineDefine, this.QueryParameter);
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
                        FrmMenuGroup _thisGroup;
                        FrmMenuItem _item;

                        IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

                        if (this.sinoSZUC_GuideLineQueryResult1.IsQuerying)
                        {

                                _thisGroup = new FrmMenuGroup("查询处理");
                                _thisGroup.MenuItems = new List<FrmMenuItem>();
                                _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataQuery.Properties.Resources.x1, this.sinoSZUC_GuideLineQueryResult1.IsQuerying);
                                _thisGroup.MenuItems.Add(_item);


                                _ret.Add(_thisGroup);
                        }

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

                                case "取消":
                                        this.sinoSZUC_GuideLineQueryResult1.CancelQuery();
                                        break;
                                case "图表展示":
                                        this.sinoSZUC_GuideLineQueryResult1.ShowAsChart(this._application);
                                        break;
                                case "导出":
                                        SinoSZExport_GridViewData.Export(this.sinoSZUC_GuideLineQueryResult1.CurrentView);

                                        break;
                        }
                        this.RaiseMenuChanged();
                        return true;
                }


                #endregion


                private void frmGuideLineQueryWithoutInput_Load(object sender, EventArgs e)
                {
                       
                        QueryData();
                }


                private void sinoSZUC_GuideLineQueryResult1_ShowDetailData(object sender, EventArgs e)
                {
                        ShowDetailDataArgs _showArgs = e as ShowDetailDataArgs;
                        GuideLineDetailControler.ShowDetail(_showArgs, _application);
                }

                private void sinoSZUC_GuideLineQueryResult1_QueryFinished(object sender, EventArgs e)
                {
                        this.RaiseMenuChanged();
                }


        }
}