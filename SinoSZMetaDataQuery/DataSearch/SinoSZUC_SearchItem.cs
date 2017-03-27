using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraEditors.Controls;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZMetaDataQuery.DataSearch
{
        public partial class SinoSZUC_SearchItem : DevExpress.XtraEditors.XtraUserControl
        {
                public string SearchData
                {
                        get
                        {
                                if (this.textEdit1.EditValue == null) return "";
                                string _str = this.textEdit1.EditValue.ToString();
                                _str = _str.Trim();
                                return _str;
                        }
                        set
                        {
                                this.textEdit1.EditValue = value;
                        }
                }

                public int SearchType
                {
                        get
                        {
                                return this.radioGroup1.SelectedIndex;
                        }

                        set
                        {
                                this.radioGroup1.SelectedIndex = value;
                        }
                }
                private MD_ConceptGroup ConceptGroup = null;
                public SinoSZUC_SearchItem()
                {
                        InitializeComponent();
                }

                public SinoSZUC_SearchItem(MD_ConceptGroup _cGroup)
                {
                        InitializeComponent();
                        ConceptGroup = _cGroup;
                        InitForm();
                }

                private void InitForm()
                {
                        this.radioGroup1.SelectedIndex = 0;
                }

  
        }
}
