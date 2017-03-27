using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.IO;
using System.Runtime.Serialization;
using DevExpress.XtraTreeList.Nodes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_ImportGuideLine : DevExpress.XtraEditors.XtraForm
    {
        private MD_GuideLine CurrentGuideLine = null;
        private MD_GuideLine SourceGuideLine = null;
        private List<MD_GuideLine> SelectedGuideLines = null;
        private Dictionary<string, MD_GuideLine> GuideLineDict = null;
        private int ImportType = 0;
        public Dialog_ImportGuideLine()
        {
            InitializeComponent();
        }

        public Dialog_ImportGuideLine(MD_GuideLine _guideLine)
        {
            InitializeComponent();
            CurrentGuideLine = _guideLine;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                this.buttonEdit1.Enabled = false;
                this.treeList1.Enabled = false;
                this.radioGroup1.Enabled = false;
                this.simpleButton1.Enabled = false;
                this.simpleButton2.Enabled = false;
                this.label4.Visible = true;
                this.progressBarControl1.Visible = true;

                this.backgroundWorker1.RunWorkerAsync();

            }
        }

        /// <summary>
        /// 验证输入是否正确
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            //判断是否选择了导入文件
            if (this.buttonEdit1.EditValue == null || this.buttonEdit1.EditValue.ToString() == null)
            {
                XtraMessageBox.Show("请选择导入文件名!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string _fname = this.buttonEdit1.EditValue.ToString();

            if (!File.Exists(_fname))
            {
                XtraMessageBox.Show("选择的导入文件不存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //判断是否选择了要导入的指标
            SelectedGuideLines = GetSelectedGuidelLines();
            int _selectCount = SelectedGuideLines.Count;
            if (_selectCount < 1)
            {
                XtraMessageBox.Show("请选择要导入的指标!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //判断是否选择了方式
            if (this.radioGroup1.SelectedIndex < 0)
            {
                XtraMessageBox.Show("请选择导入方式!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.radioGroup1.SelectedIndex == 2 && _selectCount != 1)
            {
                XtraMessageBox.Show("使用替换方式导入指标时只能选择一个要导入的指标!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ImportType = this.radioGroup1.SelectedIndex;
            return true;

        }

        private List<MD_GuideLine> GetSelectedGuidelLines()
        {
            List<MD_GuideLine> _ret = new List<MD_GuideLine>();
            foreach (TreeListNode _tn in this.treeList1.Nodes)
            {
                if (_tn.GetValue(this.treeListColumn2) != null)
                {
                    int _st = (int)_tn.GetValue(this.treeListColumn2);
                    if (_st > 0)
                    {
                        MD_GuideLine _item = _tn.GetValue(this.treeListColumn1) as MD_GuideLine;
                        _ret.Add(_item);
                    }
                }
                GetChildSelected(_tn, _ret);
            }
            return _ret;
        }

        private void GetChildSelected(TreeListNode _fnode, List<MD_GuideLine> _ret)
        {
            foreach (TreeListNode _tn in _fnode.Nodes)
            {
                if (_tn.GetValue(this.treeListColumn2) != null)
                {
                    int _st = (int)_tn.GetValue(this.treeListColumn2);
                    if (_st > 0)
                    {
                        MD_GuideLine _item = _tn.GetValue(this.treeListColumn1) as MD_GuideLine;
                        _ret.Add(_item);
                    }
                }
                GetChildSelected(_tn, _ret);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog _f = new OpenFileDialog();
            _f.Filter = "备份文件 (*.bak) | *.bak";
            if (_f.ShowDialog() == DialogResult.OK)
            {
                this.buttonEdit1.EditValue = _f.FileName;
                InitGuideLineTree(_f.FileName);
            }
        }

        private void InitGuideLineTree(string _fileName)
        {
            DataContractSerializer s = new DataContractSerializer(typeof(MD_GuideLine));
            using (FileStream fs = File.Open(_fileName, FileMode.Open))
            {
                SourceGuideLine = s.ReadObject(fs) as MD_GuideLine;
            }

            if (SourceGuideLine == null)
            {
                XtraMessageBox.Show("导入失败！因文件内容无法被反序列化！", "系统提示");
            }
            else
            {
                this.treeList1.BeginUpdate();
                this.treeList1.Nodes.Clear();
                TreeListNode _newnode = treeList1.AppendNode(null, null);
                _newnode.SetValue(this.treeListColumn1, SourceGuideLine);
                _newnode.SetValue(this.treeListColumn2, 0);
                _newnode.ImageIndex = 0;
                AddChildNodes(_newnode, SourceGuideLine);
                this.treeList1.ExpandAll();
                this.treeList1.EndUpdate();
            }
        }

        private void AddChildNodes(TreeListNode _fnode, MD_GuideLine SourceGuideLine)
        {
            if (SourceGuideLine.Children != null)
            {
                foreach (MD_GuideLine _guideLine in SourceGuideLine.Children)
                {
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _guideLine);
                    _newnode.SetValue(this.treeListColumn2, 0);
                    _newnode.ImageIndex = 0;
                    AddChildNodes(_newnode, _guideLine);
                }
            }
        }

        private void treeList1_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            int _st = (int)e.Node.GetValue(this.treeListColumn2);

            _st += 1;
            if (_st > 2)
            {
                _st = 0;
            }
            this.treeList1.BeginUpdate();
            e.Node.SetValue(this.treeListColumn2, _st);

            if (_st == 2 || _st == 0)
            {
                ChangChilds(_st, e.Node);
            }
            e.Node.ExpandAll();
            this.treeList1.EndUpdate();
        }

        private void ChangChilds(int _st, TreeListNode treeListNode)
        {
            foreach (TreeListNode _node in treeListNode.Nodes)
            {
                _node.SetValue(this.treeListColumn2, _st);
                ChangChilds(_st, _node);
            }
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(this.treeListColumn2) != null)
            {
                int _st = (int)e.Node.GetValue(this.treeListColumn2);
                e.NodeImageIndex = _st;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool _recoverOldData = false;
            bool _needAsk = true;
            GuideLineDict = CreateGuideLineDict();

            switch (ImportType)
            {
                case 0:   //新增,使用原指标ID
                    ImportByOrdID();
                    break;
                case 1:  //新增,新建指标ID
                    ImportByNewID();
                    break;
                case 2: //替换当前指标算法及参数
                    ReplaceParam();
                    break;
            }


        }

        /// <summary>
        /// 替换当前指标算法及参数
        /// </summary>
        private void ReplaceParam()
        {
            MD_GuideLine _gl = this.SelectedGuideLines[0];
            CurrentGuideLine.GuideLineMethod = _gl.GuideLineMethod;
            CurrentGuideLine.GuideLineMeta = _gl.GuideLineMeta;
            CurrentGuideLine.GuideLineQueryMethod = _gl.GuideLineQueryMethod;
            CurrentGuideLine.DetailMeta = _gl.DetailMeta;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.SaveGuideLine(CurrentGuideLine);
            }
        }

        /// <summary>
        /// 建指标的ID索引词典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, MD_GuideLine> CreateGuideLineDict()
        {
            Dictionary<string, MD_GuideLine> _ret = new Dictionary<string, MD_GuideLine>();
            foreach (MD_GuideLine _gl in this.SelectedGuideLines)
            {
                _ret.Add(_gl.ID, _gl);
            }
            return _ret;
        }

        private void ImportByNewID()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {

                //将所有顶级的指标的父指向当前的指标ID,并修改指标ID
                List<MD_GuideLine> _topLevelGuideLine = GetTopLevelGuideLines();
                decimal _count = Convert.ToDecimal(_topLevelGuideLine.Count);
                decimal i = 0;
                foreach (MD_GuideLine _gl in _topLevelGuideLine)
                {
                    _gl.FatherID = this.CurrentGuideLine.ID;

                    _gl.ID = _mdc.GetNewID();
                    ChangeChildrenID(_gl);

                    decimal _progress = i / _count * 50;
                    i++;
                    this.backgroundWorker1.ReportProgress(Convert.ToInt32(_progress));
                }

                _count = Convert.ToDecimal(SelectedGuideLines.Count);
                i = 0;
                foreach (MD_GuideLine _gl in this.SelectedGuideLines)
                {

                    if (_mdc.IsExistGuideLineID(_gl.ID))
                    {
                        XtraMessageBox.Show(string.Format("新建的ID:{0}已经存在,请管理员检查序列产生器!!!", _gl.ID), "系统提示");
                        break;
                    }
                    else
                    {
                        _mdc.SaveNewGuideLine(_gl);
                    }

                    decimal _progress = i / _count * 50 + 50;
                    i++;
                    this.backgroundWorker1.ReportProgress(Convert.ToInt32(_progress));
                }
            }

        }

        private void ChangeChildrenID(MD_GuideLine _fGuideLine)
        {
            if (_fGuideLine.Children != null)
            {
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {
                    foreach (MD_GuideLine _gl in _fGuideLine.Children)
                    {
                        _gl.ID = _mdc.GetNewID();
                        _gl.FatherID = _fGuideLine.ID;
                        ChangeChildrenID(_gl);
                    }
                }
            }
        }

        private void ImportByOrdID()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                //将所有顶级的指标的父指向当前的指标ID
                List<MD_GuideLine> _topLevelGuideLine = GetTopLevelGuideLines();
                foreach (MD_GuideLine _gl in _topLevelGuideLine)
                {
                    _gl.FatherID = this.CurrentGuideLine.ID;
                }

                decimal _count = Convert.ToDecimal(SelectedGuideLines.Count);
                decimal i = 0;
                foreach (MD_GuideLine _gl in this.SelectedGuideLines)
                {
                    if (_mdc.IsExistGuideLineID(_gl.ID))
                    {
                        _mdc.SaveGuideLine(_gl);
                    }
                    else
                    {
                        _mdc.SaveNewGuideLine(_gl);
                    }

                    decimal _progress = i / _count * 100;
                    i++;
                    this.backgroundWorker1.ReportProgress(Convert.ToInt32(_progress));
                }
            }
        }

        private List<MD_GuideLine> GetTopLevelGuideLines()
        {
            List<MD_GuideLine> _ret = new List<MD_GuideLine>();
            foreach (MD_GuideLine _gl in this.SelectedGuideLines)
            {
                if (!this.GuideLineDict.ContainsKey(_gl.FatherID))
                {
                    _ret.Add(_gl);
                }
            }
            return _ret;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBarControl1.Position = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}