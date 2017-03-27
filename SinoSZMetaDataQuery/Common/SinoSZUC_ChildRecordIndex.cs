using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
        public partial class SinoSZUC_ChildRecordIndex : UserControl
        {
                private MDModel_Table TableDefine = null;
                private int RecordCount = 0;
                private bool initFinished = false;
                private Panel ShowControl = null;
                public SinoSZUC_ChildRecordIndex()
                {
                        InitializeComponent();
                }

                public SinoSZUC_ChildRecordIndex(MDModel_Table _table, int _recNum)
                {
                        InitializeComponent();
                        TableDefine = _table;
                        RecordCount = _recNum;
                        initForm();
                }

                private void initForm()
                {
                        this.linkLabel1.Text = string.Format("{0} ({1}) ", TableDefine.TableDefine.DisplayTitle, RecordCount);
                        this.checkEdit1.Checked = false;
                        DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
                        DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
                        DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();

                        toolTipTitleItem1.Text = TableDefine.TableDefine.DisplayTitle;
                        toolTipItem1.LeftIndent = 6;
                        toolTipItem1.Text = string.Format("共有记录数{0}条!", RecordCount);
                        superToolTip1.Items.Add(toolTipTitleItem1);
                        superToolTip1.Items.Add(toolTipItem1);
                        this.toolTipController1.SetSuperTip(this.linkLabel1, superToolTip1);

                        initFinished = true;
                }




                private void checkEdit1_CheckedChanged(object sender, EventArgs e)
                {
                        //改变CHECK后
                        if (initFinished)
                        {
                                if (ShowControl == null)
                                {
                                        CreateShowControl();
                                }
                                ShowControl.Visible = checkEdit1.Checked;
                                if (ShowControl.Visible)
                                {
                                        ShowControl.BringToFront();
                                }

                        }
                }

                private void CreateShowControl()
                {
                        ShowControl = new Panel();

                }

                private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        //点击此项后
                }
        }
}
