using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SinoSZMetaDataQuery.InputModel
{
        public partial class SinoUC_IM_RefTable : SinoSZMetaDataQuery.InputModel.SinoUC_IM_Text
        {
                public SinoUC_IM_RefTable()
                {
                        InitializeComponent();
                }

                public SinoUC_IM_RefTable(string refTableName)
                {
                        InitializeComponent();
                        this.refCodeBox1.RefTableName = refTableName;
                }
                public override object EditValue
                {
                        get
                        {
                                return this.refCodeBox1.Code;
                        }
                        set
                        {
                                if (value != null)
                                {
                                        this.refCodeBox1.Code = value.ToString();
                                }
                                else
                                {
                                        this.refCodeBox1.Code = null;
                                }
                        }
                }
        }
}

