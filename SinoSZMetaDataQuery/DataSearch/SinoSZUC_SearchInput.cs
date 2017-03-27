using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using DevExpress.XtraTab;
using System.Linq;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataSearch
{
    public partial class SinoSZUC_SearchInput : DevExpress.XtraEditors.XtraUserControl
    {

        public SinoSZUC_SearchInput()
        {
            InitializeComponent();
        }

        public void InitInput()
        {

            this.xtraTabControl1.TabPages.Clear();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                List<MD_ConceptGroup> _cGroups = _msc.GetConceptList().ToList<MD_ConceptGroup>();
                foreach (MD_ConceptGroup _group in _cGroups)
                {
                    XtraTabPage _tb = this.xtraTabControl1.TabPages.Add(_group.Description);
                    _tb.Tag = _group;
                    SinoSZUC_SearchItem _si = new SinoSZUC_SearchItem(_group);
                    _si.Dock = DockStyle.Fill;
                    _tb.Controls.Add(_si);
                    _si.BringToFront();
                }
            }
        }

        public string SearchText
        {
            get
            {
                XtraTabPage _tb = this.xtraTabControl1.SelectedTabPage;
                if (_tb == null) return "";
                if (_tb.Controls.Count < 1) return "";
                SinoSZUC_SearchItem _si = _tb.Controls[0] as SinoSZUC_SearchItem;
                return _si.SearchData;
            }
        }

        public string SearchConceptGroup
        {
            get
            {
                XtraTabPage _tb = this.xtraTabControl1.SelectedTabPage;
                if (_tb == null) return "";
                MD_ConceptGroup _group = _tb.Tag as MD_ConceptGroup;
                return _group.Name;
            }
        }

        public int SearchType
        {
            get
            {
                XtraTabPage _tb = this.xtraTabControl1.SelectedTabPage;
                if (_tb == null) return -1;
                if (_tb.Controls.Count < 1) return -1;
                SinoSZUC_SearchItem _si = _tb.Controls[0] as SinoSZUC_SearchItem;
                return _si.SearchType;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.PrevPage == null) return;
            XtraTabPage _prePage = e.PrevPage;
            if (_prePage.Controls.Count < 1) return;
            SinoSZUC_SearchItem _presi = _prePage.Controls[0] as SinoSZUC_SearchItem;
            XtraTabPage _currentPage = e.Page;
            if (_currentPage.Controls.Count < 1) return;
            SinoSZUC_SearchItem _currentSi = _currentPage.Controls[0] as SinoSZUC_SearchItem;

            _currentSi.SearchData = _presi.SearchData;
            _currentSi.SearchType = _presi.SearchType;


        }
    }
}
