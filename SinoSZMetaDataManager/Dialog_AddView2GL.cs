using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZMetaDataQuery;

using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
        public partial class Dialog_AddView2GL : DevExpress.XtraEditors.XtraForm
        {
                private MD_QueryModel QueryModel = null;

                public Dialog_AddView2GL()
                {
                        InitializeComponent();
                }

                public Dialog_AddView2GL(MD_QueryModel _qv)
                {
                        InitializeComponent();
                        QueryModel = _qv;
                        this.uC_View2GLInfo1.V2GID = Guid.NewGuid().ToString();
                }

                public void SaveData()
                {
                    using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                    {
                        if (_mdc.SaveView2GL(this.uC_View2GLInfo1.V2GID, QueryModel.QueryModelID, this.uC_View2GLInfo1.GuideLineID, this.uC_View2GLInfo1.Parameters, this.uC_View2GLInfo1.DisplayOrder, this.uC_View2GLInfo1.DisplayTitle))
                        {
                            XtraMessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK);
                        }
                        else
                        {
                            XtraMessageBox.Show("保存失败！", "系统提示", MessageBoxButtons.OK);
                        }
                    }
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        string _msg = "";
                        if (this.uC_View2GLInfo1.CheckInput(ref _msg))
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show(_msg, "系统提示");
                        }
                }

        }
}