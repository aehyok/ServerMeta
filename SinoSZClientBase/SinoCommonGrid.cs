using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace SinoSZClientBase
{
        public class SinoCommonGrid: GridControl
        {
		private GridView gridView1;
	
                public SinoCommonGrid()
                        : base()
                {
                        this.ViewRegistered += new ViewOperationEventHandler(SinoCommonGrid_ViewRegistered);
                }

                void SinoCommonGrid_ViewRegistered(object sender, ViewOperationEventArgs e)
                {
                        if (e.View is GridView)
                        {
                                GridView _gv = e.View as GridView;
                                _gv.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                                _gv.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                                _gv.Appearance.EvenRow.Options.UseBackColor = true;
                                _gv.Appearance.FocusedCell.BackColor =Color.DarkOrange ;
				_gv.Appearance.FocusedCell.BackColor2 = Color.DarkOrange;
                                _gv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                                _gv.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                                _gv.Appearance.FocusedCell.Options.UseBackColor = true;
                                _gv.Appearance.FocusedCell.Options.UseForeColor = true;
				_gv.Appearance.FocusedRow.BackColor = Color.DarkOrange;
				_gv.Appearance.FocusedRow.BackColor2 = Color.DarkOrange;
                                _gv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                                _gv.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                                _gv.Appearance.FocusedRow.Options.UseBackColor = true;
                                _gv.Appearance.FocusedRow.Options.UseForeColor = true;

                                _gv.OptionsView.EnableAppearanceEvenRow = true;
                                _gv.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(_gv_CustomDrawRowIndicator);
                                _gv.DataSourceChanged += new EventHandler(_gv_DataSourceChanged);
                        }
                }

                void _gv_DataSourceChanged(object sender, EventArgs e)
                {
                        GridView _gv = sender as GridView;
                        _gv.IndicatorWidth = _gv.RowCount.ToString().Length * 10 + 15;
                }

                void _gv_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
                {
                        if (e.Info.IsRowIndicator)
                        {
                                e.Info.DisplayText = e.RowHandle >= 0 ? (e.RowHandle + 1).ToString() : "";
                        }
                }

		private void InitializeComponent()
		{
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this;
			this.gridView1.Name = "gridView1";
			// 
			// SinoCommonGrid
			// 
			this.EmbeddedNavigator.Name = "";
			this.MainView = this.gridView1;
		
			this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}
        }
}
