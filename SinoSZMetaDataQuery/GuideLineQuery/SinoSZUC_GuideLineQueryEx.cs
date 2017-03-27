using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZUC_GuideLineQueryEx : DevExpress.XtraEditors.XtraUserControl
        {
                private MD_GuideLine guideLineDefine = null;
                private List<MDQuery_GuideLineParameter> _param = null;

                public SinoSZUC_GuideLineQueryEx()
                {
                        InitializeComponent();
                }

                public SinoSZUC_GuideLineQueryEx(MD_GuideLine _gl)
                {
                        InitializeComponent();
                        guideLineDefine = _gl;
                        InitForm();
                }

                private void InitForm()
                {

                        this.sinoSZUC_GuideLineDynamicInput21.InitForm(guideLineDefine);
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
                                return this.sinoSZUC_GuideLineDynamicInput21.InputFinised;
                        }
                }

                public bool IsQuerying
                {
                        get
                        {
                                return this.sinoSZUC_GuideLineQueryResult1.IsQuerying;
                        }
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
                        this.sinoSZUC_GuideLineDynamicInput21.Enabled = false;
                        _param = this.sinoSZUC_GuideLineDynamicInput21.GetParamters();
                        this.sinoSZUC_GuideLineQueryResult1.ShowGuideLineResult(this.guideLineDefine, _param);
                }

                public void ShowAsChart(SinoSZPluginFramework.IApplication _application)
                {
                        this.sinoSZUC_GuideLineQueryResult1.ShowAsChart(_application);
                }

                private void sinoSZUC_GuideLineQueryResult1_ShowDetailData(object sender, EventArgs e)
                {
                        RaiseShowDetailDatal(e as ShowDetailDataArgs);
                }

                private void sinoSZUC_GuideLineQueryResult1_QueryFinished(object sender, EventArgs e)
                {
                        this.sinoSZUC_GuideLineDynamicInput21.Enabled = true;
                        RaiseQueryFinished();
                }

                private void sinoSZUC_GuideLineQueryResult1_FocusRowChanged(object sender, EventArgs e)
                {

                }

                private void sinoSZUC_GuideLineDynamicInput21_InputChanged(object sender, EventArgs e)
                {
                        RaiseInputChanged();
                }

                public void ExportData()
                {
                        SinoSZExport_GridViewData.Export(this.sinoSZUC_GuideLineQueryResult1.CurrentView);
                }
        }
}
