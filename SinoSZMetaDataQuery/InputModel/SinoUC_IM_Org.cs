using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Authorize;

namespace SinoSZMetaDataQuery.InputModel
{
    public partial class SinoUC_IM_Org : SinoSZMetaDataQuery.InputModel.SinoUC_IM_Text
    {
        public string RunErrorMsg = "";
        public SinoUC_IM_Org()
        {
            InitializeComponent();
        }
        public void InitOrgs()
        {
            this.sinoUC_OrgComboBox1.InitRootDWID(SessionClass.RootOrgID);
        }

        public override object EditValue
        {
            get
            {
                return this.sinoUC_OrgComboBox1.Code;
            }
            set
            {
                try
                {

                    this.sinoUC_OrgComboBox1.SelectedCode((decimal)value);
                }
                catch (Exception ex)
                {
                    RunErrorMsg = ex.Message;
                }

            }
        }
    }
}

