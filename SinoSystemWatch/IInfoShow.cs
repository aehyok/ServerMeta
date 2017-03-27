using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using SinoSystemWatch.Base.Define;

namespace SinoSystemWatch
{
    public interface IInfoShow
    {
        bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult);

        bool Show(GridView gridView, CheckInfoResult InfoResult);

        bool ShowConsole(Panel MainPanel, CheckInfoResult _r);

        bool GetMenuGroup(RibbonPage MainPage);
 
        void DoCommand(string CommandName, SystemStateItem StateItem);
    }
}
