using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;

using SinoSZJS.Base.Misc;
using SinoSZPluginFramework;

using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class frmGuideLineQuery_Single : frmBase
        {
                private string guideLineID = "";
                private MD_GuideLine guideLineDefine = null;
                private string DefalutValueStrings = "";
                private string Param = "";
                private string MergeColumn = "";
                public frmGuideLineQuery_Single()
                {
                        InitializeComponent();
                }

                public override void Init(string _title, string _menuName, object _param)
                {
                        this.Text = _title;
                        this._menuPageName = _menuName;
                        Param = _param as string;
                        guideLineID = StrUtils.GetMetaByName2("ָ��ID", Param);
                        DefalutValueStrings = StrUtils.GetMetaByName2("Ĭ��ֵ", Param);
                        MergeColumn = StrUtils.GetMetaByName2("�ϲ���", Param);
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            guideLineDefine = _msc.GetGuideLineByID(guideLineID);
                        }
                        InitForm();
                        _initFinished = true;
                        RaiseMenuChanged();
                }

                private void InitForm()
                {
                        this.sinoSZUC_GuideLineDynamicInput21.InitForm(guideLineDefine);
                        foreach (string _val in DefalutValueStrings.Split(','))
                        {
                                string[] _valueItems = _val.Split(':');
                                if (_valueItems.Length > 1)
                                {
                                        this.sinoSZUC_GuideLineDynamicInput21.WriteParamValue(_valueItems[0], _valueItems[1]);
                                }
                        }

                        QueryData();
                }

                public void QueryData()
                {
                        if (this.sinoSZUC_GuideLineDynamicInput21.InputFinised)
                        {
                                this.sinoSZUC_GuideLineDynamicInput21.Enabled = false;
                                List<MDQuery_GuideLineParameter> _param = this.sinoSZUC_GuideLineDynamicInput21.GetParamters();
                                this.sinoSZUC_GuideLineQueryResult1.SetMergeColumn(MergeColumn);
                                this.sinoSZUC_GuideLineQueryResult1.ShowGuideLineResult(this.guideLineDefine, _param);
                        }
                }


                #region ���ػ���ķ���



                protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
                {
                        IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
                        FrmMenuGroup _thisGroup = new FrmMenuGroup("Ԥ���ල����");

                        _thisGroup.MenuItems = new List<FrmMenuItem>();

                        bool _inputFinished = false;
                        if (this.sinoSZUC_GuideLineDynamicInput21.InputFinised && !this.sinoSZUC_GuideLineQueryResult1.IsQuerying)
                        {
                                _inputFinished = true;
                        }

                        FrmMenuItem _item = new FrmMenuItem("��ѯ", "��ѯ", global::SinoSZMetaDataQuery.Properties.Resources.b28, _inputFinished);
                        _thisGroup.MenuItems.Add(_item);

                        bool _cancelQuery = false;
                        if (this.sinoSZUC_GuideLineQueryResult1.IsQuerying)
                        {
                                _cancelQuery = true;
                        }

                        _item = new FrmMenuItem("ȡ��", "ȡ��", global::SinoSZMetaDataQuery.Properties.Resources.x1, _cancelQuery);
                        _thisGroup.MenuItems.Add(_item);
                        _ret.Add(_thisGroup);

                        _thisGroup = new FrmMenuGroup("�������");
                        _thisGroup.MenuItems = new List<FrmMenuItem>();
                        bool _haveResult = this.sinoSZUC_GuideLineQueryResult1.HaveResult;

                        _item = new FrmMenuItem("ͼ��չʾ", "ͼ��չʾ", global::SinoSZMetaDataQuery.Properties.Resources.b18, _haveResult);
                        _thisGroup.MenuItems.Add(_item);

                        _item = new FrmMenuItem("����", "����", global::SinoSZMetaDataQuery.Properties.Resources.x3, _haveResult);
                        _thisGroup.MenuItems.Add(_item);
                        _ret.Add(_thisGroup);
                        return _ret;
                }

                protected override bool ExcuteCommand(string _cmdName)
                {
                        switch (_cmdName)
                        {
                                case "��ѯ":
                                        QueryData();
                                        break;
                                case "ȡ��":
                                        this.sinoSZUC_GuideLineQueryResult1.CancelQuery();
                                        break;
                                case "ͼ��չʾ":
                                        ShowAsChart();
                                        break;
                                case "����":
                                        SinoSZExport_GridViewData.Export(this.sinoSZUC_GuideLineQueryResult1.CurrentView);
                                        break;

                        }
                        this.RaiseMenuChanged();
                        return true;
                }

                #endregion

                private void ShowAsChart()
                {
                        if (this.sinoSZUC_GuideLineQueryResult1.HaveResult)
                        {
                                this.sinoSZUC_GuideLineQueryResult1.ShowAsChart(_application);
                        }
                }

                private void sinoSZUC_GuideLineQueryResult1_QueryFinished(object sender, EventArgs e)
                {
                        this.sinoSZUC_GuideLineDynamicInput21.Enabled = true;
                        RaiseMenuChanged();
                }

                private void sinoSZUC_GuideLineDynamicInput21_InputChanged(object sender, EventArgs e)
                {
                        RaiseMenuChanged();
                }

                private void sinoSZUC_GuideLineQueryResult1_ShowDetailData(object sender, EventArgs e)
                {
                        ShowDetailDataArgs _showArgs = e as ShowDetailDataArgs;
                        GuideLineDetailControler.ShowDetail(_showArgs, _application);
                }

        }
}