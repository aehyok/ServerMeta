using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
        public partial class Dialog_QueryModelDescript : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_QueryModelDescript()
                {
                        InitializeComponent();
                }

                public Dialog_QueryModelDescript(string _modelName)
                {
                        InitializeComponent();
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            string _msg = _msc.GetQueryModelDescription(_modelName);
                            this.memoEdit1.EditValue = _msg;
                        }
                }

        }
}