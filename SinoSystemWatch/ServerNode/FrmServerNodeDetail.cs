using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSystemWatch.Base.Define;
using DevExpress.XtraTab;
using DevExpress.XtraBars.Ribbon;

namespace SinoSystemWatch.ServerNode
{
    public partial class FrmServerNodeDetail : DevExpress.XtraEditors.XtraForm
    {
        private SystemStateItem CurrentItem = null;
        public FrmServerNodeDetail()
        {
            InitializeComponent();
        }

        public FrmServerNodeDetail(SystemStateItem item)
        {
            InitializeComponent();
            CurrentItem = item;
        }

        private void FrmServerNodeDetail_Load(object sender, EventArgs e)
        {
            if (this.CurrentItem != null)
            {
                this.Text = string.Format("服务器[{0}]的监控详情", this.CurrentItem.SystemDescription);
                this.c_DetailPanel1.StartRefresh(this.CurrentItem);
            }
        }

        private void c_DetailPanel1_MenuChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == null) return;
            if (e.Page.Tag == null) return;
            C_CheckInfoPanel _panel = e.Page.Tag as C_CheckInfoPanel;
            IInfoShow _ics = _panel.InfoShowInterface;
            this.ribbonPage1.Groups.Clear();

            _ics.GetMenuGroup(this.ribbonPage1);

        }

        private void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                IInfoShow _is = e.Item.Tag as IInfoShow;
                _is.DoCommand(e.Item.Name, this.CurrentItem);
            }
        }


    }
}