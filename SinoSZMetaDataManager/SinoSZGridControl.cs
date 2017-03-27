using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace SinoSZMetaDataManager
{
        class SinoSZGridControl :GridControl
        {
                public SinoSZGridControl()
                {
                        if (this.MainView is GridView)
                        {
                                GridView _gv = this.MainView as GridView;
                                _gv.Appearance.OddRow.BackColor = Color.Cyan;
                                _gv.Appearance.OddRow.BackColor2 = Color.Cyan;
                                _gv.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        }
                }
        }
}
