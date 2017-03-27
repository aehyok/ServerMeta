using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using SinoSZPluginFramework;
using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZ_GuideLineQuery : DevExpress.XtraEditors.XtraUserControl
        {
                private MD_GuideLine guideLineDefine = null;
                private List<MDQuery_GuideLineParameter> _param = null;

                public SinoSZ_GuideLineQuery()
                {
                        InitializeComponent();
                }

                public bool HaveResult
                {
                        get
                        {
                                return this.sinoSZUC_GuideLineQueryResult1.HaveResult;
                        }
                }
                public bool InputFinised
                {
                        get
                        {
                                return this.sinoSZUC_GuideLineQueryInput1.InputFinised;
                        }
                }

                public bool IsQuerying
                {
                        get
                        {
                                return this.sinoSZUC_GuideLineQueryResult1.IsQuerying;
                        }
                }

                public SinoSZ_GuideLineQuery(MD_GuideLine _gl)
                {
                        InitializeComponent();
                        guideLineDefine = _gl;
                        InitForm();
                }

                private void InitForm()
                {
                        this.sinoSZUC_GuideLineQueryInput1.InitForm(guideLineDefine);
                }

                private void sinoSZUC_GuideLineQueryInput1_InputChanged(object sender, EventArgs e)
                {
                        this.RaiseInputChanged();
                }

                [Category("WinFormEx")]
                public event EventHandler InputChanged;
                protected void RaiseInputChanged()
                {
                        EventArgs e = new EventArgs();
                        if (InputChanged != null)
                                InputChanged(this, e);
                }
                [Category("WinFormEx")]
                public event EventHandler QueryFinished;
                protected void RaiseQueryFinished()
                {
                        EventArgs e = new EventArgs();
                        if (QueryFinished != null) QueryFinished(this, e);
                }

                [Category("WinFormEx")]
                public event EventHandler ShowDetailData;
                protected void RaiseShowDetailDatal(ShowDetailDataArgs _args)
                {

                        if (ShowDetailData != null)
                                ShowDetailData(this, _args);
                }

                public void QueryData()
                {
                        this.sinoSZUC_GuideLineQueryInput1.Enabled = false;
                        _param = this.sinoSZUC_GuideLineQueryInput1.GetParamters();
                        this.sinoSZUC_GuideLineQueryResult1.ShowGuideLineResult(this.guideLineDefine, _param);
                }


                private void sinoSZUC_GuideLineQueryResult1_ShowDetailData(object sender, EventArgs e)
                {
                        RaiseShowDetailDatal(e as ShowDetailDataArgs);
                }

                private void sinoSZUC_GuideLineQueryResult1_QueryFinished(object sender, EventArgs e)
                {
                        this.sinoSZUC_GuideLineQueryInput1.Enabled = true;
                        RaiseQueryFinished();
                }



                public void ShowAsChart(IApplication _application)
                {
                        this.sinoSZUC_GuideLineQueryResult1.ShowAsChart(_application);
                }

                public void ExportData()
                {
                        SinoSZExport_GridViewData.Export(this.sinoSZUC_GuideLineQueryResult1.CurrentView);
                }
        }
}
