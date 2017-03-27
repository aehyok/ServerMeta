using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using System.Linq;
using SinoSZClientBase.MetaDataQueryService;
namespace SinoSZMetaDataQuery.Common
{
    public partial class Dialog_AddFunction : DevExpress.XtraEditors.XtraForm
    {
        private string insString = "";
        protected MD_FUNCTION currentItem = null;
        static protected List<MD_FUNCTION> functionList = null;
        protected MDModel_Table TableDefine = null;
        static public List<MD_FUNCTION> FunctionList
        {
            get
            {
                if (functionList == null)
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        functionList = _msc.GetFunctionList(0).ToList<MD_FUNCTION>();
                    }
                }
                return functionList;
            }
        }


        public string InsertString
        {
            get { return insString; }
        }

        public Dialog_AddFunction()
        {
            InitializeComponent();
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CreateInsertString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CreateInsertString()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(currentItem.Name);
            _sb.Append("(");
            string _fg = "";
            foreach (SinoUC_FunctionParam _pc in this.xtraScrollableControl1.Controls)
            {
                _sb.Append(_fg);
                _sb.Append(_pc.GetInput());
                _fg = ",";
            }
            _sb.Append(")");
            this.insString = _sb.ToString();
        }

        public void InitForm(MDModel_Table _table)
        {
            this.gridControl1.DataSource = FunctionList;
            TableDefine = _table;
            ShowFunction();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowFunction();
        }

        private void ShowFunction()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                this.xtraScrollableControl1.Controls.Clear();
                currentItem = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MD_FUNCTION;
                this.te_Name.EditValue = currentItem.Name;
                this.te_Des.EditValue = currentItem.Description;
                this.te_Result.EditValue = currentItem.ResultType;
                foreach (string _pname in currentItem.ParamList)
                {
                    string _type = currentItem.ParamTypeDict[_pname];

                    SinoUC_FunctionParam _pc = new SinoUC_FunctionParam(_pname, _type, this.TableDefine);
                    _pc.Dock = DockStyle.Top;
                    _pc.BringToFront();
                    this.xtraScrollableControl1.Controls.Add(_pc);
                }
            }
        }
    }
}