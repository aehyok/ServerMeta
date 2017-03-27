using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Misc;
using SinoSZClientBase.PortalItem;
using SinoSZPluginFramework;

namespace SinoSZMetaDataQuery.Portal
{
        public partial class frmPortal : DevExpress.XtraEditors.XtraForm
        {
                protected string Param = "";
                protected int PortalColumn = 0;
                protected int PortalRow = 0;
                protected List<PortalItemDefine> Items = new List<PortalItemDefine>();
                protected IApplication Application = null;
                public frmPortal()
                {
                        InitializeComponent();
                }

                public frmPortal(string _param, IApplication _application)
                {

                        InitializeComponent();
                        Param = _param;
                        Application = _application;
                        this.Text = StrUtils.GetMetaByName2("标题", _param);
                        Items.Clear();
                        foreach (string _s in StrUtils.GetMetasByName2("项目", _param))
                        {
                                Items.Add(new PortalItemDefine(_s));
                        }
                        double _colcout = Items.Count / 2;
                        PortalColumn = Convert.ToInt16(Math.Ceiling(_colcout));
                        if (Items.Count <= 1)
                        {
                                PortalRow = 1;
                        }
                        else
                        {
                                PortalRow = 2;
                        }

                        InitGridLayoutPanel();
                }

                private void InitGridLayoutPanel()
                {
                        this.tableLayoutPanel1.Controls.Clear();
                        this.tableLayoutPanel1.RowCount = PortalRow;
                        this.tableLayoutPanel1.ColumnCount = PortalColumn;
                        float _colWidth = 100 / PortalColumn;
                        this.tableLayoutPanel1.ColumnStyles.Clear();
                        for (int i = 0; i < PortalColumn; i++)
                        {
                                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, _colWidth));
                        }
                        this.tableLayoutPanel1.RowStyles.Clear();
                        float _rowHeight = 100 / PortalRow;
                        for (int i = 0; i < PortalRow; i++)
                        {

                                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, _rowHeight));
                        }
                        int _crow = 0;
                        int _ccol = 0;
                        IPluginService pluginService = (IPluginService)Application.GetService(typeof(IPluginService));
                        foreach (PortalItemDefine _item in Items)
                        {
                                IPlugin _plugin = pluginService.GetPluginInstance(_item.PluginName);
                                if (_plugin != null)
                                {
                                        object _obj = _plugin.LoadPortalItem(_item.Name, _item.Param);
                                        if (_obj != null)
                                        {
                                                Control _sb = _obj as Control;
                                                _sb.Anchor = (AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                                   | System.Windows.Forms.AnchorStyles.Left)
                                                                   | System.Windows.Forms.AnchorStyles.Right));
                                                this.tableLayoutPanel1.Controls.Add(_sb, _ccol, _crow);
                                                _sb.Margin = new Padding(20, 10, 20, 10);
                                                _crow++;
                                                if (_crow > 1)
                                                {
                                                        _crow = 0;
                                                        _ccol++;
                                                }
                                        }
                                }
                        }
                }
        }
}