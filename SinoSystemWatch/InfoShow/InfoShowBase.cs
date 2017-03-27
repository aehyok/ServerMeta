using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Drawing;
using DevExpress.XtraBars.Ribbon;
using SinoSystemWatch.Base.Define;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShowBase : IInfoShow
    {
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            Label _lb = new Label();
            _lb.Text = InfoResult.CheckResult;
            _lb.TextAlign = ContentAlignment.MiddleLeft;
            _lb.AutoSize = true;
            panel.Controls.Add(_lb);
            return true;
        }


        public bool Show(DevExpress.XtraGrid.Views.Grid.GridView gridView, CheckInfoResult InfoResult)
        {
            return true;
        }


        public bool ShowConsole(Panel MainPanel, CheckInfoResult _r)
        {
            return true;
        }


        public bool GetMenuGroup(RibbonPage MainPage)
        {
            return true;
        }

        public void DoCommand(string CommandName, SystemStateItem StateItem)
        {
            switch (CommandName)
            {
                default:
                    MessageBox.Show(CommandName, "提示");
                    break;
            }
        }
    }
}
