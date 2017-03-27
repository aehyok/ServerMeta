using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SinoSZMetaDataQuery.InputModel
{
        public partial class SinoUC_IM_Date : SinoSZMetaDataQuery.InputModel.SinoUC_IM_Text
        {
                public SinoUC_IM_Date()
                {
                        InitializeComponent();
                }

                public override object EditValue
                {
                        get
                        {
                                return this.dateEdit1.EditValue;
                        }
                        set
                        {
                                this.dateEdit1.EditValue = value;
                        }
                }
        }
}

