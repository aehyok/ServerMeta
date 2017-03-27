using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.InfoShow;
using DevExpress.XtraGrid.Columns;

namespace SinoSystemWatch
{
    public partial class C_CheckInfoPanel : UserControl
    {
        private CheckInfoResult CurrentData = null;
        public IInfoShow InfoShowInterface { get; set; }
        public C_CheckInfoPanel()
        {
            InitializeComponent();
        }

        public string Projectname
        {
            get
            {
                if (CurrentData == null)
                {
                    return "";
                }
                else
                {
                    return CurrentData.CheckProjectName;
                }
            }
        }

        internal void RefreshData(CheckInfoResult _r)
        {
            CurrentData = _r;
            this.MainPanel.Controls.Clear();
            if (_r.StateFlag < 4)
            {
                this.pictureBox1.BackgroundImage = this.imageList1.Images[_r.StateFlag];
            }
            else
            {
                this.pictureBox1.BackgroundImage = this.imageList1.Images[0];
            }
            if (this.gridView1.Columns.Count > 1)
            {
                List<GridColumn> _glist = new List<GridColumn>();
                foreach (GridColumn _dc in this.gridView1.Columns)
                {
                    if (_dc.FieldName != "Flag")
                    {
                        _glist.Add(_dc);
                    }
                }

                this.gridView1.BeginUpdate();
                foreach (GridColumn _dc in _glist)
                {
                    this.gridView1.Columns.Remove(_dc);
                }
                this.gridView1.EndUpdate();
            }

            InfoShowInterface = InfoShowLib.CreateInterface(_r);
            //_show.Show(this.MainPanel, _r);
            InfoShowInterface.Show(this.gridView1, _r);
            InfoShowInterface.ShowConsole(this.MainPanel, _r);

        }



    }
}
