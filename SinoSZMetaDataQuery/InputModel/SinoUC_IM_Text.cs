using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZMetaDataQuery.InputModel
{
        public partial class SinoUC_IM_Text : DevExpress.XtraEditors.XtraUserControl
        {
                public SinoUC_IM_Text()
                {
                        InitializeComponent();
                }

                virtual public object EditValue
                {
                        get
                        {
                                return this.textEdit1.EditValue;
                        }
                        set
                        {
                                this.textEdit1.EditValue = value;
                        }
                }

        }
}
