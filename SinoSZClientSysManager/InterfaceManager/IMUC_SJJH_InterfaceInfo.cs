using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.SystemInterface;

namespace SinoSZClientSysManager.InterfaceManager
{
        public partial class IMUC_SJJH_InterfaceInfo : DevExpress.XtraEditors.XtraUserControl
        {
                public IMUC_SJJH_InterfaceInfo()
                {
                        InitializeComponent();
                }

                public void ShowInfo(SystemICS_SJJH_Node _selectNode)
                {
                        this.ICS_Name.Text = _selectNode.DisplayName;
                        this.ICS_State.Text = "∆Ù”√";

                }

                public void Clear()
                {
                        this.ICS_Name.Text = "";
                        this.ICS_State.Text = "";
                }
        }
}
